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
    public partial class AdminEmpleadosVendedor : System.Web.UI.Page
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
                    ListarEmpleado();
                    EmpleadoCN obj = new EmpleadoCN();
                    ddlCargo.DataSource = obj.ListarCargoEmpleado();
                    ddlCargo.DataTextField = "nomCargo";
                    ddlCargo.DataValueField = "codCargo";
                    ddlCargo.DataBind();
                    ddlCargo.Items.Insert(0, "Seleccionar Cargo");
                    panelRegistro.Visible = false;
                    /*CategoriaProductosCN categoriasPanel = new CategoriaProductosCN();
                    ddlRegProducto.DataSource = categoriasPanel.ListarCategorias();
                    ddlRegProducto.DataTextField = "nomCategoria";
                    ddlRegProducto.DataValueField = "codCategoria";
                    ddlRegProducto.DataBind();
                    ddlRegProducto.Items.Insert(0, "Seleccionar Categoría");*/
                }
            }
        }

        public void ListarEmpleado()
        {
            DataTable dt;
            EmpleadoCN empleado = new EmpleadoCN();
            dt = empleado.ListarEmpleadosVendedores();
            GvEmpleadoVendedor.DataSource = dt;
            GvEmpleadoVendedor.DataBind();

            /*foreach (GridViewRow gvr in GvEmpleadoVendedor.Rows)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    gvr.Cells[8].Text = Convert.ToDateTime(dr[6]).ToString("dd/MM/yyyy");
                }
            }*/
        }

        protected void btnNuevoEmpleado_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = true;
            btnRegistrar.Text = "Registrar";
            txtcodEmpleado.ReadOnly = true;
            txtcodEmpleado.Text = string.Empty;
            txtNomEmpleado.Text = string.Empty;
            txtApeEmpleado.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtCelular.Text = string.Empty;
            ddlCargo.SelectedIndex = 0;
            txtFecNacimiento.Text = DateTime.Today.ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            EmpleadoCE empleadoCE = new EmpleadoCE();
            EmpleadoCN empleadoCN = new EmpleadoCN();

            if (string.IsNullOrEmpty(txtcodEmpleado.Text))
            {
                empleadoCE.CodEmpleado = 0;
            }
            else
            {
                empleadoCE.CodEmpleado = Convert.ToInt32(txtcodEmpleado.Text);
            }
            empleadoCE.Nombre = txtNomEmpleado.Text;
            empleadoCE.Apellido = txtApeEmpleado.Text;
            empleadoCE.Celular = txtCelular.Text;
            empleadoCE.Dni = txtDNI.Text;
            empleadoCE.Correo = txtCorreo.Text;
            empleadoCE.Clave = txtClave.Text;
            empleadoCE.FecNacimiento = Convert.ToDateTime(txtFecNacimiento.Text);
            empleadoCE.CodCargo = ddlCargo.SelectedIndex;

            if (btnRegistrar.Text == "Registrar")
            {
                empleadoCN.Insertar(empleadoCE);
                Response.Redirect("AdminEmpleadosVendedor.aspx?registro=success");
            }
            else if (btnRegistrar.Text == "Actualizar")
            {
                empleadoCN.Actualizar(empleadoCE);
                Response.Redirect("AdminEmpleadosVendedor.aspx?actualizar=success");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            txtcodEmpleado.ReadOnly = true;
            txtNomEmpleado.Text = string.Empty;
            txtApeEmpleado.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtCelular.Text = string.Empty;
            ddlCargo.SelectedIndex = 0;
            txtFecNacimiento.Text = DateTime.Today.ToString();
        }

        protected void btnBuscarByNombre_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();

            if (txtBuscarByNombre.Text.Length == 0)
            {
                Response.Redirect("AdminEmpleadosVendedor.aspx");
            }
            else
            {
                string nombre = txtBuscarByNombre.Text;
                DataTable dt = empleadoCN.BuscarEmpleadoVenByNombre(nombre);

                if (dt.Rows.Count >= 1)
                {
                    GvEmpleadoVendedor.DataSource = dt;
                    GvEmpleadoVendedor.DataBind();
                }
                else
                {
                    GvEmpleadoVendedor.DataSource = empleadoCN.ListarEmpleadosVendedores();
                    GvEmpleadoVendedor.DataBind();
                }
            }
        }

        protected void btnBuscarByApellido_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();

            if (txtBuscarByApellido.Text.Length == 0)
            {
                Response.Redirect("AdminEmpleadosVendedor.aspx");
            }
            else
            {
                string apellido = txtBuscarByApellido.Text;
                DataTable dt = empleadoCN.BuscarEmpleadoVenByApellido(apellido);

                if (dt.Rows.Count >= 1)
                {
                    GvEmpleadoVendedor.DataSource = dt;
                    GvEmpleadoVendedor.DataBind();
                }
                else
                {
                    GvEmpleadoVendedor.DataSource = empleadoCN.ListarEmpleadosVendedores();
                    GvEmpleadoVendedor.DataBind();
                }
            }
        }

        protected void GvEmpleadoVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ddlcargo = HttpUtility.HtmlDecode(GvEmpleadoVendedor.SelectedRow.Cells[9].Text);
            btnRegistrar.Text = "Actualizar";
            panelRegistro.Visible = true;
            txtcodEmpleado.ReadOnly = true;
            txtcodEmpleado.Text = GvEmpleadoVendedor.SelectedRow.Cells[2].Text;
            txtNomEmpleado.Text = HttpUtility.HtmlDecode(GvEmpleadoVendedor.SelectedRow.Cells[3].Text);
            txtApeEmpleado.Text = HttpUtility.HtmlDecode(GvEmpleadoVendedor.SelectedRow.Cells[4].Text);
            txtCorreo.Text = GvEmpleadoVendedor.SelectedRow.Cells[5].Text;
            txtDNI.Text = GvEmpleadoVendedor.SelectedRow.Cells[6].Text;
            txtCelular.Text = GvEmpleadoVendedor.SelectedRow.Cells[7].Text;
            txtFecNacimiento.Text = Convert.ToDateTime(GvEmpleadoVendedor.SelectedRow.Cells[8].Text).ToString("yyyy-MM-dd");

            if (ddlcargo == "Administrador")
            {
                ddlCargo.SelectedIndex = 1;
            }
            if (ddlcargo == "Vendedor")
            {
                ddlCargo.SelectedIndex = 2;
            }
            if (ddlcargo == "Repartidor")
            {
                ddlCargo.SelectedIndex = 3;
            }
        }
    }
}