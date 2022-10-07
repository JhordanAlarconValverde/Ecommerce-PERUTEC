using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;


namespace CapaPresentacion
{
    public partial class busquedaProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { ListarBusqueda(); }
        }

        public void ListarBusqueda()
        {
            string producto = Request.QueryString["producto"];
            int categoria = Convert.ToInt32(Request.QueryString["categoria"]);

            /*ProductoCN productoCN = new ProductoCN();
            DataTable tb = new DataTable();
            tb = productoCN.BuscarByNombreYCategoria(producto,categoria);
            */

            ProductoCN productoCN = new ProductoCN();
            DlProductos.DataSource = productoCN.BuscarProductoByNombreYCategoria(producto, categoria);
            DlProductos.DataBind();
            //string[] data;
            /*foreach (DataRow dr in tb.Rows)
            {
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["imgReferencial"]);
                imgProducto.ImageUrl = imageUrl;
                lblNombreProducto.Text = dr["nombre"].ToString();
                lblDescripcion.Text = dr["descripcion"].ToString();
                lblPrecio.Text = dr["precio"].ToString();
                lblStock.Text = dr["stock"].ToString();
            }*/
        }
    }
}