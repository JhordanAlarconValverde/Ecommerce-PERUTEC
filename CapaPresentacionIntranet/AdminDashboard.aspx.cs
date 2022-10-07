using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion.Administrador
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                Object xhr = Request.Headers["xhr"];
                if (xhr != null)
                {
                    GetData();
                }
            }
        }

        public void GetData()
        {
            ProductoCN productoCN = new ProductoCN();
            string rpta= productoCN.DetalleDashboard();
            //string rpta = "prueba";
            Response.Write(rpta);
            Response.End();
        }
    }
}