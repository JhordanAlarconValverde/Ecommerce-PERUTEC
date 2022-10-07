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
    public class MetodoPagoCN
    {
        public DataTable ListarMetodosDePago()
        {
            MetodoPagoCD metodoPagoCD = new MetodoPagoCD();
            return metodoPagoCD.ListarMetodosDePago();
        }
    }
}
