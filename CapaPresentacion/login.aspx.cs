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
using System.Text;
using System.Security.Cryptography;

namespace CapaPresentacion
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /* LIMPIAR */
        private void Limpiar()
        {
            txtCorreo.Text = string.Empty;
            txtClave.Text = string.Empty;
        }

        /* ENCRIPTACION DE CLAVE */
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

        /* INICIAR SESION */
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtCorreo.Text.Length == 0 || txtClave.Text.Length == 0)
            {
                Limpiar();
                Response.Redirect("login.aspx?status=empty");
            }
            else
            {
                string correo = txtCorreo.Text;
                string clave = GetSHA256(txtClave.Text);

                ClienteCE clienteCE = new ClienteCE(correo, clave);
                ClienteCN clienteCN = new ClienteCN();

                DataTable tb = clienteCN.IniciarSesionCliente(clienteCE);

                int codCliente = 0;

                if (tb.Rows.Count > 0)
                {
                    foreach (DataRow dr in tb.Rows)
                    {
                        Session["codCliente"] = dr["codCliente"];
                        codCliente = Convert.ToInt32(dr["codCliente"]);
                        Session["nombre"] = dr["nombre"].ToString();
                        Session["apellido"] = dr["apellido"].ToString();
                        Session["correo"] = dr["correo"].ToString();
                        Session["dni"] = dr["dni"].ToString();
                        Session["celular"] = dr["celular"].ToString();
                        Session["fecNacimiento"] = dr["fecNacimiento"].ToString();
                        Session["direccion"] = dr["direccion"].ToString();
                    }

                    /*DetalleCarritosCN detalleCarritosCN = new DetalleCarritosCN();
                    DetalleCarritosCE detalleCarritosCE = new DetalleCarritosCE();

                    DataTable Carritotb;

                    Carritotb = detalleCarritosCN.ListarDetalleCarritosBySession(codCliente);

                    List<DetalleCarritosCE> listaCarritos = new List<DetalleCarritosCE>();

                    if (Carritotb.Rows.Count > 0)
                    {
                        //detalleCarritosCE.

                    }*/

                    
                    if (Session["codCliente"].ToString() != null)
                    {
                        Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    Response.Redirect("login.aspx?status=failed");
                }
            }
        }
        
    }
}