using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClienteCE
    {

        // PROPIEDADES
        private int codCliente;
        private string codUbigeo;
        private string nombre;
        private string apellido;
        private string correo;
        private string clave;
        private string dni;
        private string celular;
        private DateTime fecNacimiento;
        private string direccion;
        
        
        // ENCAMPSULAMIENTO
        public int CodCliente
        {
            get { return codCliente; }
            set { codCliente = value; }
        }

        public string CodUbigeo
        {
            get { return codUbigeo; }
            set { codUbigeo = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }

        public DateTime FecNacimiento
        {
            get { return fecNacimiento; }
            set { fecNacimiento = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        
        // CONTRUCTOR
        public ClienteCE() { }

        public ClienteCE(int codCliente, string codUbigeo, string nombre, string apellido, string correo, string clave, string dni, string celular, DateTime fecNacimiento, string direccion)
        {
            this.codCliente = codCliente;
            this.codUbigeo = codUbigeo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.clave = clave;
            this.dni = dni;
            this.celular = celular;
            this.fecNacimiento = fecNacimiento;
            this.direccion = direccion;            
        }

        public ClienteCE(string correo, string clave)
        {
            this.correo = correo;
            this.clave = clave;
        }
    }
}