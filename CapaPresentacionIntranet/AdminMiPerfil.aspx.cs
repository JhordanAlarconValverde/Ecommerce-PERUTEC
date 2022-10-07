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
using System.Security.Cryptography;
using System.Text;

namespace CapaPresentacionIntranet
{
    public partial class AdminMiPerfil : System.Web.UI.Page
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
                    txtNombre.Text = Session["nombre"].ToString();
                    txtApellido.Text = Session["apellido"].ToString();
                    txtDni.Text = Session["dni"].ToString();
                    txtCelular.Text = Session["celular"].ToString();
                    txtCorreo.Text = Session["correo"].ToString();
                    txtFecNacimiento.Text = Convert.ToDateTime(Session["fecNacimiento"]).ToString("yyyy-MM-dd");
                }
            }
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

        protected void btnActualizarPerfil_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();
            EmpleadoCE empleadoCE = new EmpleadoCE();
            string claveEncriptada = GetSHA256(txtClave.Text);
            empleadoCE.CodEmpleado = Convert.ToInt32(Session["codEmpleado"]);
            empleadoCE.CodCargo = Convert.ToInt32(Session["codCargo"]);
            empleadoCE.Nombre = txtNombre.Text;
            empleadoCE.Apellido = txtApellido.Text;
            empleadoCE.Correo = txtCorreo.Text;
            empleadoCE.Clave = claveEncriptada;
            empleadoCE.Dni = txtDni.Text;
            empleadoCE.Celular = txtCelular.Text;
            empleadoCE.FecNacimiento = Convert.ToDateTime(txtFecNacimiento.Text);

            DataTable tb;

            tb = empleadoCN.Actualizar(empleadoCE);

            if (tb.Rows.Count > 0)
            {
                foreach(DataRow dr in tb.Rows){ 

                 Session["codEmpleado"] = Convert.ToInt32(dr["codEmpleado"]);
                 Session["codCargo"] = Convert.ToInt32(dr["codCargo"]);
                 Session["nombre"] = dr["nombre"].ToString();
                 Session["apellido"] = dr["apellido"].ToString();
                 Session["correo"] = dr["correo"].ToString();
                 Session["dni"] = dr["dni"].ToString();
                 Session["celular"] = dr["celular"].ToString();
                 Session["fecNacimiento"] = Convert.ToDateTime(dr["fecNacimiento"]);

                }
                Response.Redirect("AdminMiPerfil.aspx?update=success");
            }
            else
            {
                Response.Redirect("AdminMiPerfil.aspx?update=failed");
            }
        }
    }
}