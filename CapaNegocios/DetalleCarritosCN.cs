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
    public class DetalleCarritosCN
    {
        /*// LISTAR DETALLE CARRITO BY CLIENTE
        public DataTable ListarDetalleCarritosByCliente(int codCliente)
        {
            DetalleCarritosCD detalleCarritosCD = new DetalleCarritosCD();
            return detalleCarritosCD.ListarDetalleCarritosByCliente(codCliente);
        }*/

        // LISTAR DETALLE CARRITO BY CARRITO
        public DataTable ListarDetalleCarritoByCodCarrito(int codCarrito)
        {
            DetalleCarritosCD detalleCarritosCD = new DetalleCarritosCD();
            return detalleCarritosCD.ListarDetalleCarritoByCodCarrito(codCarrito);
        }

        // CRUD
        public DataTable Listar()
        {
            DetalleCarritosCD detalleCarritosCD = new DetalleCarritosCD();
            return detalleCarritosCD.Listar();
        }

        public int Insertar(DetalleCarritosCE detalleCarritosCE)
        {
            DetalleCarritosCD detalleCarritosCD = new DetalleCarritosCD();
            return detalleCarritosCD.Insertar(detalleCarritosCE);
        }

        public int Actualizar(DetalleCarritosCE detalleCarritosCE)
        {
            DetalleCarritosCD detalleCarritosCD = new DetalleCarritosCD();
            return detalleCarritosCD.Actualizar(detalleCarritosCE);
        }

        public int Eliminar(int idEliminar)
        {
            DetalleCarritosCD detalleCarritosCD = new DetalleCarritosCD();
            return detalleCarritosCD.Eliminar(idEliminar);
        }
    }
}
