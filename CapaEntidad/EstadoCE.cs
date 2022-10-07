using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EstadoCE
    {

        // PROPIEDADES
        private int codEstado;
        private string nomEstado;

        // ENCAPSULAMIENTO
        public int CodEstado
        {
            get { return codEstado; }
            set { codEstado = value; }
        } 
        public string NomEstado
        {
            get { return nomEstado; }
            set { nomEstado = value; }
        }

        // CONSTRUCTOR
        EstadoCE() { }

        EstadoCE(int codEstado, string nomEstado)
        {
            this.codEstado = codEstado;
            this.nomEstado = nomEstado;
        }
    }
}
