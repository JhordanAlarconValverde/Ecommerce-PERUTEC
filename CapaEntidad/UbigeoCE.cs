using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class UbigeoCE
    {

        // PROPIEDADES
        private string codDistrito;
        private string nomDistrito;
        private string codProvincia;
        private string nomProvincia;
        private string codDepartamento;
        private string nomDepartamento;

        // ENCAPSULAMIENTO
        public string CodDistrito
        {
            get { return codDistrito; }
            set { codDistrito = value; }
        }
        public string NomDistrito
        {
            get { return nomDistrito; }
            set { nomDistrito = value; }
        }
        public string CodProvincia
        {
            get { return codProvincia; }
            set { codProvincia = value; }
        }
        public string NomProvincia
        {
            get { return nomProvincia; }
            set { nomProvincia = value; }
        }
        public string CodDepartamento
        {
            get { return codDepartamento; }
            set { codDepartamento = value; }
        }
        public string NomDepartamento
        {
            get { return nomDepartamento; }
            set { nomDepartamento = value; }
        }

        // CONSTRUCTOR
        public UbigeoCE() { }

        public UbigeoCE(string codDistrito = "", string nomDistrito = "", string codProvincia = "", string nomProvincia = "", string codDepartamento = "", string nomDepartamento = "")
        {
            this.codDistrito = codDistrito;
            this.nomDistrito = nomDistrito;
            this.codProvincia = codProvincia;
            this.nomProvincia = nomProvincia;
            this.codDepartamento = codDepartamento;
            this.nomDepartamento = nomDepartamento;
        }
    }
}
