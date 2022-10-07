using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIA
using CapaEntidad;
using CapaNegocios;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace CapaPresentacionIntranet
{
    public partial class AdminPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        private void MostrarPedidos()
        {
            
        }

        protected void txtBuscarByNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}