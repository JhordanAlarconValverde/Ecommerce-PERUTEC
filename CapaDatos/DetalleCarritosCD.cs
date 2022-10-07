using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

// LIBRERIAS
using CapaEntidad;

namespace CapaDatos
{
    public class DetalleCarritosCD
    {
        /*// LISTAR DETALLE CARRITO BY CLIENTE
        public DataTable ListarDetalleCarritosByCliente(int codCliente)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarDetalleCarritosByCliente", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = codCliente;
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
        }*/

        // LISTAR DETALLE CARRITO BY CARRITO
        public DataTable ListarDetalleCarritoByCodCarrito(int codCarrito)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarDetalleCarritoByCodCarrito", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@codCarrito", SqlDbType.Int).Value = codCarrito;
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

        // CRUD
        public DataTable Listar()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarDetalleCarritos", conec);
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

        public int Insertar(DetalleCarritosCE detalleCarritosCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarDetalleCarritos";
                cmd.Parameters.AddWithValue("@codCarritos", SqlDbType.Int).Value = detalleCarritosCE.CodCarritos;
                cmd.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = detalleCarritosCE.ProductoCE.CodProducto;
                cmd.Parameters.AddWithValue("@cantidadProducto", SqlDbType.Int).Value = detalleCarritosCE.CantidadProducto;
                cmd.Parameters.AddWithValue("@subtotal", SqlDbType.Money).Value = detalleCarritosCE.Subtotal;

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

        public int Actualizar(DetalleCarritosCE detalleCarritosCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarDetalleCarritos";
                cmd.Parameters.AddWithValue("@codDetalleCarrito", SqlDbType.Int).Value = detalleCarritosCE.CodDetalleCarritos;
                cmd.Parameters.AddWithValue("@codCarritos", SqlDbType.Int).Value = detalleCarritosCE.CodCarritos;
                cmd.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = detalleCarritosCE.ProductoCE.CodProducto;
                cmd.Parameters.AddWithValue("@cantidadProducto", SqlDbType.Int).Value = detalleCarritosCE.CantidadProducto;
                cmd.Parameters.AddWithValue("@subtotal", SqlDbType.Money).Value = detalleCarritosCE.Subtotal;

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
                cmd.CommandText = "EliminarDetalleCarritos";
                cmd.Parameters.AddWithValue("@codDetalleCarrito", SqlDbType.Int).Value = idEliminar;

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
