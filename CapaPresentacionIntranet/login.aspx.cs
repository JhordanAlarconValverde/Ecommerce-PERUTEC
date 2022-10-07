using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using System.Data;
using CapaEntidad;
using CapaNegocios;
using System.Security.Cryptography;
using System.Text;

namespace CapaPresentacionIntranet
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Request.QueryString["logout"] == "success")
            {
                Response.Redirect("login.aspx");
            }*/
            /*if (Session["codEmpleado"] == null)
            {
                Response.Redirect("login.aspx");
            }*/
            /*if (Session["codEmpleado"] == null)
            {
                Response.Redirect("login.aspx");
            }*/
            /*if (!IsPostBack)
            {
                if (Request.QueryString["logout"] == "success")
                {
                    Session.Remove("codEmpleado");
                    Session.Remove("codCargo");
                    Session.Remove("nombre");
                    Session.Remove("apellido");
                    Session.Remove("correo");
                    Session.Remove("dni");
                    Session.Remove("celular");
                    Session.Remove("fecNacimiento");
                }
            }*/
        }

        public string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        protected void btnEmpIniciarSesion_Click(object sender, EventArgs e)
        {
            string empCorreo = txtEmpCorreo.Text;
            string empClave = GetSHA256(txtEmpClave.Text);
            int codEmpleado = 0;
            EmpleadoCN empleadoCN = new EmpleadoCN();

            DataTable empleadoTable = empleadoCN.IniciarSesionEmpleado(empCorreo, empClave);

            if (empleadoTable.Rows.Count > 0)
            {
                foreach (DataRow dr in empleadoTable.Rows)
                {
                    Session["codEmpleado"] = Convert.ToInt32(dr["codEmpleado"]);
                    Session["codCargo"] = Convert.ToInt32(dr["codCargo"]);
                    codEmpleado = Convert.ToInt32(dr["codCargo"]);
                    Session["nombre"] = dr["nombre"].ToString();
                    Session["apellido"] = dr["apellido"].ToString();
                    Session["correo"] = dr["correo"].ToString();
                    Session["dni"] = dr["dni"].ToString();
                    Session["celular"] = dr["celular"].ToString();
                    Session["fecNacimiento"] = Convert.ToDateTime(dr["fecNacimiento"]);
                }

                if (codEmpleado == 1)
                {
                    Response.Redirect("AdminDashboard.aspx");
                }
                else if (codEmpleado == 2)
                {
                    Response.Redirect("AdminClientes.aspx");
                }
                else if (codEmpleado == 3)
                {
                    Response.Redirect("AdminPedidos.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx?login=failed");
            }
            /*
             string empCorreo = txtEmpCorreo.Text;
            string empClave = GetSHA256(txtEmpClave.Text);
            int codEmpleado = 0;
            EmpleadoCN empleadoCN = new EmpleadoCN();

            DataTable empleadoTable = empleadoCN.IniciarSesionEmpleado(empCorreo, empClave);
            if (empleadoTable.Rows.Count > 0)
            {
                foreach (DataRow dr in empleadoTable.Rows)
                {
                    Session["codEmpleado"] = Convert.ToInt32(dr["codEmpleado"]);
                    Session["codCargo"] = Convert.ToInt32(dr["codCargo"]);
                    codEmpleado = Convert.ToInt32(dr["codCargo"]);
                    Session["nombre"] = dr["nombre"].ToString();
                    Session["apellido"] = dr["apellido"].ToString();
                    Session["correo"] = dr["correo"].ToString();
                    Session["dni"] = dr["dni"].ToString();
                    Session["celular"] = dr["celular"].ToString();
                    Session["fecNacimiento"] = Convert.ToDateTime(dr["fecNacimiento"]);
                }

                if(codEmpleado == 1)
                {
                    Response.Redirect("AdminDashboard.aspx");
                }else if (codEmpleado == 2)
                {
                    Response.Redirect("AdminClientes.aspx");
                }else if (codEmpleado == 3)
                {
                    Response.Redirect("AdminPedidos.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx?login=failed");
            }*/
        }
    }
}