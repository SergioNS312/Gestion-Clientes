using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTTDATAEXAMEN.BE;

namespace NTTDATAEXAMEN.DAC
{
    public class UsuarioDAC : IUsuarioDAC
    {
        public bool Delete(int id)
        {
            bool rpta = false;
            try
            {

                string cadenaConexion = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = BDUsuario; Integrated Security = true";
                string str = "dbo.uspDeleteUsuarioBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_ID", SqlDbType.Int).SqlValue = id;
                    cmd.Parameters.Add("@PO_OUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    rpta = (bool.Parse(cmd.Parameters["@PO_OUT"].Value.ToString()));
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                rpta = false;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                rpta = false;
            }

            return rpta;
        }

        public UsuarioBE Get(int id)
        {
            UsuarioBE entity = null;

            try
            {
                string cadenaConexion = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = BDUsuario; Integrated Security = true";
                string str = "dbo.uspGetUsuarioBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_ID", SqlDbType.Int).SqlValue = id;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity = new UsuarioBE();
                            entity.id = Convert.ToInt32(reader["id"].ToString());
                            entity.codigo = reader["codigo"].ToString();
                            entity.nombre = reader["nombre"].ToString();
                            entity.apellido = reader["apellido"].ToString();
                            entity.edad = Convert.ToInt32(reader["edad"].ToString());
                            entity.correo = reader["correo"].ToString();
                            entity.idGenero = Convert.ToInt32(reader["idGenero"].ToString());
                            entity.idNacionalidad = Convert.ToInt32(reader["idNacionalidad"].ToString());
                            entity.idPerfil = Convert.ToInt32(reader["idPerfil"].ToString());

                        }
                    }
                    reader.Close();
                    conn.Close();
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                entity = null;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                entity = null;
            }

            return entity;
        }

        public bool Insertar(UsuarioBE entity)
        {
            bool rpta = false;
            try
            {

                string cadenaConexion = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = BDUsuario; Integrated Security = true";
                string str = "dbo.uspInsertUsuarioBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_CODIGO", SqlDbType.NVarChar, 5).SqlValue = entity.codigo;
                    cmd.Parameters.Add("@PI_NOMBRE", SqlDbType.NVarChar, 100).SqlValue = entity.nombre;
                    cmd.Parameters.Add("@PI_APELLIDO", SqlDbType.NVarChar, 100).SqlValue = entity.apellido;
                    cmd.Parameters.Add("@PI_EDAD", SqlDbType.Int).SqlValue = entity.edad;
                    cmd.Parameters.Add("@PI_CORREO", SqlDbType.NVarChar, 100).SqlValue = entity.correo;
                    cmd.Parameters.Add("@PI_IDGENERO", SqlDbType.Int).SqlValue = entity.idGenero;
                    cmd.Parameters.Add("@PI_IDNACIONALIDAD", SqlDbType.Int).SqlValue = entity.idNacionalidad;
                    cmd.Parameters.Add("@PI_IDPERFIL", SqlDbType.Int).SqlValue = entity.idPerfil;
                    cmd.Parameters.Add("@PO_OUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    rpta = (bool.Parse(cmd.Parameters["@PO_OUT"].Value.ToString()));
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                rpta = false;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                rpta = false;
            }

            return rpta;
        }

        public List<UsuarioListBE> Listar(UsuarioBE entity)
        {
            List<UsuarioListBE> list = null;

            try
            {
                string cadenaConexion = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = BDUsuario; Integrated Security = true";
                string str = "dbo.uspListUsuarioBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_CODIGO", SqlDbType.NVarChar, 5).SqlValue = entity.codigo;
                    cmd.Parameters.Add("@PI_APELLIDO", SqlDbType.NVarChar, 100).SqlValue = entity.apellido;
                    cmd.Parameters.Add("@PI_IDGENERO", SqlDbType.Int).SqlValue = entity.idGenero;
                    cmd.Parameters.Add("@PI_IDNACIONALIDAD", SqlDbType.Int).SqlValue = entity.idNacionalidad;
                    cmd.Parameters.Add("@PI_IDPERFIL", SqlDbType.Int).SqlValue = entity.idPerfil;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        UsuarioListBE objClient = null;
                        list = new List<UsuarioListBE>();
                        while (reader.Read())
                        {
                            objClient = new UsuarioListBE();
                            objClient.id = Convert.ToInt32(reader["id"].ToString());
                            objClient.codigo = reader["codigo"].ToString();
                            objClient.nombre = reader["nombre"].ToString();
                            objClient.apellido = reader["apellido"].ToString();
                            objClient.edad = Convert.ToInt32(reader["edad"].ToString());
                            objClient.correo = reader["correo"].ToString();
                            objClient.genero = reader["genero"].ToString();
                            objClient.nacionalidad = reader["nacionalidad"].ToString();
                            objClient.perfil = reader["perfil"].ToString();

                            list.Add(objClient);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }



            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                list = null;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                list = null;
            }

            return list;
        }

        public bool Update(UsuarioBE entity)
        {
            bool rpta = false;
            try
            {

                string cadenaConexion = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = BDUsuario; Integrated Security = true";
                string str = "dbo.uspUpdateUsuarioBE";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PI_ID", SqlDbType.Int).SqlValue = entity.id;
                    cmd.Parameters.Add("@PI_CODIGO", SqlDbType.NVarChar, 5).SqlValue = entity.codigo;
                    cmd.Parameters.Add("@PI_NOMBRE", SqlDbType.NVarChar, 100).SqlValue = entity.nombre;
                    cmd.Parameters.Add("@PI_APELLIDO", SqlDbType.NVarChar, 100).SqlValue = entity.apellido;
                    cmd.Parameters.Add("@PI_EDAD", SqlDbType.Int).SqlValue = entity.edad;
                    cmd.Parameters.Add("@PI_CORREO", SqlDbType.NVarChar, 100).SqlValue = entity.correo;
                    cmd.Parameters.Add("@PI_IDGENERO", SqlDbType.Int).SqlValue = entity.idGenero;
                    cmd.Parameters.Add("@PI_IDNACIONALIDAD", SqlDbType.Int).SqlValue = entity.idNacionalidad;
                    cmd.Parameters.Add("@PI_IDPERFIL", SqlDbType.Int).SqlValue = entity.idPerfil;
                    cmd.Parameters.Add("@PO_OUT", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    rpta = (bool.Parse(cmd.Parameters["@PO_OUT"].Value.ToString()));
                    conn.Close();
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                rpta = false;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message);
                rpta = false;
            }

            return rpta;
        }
    }
}
