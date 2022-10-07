using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Web.Services;
using System.Web.Script.Services;

namespace CapaPresentacion.Administrador
{
    public partial class AdminProdDisponibles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (Request.Headers["xhr"] != null)
            {
                string metodo = Request.Headers["xhr"].ToString();
                GetType().GetMethod(metodo).Invoke(this,null);
            }*/


            if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    ListarProductos();
                    CategoriaProductosCN categorias = new CategoriaProductosCN();
                    ddlCategoria.DataSource = categorias.ListarCategoria();
                    ddlCategoria.DataTextField = "nomCategoria";
                    ddlCategoria.DataValueField = "codCategoria";
                    ddlCategoria.DataBind();
                    ddlCategoria.Items.Insert(0, "Seleccionar Categoría");

                    CategoriaProductosCN categoriasPanel = new CategoriaProductosCN();
                    ddlRegProducto.DataSource = categoriasPanel.ListarCategoria();
                    ddlRegProducto.DataTextField = "nomCategoria";
                    ddlRegProducto.DataValueField = "codCategoria";
                    ddlRegProducto.DataBind();
                    ddlRegProducto.Items.Insert(0, "Seleccionar Categoría");

                    panelRegistro.Visible = false;
                }
            }
        }

        public void ListarProductos()
        {
            ProductoCN obj = new ProductoCN();
            GvProdDisponibles.DataSource = obj.Listar();
            GvProdDisponibles.DataBind();
        }

        protected void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = true;
            btnRegistrar.Text = "Registrar";
            txtCodProducto.ReadOnly= true;
            txtCodProducto.Text = string.Empty;
            txtNomProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlRegProducto.SelectedIndex = 0;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        public void WriteExcelWithNPOI(DataTable dt, String extension)
        {

            NPOI.SS.UserModel.IWorkbook workbook;

            if (extension == "xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (extension == "xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                throw new Exception("This format is not supported");
            }

            ISheet sheet1 = workbook.CreateSheet("Sheet 1");

            //make a header row
            IRow row1 = sheet1.CreateRow(0);

            for (int j = 0; j < dt.Columns.Count; j++)
            {

                ICell cell = row1.CreateCell(j);
                String columnName = dt.Columns[j].ToString();
                cell.SetCellValue(columnName);
            }

            //loops through data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row = sheet1.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {

                    ICell cell = row.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                }
            }

            using (var exportData = new MemoryStream())
            {
                Response.Clear();
                workbook.Write(exportData);
                if (extension == "xlsx") //xlsx file format
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "Productos disponibles.xlsx"));
                    Response.BinaryWrite(exportData.ToArray());
                }
                else if (extension == "xls")  //xls file format
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "Productos disponibles.xls"));
                    Response.BinaryWrite(exportData.GetBuffer());
                }
                Response.End();
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            ProductoCN obj = new ProductoCN();
            dt = obj.Listar();
            WriteExcelWithNPOI(dt, "xls");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            panelRegistro.Visible = false;
            txtCodProducto.Text = string.Empty;
            txtNomProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlRegProducto.SelectedIndex = 0;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        protected void GvProdDisponibles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idProducto = Convert.ToInt16(GvProdDisponibles.Rows[e.RowIndex].Cells[2].Text);
            ProductoCN producto = new ProductoCN();
            producto.Eliminar(idProducto);
            Response.Redirect("AdminProdDisponibles.aspx?eliminar=success");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ProductoCN productoCN = new ProductoCN();
            ProductoCE productoCE = new ProductoCE();

            if (string.IsNullOrEmpty(txtCodProducto.Text))
            {
                productoCE.CodProducto = 0;
            }
            else
            {
                productoCE.CodProducto = Convert.ToInt32(txtCodProducto.Text);
            }

            productoCE.Nombre = txtNomProducto.Text;
            productoCE.CodCategoria = ddlRegProducto.SelectedIndex;
            productoCE.Descripcion = txtDescripcion.Text;
            productoCE.Stock = Convert.ToInt32(txtStock.Text);
            productoCE.Precio = Convert.ToDouble(txtPrecio.Text);

            using (BinaryReader br = new BinaryReader(imgProducto.PostedFile.InputStream))
            {
                productoCE.ImgReferencial = br.ReadBytes(imgProducto.PostedFile.ContentLength);
            }

            if (btnRegistrar.Text == "Registrar")
            {
                productoCN.Insertar(productoCE);
                Response.Redirect("AdminProdDisponibles.aspx?registro=success");
            }
            else if (btnRegistrar.Text == "Actualizar")
            {
                productoCN.Actualizar(productoCE);
                Response.Redirect("AdminProdDisponibles.aspx?actualizar=success");
            }
            /*MostrarProductos();
            panelRegistro.Visible = false;
            txtCodProducto.Text = string.Empty;
            txtNomProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlRegProducto.SelectedIndex = 0;
            txtPrecio.Text = string.Empty;
            txtStock.Text = string.Empty;*/

        } 

        //protected string testVarialbe = "Hello World";
        protected void btnPDF_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Reportes/ReporteProductosDisponibles.aspx");
        }

        protected void btnBuscarByProducto_Click(object sender, EventArgs e)
        {
            string txtNomProducto = txtProducto.Text;
            if (string.IsNullOrEmpty(txtNomProducto))
            {
                ListarProductos();
            }
            else
            {
                ProductoCN productoCN = new ProductoCN();
                GvProdDisponibles.DataSource = productoCN.BuscarProductoByNombre(txtNomProducto);
                GvProdDisponibles.DataBind();
            }
        }

        protected void btnBuscarByCategoria_Click(object sender, EventArgs e)
        {
            int categoria = ddlCategoria.SelectedIndex;
            if (categoria == null || categoria <= 0 )
            {
                ListarProductos();
            }
            else
            {
                ProductoCN productoCN = new ProductoCN();
                GvProdDisponibles.DataSource = productoCN.BuscarProductoByCategoria(categoria);
                GvProdDisponibles.DataBind();
            }
        }

        protected void GvProdDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*string ddlCategoria = HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[5].Text);
            btnRegistrar.Text = "Actualizar";
            panelRegistro.Visible = true;
            txtCodProducto.ReadOnly = true;
            txtCodProducto.Text = GvProdDisponibles.SelectedRow.Cells[2].Text;
            txtNomProducto.Text = HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[3].Text);
            txtDescripcion.Text = HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[4].Text);
            //ddlRegProducto.SelectedItem.Text= HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[5].Text);
            if (ddlCategoria == "LAPTOPS")
            {
                ddlRegProducto.SelectedIndex = 1;
            }
            else if (ddlCategoria == "COMPUTADORAS")
            {
                ddlRegProducto.SelectedIndex = 2;
            }
            else if (ddlCategoria == "SMARTPHONES")
            {
                ddlRegProducto.SelectedIndex = 3;
            }
            else if (ddlCategoria == "TABLETS")
            {
                ddlRegProducto.SelectedIndex = 4;
            }
            else
            {
                ddlRegProducto.SelectedIndex = 0;
            }
            txtStock.Text = GvProdDisponibles.SelectedRow.Cells[6].Text;
            txtPrecio.Text = GvProdDisponibles.SelectedRow.Cells[7].Text;*/

            string ddlCategoria = HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[6].Text);
            btnRegistrar.Text = "Actualizar";
            panelRegistro.Visible = true;
            txtCodProducto.ReadOnly = true;
            txtCodProducto.Text = GvProdDisponibles.SelectedRow.Cells[3].Text;
            txtNomProducto.Text = HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[4].Text);
            txtDescripcion.Text = HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[5].Text);
            //ddlRegProducto.SelectedItem.Text= HttpUtility.HtmlDecode(GvProdDisponibles.SelectedRow.Cells[5].Text);
            if (ddlCategoria == "LAPTOPS")
            {
                ddlRegProducto.SelectedIndex = 1;
            }
            else if (ddlCategoria == "COMPUTADORAS")
            {
                ddlRegProducto.SelectedIndex = 2;
            }
            else if (ddlCategoria == "SMARTPHONES")
            {
                ddlRegProducto.SelectedIndex = 3;
            }
            else if (ddlCategoria == "TABLETS")
            {
                ddlRegProducto.SelectedIndex = 4;
            }
            else
            {
                ddlRegProducto.SelectedIndex = 0;
            }
            txtStock.Text = GvProdDisponibles.SelectedRow.Cells[7].Text;
            txtPrecio.Text = GvProdDisponibles.SelectedRow.Cells[8].Text;
        }

        protected void GvProdDisponibles_RowDeleting(object sender, GridViewSelectEventArgs e)
        {

        }

        /*protected void OnSelectedIndexChanged(object sender, GridViewEventArgs e)
        { 
            ScriptManager.RegisterStartupScript
        }
        */

        /*public void PruebaRetornoCadena() {
            string rpta = "Esto es una prueba";
            Response.Write(rpta);
            Response.End();
        }

        public void PruebaPost(string data)
        {
            string cadena = "Concatenar "+ data;

            if(Request.InputStream != null && Request.InputStream.Length > 0)
            {
                Stream Flujo = Request.InputStream;
                double N = Request.InputStream.Length;
                Byte[N] Buffer = Request.InputStream.Read(Buffer,0,N);
            }
            Response.Write(cadena);
            Response.End();
        }*/
    }
}