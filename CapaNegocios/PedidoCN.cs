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
    public class PedidoCN
    {
        // CRUD
        public DataTable Listar()
        {
            PedidoCD pedidoCD = new PedidoCD();
            return pedidoCD.Listar();
        }

        public int Insertar(PedidoCE pedidoCE)
        {
            PedidoCD pedidoCD = new PedidoCD();
            return pedidoCD.Insertar(pedidoCE);
        }

        public int Actualizar(PedidoCE pedidoCE)
        {
            PedidoCD pedidoCD = new PedidoCD();
            return pedidoCD.Actualizar(pedidoCE);
        }

        public int Eliminar(int idEliminar)
        {
            PedidoCD pedidoCD = new PedidoCD();
            return pedidoCD.Eliminar(idEliminar);
        }
    }
}
