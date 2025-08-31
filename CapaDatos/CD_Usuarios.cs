using System;
using System.Collections.Generic;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;




namespace CapaDatos

{
    public class CD_Usuarios
    {
        public List<Usuario> listar()
        {

            List<Usuario> lista = new List<Usuario>();

            try
            {

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {

                    string query = "SELECT IdUsuario,Nombre,Apellido,Correo,Clave,Reestablecer,Activo from USUARIO";

                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombres = dr["Nombre"].ToString(),
                                    Apellidos = dr["Apellido"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Reestablecer = Convert.ToBoolean(dr["Reestablecer"]),
                                    Activo = Convert.ToBoolean(dr["Activo"])
                                }
                                );
                        }
                    }

                }
            }
            catch
            {

                lista = new List<Usuario>();


            }
            return lista;
        }

                    public int Registrar(Usuario obj, out string Mensaje)
                    {
                        int idautogenerado = 0;
                        Mensaje = string.Empty;
                        using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                        {
                            try
                            {
                                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                                {
                                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oConexion);
                                    cmd.Parameters.AddWithValue("Nombre", obj.Nombres);
                                    cmd.Parameters.AddWithValue("Apellido", obj.Apellidos);
                                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                                    cmd.CommandType = CommandType.StoredProcedure;

                                    oConexion.Open();

                                    cmd.ExecuteNonQuery();

                                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                                }
                            }
                            catch (Exception ex)
                            {
                                idautogenerado = 0;
                                Mensaje = ex.Message;
                            }
            
                            return idautogenerado;
                        }
                    }

                public bool Editar(Usuario obj, out string Mensaje)
                {
                    bool resultado = false;
                    Mensaje = string.Empty;
                    try
                        {
                          using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                          { 
                            SqlCommand cmd = new SqlCommand("sp_EditarUsuario", oConexion);
                            cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                            cmd.Parameters.AddWithValue("Nombre", obj.Nombres);
                            cmd.Parameters.AddWithValue("Apellido", obj.Apellidos);
                            cmd.Parameters.AddWithValue("Correo", obj.Correo);
                            cmd.Parameters.AddWithValue("Activo", obj.Activo);
                            cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar,500).Direction = ParameterDirection.Output;
                            cmd.CommandType = CommandType.StoredProcedure;

                            oConexion.Open();

                            cmd.ExecuteNonQuery();

                            resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        resultado = false;
                        Mensaje = ex.Message;
                    }

                    return resultado;
                }


        public bool Eliminar(int id, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;


            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from usuario where IdUsuario = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
            }

        public bool CambiarClave(int idusuario,string nuevaclave, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("update usuario set clave = @nuevaclave, reestablecer = 0  where IdUsuario = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", idusuario);
                    cmd.Parameters.AddWithValue("@nuevaclave", nuevaclave);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
        public bool RestablecerClave(int idusuario, string clave, out string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("update usuario set clave = @clave, reestablecer = 1  where IdUsuario = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", idusuario);
                    cmd.Parameters.AddWithValue("@clave", clave);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;

                }
            }
            catch (Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }

    }

}

