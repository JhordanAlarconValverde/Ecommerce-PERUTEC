using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class MetodoPagoCE
    {

        // PROPIEDADES
        private int codMetodoPago;
        private string nomMetodoPago;

        // ENCAPSULAMIENTO
        public int CodMetodoPago
        {
            get { return codMetodoPago; }
            set { codMetodoPago = value; }
        }

        public string NomMetodoPago
        {
            get { return nomMetodoPago; }
            set { nomMetodoPago = value; }
        }

        // CONSTRUCTOR
        MetodoPagoCE() { }

        MetodoPagoCE(int codMetodoPago, string nomMetodoPago)
        {
            this.codMetodoPago = codMetodoPago;
            this.nomMetodoPago = nomMetodoPago;
        }

    }
}
