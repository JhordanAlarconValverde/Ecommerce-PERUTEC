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
    public class ProductoCD
    {
        // LISTAR PRODUCTOS INDEX
        public DataTable ListarProductosIndex()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();
            SqlDataAdapter sda = new SqlDataAdapter("ListarProductosIndex", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            conec.Close();
            return dt;
        }

        // LISTAR PRODUCTOS SIN STOCK
        public DataTable ListarProductosSinStock()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarProductosSinStock", conec);
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

        // LISTAR ULTIMOS PRODUCTOS
        public DataTable ListarUltimosProductos()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("ListarUltimosProductos", conec);
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

        // LISTAR DETALLE PRODUCTO
        public DataTable DetalleProducto(int codProducto)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("DetalleProducto", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = codProducto;
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

        // BUSCAR
        public DataTable BuscarProductoByNombre(string nombre)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarProductoByNombre", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
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

        public DataTable BuscarProductoByCategoria(int codCategoria)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarProductoByCategoria", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@codCategoria", SqlDbType.Int).Value = codCategoria;
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

        public DataTable BuscarProductoByNombreYCategoria(string nombre, int codCategoria)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("BuscarProductoByNombreYCategoria", conec);
                sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sda.SelectCommand.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = nombre;
                sda.SelectCommand.Parameters.AddWithValue("@codCategoria", SqlDbType.Int).Value = codCategoria;
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

        // DETALLE DASHBOARD
        public string DetalleDashboard()
        {
            SqlConnection cnx = ConexionCD.ConectarToSqlServer();
            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DataDashboard";

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
                SqlDataAdapter sda = new SqlDataAdapter("ListarProductos", conec);
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

        public int Insertar(ProductoCE productoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertarProducto";
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = productoCE.Nombre;
                cmd.Parameters.AddWithValue("@descripcion", SqlDbType.Text).Value = productoCE.Descripcion;
                cmd.Parameters.AddWithValue("@codCategoria", SqlDbType.Int).Value = productoCE.CodCategoria;
                cmd.Parameters.AddWithValue("@stock", SqlDbType.Int).Value = productoCE.Stock;
                cmd.Parameters.AddWithValue("@precio", SqlDbType.Money).Value = productoCE.Precio;
                cmd.Parameters.AddWithValue("@imgReferencial", SqlDbType.VarBinary).Value = productoCE.ImgReferencial;

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

        public int Actualizar(ProductoCE productoCE)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();

            int nfilas;

            try
            {
                SqlCommand cmd = conec.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ActualizarProducto";
                cmd.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = productoCE.CodProducto;
                cmd.Parameters.AddWithValue("@nombre", SqlDbType.VarChar).Value = productoCE.Nombre;
                cmd.Parameters.AddWithValue("@descripcion", SqlDbType.Text).Value = productoCE.Descripcion;
                cmd.Parameters.AddWithValue("@codCategoria", SqlDbType.Int).Value = productoCE.CodCategoria;
                cmd.Parameters.AddWithValue("@stock", SqlDbType.Int).Value = productoCE.Stock;
                cmd.Parameters.AddWithValue("@precio", SqlDbType.Money).Value = productoCE.Precio;
                cmd.Parameters.AddWithValue("@imgReferencial", SqlDbType.VarBinary).Value = productoCE.ImgReferencial;

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
                cmd.CommandText = "EliminarProducto";
                cmd.Parameters.AddWithValue("@codProducto", SqlDbType.Int).Value = idEliminar;

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
