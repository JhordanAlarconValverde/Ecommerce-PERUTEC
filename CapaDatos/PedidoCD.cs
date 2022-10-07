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
    public class PedidoCD
    {

        // CRUD
        public DataTable Listar()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarPedidos", conec);
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

        public int Insertar(PedidoCE pedidoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            SqlCommand cmd = conec.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO PEDIDO VALUES(@codCliente, @codMetodoPago, @codEstado, @fecPedido, @montoTotal, @tiempoEntrega, @fecPago, @fecEntrega)";
            cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = pedidoCE.CodCliente;
            cmd.Parameters.AddWithValue("@codMetodoPago", SqlDbType.Int).Value = pedidoCE.CodMetodoPago;
            cmd.Parameters.AddWithValue("@codEstado", SqlDbType.Int).Value = pedidoCE.CodEstado;
            cmd.Parameters.AddWithValue("@fecPedido", SqlDbType.Date).Value = pedidoCE.FecPedido;
            cmd.Parameters.AddWithValue("@montoTotal", SqlDbType.Money).Value = pedidoCE.MontoTotal;
            cmd.Parameters.AddWithValue("@tiempoEntrega", SqlDbType.Int).Value = pedidoCE.TiempoEntrega;
            cmd.Parameters.AddWithValue("@fecPago", SqlDbType.Date).Value = pedidoCE.FecPago;
            cmd.Parameters.AddWithValue("@fecEntrega", SqlDbType.Date).Value = pedidoCE.FecEntrega;
            int nfilas = cmd.ExecuteNonQuery();

            int idPedido;

            if (nfilas > 0)
            {
                cmd.CommandText = "select max(codPedido) as nuevoID from Pedido where codCliente = @codCliente";
                cmd.Parameters["@codCliente"].Value = pedidoCE.CodCliente;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    idPedido = Convert.ToInt32(dr["nuevoID"]);
                }
                else
                {
                    idPedido = 0;
                }
            }
            else
            {
                idPedido = 0;
            }
            conec.Close();
            return idPedido;
        }

        public int Actualizar(PedidoCE pedidoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarPedido";
                cmd.Parameters.AddWithValue("@codPedido", SqlDbType.Int).Value = pedidoCE.CodPedido;
                cmd.Parameters.AddWithValue("@codCliente", SqlDbType.Int).Value = pedidoCE.CodCliente;
                cmd.Parameters.AddWithValue("@codMetodoPago", SqlDbType.Int).Value = pedidoCE.CodMetodoPago;
                cmd.Parameters.AddWithValue("@codEstado", SqlDbType.Int).Value = pedidoCE.CodEstado;
                cmd.Parameters.AddWithValue("@fecPedido", SqlDbType.DateTime).Value = pedidoCE.FecPedido;
                cmd.Parameters.AddWithValue("@montoTotal", SqlDbType.Money).Value = pedidoCE.MontoTotal;
                cmd.Parameters.AddWithValue("@tiempoEntrega", SqlDbType.Int).Value = pedidoCE.TiempoEntrega;
                cmd.Parameters.AddWithValue("@fecPago", SqlDbType.DateTime).Value = pedidoCE.FecPago;
                cmd.Parameters.AddWithValue("@fecEntrega", SqlDbType.DateTime).Value = pedidoCE.FecEntrega;

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
                cmd.CommandText = "EliminarPedido";
                cmd.Parameters.AddWithValue("@codPedido", SqlDbType.Int).Value = idEliminar;

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
