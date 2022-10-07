using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PedidoCE
    {

        // PROPIEDADES
        private int codPedido;
        private int codCliente;
        private int codMetodoPago;
        private int codEstado;
        private DateTime fecPedido;
        private double montoTotal;
        private int tiempoEntrega;
        private DateTime fecPago;
        private DateTime fecEntrega;

        // ENCAPSULAMIENTO
        public int CodPedido
        {
            get { return codPedido; }
            set { codPedido = value; }
        }

        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }

        public int CodMetodoPago
        {
            get { return codMetodoPago; }
            set { codMetodoPago = value; }
        }

        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
        }

        public DateTime FecPedido
        {
            get { return fecPedido; }
            set { fecPedido = value; }
        }

        public double MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        public int TiempoEntrega
        {
            get { return tiempoEntrega; }
            set { tiempoEntrega = value; }
        }

        public DateTime FecPago
        {
            get { return fecPago; }
            set { fecPago = value; }
        }

        public DateTime FecEntrega
        {
            get { return fecEntrega; }
            set { fecEntrega = value; }
        }

        // CONSTRUCTOR
        public PedidoCE() { }

        public PedidoCE(int codPedido, int codCliente, int codMetodoPago, int codEstado, DateTime fecPedido, double montoTotal, int tiempoEntrega, DateTime fecPago, DateTime fecEntrega)
        {
            this.codPedido = codPedido;
            this.codCliente = codCliente;
            this.codMetodoPago = codMetodoPago;
            this.codEstado = codEstado;
            this.fecPedido = fecPedido;
            this.montoTotal = montoTotal;
            this.tiempoEntrega = tiempoEntrega;
            this.fecPago = fecPago;
            this.fecEntrega = fecEntrega;
        }

    }
}
