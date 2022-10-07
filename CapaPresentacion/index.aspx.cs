using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// LIBRERIAS
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // SI NO SE PUBLICO ENTONCES MOSTRAR
            if (!IsPostBack)
            {
                mostrarUltimosProductos();

                if(Request.QueryString["status"] == "logout")
                {
                    Session.Remove("codCliente");
                    Session.Remove("nombre");
                    Session.Remove("apellido");
                    Session.Remove("correo");
                    Session.Remove("dni");
                    Session.Remove("celular");
                    Session.Remove("fecNacimiento");
                    /********************/
                    Session.Remove("carrito");


                    Session.Remove("codCarrito");
                    //Session["codCliente"] = null;
                    //Session["nombre"] = null;
                    //Session["apellido"] = null;
                    //Session["correo"] = null;
                    //Session["dni"] = null;
                    //Session["celular"] = null;
                    //Session["fecNacimiento"] = null;
                    ///********************/
                    //Session["carrito"] = null;


                    //Session["codCarrito"] = null;
                    /********************/
                    /*CarritosCN carritosCN = new CarritosCN();
                    CarritosCE carritosCE = new CarritosCE();
                    carritosCE.CodCliente =(int) Session["codCliente"];
                    carritosCE.FechaGuardado = DateTime.Now;
                    carritosCE.MontoTotal = Convert.ToDouble(Session["MontoTotal"]);
                    carritosCE.Estado = false;

                    int codCarritos = carritosCN.Insertar(carritosCE);


                    ProductoCE productoCE;
                    DetalleCarritosCN detalleCarritosCN = new DetalleCarritosCN();
                    List<DetalleCarritosCE> listaDetalleCarrito = (List<DetalleCarritosCE>)Session["Carrito"];
                    DetalleCarritosCE detalleCarritosCE;
                    for(int i = 0; i < listaDetalleCarrito.Count; i++)
                    {
                        productoCE = new ProductoCE();
                        //productoCE.CodProducto = listaDetalleCarrito[i].ProductoCE.CodProducto;
                        detalleCarritosCE = new DetalleCarritosCE();
                        detalleCarritosCE.CodCarritos = codCarritos;
                        detalleCarritosCE.Cantidad = listaDetalleCarrito[i].Cantidad;
                        //detalleCarritosCE.ProductoCE.CodProducto = productoCE.CodProducto;
                        detalleCarritosCE.ProductoCE = productoCE;
                        detalleCarritosCE.ProductoCE.CodProducto = listaDetalleCarrito[i].ProductoCE.CodProducto;
                        detalleCarritosCE.Subtotal = listaDetalleCarrito[i].Subtotal;
                        detalleCarritosCN.Insertar(detalleCarritosCE);
                    }

                    Session["codCliente"] = null;
                    Session["nombre"] = null;
                    Session["apellido"] = null;
                    Session["correo"] = null;
                    Session["dni"] = null;
                    Session["celular"] = null;
                    Session["fecNacimiento"] = null;
                    Session["Carrito"] = null;*/
                }
                else if (Request.QueryString["compra"] == "success")
                {
                    Session["Carrito"] = null;
                }
            }
        }

        protected void mostrarUltimosProductos()
        {
            ProductoCN productoCN = new ProductoCN();
            DlUltimosProductos.DataSource = productoCN.ListarUltimosProductos();
            DlUltimosProductos.DataBind();
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView dr = (DataRowView)e.Row.DataItem;
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["imgReferencial"]);
                (e.Row.FindControl("imgProducto") as Image).ImageUrl = imageUrl; 
            }
        }
    }
}