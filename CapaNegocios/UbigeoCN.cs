using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LIBRERIAS
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CapaNegocios
{
    public class UbigeoCN
    {
        public DataTable ListarDistritosByProvincia(string codProvincia)
        {
            UbigeoCD ubigeoCD = new UbigeoCD();
            return ubigeoCD.ListarDistritosByProvincia(codProvincia);
        }

        public DataTable ListarProvinciasByDepartamento(string codDepartamento)
        {
            UbigeoCD ubigeoCD = new UbigeoCD();
            return ubigeoCD.ListarProvinciasByDepartamento(codDepartamento);
        }

        public DataTable ListarDepartamentos()
        {
            UbigeoCD ubigeoCD = new UbigeoCD();
            return ubigeoCD.ListarDepartamentos();
        }
    }
}
