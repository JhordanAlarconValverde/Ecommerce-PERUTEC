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
    public class EmpleadoCD
    {
        // BUSCAR
        public DataTable BuscarEmpleadoVenByNombre(string nombre)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarEmpleadoVenByNombre", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure; ;
                sda.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
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

        public DataTable BuscarEmpleadoReByNombre(string nombre)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarEmpleadoReByNombre", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure; ;
                sda.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
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

        public DataTable BuscarEmpleadoVenByApellido(string apellido)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarEmpleadoVenByApellido", conec);
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

        public DataTable BuscarEmpleadoReByApellido(string apellido)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarEmpleadoReByApellido", conec);
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

        public DataTable BuscarEmpleadoByCargo(string nomCargo)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarEmpleadoByCargo", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure; ;
                sda.SelectCommand.Parameters.Add("@nomCargo", SqlDbType.VarChar).Value = nomCargo;
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

        // LISTAR CARGO EMPLEADO
        public DataTable ListarCargoEmpleado()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            SqlDataAdapter sda = new SqlDataAdapter("ListarCargoEmpleado", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure; ;
            DataTable tb = new DataTable();
            sda.Fill(tb);
            conec.Close();
            return tb;
        }

        // INICIAR SESION
        public DataTable IniciarSesionEmpleado(string correo, string clave)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("IniciarSesionEmpleado", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.Add("@correo", SqlDbType.VarChar).Value = correo;
                sda.SelectCommand.Parameters.Add("@clave", SqlDbType.VarChar).Value = clave;
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

        // CRUD
        public DataTable ListarEmpleadosRepartidores()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarEmpleadosRepartidores", conec);
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

        public DataTable ListarEmpleadosVendedores()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarEmpleadosVendedores", conec);
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

        public int Insertar(EmpleadoCE empleadoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarEmpleado";
                cmd.Parameters.AddWithValue("@CodCargo", SqlDbType.Int).Value = empleadoCE.CodCargo;
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = empleadoCE.Nombre;
                cmd.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = empleadoCE.Apellido;
                cmd.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = empleadoCE.Correo;
                cmd.Parameters.AddWithValue("@clave", SqlDbType.VarChar).Value = empleadoCE.Clave;
                cmd.Parameters.AddWithValue("@dni", SqlDbType.Char).Value = empleadoCE.Dni;
                cmd.Parameters.AddWithValue("@celular", SqlDbType.Char).Value = empleadoCE.Celular;
                cmd.Parameters.AddWithValue("@fecNacimiento", SqlDbType.DateTime).Value = empleadoCE.FecNacimiento;

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

        public DataTable Actualizar(EmpleadoCE empleadoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ActualizarEmpleado", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@codEmpleado", SqlDbType.Int).Value = empleadoCE.CodEmpleado;
                sda.SelectCommand.Parameters.AddWithValue("@CodCargo", SqlDbType.Int).Value = empleadoCE.CodCargo;
                sda.SelectCommand.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = empleadoCE.Nombre;
                sda.SelectCommand.Parameters.AddWithValue("@apellido", SqlDbType.VarChar).Value = empleadoCE.Apellido;
                sda.SelectCommand.Parameters.AddWithValue("@correo", SqlDbType.VarChar).Value = empleadoCE.Correo;
                sda.SelectCommand.Parameters.AddWithValue("@clave", SqlDbType.VarChar).Value = empleadoCE.Clave;
                sda.SelectCommand.Parameters.AddWithValue("@dni", SqlDbType.Char).Value = empleadoCE.Dni;
                sda.SelectCommand.Parameters.AddWithValue("@celular", SqlDbType.Char).Value = empleadoCE.Celular;
                sda.SelectCommand.Parameters.AddWithValue("@fecNacimiento", SqlDbType.DateTime).Value = empleadoCE.FecNacimiento;
                DataTable dt = new DataTable();
                using (SqlTransaction transaction = conec.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    sda.SelectCommand.Transaction = transaction;

                    try
                    {
                        sda.Fill(dt);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
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
                cmd.CommandText = "EliminarEmpleado";
                cmd.Parameters.AddWithValue("@codEmpleado", SqlDbType.Int).Value = idEliminar;

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
