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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UbigeoCN ubigeoCN = new UbigeoCN();
                ddlDepartamento.DataSource = ubigeoCN.ListarDepartamentos();
                ddlDepartamento.DataTextField = "nomDepartamento";
                ddlDepartamento.DataValueField = "codDepartamento";
                ddlDepartamento.DataBind();
                ddlDepartamento.Items.Insert(0, "Seleccionar Departamento");
            }
        }

        private void ListarProvincias()
        {
            UbigeoCN ubigeoCNProvincias = new UbigeoCN();
            string codDepartamento = ddlDepartamento.SelectedValue.ToString();
            ddlProvincia.DataSource = ubigeoCNProvincias.ListarProvinciasByDepartamento(codDepartamento);
            ddlProvincia.DataTextField = "nomProvincia";
            ddlProvincia.DataValueField = "codProvincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, "Seleccionar Provincia");
        }

        private void ListarDistritos()
        {
            UbigeoCN ubigeoCNProvincias = new UbigeoCN();
            string codProvincia = ddlProvincia.SelectedValue.ToString();
            ddlDistrito.DataSource = ubigeoCNProvincias.ListarDistritosByProvincia(codProvincia);
            ddlDistrito.DataTextField = "nomDistrito";
            ddlDistrito.DataValueField = "codDistrito";
            ddlDistrito.DataBind();
            ddlDistrito.Items.Insert(0, "Seleccionar Provincia");
        }

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarProvincias();
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarDistritos();
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

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();
            ClienteCE clienteCE = new ClienteCE();

            if (txtClave.Text == txtClave2.Text)
            {
                clienteCE.Nombre = txtNombre.Text;
                clienteCE.Apellido= txtApellido.Text;
                clienteCE.DNI = txtDni.Text;
                clienteCE.Celular = txtCelular.Text;
                clienteCE.CodUbigeo = ddlDistrito.SelectedValue;
                clienteCE.Direccion = txtDireccion.Text;
                clienteCE.FecNacimiento = Convert.ToDateTime(txtFecNacimiento.Text);
                clienteCE.Correo = txtCorreo.Text;
                clienteCE.Clave = GetSHA256(txtClave.Text);

                int nfilas = clienteCN.Insertar(clienteCE);

                if (nfilas >= 1)
                {
                    Response.Redirect("login.aspx?registro=success");
                }
                else
                {
                    Response.Redirect("Registro.aspx?registro=failed");
                }
            }
            else
            {
                Response.Redirect("Registro.aspx?clave=failed");
            }
        }
    }
}