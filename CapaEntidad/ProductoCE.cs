using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ProductoCE
    {

        // PROPIEDADES
        private int codProducto;
        private string nombre;
        private string descripcion;
        private int codCategoria;
        private int stock;
        private double precio;
        private byte[] imgReferencial;

        // ENCAPSULAMIENTO
        public int CodProducto
        {
            get { return codProducto; }
            set { codProducto = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public int CodCategoria
        {
            get { return codCategoria; }
            set { codCategoria = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public byte[] ImgReferencial
        {
            get { return imgReferencial; }
            set { imgReferencial = value; }
        }

        // CONSTRUCTOR
        public ProductoCE() { }

        public ProductoCE(int codProducto, string nombre, string descripcion, int codCategoria, int stock, double precio, byte[] imgReferencial)
        {
            this.codProducto = codProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.codCategoria = codCategoria;
            this.stock = stock;
            this.precio = precio;
            this.imgReferencial = imgReferencial;
        }
    }
}
