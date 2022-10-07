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
    public class DetallePedidoCN
    {
        // CRUD
        public DataTable Listar()
        {
            DetallePedidoCD detallePedidoCD = new DetallePedidoCD();
            return detallePedidoCD.Listar();
        }

        public int Insertar(DetallePedidoCE detallepedidoCE)
        {
            DetallePedidoCD detallePedidoCD = new DetallePedidoCD();
            return detallePedidoCD.Insertar(detallepedidoCE);
        }

        public int Actualizar(DetallePedidoCE detallepedidoCE)
        {
            DetallePedidoCD detallePedidoCD = new DetallePedidoCD();
            return detallePedidoCD.Actualizar(detallepedidoCE);
        }

        public int Eliminar(int idEliminar)
        {
            DetallePedidoCD detallePedidoCD = new DetallePedidoCD();
            return detallePedidoCD.Eliminar(idEliminar);
        }
    }
}
