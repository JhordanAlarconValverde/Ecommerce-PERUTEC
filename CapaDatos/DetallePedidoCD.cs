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
    public class DetallePedidoCD
    {

        // CRUD
        public DataTable Listar()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarDetallePedido", conec);
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

        public int Insertar(DetallePedidoCE detallepedidoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarDetallePedido";
                cmd.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = detallepedidoCE.CodProducto;
                cmd.Parameters.AddWithValue("@codPedido", SqlDbType.Int).Value = detallepedidoCE.CodPedido;
                cmd.Parameters.AddWithValue("@cantidadProducto", SqlDbType.Int).Value = detallepedidoCE.CantidadProducto;
                cmd.Parameters.AddWithValue("@subtotal", SqlDbType.Money).Value = detallepedidoCE.Subtotal;

                int nfilas;
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
                conec.Close();
                return nfilas;
            }
            catch
            {
                conec.Close();
                return 0;
            }
        }

        public int Actualizar(DetallePedidoCE detallepedidoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarDetallePedido";
                cmd.Parameters.AddWithValue("@codDetallePedido", SqlDbType.Int).Value = detallepedidoCE.CodDetallePedido;
                cmd.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = detallepedidoCE.CodProducto;
                cmd.Parameters.AddWithValue("@codPedido", SqlDbType.Int).Value = detallepedidoCE.CodPedido;
                cmd.Parameters.AddWithValue("@cantidadProducto", SqlDbType.Int).Value = detallepedidoCE.CantidadProducto;
                cmd.Parameters.AddWithValue("@subtotal", SqlDbType.Money).Value = detallepedidoCE.Subtotal;

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
                cmd.CommandText = "EliminarDetallePedido";
                cmd.Parameters.AddWithValue("@codDetallePedido", SqlDbType.Int).Value = idEliminar;

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
