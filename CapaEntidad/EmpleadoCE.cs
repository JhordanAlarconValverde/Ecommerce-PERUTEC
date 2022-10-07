using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EmpleadoCE
    {

        // PROPIEDADES
        private int codEmpleado;
        private int codCargo;
        private string nombre;
        private string apellido;
        private string correo;
        private string clave; 
        private string dni;
        private string celular;
        private DateTime fecNacimiento;

        // ENCAPSULAMIENTO
        public int CodEmpleado
        {
            get { return codEmpleado; }
            set { codEmpleado = value; }
        }

        public int CodCargo
        {
            get { return codCargo; }
            set { codCargo = value; }
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

        public string Dni
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

        // CONSTRUCTOR
        public EmpleadoCE() { }

        public EmpleadoCE(int codEmpleado, int codCargo, string nombre, string apellido, string correo, string clave, string dni, string celular, DateTime fecNacimiento)
        {
            this.codEmpleado = codEmpleado;
            this.codCargo = codCargo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.correo = correo;
            this.clave = clave;
            this.dni = dni;
            this.celular = celular;
            this.fecNacimiento = fecNacimiento;
        }

        public EmpleadoCE(string correo, string clave)
        {
            this.correo = correo;
            this.clave = clave;
        }
    }
}
