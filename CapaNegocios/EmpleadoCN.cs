using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LIBRERIAS
using CapaEntidad;
using CapaDatos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CapaNegocios
{
    public class EmpleadoCN
    {
        // BUSCAR
        public DataTable BuscarEmpleadoVenByNombre(string nombre)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.BuscarEmpleadoVenByNombre(nombre);
        }

        public DataTable BuscarEmpleadoReByNombre(string nombre)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.BuscarEmpleadoReByNombre(nombre);
        }

        public DataTable BuscarEmpleadoVenByApellido(string apellido)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.BuscarEmpleadoVenByApellido(apellido);
        }

        public DataTable BuscarEmpleadoReByApellido(string apellido)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.BuscarEmpleadoReByApellido(apellido);
        }

        public DataTable BuscarEmpleadoByCargo(string nomCargo)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.BuscarEmpleadoByCargo(nomCargo);
        }

        // LISTAR CARGO EMPLEADO
        public DataTable ListarCargoEmpleado()
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.ListarCargoEmpleado();
        }

        // INICIAR SESION
        public DataTable IniciarSesionEmpleado(string correo, string clave)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.IniciarSesionEmpleado(correo,clave);
        }

        // CRUD
        public DataTable ListarEmpleadosRepartidores()
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.ListarEmpleadosRepartidores();
        }

        public DataTable ListarEmpleadosVendedores()
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.ListarEmpleadosVendedores();
        }

        public int Insertar(EmpleadoCE empleadoCE)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.Insertar(empleadoCE);
        }

        public DataTable Actualizar(EmpleadoCE empleadoCE)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.Actualizar(empleadoCE);
        }

        public int Eliminar(int idEliminar)
        {
            EmpleadoCD empleadoCD = new EmpleadoCD();
            return empleadoCD.Eliminar(idEliminar);
        }
    }
}
