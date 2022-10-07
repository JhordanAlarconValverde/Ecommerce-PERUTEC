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
using System.Security.Cryptography;
using System.Text;

namespace CapaPresentacion
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtNombre.Text = Session["nombre"].ToString();
                txtApellido.Text = Session["apellido"].ToString();
                txtCorreo.Text = Session["correo"].ToString();
                txtCelular.Text = Session["celular"].ToString();
                txtDni.Text = Session["Dni"].ToString();
                txtFecNacimiento.Text = Convert.ToDateTime(Session["fecNacimiento"]).ToString("yyyy-MM-dd");
                txtDireccion.Text = Session["direccion"].ToString();
            }
        }

        protected void btnActualizarPerfil_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();
            ClienteCE clienteCE = new ClienteCE();

            clienteCE.CodCliente = Convert.ToInt32(Session["codCliente"]);
            clienteCE.Correo = txtCorreo.Text;
            clienteCE.Celular = txtCelular.Text;         

            DataTable tb;
            tb = clienteCN.ActualizarPerfilCliente(clienteCE);

            if (tb.Rows.Count > 0)
            {
                foreach(DataRow dr in tb.Rows)
                {
                    Session["correo"] = dr["correo"].ToString();
                    Session["celular"] = dr["celular"].ToString();
                }
                Response.Redirect("MiPerfil.aspx?cambio=success");
            }
            else
            {
                Response.Redirect("MiPerfil.aspx?cambio=failed");
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

        protected void btnActualizarClave_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();
            string correo = txtCorreoTab.Text;
            string clave = GetSHA256(txtClave.Text);
            string nuevaClave = GetSHA256(txtNuevaClave.Text);

            int nfilas = clienteCN.CambiarClaveCliente(correo, clave, nuevaClave);

            if (nfilas >= 1)
            {
                Response.Redirect("MiPerfil.aspx?cambio=success");
            }
            else
            {
                Response.Redirect("MiPerfil.aspx?cambio=failed");
            }
            /*if (!string.IsNullOrEmpty(rpta))
            {
                Response.Redirect("MiPerfil.aspx?cambio=success");
            }
            else
            {
                Response.Redirect("MiPerfil.aspx?cambio=failed");
            }*/
        }
    }
}