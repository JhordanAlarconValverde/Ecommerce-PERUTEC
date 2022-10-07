using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LIBRERIAS
using CapaEntidad;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class ClienteCD
    {
        // BUSCAR
        public DataTable BuscarClienteByNombre(string nombre)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarClienteByNombre", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;;
                sda.SelectCommand.Parameters.Add("@nombre",SqlDbType.VarChar).Value = nombre;
                DataTable tb = new DataTable();
                sda.Fill(tb);
                conec.Close();
                return tb;
            }
            catch
            {
                conec.Close();
                return null;
            } 
        }

        public DataTable BuscarClienteByApellido(string apellido)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarClienteByApellido", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure; ;
                sda.SelectCommand.Parameters.Add("@apellido", SqlDbType.VarChar).Value = apellido;
                DataTable tb = new DataTable();
                sda.Fill(tb);
                conec.Close();
                return tb;
            }
            catch
            {
                conec.Close();
                return null;
            }
        }

        public DataTable BuscarClienteByDepartamento(string codDepartamento, string codProvincia, string codDistrito)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarClienteByDepartamento", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure; ;
                sda.SelectCommand.Parameters.Add("@codDepartamento", SqlDbType.VarChar).Value = codDepartamento;
                sda.SelectCommand.Parameters.Add("@codProvincia", SqlDbType.VarChar).Value = codProvincia;
                sda.SelectCommand.Parameters.Add("@codDistrito", SqlDbType.VarChar).Value = codDistrito;
                DataTable tb = new DataTable();
                sda.Fill(tb);
                conec.Close();
                return tb;
            }
            catch
            {
                conec.Close();
                return null;
            }
        }

        // INICIAR SESION
        public DataTable IniciarSesionCliente(ClienteCE clienteCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("IniciarSesionCliente", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@correo", SqlDbType.VarChar).Value = clienteCE.Correo;
                sda.SelectCommand.Parameters.Add("@clave", SqlDbType.VarChar).Value = clienteCE.Clave;
                DataTable tb = new DataTable();
                sda.Fill(tb);
                conec.Close();
                return tb;
            }
            catch
            {
                conec.Close();
                return null;
            }
        }

        // CAMBIAR CLAVE
        public int CambiarClaveCliente(string correo, string clave, string nuevaClave)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = new SqlCommand("CambiarClaveCliente", conec);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
                cmd.Parameters.Add("@nuevaClave", SqlDbType.VarChar).Value = nuevaClave;

                using (SqlTransaction transaction = conec.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    cmd.Transaction = transaction;

                    try
                    {
                        nfilas = cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        nfilas = 0;
                        transaction.Rollback();
                    }
                }
            }
            catch
            {
                nfilas = 0;
            }
            conec.Close();
            return nfilas;
        }

        // ACTUALIZAR PERFIL
        public DataTable ActualizarPerfilCliente(ClienteCE clienteCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ActualizarPerfilCliente", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@codCliente", SqlDbType.Int).Value = clienteCE.CodCliente;
                sda.SelectCommand.Parameters.Add("@correo", SqlDbType.VarChar).Value = clienteCE.Correo;
                sda.SelectCommand.Parameters.Add("@celular", SqlDbType.Char).Value = clienteCE.Celular;
                DataTable tb = new DataTable();
                sda.Fill(tb);
                conec.Close();
                return tb;
            }
            catch
            {
                conec.Close();
                return null;
            }
        }

        // DETALLE CLIENTE
        public string DetalleCliente(int codCliente)
        {
            SqlConnection cnx = ConexionCD.ConectarToSqlServer();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DetalleCliente";
            cmd.Parameters.AddWithValue("@codCliente", codCliente);

            string data = cmd.ExecuteScalar().ToString();
            cnx.Close();
            return data;
        }

        // CRUD
        public DataTable Listar()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarClientes", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                conec.Close();
                return dt;
            }
            catch
            {
                conec.Close();
                return null;
            }
        }

        public int Insertar(ClienteCE clienteCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarCliente";
                cmd.Parameters.AddWithValue("@codUbigeo", SqlDbType.Int).Value = clienteCE.CodUbigeo;
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = clienteCE.Nombre;
                cmd.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = clienteCE.Apellido;
                cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = clienteCE.Correo;
                cmd.Parameters.AddWithValue("@clave", SqlDbType.VarChar).Value = clienteCE.Clave;
                cmd.Parameters.AddWithValue("@dni", SqlDbType.Char).Value = clienteCE.DNI;
                cmd.Parameters.AddWithValue("@celular", SqlDbType.Char).Value = clienteCE.Celular;
                cmd.Parameters.AddWithValue("@fecNacimiento", SqlDbType.DateTime).Value = clienteCE.FecNacimiento;
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = clienteCE.Direccion;

                using (SqlTransaction transaction = conec.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    cmd.Transaction = transaction;

                    try
                    {
                        nfilas = cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        nfilas = 0;
                        transaction.Rollback();
                    }
                }
            }
            catch
            {
                nfilas = 0;
            }
            conec.Close();
            return nfilas;
        }

        public int Actualizar(ClienteCE clienteCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarCliente";
                cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = clienteCE.CodCliente;
                cmd.Parameters.AddWithValue("@codUbigeo", SqlDbType.Int).Value = clienteCE.CodUbigeo;
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = clienteCE.Nombre;
                cmd.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = clienteCE.Apellido;
                cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = clienteCE.Correo;
                cmd.Parameters.AddWithValue("@clave", SqlDbType.VarChar).Value = clienteCE.Clave;
                cmd.Parameters.AddWithValue("@dni", SqlDbType.Char).Value = clienteCE.DNI;
                cmd.Parameters.AddWithValue("@celular", SqlDbType.Char).Value = clienteCE.Celular;
                cmd.Parameters.AddWithValue("@fecNacimiento", SqlDbType.DateTime).Value = clienteCE.FecNacimiento;
                cmd.Parameters.AddWithValue("@direccion", SqlDbType.VarChar).Value = clienteCE.Direccion;

                using (SqlTransaction transaction = conec.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    cmd.Transaction = transaction;

                    try
                    {
                        nfilas = cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        nfilas = 0;
                        transaction.Rollback();
                    }
                }
            }
            catch
            {
                nfilas = 0;
            }
            conec.Close();
            return nfilas;
        }

        public int Eliminar(int idEliminar)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EliminarCliente";
                cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = idEliminar;

                using (SqlTransaction transaction = conec.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    cmd.Transaction = transaction;

                    try
                    {
                        nfilas = cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch
                    {
                        nfilas = 0;
                        transaction.Rollback();
                    }
                }
            }
            catch
            {
                nfilas = 0;
            }
            conec.Close();
            return nfilas;
        }
    }
}
