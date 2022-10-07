using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mostrarProductos();
            }

        }
        protected void mostrarProductos()
        {
            ProductoCN productoCN = new ProductoCN();
            DlProductos.DataSource = productoCN.ListarProductosIndex();
            DlProductos.DataBind();
        }
    }
}