using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidad;
using CapaNegocios;
using System.Data;
namespace CapaPresentacion.Administrador
{
    public partial class AdminClientes : System.Web.UI.Page
    {
        /*public string codDepartamento { get; set; }
        public string codProvincia { get; set; }
        public int codCliente{ get; set; }*/

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarClientes();
                UbigeoCN ubigeoCN = new UbigeoCN();
                ddlBuscarByDepartamento.DataSource = ubigeoCN.ListarDepartamentos();
                ddlBuscarByDepartamento.DataTextField = "nomDepartamento";
                ddlBuscarByDepartamento.DataValueField = "codDepartamento";
                ddlBuscarByDepartamento.DataBind();
                ddlBuscarByDepartamento.Items.Insert(0, "Seleccionar Departamento");
                /*
                ddlBuscarByProvincia.DataSource = ubigeoCN.ListarProvincias();
                ddlBuscarByProvincia.DataTextField = "nomProvincia";
                ddlBuscarByProvincia.DataValueField = "codProvincia";
                ddlBuscarByProvincia.DataBind();
                ddlBuscarByProvincia.Items.Insert(0, "Seleccionar Provincia");*/
            }
            /*codDepartamento = ddlBuscarByDepartamento.SelectedValue.ToString();
            UbigeoCN ubigeoCN1 = new UbigeoCN();
            ddlBuscarByProvincia.DataSource = ubigeoCN1.ListarProvincias(codDepartamento);
            ddlBuscarByProvincia.DataTextField = "nomDepartamento";
            ddlBuscarByProvincia.DataValueField = "codDepartamento";
            ddlBuscarByProvincia.DataBind();
            ddlBuscarByProvincia.Items.Insert(0, "Seleccionar Departamento");*/

        }
        private void ListarClientes()
        {
            DataTable dt;
            ClienteCN clienteCN = new ClienteCN();
            dt = clienteCN.Listar();
            foreach(DataRow gvr in dt.Rows)
            {
                //gvr[7] = Convert.ToDateTime(gvr[7]).Year;
            }

            GvClientes.DataSource = dt;
            GvClientes.DataBind();
        }

        /*protected void btnBuscarByDepartamento_Click(object sender, EventArgs e)
        {
            string codDepartamento = ddlBuscarByDepartamento.SelectedItem.Text;
            ClienteCN clienteCN = new ClienteCN();
            GvClientes.DataSource = clienteCN.BuscarByDepartamento(codDepartamento);
            GvClientes.DataBind();
        }*/

        protected void btnBuscarByProvincia_Click(object sender, EventArgs e)
        {
            /*string codProvincia = ddlBuscarByProvincia.SelectedItem.Text;
            ClienteCN clienteCN = new ClienteCN();
            GvClientes.DataSource = clienteCN.BuscarByProvincia(codProvincia);
            GvClientes.DataBind();*/
        }

        /*public void DataDetalleCliente()
        {
            string VL_DATA_CLIENTE;
            ClienteCN clienteCN = new ClienteCN();
            VL_DATA_CLIENTE = clienteCN.DetalleCliente(codCliente);
            Response.Write(VL_DATA_CLIENTE);
            Response.End();
        }*/


        protected void GvProdDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int codCliente = Convert.ToInt32(GvClientes.SelectedRow.Cells[2].Text);
        }
    }
}