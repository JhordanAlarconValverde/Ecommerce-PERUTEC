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
    public class CategoriaProductosCN
    {
        public DataTable ListarCategoriaProducto()
        {
            CategoriaProductoCD obj = new CategoriaProductoCD();
            return obj.ListarCategoriaProducto();
        }

        // LISTAR CATEGORIAS
        public DataTable ListarCategoria()
        {
            CategoriaProductoCD obj = new CategoriaProductoCD();
            return obj.ListarCategoria();
        }
    }
}
