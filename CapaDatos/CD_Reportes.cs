using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reportes
    {
        public List<Reportes> Ventas(string fechainicio, string fechafin,string idtransaccion)
        {

            List<Reportes> lista = new List<Reportes>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                        SqlCommand cmd = new SqlCommand("sp_ReportVentas", oconexion);
                        cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                        cmd.Parameters.AddWithValue("fechafin", fechafin);
                        cmd.Parameters.AddWithValue("idtransaccion", idtransaccion);
                        cmd.CommandType = CommandType.StoredProcedure;

                        oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader()) { 
                        while (dr.Read())
                        {
                            lista.Add(
                                new Reportes()
                                {
                                    FechaVenta = dr["FechaVenta"].ToString(),
                                    Cliente = dr["Cliente"].ToString(),
                                    Producto = dr["Producto"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("ar")),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                    Total = Convert.ToDecimal(dr["Total"], new CultureInfo("ar")),
                                    IdTransaccion = dr["IdTransaccion"].ToString()
                                });
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Reportes>();
            }
            return lista;
        }



        public DashBoard verDashBoard()
        {

            DashBoard objeto = new DashBoard();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new DashBoard()
                            {
                                TotalCliente = Convert.ToInt32(dr["TotalClientes"]),
                                TotalVenta = Convert.ToInt32(dr["TotalVenta"]),
                                TotalProducto = Convert.ToInt32(dr["TotalProducto"]),

                            };

                        }
                    }

                }
            }
            catch
            {
                objeto = new DashBoard();
            }
            return objeto;
        }
    }
}
