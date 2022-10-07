using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CarritosCE
    {

        // PROPIEDADES
        private int codCarritos;
        private int codCliente;
        private DateTime fechaGuardado;
        private double montoTotal;
        private bool estado;

        // ENCAPSULAMIENTO
        public int CodCarritos
        {
            get { return codCarritos; }
            set { codCarritos = value; }
        }
        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }
        public DateTime FechaGuardado
        {
            get { return fechaGuardado; }
            set { fechaGuardado = value; }
        }
        public double MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        public bool Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        // CONSTRUCTOR
        public CarritosCE() { }

        public CarritosCE(int codCarritos,int codCliente,DateTime fechaGuardado,double montoTotal,bool estado)
        {
            this.codCarritos = codCarritos;
            this.codCliente = codCliente;
            this.fechaGuardado = fechaGuardado;
            this.montoTotal = montoTotal;
            this.estado = estado;
        }
    }
}
