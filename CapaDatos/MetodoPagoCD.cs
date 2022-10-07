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
    public class MetodoPagoCD
    {
        public DataTable ListarMetodosDePago()
        {
            SqlConnection conec = ConexionCD.ConectarToSqlServer();
            SqlDataAdapter sda = new SqlDataAdapter("ListarMetodosDePago", conec);
            DataTable tb = new DataTable();
            sda.Fill(tb);
            return tb;
        }
    }
}
