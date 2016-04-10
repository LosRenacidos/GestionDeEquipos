using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Web;
using RestCrudFull.Dominio;
using System.Text;
using System.Net;
using System.Data.SqlClient;


namespace RestCrudFull.Persistencia
{
    public class GestionAveriaDAO
    {
        public Averia ModificarAveria(Averia AveriaAAsignarP)
        {
            Averia AveriaAsignadaP = null;
            string postdata = "{\"Codigo\":\"" + AveriaAAsignarP.Codigo + "\",\"Estado\":\"" + AveriaAAsignarP.Estado + "\",\"FechaRegistro\":\""+ AveriaAAsignarP.FechaRegistro+"\",\"FechaCierre\":\""+AveriaAAsignarP.FechaCierre+"\",\"Proveedor\":\""+AveriaAAsignarP.Proveedor+"\",\"CodigoEquipo\":\""+AveriaAAsignarP.CodigoEquipo+"\",\"TecnicoAsignado\":\""+AveriaAAsignarP.TecnicoAsignado+"\",\"TipoReparacion\":\""+AveriaAAsignarP.TipoReparacion+"\",\"Descripcion\":\""+AveriaAAsignarP.Descripcion+"\"}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:41782/Averias.svc/Averias");

            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

       
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            enviarCola(AveriaAAsignarP);

     
            AveriaAsignadaP = Obtener(AveriaAAsignarP.Codigo);
            return AveriaAsignadaP;
        }

        public Averia CerrarAveria(Averia AveriaACerrar)
        {
            Averia AveriaCerrada = null;
            string sql = "UPDATE t_averia SET averia_estado=@est WHERE averia_id=@ida";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ida", AveriaACerrar.Codigo));
                    com.Parameters.Add(new SqlParameter("@est", "Cerrada"));
                    com.ExecuteNonQuery();
                }
            }
            AveriaCerrada = Obtener(AveriaACerrar.Codigo);
            return AveriaCerrada;
        }

        public Averia ConfirmarReparacion(Averia AveriaAConfirmar)
        {
            Averia AveriaConfirmada = null;
            string sql = "UPDATE t_averia SET averia_estado=@est WHERE averia_id=@ida";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ida", AveriaAConfirmar.Codigo));
                    com.Parameters.Add(new SqlParameter("@est", "Reparada"));
                    com.ExecuteNonQuery();
                }
            }
            AveriaConfirmada = Obtener(AveriaAConfirmar.Codigo);
            return AveriaConfirmada;
        }

        public Averia Obtener(int codigo)
        {
            Averia AveriaEncontrado = null;
            string sql = "SELECT * FROM t_averia WHERE averia_id=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            AveriaEncontrado = new Averia()
                            {
                                Codigo = int.Parse(resultado["averia_id"].ToString()),
                                Estado = (string)resultado["averia_estado"],
                                FechaRegistro = (string)resultado["fecha_registro"],
                                FechaCierre = (string)resultado["fecha_cierre"],
                                Proveedor = (string)resultado["proveedor"],
                                CodigoEquipo = int.Parse(resultado["equipo_id"].ToString()),
                                TecnicoAsignado = (string)resultado["tecnico_asignado"],
                                TipoReparacion = (string)resultado["tipo_reparacion"],
                                Descripcion = (string)resultado["averia_descripcion"]
                            };
                        }
                    }
                }
            }
            return AveriaEncontrado;
        }

        private void enviarCola(Averia averiaCola)
        {
            String rutaCola = @".\private$\pendientes";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            Message mensaje = new Message();
            mensaje.Label = "pendiente" + averiaCola.Codigo;
            mensaje.Body = new Averia() { Codigo = averiaCola.Codigo, Estado = averiaCola.Estado,FechaRegistro = averiaCola.FechaRegistro, FechaCierre = averiaCola.FechaCierre, CodigoEquipo = averiaCola.CodigoEquipo, Proveedor= averiaCola.Proveedor, TecnicoAsignado = averiaCola.TecnicoAsignado, TipoReparacion = averiaCola.TipoReparacion, Descripcion = averiaCola.Descripcion };
            cola.Send(mensaje);
        }

    }
}