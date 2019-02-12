using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class BaseDatos
    {
        public List<Entidades.EntTipoDocumento> DaoGetTipoDocumentos()
        {
            try
            {
                List<Entidades.EntTipoDocumento> ListaTipoDocuemntos = new List<Entidades.EntTipoDocumento>();
                Entidades.EntTipoDocumento tipoDocumento;
            
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDatos"].ToString()))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("Sp_Get_TipoDocumentos", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tipoDocumento = new Entidades.EntTipoDocumento();

                                tipoDocumento.IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"].ToString());
                                tipoDocumento.TipoDocumento = reader["TipoDocumento"].ToString();

                                ListaTipoDocuemntos.Add(tipoDocumento);
                            }
                        }
                    }                    
                }

                return ListaTipoDocuemntos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DaoSetContactenos(Entidades.EntContactenos contactenos)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexionDatos"].ToString()))
                {
                    using (SqlCommand command = new SqlCommand("Sp_Insert_Contactenos", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = contactenos.IdTipoDocumento;
                        command.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = contactenos.Nombres;
                        command.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = contactenos.Apellidos;
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = contactenos.Email;
                        command.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = contactenos.Telefono;
                        command.Parameters.Add("@Asunto", SqlDbType.VarChar).Value = contactenos.Asunto;
                        command.Parameters.Add("@Mensaje", SqlDbType.VarChar).Value = contactenos.Mensaje;

                        con.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
