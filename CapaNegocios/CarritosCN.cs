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
    public class CarritosCN
    {
        // LISTAR CARRITOS BY CLIENTE
        public DataTable ListarCarritoByCliente()
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.ListarCarritoByCliente();
        }

        /*// BUSCAR CARRITOS BY CLIENTE
        public DataTable BuscarCarritosByCliente(int codCliente)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.BuscarCarritosByCliente(codCliente);
        }*/

        // CRUD
        public DataTable Listar()
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Listar();
        }

        public int Insertar(CarritosCE carritosCE)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Insertar(carritosCE);
        }

        public int Actualizar(CarritosCE carritosCE)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Actualizar(carritosCE);
        }

        public int Eliminar(int idEliminar)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Eliminar(idEliminar);
        }

        /*public int Insertar(CarritosCE carritosCE)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Insertar(carritosCE);
        }
        public string Eliminar(int codCarrito)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Eliminar(codCarrito);
        }
        public string Actualizar(CarritosCE carritosCE)
        {
            CarritosCD carritosCD = new CarritosCD();
            return carritosCD.Actualizar(carritosCE);
        }*/
    }
}
