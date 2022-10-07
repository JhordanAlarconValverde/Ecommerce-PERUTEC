using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
namespace CapaEntidad
{
    public class DetalleCarritosCE
    {
        private int codDetalleCarritos;
        private int codCarritos;
        private ProductoCE productoCE; //Trabajarlo con codProducto a nivel de base de datos.
        private int cantidadProducto;
        private double subtotal;

        public int CodDetalleCarritos
        {
            get { return codDetalleCarritos; }
            set { codDetalleCarritos = value; }
        }

        public int CodCarritos
        {
            get { return codCarritos; }
            set { codCarritos = value; }
        }

        public ProductoCE ProductoCE
        {
            get { return productoCE; }
            set { productoCE = value; }
        }
        public int CantidadProducto
        {
            get { return cantidadProducto; }
            set { cantidadProducto = value; }
        }
        public double Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        public DetalleCarritosCE() { }

        public DetalleCarritosCE(int codDetalleCarritos, int codCarritos, ProductoCE productoCE, int cantidadProducto, double subtotal)
        {
            this.codDetalleCarritos = codDetalleCarritos;
            this.codCarritos = codCarritos;
            this.productoCE = productoCE;
            this.cantidadProducto = cantidadProducto;
            this.subtotal = subtotal;
        }
    }
}