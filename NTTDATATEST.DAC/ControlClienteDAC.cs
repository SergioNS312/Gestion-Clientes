using NTTDATAEXAMEN.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NTTDATAEXAMEN.DAC
{
    public class ControlClienteDAC : IControlClienteDAC
    {
        public List<ControlClienteBE> ListarControlCliente()
        {
            List<ControlClienteBE> list = null;

            try
            {
                string cadenaConexion = "Data Source=18.218.188.229\\PRODUCCION;Initial Catalog=S_GENERAL;Persist Security Info=True;User ID=sa;Password=Nba2610@";

                string str = "dbo.PA_GETS7_CONTROL_CLIENTES_NBA";

                using (SqlConnection conn = new SqlConnection(cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(str, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        ControlClienteBE objClient = null;
                        list = new List<ControlClienteBE>();
                        while (reader.Read())
                        {
                            objClient = new ControlClienteBE();
                            objClient.id = Convert.ToInt32(reader["id"].ToString());
                            objClient.empresa = reader["empresa"].ToString();
                            objClient.nro_doi = reader["nro_doi"].ToString();
                            objClient.tipo_contrato = reader["tipo_contrato"].ToString();
                            objClient.tipo_software = reader["tipo_software"].ToString();
                            objClient.nro_empresas = Convert.ToInt32(reader["nro_empresas"].ToString());
                            objClient.nro_empresas_con_data = (reader["nro_empresa_con_data"] as int?).GetValueOrDefault();//Convert.ToInt32(reader["nro_empresas_con_data"].ToString());
                            objClient.tipo_pago = Convert.ToInt32(reader["tipo_pago"].ToString());
                            objClient.deuda_anterior = (reader["deuda_anterior"] as decimal?).GetValueOrDefault(); //Convert.ToDecimal(reader["deuda_anterior"].ToString());
                            objClient.descuento = (reader["descuento"] as decimal?).GetValueOrDefault();//Convert.ToDecimal(reader["descuento"].ToString());
                            objClient.licencia_anual = (reader["licencia_anual"] as decimal?).GetValueOrDefault();//Convert.ToDecimal(reader["licencia_anual"].ToString());
                            objClient.total_a_pagar = (reader["total_a_pagar"] as decimal?).GetValueOrDefault();//Convert.ToDecimal(reader["total_a_pagar"].ToString());
                            objClient.contacto_nombre = reader["contacto_nombre"].ToString();
                            objClient.contcto_telefono = reader["contcto_telefono"].ToString();
                            objClient.compromiso_descripcion = reader["compromiso_descripcion"].ToString();
                            objClient.compromiso_fecha = reader["compromiso_fecha"].ToString() != null ? DateTime.MinValue : DateTime.Parse(reader["compromiso_fecha"].ToString());
                            objClient.compromiso_importe = (reader["compromiso_importe"] as decimal?).GetValueOrDefault();//Convert.ToDecimal(reader["compromiso_importe"].ToString());
                            objClient.observacion = reader["observacion"].ToString();
                            objClient.estado = (reader["estado"] as int?).GetValueOrDefault();//Convert.ToInt32(reader["estado"].ToString());
                            objClient.fecha_vencimiento = reader["fecha_vencimiento"].ToString() != null ? DateTime.MinValue : DateTime.Parse(reader["fecha_vencimiento"].ToString());
                            objClient.limite_empresas = (reader["limite_empresas"] as int?).GetValueOrDefault();//Convert.ToInt32(reader["limite_empresas"].ToString());
                            objClient.limite_usuarios = (reader["limite_usuarios"] as int?).GetValueOrDefault();//Convert.ToInt32(reader["limite_usuarios"].ToString());


                            list.Add(objClient);
                        }
                    }
                    reader.Close();
                    conn.Close();
                }



            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);//Console.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);//Console.WriteLine(ex.StackTrace);
                list = null;
            }
            catch (Exception ex2)
            {
                Debug.WriteLine(ex2.Message);//Console.WriteLine(ex2.Message);
                Debug.WriteLine(ex2.StackTrace);//Console.WriteLine(ex2.StackTrace);
                list = null;
            }

            return list;
        }
    }
}
