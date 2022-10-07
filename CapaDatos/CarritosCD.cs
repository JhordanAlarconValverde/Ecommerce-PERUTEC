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
    public  class CarritosCD
    {
        // LISTAR CARRITOS BY CLIENTE
        public DataTable ListarCarritoByCliente()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();
            SqlDataAdapter sda = new SqlDataAdapter("ListarCarritoByCliente", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conec.Close();
            return dt;
        }

        /*// BUSCAR CARRITOS BY CLIENTE
        public DataTable BuscarCarritosByCliente(int codCliente)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();
            SqlDataAdapter sda = new SqlDataAdapter("BuscarCarritosByCliente", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@codCliente",codCliente);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conec.Close();
            return dt;
        }*/

        // CRUD
        public DataTable Listar()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarCarritos", conec);
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

        public int Insertar(CarritosCE carritosCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            SqlCommand cmd = conec.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CARRITOS values(@codCliente, @fechaGuardado, @montoTotal, @estado)";
            cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = carritosCE.CodCliente;
            cmd.Parameters.AddWithValue("@fechaGuardado", SqlDbType.DateTime).Value = carritosCE.FechaGuardado;
            cmd.Parameters.AddWithValue("@montoTotal", SqlDbType.Money).Value = carritosCE.MontoTotal;
            cmd.Parameters.AddWithValue("@estado", SqlDbType.Bit).Value = carritosCE.Estado;

            int nfilas = cmd.ExecuteNonQuery();

            int idCarrito;

            if (nfilas > 0)
            {
                cmd.CommandText = "select max(codCarritos) as nuevoID from CARRITOS where codCliente = @codCliente";
                cmd.Parameters["@codCliente"].Value = carritosCE.CodCliente;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idCarrito = Convert.ToInt32(dr["nuevoID"]);
                }
                else
                {
                    idCarrito = 0;
                }
            }
            else
            {
                idCarrito = 0;
            }
            conec.Close();
            return idCarrito;

            /*int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarCarritos";
                cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = carritosCE.CodCliente;
                cmd.Parameters.AddWithValue("@fechaGuardado", SqlDbType.DateTime).Value = carritosCE.FechaGuardado;
                cmd.Parameters.AddWithValue("@montoTotal", SqlDbType.Money).Value = carritosCE.MontoTotal;
                cmd.Parameters.AddWithValue("@estado", SqlDbType.Bit).Value = carritosCE.Estado;

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
            return nfilas;*/
        }

        public int Actualizar(CarritosCE carritosCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();

            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarCarritos";
                cmd.Parameters.AddWithValue("@codCarritos", SqlDbType.Int).Value = carritosCE.CodCarritos;
                cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = carritosCE.CodCliente;
                cmd.Parameters.AddWithValue("@fechaGuardado", SqlDbType.DateTime).Value = carritosCE.FechaGuardado;
                cmd.Parameters.AddWithValue("@montoTotal", SqlDbType.Money).Value = carritosCE.MontoTotal;
                cmd.Parameters.AddWithValue("@estado", SqlDbType.Bit).Value = carritosCE.Estado;

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
                cmd.CommandText = "EliminarCarritos";
                cmd.Parameters.AddWithValue("@codCarritos", SqlDbType.Int).Value = idEliminar;

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
