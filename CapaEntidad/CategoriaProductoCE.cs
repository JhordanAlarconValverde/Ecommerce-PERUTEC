using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CategoriaProductoCE
    {

        // PROPIEDADES
        private int codCategoria;
        private string nomCategoria;

        // ENCAPSULAMIENTO
        public int CodCategoria { 
            get { return codCategoria; } 
            set { codCategoria = value; }    
        }
        public string NomCategoria
        {
            get { return nomCategoria; }
            set { nomCategoria = value; }
        }

        // CONSTRUCTOR
        public CategoriaProductoCE() { }

        public CategoriaProductoCE(int codCategoria,string nomCategoria) {
            this.codCategoria = codCategoria;
            this.nomCategoria = nomCategoria;
        }
    }
}
