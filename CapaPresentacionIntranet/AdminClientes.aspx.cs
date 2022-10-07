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

namespace CapaPresentacion.Administrador
{
    public partial class AdminClientes : System.Web.UI.Page
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
                    ListarClientes();
                    UbigeoCN ubigeoCN = new UbigeoCN();
                    ddlBuscarByDepartamento.DataSource = ubigeoCN.ListarDepartamentos();
                    ddlBuscarByDepartamento.DataTextField = "nomDepartamento";
                    ddlBuscarByDepartamento.DataValueField = "codDepartamento";
                    ddlBuscarByDepartamento.DataBind();
                    ddlBuscarByDepartamento.Items.Insert(0, "Seleccionar Departamento");

                    ddlRegCliDepartamento.DataSource = ubigeoCN.ListarDepartamentos();
                    ddlRegCliDepartamento.DataTextField = "nomDepartamento";
                    ddlRegCliDepartamento.DataValueField = "codDepartamento";
                    ddlRegCliDepartamento.DataBind();
                    ddlRegCliDepartamento.Items.Insert(0, "Seleccionar Departamento");
                    panelRegistro.Visible = false;
                    txtCodCliente.Enabled = false;
                }
            }
        }

        private void ListarClientes()
        {
            DataTable dt;
            ClienteCN clienteCN = new ClienteCN();
            dt = clienteCN.Listar();

            GvClientes.DataSource = dt;
            GvClientes.DataBind();

            /*foreach(GridViewRow gvr in GvClientes.Rows)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    gvr.Cells[8].Text = Convert.ToDateTime(dr[6]).ToString("dd/MM/yyyy");
                }
            }*/
        }

        private void ListarProvincias()
        {
            string codDepartamento = ddlBuscarByDepartamento.SelectedValue.ToString();

            UbigeoCN ubigeoCN = new UbigeoCN();
            ddlBuscarByProvincia.DataSource = ubigeoCN.ListarProvinciasByDepartamento(codDepartamento);
            ddlBuscarByProvincia.DataTextField = "nomProvincia";
            ddlBuscarByProvincia.DataValueField = "codProvincia";
            ddlBuscarByProvincia.DataBind();
            ddlBuscarByProvincia.Items.Insert(0, "Seleccionar Provincia");
        }

        private void ListarProvinciasNuevoregistro()
        {
            string codDepartamento = ddlRegCliDepartamento.SelectedValue.ToString();

            UbigeoCN ubigeoCNProvincias = new UbigeoCN();
            //tbProvincias = ubigeoCNProvincias.ListarProvincias(codDepartamento);
            ddlRegCliProvincia.DataSource = ubigeoCNProvincias.ListarProvinciasByDepartamento(codDepartamento);
            ddlRegCliProvincia.DataTextField = "nomProvincia";
            ddlRegCliProvincia.DataValueField = "codProvincia";
            ddlRegCliProvincia.DataBind();
            ddlRegCliProvincia.Items.Insert(0, "Seleccionar Provincia");
        }

        private void ListarDistritos()
        {
            string codProvincia = ddlBuscarByProvincia.SelectedValue.ToString();

            UbigeoCN ubigeoCN = new UbigeoCN();
            ddlBuscarByDistrito.DataSource = ubigeoCN.ListarDistritosByProvincia(codProvincia);
            ddlBuscarByDistrito.DataTextField = "nomDistrito";
            ddlBuscarByDistrito.DataValueField = "codDistrito";
            ddlBuscarByDistrito.DataBind();
            ddlBuscarByDistrito.Items.Insert(0, "Seleccionar Distrito");
        }

        private void ListarDistritosNuevoRegistro()
        {
            string codProvincia = ddlRegCliProvincia.SelectedValue.ToString();

            UbigeoCN ubigeoCNProvincias = new UbigeoCN();
            ddlRegCliDistrito.DataSource = ubigeoCNProvincias.ListarDistritosByProvincia(codProvincia);
            ddlRegCliDistrito.DataTextField = "nomDistrito";
            ddlRegCliDistrito.DataValueField = "codDistrito";
            ddlRegCliDistrito.DataBind();
            ddlRegCliDistrito.Items.Insert(0, "Seleccionar Distrito");
        }

        protected void btnSeleccionarDepartamento_Click(object sender, EventArgs e)
        {
            ListarProvincias();
        }

        protected void btnSeleccionarProvincia_Click(object sender, EventArgs e)
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
            ClienteCE clienteCE = new ClienteCE();
            ClienteCN clienteCN = new ClienteCN();

            if (string.IsNullOrEmpty(txtCodCliente.Text))
            {
                clienteCE.CodCliente = 0;
            }
            else
            {
                clienteCE.CodCliente = Convert.ToInt32(txtCodCliente.Text);
            }

            clienteCE.CodUbigeo = ddlRegCliDistrito.SelectedValue;
            clienteCE.Nombre = txtNomCliente.Text;
            clienteCE.Apellido = txtApeCliente.Text;
            clienteCE.Correo = txtCorreo.Text;
            clienteCE.Clave = GetSHA256(txtClave.Text);
            clienteCE.DNI = txtDni.Text;
            clienteCE.Celular = txtCelular.Text;
            clienteCE.FecNacimiento = Convert.ToDateTime(txtFecNacimiento.Text);
            clienteCE.Direccion = txtDireccion.Text;

            if (btnRegistrar.Text == "Registrar")
            {
                clienteCN.Insertar(clienteCE);
                Response.Redirect("AdminClientes.aspx?registro=success");
            }
            else if (btnRegistrar.Text == "Actualizar")
            {
                clienteCN.Actualizar(clienteCE);
                Response.Redirect("AdminClientes.aspx?update=success");
            }
        }

        protected void ddlRegCliDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarProvinciasNuevoregistro();
        }

        protected void ddlRegCliProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarDistritosNuevoRegistro();
        }

        protected void ddlRegCliDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            btnRegistrar.Text = "Registrar";
            panelRegistro.Visible = true;
            txtCodCliente.ReadOnly = true;
            txtCodCliente.Text = string.Empty;
            txtNomCliente.Text = string.Empty;
            txtApeCliente.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtFecNacimiento.Text = DateTime.Today.ToString();
            txtDireccion.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            txtCodCliente.ReadOnly = true;
            txtCodCliente.Text = string.Empty;
            txtNomCliente.Text = string.Empty;
            txtApeCliente.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtFecNacimiento.Text = DateTime.Today.ToString();
            txtDireccion.Text = string.Empty;
        }

        protected void GvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRegistrar.Text = "Actualizar";
            panelRegistro.Visible = true;
            txtCodCliente.ReadOnly = true;
            txtCodCliente.Text = GvClientes.SelectedRow.Cells[2].Text;
            txtNomCliente.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[3].Text);
            txtApeCliente.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[4].Text);
            txtCorreo.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[5].Text);
            txtDni.Text = GvClientes.SelectedRow.Cells[6].Text;
            txtCelular.Text = GvClientes.SelectedRow.Cells[7].Text;
            txtFecNacimiento.Text = Convert.ToDateTime(GvClientes.SelectedRow.Cells[8].Text).ToString("yyyy-MM-dd");
            ddlRegCliDepartamento.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[9].Text);
            ddlRegCliProvincia.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[10].Text);
            ddlRegCliDistrito.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[11].Text);
            txtDireccion.Text = HttpUtility.HtmlDecode(GvClientes.SelectedRow.Cells[12].Text);
        }

        protected void btnBuscarByNombre_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();

            if (txtBuscarByNombre.Text.Length == 0)
            {
                Response.Redirect("AdminClientes.aspx");
            }
            else
            {
                string nombre = txtBuscarByNombre.Text;
                DataTable dt = clienteCN.BuscarClienteByNombre(nombre);

                if (dt.Rows.Count > 0)
                {
                    GvClientes.DataSource = dt;
                    GvClientes.DataBind();
                }
                else
                {
                    GvClientes.DataSource = clienteCN.Listar();
                    GvClientes.DataBind();
                }
            }
        }

        protected void btnBuscarByApellido_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();

            if (txtBuscarByApellido.Text.Length == 0)
            {
                Response.Redirect("AdminClientes.aspx");
            }
            else
            {
                string apellido = txtBuscarByApellido.Text;

                DataTable dt = clienteCN.BuscarClienteByApellido(apellido);

                if (dt.Rows.Count > 0)
                {
                    GvClientes.DataSource = dt;
                    GvClientes.DataBind();
                }
                else
                {
                    
                    GvClientes.DataSource = clienteCN.Listar();
                    GvClientes.DataBind();
                }
            }
        }

        protected void btnBuscarByUbigeo_Click(object sender, EventArgs e)
        {
            ClienteCN clienteCN = new ClienteCN();

            string codDepartamento = ddlBuscarByDepartamento.SelectedValue;
            string codProvincia = ddlBuscarByProvincia.SelectedValue;
            string codDistrito = ddlBuscarByDistrito.SelectedValue;


            if (ddlBuscarByDepartamento.SelectedValue != "" && ddlBuscarByProvincia.SelectedValue != "" && ddlBuscarByDistrito.SelectedValue != "")
            {
                DataTable dt = clienteCN.BuscarClienteByDepartamento(codDepartamento, codProvincia, codDistrito);

                if (dt.Rows.Count > 0)
                {
                    GvClientes.DataSource = dt;
                    GvClientes.DataBind();
                }
                else
                {

                    GvClientes.DataSource = clienteCN.Listar();
                    GvClientes.DataBind();
                }
            }
            else
            {
                Response.Redirect("AdminClientes.aspx");
            }
        }

        protected void GvClientes_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            
        }

        /*public void DataDetalleCliente()
        {
            string VL_DATA_CLIENTE;
            ClienteCN clienteCN = new ClienteCN();
            VL_DATA_CLIENTE = clienteCN.(codCliente);
            Response.Write(VL_DATA_CLIENTE);
            Response.End();
        }*/
    }
}