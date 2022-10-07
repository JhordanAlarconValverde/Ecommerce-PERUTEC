using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;
using System.Data;

namespace CapaPresentacionIntranet
{
    public partial class AdminProdSinStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    CategoriaProductosCN categorias = new CategoriaProductosCN();
                    ddlCategoria.DataSource = categorias.ListarCategoria();
                    ddlCategoria.DataTextField = "nomCategoria";
                    ddlCategoria.DataValueField = "codCategoria";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, "Seleccionar Categoría");
                }
            }
        }
        public void MostrarProductos()
        {
            ProductoCN productoCN = new ProductoCN();
            GvProdSinStock.DataSource = productoCN.ListarProductosSinStock();
            GvProdSinStock.DataBind();
        }
    }
}