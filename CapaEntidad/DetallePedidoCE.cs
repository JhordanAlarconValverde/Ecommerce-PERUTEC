using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePedidoCE
    {

        // PROPIEDADES
        private int codDetallePedido;
        private int codProducto;
        private int codPedido;
        private int cantidadProducto;
        private double subtotal;

        // ENCAPSULAMIENTO
        public int CodDetallePedido
        {
            get { return codDetallePedido; }
            set { codDetallePedido = value; }
        }

        public int CodProducto
        {
            get { return codProducto; }
            set { codProducto = value; }
        }

        public int CodPedido
        {
            get { return codPedido; }
            set { codPedido = value; }
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


        public DetallePedidoCE() { }

        public DetallePedidoCE(int codDetallePedido, int codProducto, int codPedido, int cantidadProducto, double subtotal)
        {
            this.codDetallePedido = codDetallePedido;
            this.codProducto = codProducto;
            this.codPedido = codPedido;
            this.cantidadProducto = cantidadProducto;
            this.subtotal = subtotal;
        }
    }
}
