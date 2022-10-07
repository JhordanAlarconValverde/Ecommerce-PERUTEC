using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaNegocios;
using CapaEntidad;
using System.Data;

namespace CapaPresentacion
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaProductosCN categoriaProductosCN = new CategoriaProductosCN();
                ddlCategoriaProducto.DataSource = categoriaProductosCN.ListarCategoria();
                ddlCategoriaProducto.DataTextField = "nomCategoria";
                ddlCategoriaProducto.DataValueField = "codCategoria";
                ddlCategoriaProducto.DataBind();
                ddlCategoriaProducto.Items.Insert(0, "CATEGORÍA");
            }
        }

        protected void lbuttonBusqueda_Click(object sender, EventArgs e)
        {
            if (txtBuscarProducto.Text.Length >= 1)
            {
                string busquedaProducto = txtBuscarProducto.Text;
                string categoria = ddlCategoriaProducto.SelectedValue;
                Response.Redirect("busquedaProducto.aspx?producto="+busquedaProducto+"&categoria="+categoria);
            }
        }

        protected void btnComprarCarrito_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                Response.Redirect("CompraCarrito.aspx");
            }
        }

        protected void btnVerCarrito_Click(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                Response.Redirect("VerCarrito.aspx");
            }
        }
    }
}