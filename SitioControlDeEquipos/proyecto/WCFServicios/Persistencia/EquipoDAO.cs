using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServicios.Dominio;

namespace WCFServicios.Persistencia
{
    public class EquipoDAO
    {
        private string cnx = "Data Source=(local);Initial Catalog=BDEquipos;Integrated Security=SSPI;";

        //CREAREQUIPO
        public Equipo Crear(Equipo equipoACrear)
        {
            Equipo equipoCreado = null;
            string sql = "INSERT INTO equipo VALUES (@codigo_equipo, @marca_equipo,@modelo_equipo, @descripcion_equipo,@serie_equipo,@responsable_equipo,@ubicacion_equipo)";
                     
            using (SqlConnection conexion = new SqlConnection(cnx))
            {
                try { 
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo_equipo", equipoACrear.codigo_equipo));
                    comando.Parameters.Add(new SqlParameter("@marca_equipo", equipoACrear.marca_equipo));
                    comando.Parameters.Add(new SqlParameter("@modelo_equipo", equipoACrear.modelo_equipo));
                    comando.Parameters.Add(new SqlParameter("@descripcion_equipo", equipoACrear.descripcion_equipo));
                    comando.Parameters.Add(new SqlParameter("@serie_equipo", equipoACrear.serie_equipo));
                    comando.Parameters.Add(new SqlParameter("@responsable_equipo", equipoACrear.responsable_equipo));
                    comando.Parameters.Add(new SqlParameter("@ubicacion_equipo", equipoACrear.ubicacion_equipo));
                                       
                    comando.ExecuteNonQuery();
                }
                
                }
                catch(Exception ex)
                {
                    throw ex;

                }
            }
            equipoCreado = Obtener(equipoACrear.codigo_equipo);
            return equipoCreado;
            
        }
        public Equipo Obtener(int codigo_equipo)
        {
            Equipo equipoEncontrado = null;
            string sql = "SELECT * FROM equipo WHERE codigo_equipo=@codigo_equipo";
            using (SqlConnection conexion = new SqlConnection(cnx))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo_equipo", codigo_equipo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            equipoEncontrado = new Equipo()
                            {
                                codigo_equipo = (int)resultado["codigo_equipo"],
                                marca_equipo = (string)resultado["marca_equipo"],
                                modelo_equipo = (string)resultado["modelo_equipo"],
                                descripcion_equipo = (string)resultado["descripcion_equipo"],
                                serie_equipo = (string)resultado["serie_equipo"],
                                responsable_equipo=(string)resultado["responsable_equipo"],
                                ubicacion_equipo=(string)resultado["ubicacion_equipo"]

                            };
                        }
                    }
                }
            }
            return equipoEncontrado;
        }
        public Equipo Modificar(Equipo equipoAModificar)
        {
            Equipo equipoModificado = null;
            string sql = "UPDATE equipo SET codigo_equipo=@codigo_equipo,marca_equipo=@marca_equipo,modelo_equipo=@modelo_equipo, descripcion_equipo=@descripcion_equipo,serie_equipo=@serie_equipo,responsable_equipo=@responsable_equipo,ubicacion_equipo=@ubicacion_equipo WHERE codigo_equipo=@codigo_equipo";
            using (SqlConnection conexion = new SqlConnection(cnx))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo_equipo", equipoAModificar.codigo_equipo));
                    comando.Parameters.Add(new SqlParameter("@marca_equipo", equipoAModificar.marca_equipo));
                    comando.Parameters.Add(new SqlParameter("@modelo_equipo", equipoAModificar.modelo_equipo));
                    comando.Parameters.Add(new SqlParameter("@descripcion_equipo", equipoAModificar.descripcion_equipo));
                    comando.Parameters.Add(new SqlParameter("@serie_equipo", equipoAModificar.serie_equipo));
                    comando.Parameters.Add(new SqlParameter("@responsable_equipo", equipoAModificar.responsable_equipo));
                    comando.Parameters.Add(new SqlParameter("@ubicacion_equipo", equipoAModificar.ubicacion_equipo));
                    comando.ExecuteNonQuery();
                }
            }
            equipoModificado = Obtener(equipoAModificar.codigo_equipo);
            return equipoModificado;
        }
        public void Eliminar(int codigo_equipo)
        {
            string sql = "DELETE FROM equipo WHERE codigo_equipo=@codigo_equipo";
            using (SqlConnection conexion = new SqlConnection(cnx))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo_equipo", codigo_equipo));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Equipo> Listar()
        {
            List<Equipo> equiposEncontrados = new List<Equipo>();
            Equipo equipoEncontrado = null;
            string sql = "Select * from equipos";
            using (SqlConnection conexion = new SqlConnection(cnx))
            {
               
                
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            equipoEncontrado = new Equipo()
                            {
                                codigo_equipo = (int)resultado["codigo_equipo"],
                                marca_equipo = (string)resultado["marca_equipo"],
                                modelo_equipo = (string)resultado["modelo_equipo"],
                                descripcion_equipo = (string)resultado["descripcion_equipo"],
                                serie_equipo = (string)resultado["serie_equipo"],
                                responsable_equipo = (string)resultado["responsable_equipo"],
                                ubicacion_equipo = (string)resultado["ubicacion_equipo"]
                            };
                            equiposEncontrados.Add(equipoEncontrado);
                        }
                    }
                }

            }
            
            return equiposEncontrados;

        }
    
    
    }
}