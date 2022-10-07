using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class ConexionCD
    { 
        public static SqlConnection ConectarToSqlServer()
            {
            //Generador de cadena de conexion
            SqlConnectionStringBuilder generar = new SqlConnectionStringBuilder();
            generar.DataSource = "localhost";       //SERVIDOR
            generar.InitialCatalog = "DBPERUTEC";   //BASE DE DATOS
            generar.UserID = "sa";                  //USUARIO
            generar.Password = "123456";       //CLAVE

            //Cadena de conexion
            string conec = generar.ConnectionString;

            //Instanciar una conexion
            SqlConnection conexion = new SqlConnection(conec);
            return conexion;
        }
    }
}
