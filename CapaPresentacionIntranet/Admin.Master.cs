using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Resources;
namespace CapaPresentacion.Administrador
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            /*if (Session["codEmpleado"] == null)
            {
                
            }
            else
            {
                Response.Redirect("AdminDashboard.aspx");
            }*/
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["codEmpleado"] = null;
            Session["codCargo"] = null;
            Session["nombre"] = null;
            Session["apellido"] = null;
            Session["correo"] = null;
            Session["dni"] = null;
            Session["celular"] = null;
            Session["fecNacimiento"] = null;
            Response.Redirect("login.aspx");
            /*Session.Remove("codEmpleado");
            Session.Remove("codCargo");
            Session.Remove("nombre");
            Session.Remove("apellido");
            Session.Remove("correo");
            Session.Remove("dni");
            Session.Remove("celular");
            Session.Remove("fecNacimiento");
            Response.Redirect("login.aspx");*/
        }
    }
}