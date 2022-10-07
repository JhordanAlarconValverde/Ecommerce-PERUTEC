using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class ProcesarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarMetodosPago();
            lblMontoTotal.Text = Session["MontoTotalPago"].ToString();
        }

        private void ListarMetodosPago()
        {
            MetodoPagoCN metodoPagoCN = new MetodoPagoCN();
            ddlMetodosPago.DataSource = metodoPagoCN.ListarMetodosDePago();
            ddlMetodosPago.DataValueField = "codMetodoPago";
            ddlMetodosPago.DataTextField = "nomMetodoPago";
            ddlMetodosPago.DataBind();
        }

        protected void btnRealizarPago_Click(object sender, EventArgs e)
        {
            List<DetalleCarritosCE> listaCarrito = (List<DetalleCarritosCE>) Session["Carrito"];
            
            PedidoCN pedidoCN = new PedidoCN();
            PedidoCE pedidoCE = new PedidoCE();
            pedidoCE.CodCliente = Convert.ToInt32(Session["codCliente"]);
            pedidoCE.CodMetodoPago = Convert.ToInt32(ddlMetodosPago.SelectedValue);
            pedidoCE.CodEstado = 2;
            pedidoCE.FecPedido = DateTime.Now;
            pedidoCE.MontoTotal = Convert.ToDouble(Session["MontoTotalPago"]);
            pedidoCE.TiempoEntrega = 1;
            pedidoCE.FecPago = DateTime.Now;
            pedidoCE.FecEntrega = DateTime.Now;
            int codPedido = pedidoCN.Insertar(pedidoCE);

            DetallePedidoCN detallePedidoCN = new DetallePedidoCN();
            for (int i = 0; i < listaCarrito.Count; i++)
            {
                DetallePedidoCE detallePedidoCE = new DetallePedidoCE();
                detallePedidoCE.CodProducto = listaCarrito[i].ProductoCE.CodProducto;
                detallePedidoCE.CodPedido = codPedido;
                detallePedidoCE.CantidadProducto = listaCarrito[i].CantidadProducto;
                detallePedidoCE.Subtotal = listaCarrito[i].Subtotal;
                detallePedidoCN.Insertar(detallePedidoCE);
            }

            List<DetalleCarritosCE> Carrito = new List<DetalleCarritosCE>();
            Carrito = (List<DetalleCarritosCE>)Session["Carrito"];
            CarritosCN carritoCN = new CarritosCN();
            CarritosCE carritoCE = new CarritosCE();

            double total = 0;
            if (codPedido > 0)
            {
                carritoCE = new CarritosCE();
                carritoCE.CodCarritos = Convert.ToInt32(Session["codCarrito"]);
                carritoCE.CodCliente = Convert.ToInt32(Session["codCliente"]);
                carritoCE.FechaGuardado = DateTime.Today;
                carritoCE.Estado = true;

                foreach (DetalleCarritosCE detalle in Carrito)
                {
                    total += detalle.Subtotal;
                }
                carritoCE.MontoTotal = total;
                carritoCN.Actualizar(carritoCE);
                Response.Redirect("index.aspx?compra=success");
            }
            else
            {
                Response.Redirect("ProcesarCompra.aspx?compra=failed");
            }
             //detallePedidoCE;
            //DetallePedidoCN detallePedidoCN = new DetallePedidoCN();
            
            //int nfilas;

            /*for (int i = 0; i < ListaCarrito.Count; i++)
            {
                DetallePedidoCE detallePedidoCE = new DetallePedidoCE();
                detallePedidoCE.CodProducto = ListaCarrito[i].ProductoCE.CodProducto;
                detallePedidoCE.CodPedido = CodPedido;
                detallePedidoCE.CantidadProducto = ListaCarrito[i].CantidadProducto;
                detallePedidoCE.Subtotal = ListaCarrito[i].Subtotal;
                
                detallePedidoCN.Insertar(detallePedidoCE);

            }
            
            if (CodPedido > 0)
            {
                Response.Redirect("ProcesarCompra.aspx?compra=success");
            }
            else
            {
                Response.Redirect("ProcesarCompra.aspx?compra=failed");
            }*/



            /*if (!string.IsNullOrEmpty(rpta))
            {
                //Reportes.PDFBoletaCompra.Generar();
                //System.IO.File.WriteAllBytes(@"C:\testpdf.pdf", Reportes.PDFBoletaCompra.Generar());
                //System.IO.File.WriteAllBytes();
                //System.IO.File.WriteAllBytes("hello.pdf", Reportes.PDFBoletaCompra.Generar());
                Response.Redirect("index.aspx?compra=success");
            }
            else
            {
                Response.Redirect("ProcesarCompra.aspx?compra=failed");
            }*/
        }
    }
}