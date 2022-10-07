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
    public class ProductoCN
    {
        // LISTAR PRODUCTOS INDEX
        public DataTable ListarProductosIndex()
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.ListarProductosIndex();
        }

        // BUSCAR
        public DataTable BuscarProductoByNombre(string nombre)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.BuscarProductoByNombre(nombre);
        }

        public DataTable BuscarProductoByCategoria(int codCategoria)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.BuscarProductoByCategoria(codCategoria);
        }

        public DataTable BuscarProductoByNombreYCategoria(string nombre, int codCategoria)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.BuscarProductoByNombreYCategoria(nombre, codCategoria);
        }

        // LISTAR PRODUCTOS SIN STOCK
        public DataTable ListarProductosSinStock()
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.ListarProductosSinStock();
        }

        // LISTAR ULTIMOS PRODUCTOS
        public DataTable ListarUltimosProductos()
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.ListarUltimosProductos();
        }

        // LISTAR DETALLE PRODUCTO
        public DataTable DetalleProducto(int codProducto)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.DetalleProducto(codProducto);
        }

        // DETALLE DASHBOARD
        public string DetalleDashboard()
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.DetalleDashboard();
        }

        // CRUD
        public DataTable Listar()
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.Listar();
        }

        public int Insertar(ProductoCE productoCE)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.Insertar(productoCE);
        }

        public int Actualizar(ProductoCE productoCE)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.Actualizar(productoCE);
        }

        public int Eliminar(int idEliminar)
        {
            ProductoCD productoCD = new ProductoCD();
            return productoCD.Eliminar(idEliminar);
        }
    }
}
