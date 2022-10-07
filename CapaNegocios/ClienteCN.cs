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
    public class ClienteCN
    {
        // BUSCAR
        public DataTable BuscarClienteByNombre(string nombre)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.BuscarClienteByNombre(nombre);
        }

        public DataTable BuscarClienteByApellido(string apellido)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.BuscarClienteByApellido(apellido);
        }

        public DataTable BuscarClienteByDepartamento(string codDepartamento, string codProvincia, string codDistrito)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.BuscarClienteByDepartamento(codDepartamento, codProvincia, codDistrito);
        }

        // INICIAR SESION
        public DataTable IniciarSesionCliente(ClienteCE clienteCE)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.IniciarSesionCliente(clienteCE);
        }

        // CAMBIAR CLAVE
        public int CambiarClaveCliente(string correo, string clave, string nuevaClave)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.CambiarClaveCliente(correo, clave, nuevaClave);
        }

        // ACTUALIZAR PERFIL
        public DataTable ActualizarPerfilCliente(ClienteCE clienteCE)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.ActualizarPerfilCliente(clienteCE);
        }

        // DETALLE CLIENTE
        public string DetalleCliente(int codCliente)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.DetalleCliente(codCliente);
        }

        // CRUD
        public DataTable Listar()
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.Listar();
        }

        public int Insertar(ClienteCE clienteCE)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.Insertar(clienteCE);
        }

        public int Actualizar(ClienteCE clienteCE)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.Actualizar(clienteCE);
        }

        public int Eliminar(int idEliminar)
        {
            ClienteCD clienteCD = new ClienteCD();
            return clienteCD.Eliminar(idEliminar);

        }
    }
}
