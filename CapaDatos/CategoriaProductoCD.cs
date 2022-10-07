using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LIBRERIAS
using CapaEntidad;

namespace CapaDatos
{
    public class CategoriaProductoCD
    {
        public DataTable ListarCategoriaProducto()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            SqlDataAdapter sda = new SqlDataAdapter("ListarCategoriaProducto", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tb = new DataTable();
            sda.Fill(tb);
            return tb;
        }

        // LISTAR CATEGORIAS
        public DataTable ListarCategoria()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            conec.Open();
            SqlDataAdapter sda = new SqlDataAdapter("ListarCategoria", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
