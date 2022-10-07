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
    public class UbigeoCD
    {
        public DataTable ListarDistritosByProvincia(string codProvincia)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            SqlDataAdapter sda = new SqlDataAdapter("ListarDistritosByProvincia", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@codProvincia", SqlDbType.VarChar).Value = codProvincia;
            DataTable tb = new DataTable();
            sda.Fill(tb);
            return tb;
        }

        public DataTable ListarProvinciasByDepartamento(string codDepartamento)
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            SqlDataAdapter sda = new SqlDataAdapter("ListarProvinciasByDepartamento", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@codDepartamento", SqlDbType.VarChar).Value = codDepartamento;
            DataTable tb = new DataTable();
            sda.Fill(tb);
            return tb;
        }

        public DataTable ListarDepartamentos()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            SqlDataAdapter sda = new SqlDataAdapter("ListarDepartamentos", conec);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tb = new DataTable();
            sda.Fill(tb);
            return tb;
        }
    }
}
