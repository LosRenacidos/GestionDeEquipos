using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestCrudFull.Dominio;
using System.Data.SqlClient;

namespace RestCrudFull.Persistencia
{
    public class AveriaDAO
    {
        public Averia Crear(Averia AveriaACrear)
        {
            Averia AveriaCreado = null;
            string sql = "INSERT INTO t_averia VALUES (@ida, @est, @fer,@fec, @pro, @ide,@tec, @rep, @des)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ida", AveriaACrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@est", AveriaACrear.Estado));
                    com.Parameters.Add(new SqlParameter("@fer", AveriaACrear.FechaRegistro));
                    com.Parameters.Add(new SqlParameter("@fec", AveriaACrear.FechaCierre));
                    com.Parameters.Add(new SqlParameter("@pro", AveriaACrear.Proveedor));
                    com.Parameters.Add(new SqlParameter("@ide", AveriaACrear.CodigoEquipo));
                    com.Parameters.Add(new SqlParameter("@tec", AveriaACrear.TecnicoAsignado));
                    com.Parameters.Add(new SqlParameter("@rep", AveriaACrear.TipoReparacion));
                    com.Parameters.Add(new SqlParameter("@des", AveriaACrear.Descripcion));
                    com.ExecuteNonQuery();
                }
            }
            AveriaCreado = Obtener(AveriaACrear.Codigo);
            return AveriaCreado;
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
        public Averia Modificar(Averia AveriaAModificar)
        {
            Averia AveriaModificado = null;
            string sql = "UPDATE t_averia SET averia_estado=@est, fecha_registro=@fer, fecha_cierre=@fec, proveedor=@pro, equipo_id=@ide,tecnico_asignado=@tec, tipo_reparacion=@rep, averia_descripcion=@des  WHERE averia_id=@ida";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ida", AveriaAModificar.Codigo));
                    com.Parameters.Add(new SqlParameter("@est", AveriaAModificar.Estado));
                    com.Parameters.Add(new SqlParameter("@fer", AveriaAModificar.FechaRegistro));
                    com.Parameters.Add(new SqlParameter("@fec", AveriaAModificar.FechaCierre));
                    com.Parameters.Add(new SqlParameter("@pro", AveriaAModificar.Proveedor));
                    com.Parameters.Add(new SqlParameter("@ide", AveriaAModificar.CodigoEquipo));
                    com.Parameters.Add(new SqlParameter("@tec", AveriaAModificar.TecnicoAsignado));
                    com.Parameters.Add(new SqlParameter("@rep", AveriaAModificar.TipoReparacion));
                    com.Parameters.Add(new SqlParameter("@des", AveriaAModificar.Descripcion));
                    com.ExecuteNonQuery();
                }
            }
            AveriaModificado = Obtener(AveriaAModificar.Codigo);
            return AveriaModificado;
        }
        public void Eliminar(int codigo)
        {
            Averia AveriaAEliminar = Obtener(codigo);
            string sql = "DELETE FROM t_averia WHERE averia_id=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    com.ExecuteNonQuery();
                }
            }
        }
        public List<Averia> ListarTodos()
        {

            SqlConnection con = new SqlConnection(ConexionUtil.ObtenerCadena());
            SqlDataReader resultado = null;
            var result = new List<Averia>();
            string sql = "Select * from t_averia";
            try
            {
                using (con)
                //using (var cmd = new SqlCommand("usp_ListarTorneos", cnn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                        //cmd.CommandType = CommandType.StoredProcedure; 
                        //SqlDataReader resultado = com.ExecuteReader()
                        //cnn.Open();
                        resultado = com.ExecuteReader();

                    while (resultado.Read())
                    {
                        result.Add(new Averia()
                        {
                            //Codigo = (int)resultado["averia_id"],
                            //Estado = resultado["averia_estado"].ToString(),
                            //FechaRegistro = resultado["fecha_registro"].ToString(),
                            //FechaCierre = resultado["fecha_cierre"].ToString(),
                            //Proveedor = resultado["proveedor"].ToString(),
                            //CodigoEquipo = (int)resultado["equipo_id"],
                            //TecnicoAsignado = resultado["tecnico_asignado"].ToString(),  
                            //TipoReparacion = resultado["tipo_reparacion"].ToString(),
                            //Descripcion = resultado["averia_descripcion"].ToString()

                            Codigo = int.Parse(resultado["averia_id"].ToString()),
                            Estado = (string)resultado["averia_estado"],
                            FechaRegistro = (string)resultado["fecha_registro"],
                            FechaCierre = (string)resultado["fecha_cierre"],
                            Proveedor = (string)resultado["proveedor"],
                            CodigoEquipo = int.Parse(resultado["equipo_id"].ToString()),
                            TecnicoAsignado = (string)resultado["tecnico_asignado"],
                            TipoReparacion = (string)resultado["tipo_reparacion"],
                            Descripcion = (string)resultado["averia_descripcion"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }

                if (resultado != null)
                {
                    resultado.Close();
                }
            }

            return result;
        }
    }
}