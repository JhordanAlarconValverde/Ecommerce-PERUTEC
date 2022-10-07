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
    public partial class AdminEmpleadosRepartidor : System.Web.UI.Page
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
            dt = empleado.ListarEmpleadosRepartidores();
            GvEmpleadoRepartidor.DataSource = dt;
            GvEmpleadoRepartidor.DataBind();

            /*foreach (GridViewRow gvr in GvEmpleadoRepartidor.Rows)
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
                Response.Redirect("AdminEmpleadosRepartidor.aspx?registro=success");
            }
            else if (btnRegistrar.Text == "Actualizar")
            {
                empleadoCN.Actualizar(empleadoCE);
                Response.Redirect("AdminEmpleadosRepartidor.aspx?actualizar=success");
            }
        }

        //protected void GvEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string ddlcargo = HttpUtility.HtmlDecode(GvEmpleadoRepartidor.SelectedRow.Cells[9].Text);
        //    btnRegistrar.Text = "Actualizar";
        //    panelRegistro.Visible = true;
        //    txtcodEmpleado.ReadOnly = true;
        //    txtcodEmpleado.Text = GvEmpleadoRepartidor.SelectedRow.Cells[2].Text;
        //    txtNomEmpleado.Text = HttpUtility.HtmlDecode(GvEmpleadoRepartidor.SelectedRow.Cells[3].Text);
        //    txtApeEmpleado.Text = HttpUtility.HtmlDecode(GvEmpleadoRepartidor.SelectedRow.Cells[4].Text);
        //    txtCorreo.Text = GvEmpleadoRepartidor.SelectedRow.Cells[5].Text;
        //    txtDNI.Text = GvEmpleadoRepartidor.SelectedRow.Cells[6].Text;
        //    txtCelular.Text = GvEmpleadoRepartidor.SelectedRow.Cells[7].Text;
        //    txtFecNacimiento.Text = Convert.ToDateTime(GvEmpleadoRepartidor.SelectedRow.Cells[8].Text).ToString("yyyy-MM-dd");

        //    if (ddlcargo == "Administrador")
        //    {
        //        ddlCargo.SelectedIndex = 1;
        //    }
        //    if (ddlcargo == "Vendedor")
        //    {
        //        ddlCargo.SelectedIndex = 2;
        //    }
        //    if (ddlcargo == "Repartidor")
        //    {
        //        ddlCargo.SelectedIndex = 3;
        //    }
        //}

        protected void btnBuscarByNombre_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();

            if (txtBuscarByNombre.Text.Length == 0)
            {
                Response.Redirect("AdminEmpleadosRepartidor.aspx");
            }
            else
            {
                string nombre = txtBuscarByNombre.Text;
                DataTable dt = empleadoCN.BuscarEmpleadoReByNombre(nombre);

                if (dt.Rows.Count >= 1)
                {
                    GvEmpleadoRepartidor.DataSource = dt;
                    GvEmpleadoRepartidor.DataBind();
                }
                else
                {
                    GvEmpleadoRepartidor.DataSource = empleadoCN.ListarEmpleadosRepartidores();
                    GvEmpleadoRepartidor.DataBind();
                }
            }
        }

        protected void btnBuscarByApellido_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();

            if (txtBuscarByApellido.Text.Length == 0)
            {
                Response.Redirect("AdminEmpleadosRepartidor.aspx");
            }
            else
            {
                string apellido = txtBuscarByApellido.Text;
                DataTable dt = empleadoCN.BuscarEmpleadoReByApellido(apellido);

                if (dt.Rows.Count >= 1)
                {
                    GvEmpleadoRepartidor.DataSource = dt;
                    GvEmpleadoRepartidor.DataBind();
                }
                else
                {
                    GvEmpleadoRepartidor.DataSource = empleadoCN.ListarEmpleadosRepartidores();
                    GvEmpleadoRepartidor.DataBind();
                }
            }
        }

        protected void GvEmpleado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();
            panelRegistro.Visible = true;
            txtcodEmpleado.Text = GvEmpleadoRepartidor.SelectedRow.Cells[2].Text;
            //int id = Convert.ToInt32(txtcodEmpleado.Text);
            /*
            string proceso = empleadoCN.Eliminar(id);

            if (proceso == "Se ha eliminado el registro correctamente")
            {
                Response.Redirect("AdminEmpleadosRepartidor.aspx?eliminar=success");
            }
            else
            {
                Response.Redirect("login.aspx");
            }*/
        }

        protected void GvEmpleadoRepartidor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ddlcargo = HttpUtility.HtmlDecode(GvEmpleadoRepartidor.SelectedRow.Cells[9].Text);
            btnRegistrar.Text = "Actualizar";
            panelRegistro.Visible = true;
            txtcodEmpleado.ReadOnly = true;
            txtcodEmpleado.Text = GvEmpleadoRepartidor.SelectedRow.Cells[2].Text;
            txtNomEmpleado.Text = HttpUtility.HtmlDecode(GvEmpleadoRepartidor.SelectedRow.Cells[3].Text);
            txtApeEmpleado.Text = HttpUtility.HtmlDecode(GvEmpleadoRepartidor.SelectedRow.Cells[4].Text);
            txtCorreo.Text = GvEmpleadoRepartidor.SelectedRow.Cells[5].Text;
            txtDNI.Text = GvEmpleadoRepartidor.SelectedRow.Cells[6].Text;
            txtCelular.Text = GvEmpleadoRepartidor.SelectedRow.Cells[7].Text;
            txtFecNacimiento.Text = Convert.ToDateTime(GvEmpleadoRepartidor.SelectedRow.Cells[8].Text).ToString("yyyy-MM-dd");

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

        private void EliminarItem(int codEliminar)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();
            int nfilas = empleadoCN.Eliminar(codEliminar);

            if (nfilas >= 1)
            {
                Response.Redirect("AdminEmpleadosRepartidor.aspx?eliminar=success");
            }
            else
            {
                Response.Redirect("AdminEmpleadosRepartidor.aspx");
            }
        }
        protected void GvEmpleadoRepartidor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
        }

        /*protected void btnNuevoEmpleado_Click1(object sender, EventArgs e)
        {
            panelRegistro.Visible = true;
        }*/

        /*protected void btnBuscarByNombre_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();
            string nombre = txtBuscarByNombre.Text;
            DataTable dt = empleadoCN.buscarEmpleadoPorNombre(nombre);
            GvEmpleado.DataSource = dt;
            GvEmpleado.DataBind();
        }

        protected void btnBuscarByApellido_Click(object sender, EventArgs e)
        {
            EmpleadoCN empleadoCN = new EmpleadoCN();
            string apellido = txtBuscarByApellido.Text;
            DataTable dt = empleadoCN.buscarEmpleadoPorApellidos(apellido);
            GvEmpleado.DataSource = dt;
            GvEmpleado.DataBind();
        }*/
    }
}