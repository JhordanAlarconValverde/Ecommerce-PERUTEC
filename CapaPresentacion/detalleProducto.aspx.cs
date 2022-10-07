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
    public partial class detalleProducto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerDetalle();
                txtCantidad.Text = "1";
            }
        }

        public void ObtenerDetalle()
        {
            ProductoCN productoCN = new ProductoCN();
            int codProducto = Convert.ToInt32(Request.QueryString["cod"]);
            DataTable tb = new DataTable();
            tb = productoCN.DetalleProducto(codProducto);
            //string[] data;
            foreach (DataRow dr in tb.Rows)
            {
                string imageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dr["imgReferencial"]);
                imgProducto.ImageUrl = imageUrl;
                lblNombreProducto.Text = dr["nombre"].ToString();
                lblCategoria.Text = dr["nomCategoria"].ToString();
                lblDescripcion.Text = dr["descripcion"].ToString();
                lblPrecio.Text = dr["precio"].ToString();
                //lblStock.Text = dr["stock"].ToString();
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx?status=required");
            }
            else
            {
                CarritosCN carritoCN = new CarritosCN();
                CarritosCE carritoCE;

                string nombreProducto = lblNombreProducto.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                double precio = Convert.ToDouble(lblPrecio.Text);

                List<DetalleCarritosCE> Carrito = new List<DetalleCarritosCE>();
                Carrito = (List<DetalleCarritosCE>)Session["Carrito"];
                //DetalleCarritosCE detalleCarritosCE = new DetalleCarritosCE();
                DetalleCarritosCE detalleCarritosCE;
                DetalleCarritosCN detalleCarritosCN = new DetalleCarritosCN();
                ProductoCE productoCE;

                List<CarritosCE> añadirCarrito = new List<CarritosCE>();
                añadirCarrito = (List<CarritosCE>)Session["añadirCarrito"];
                if (Carrito == null)
                {
                    carritoCE = new CarritosCE();
                    carritoCE.CodCliente = Convert.ToInt32(Session["codCliente"]);
                    carritoCE.FechaGuardado = DateTime.Today;
                    carritoCE.MontoTotal = 0;
                    carritoCE.Estado = false;
                    Session["codCarrito"] = carritoCN.Insertar(carritoCE);

                    productoCE = new ProductoCE();
                    Carrito = new List<DetalleCarritosCE>();
                    detalleCarritosCE = new DetalleCarritosCE();
                    //Carrito = new List<DetalleCarritosCE>();
                    productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                    productoCE.Nombre = nombreProducto;
                    productoCE.Precio = precio;
                    detalleCarritosCE.CodCarritos = Convert.ToInt32(Session["codCarrito"]);
                    detalleCarritosCE.CantidadProducto = cantidad;
                    detalleCarritosCE.ProductoCE = productoCE;
                    //producto.ProductoCE.ImgReferencial = imgReferencial;
                    detalleCarritosCE.Subtotal = cantidad * precio;
                    Carrito.Add(detalleCarritosCE);
                    Session["Carrito"] = Carrito;
                    detalleCarritosCN.Insertar(detalleCarritosCE);
                }
                else
                {
                    productoCE = new ProductoCE();
                    detalleCarritosCE = new DetalleCarritosCE();
                    productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                    productoCE.Nombre = nombreProducto;
                    productoCE.Precio = precio;
                    detalleCarritosCE.CodCarritos = Convert.ToInt32(Session["codCarrito"]);
                    detalleCarritosCE.CantidadProducto = cantidad;
                    detalleCarritosCE.ProductoCE = productoCE;
                    //producto.ProductoCE.ImgReferencial = imgReferencial;
                    detalleCarritosCE.Subtotal = cantidad * precio;
                    Carrito.Add(detalleCarritosCE);
                    Session["Carrito"] = Carrito;
                    detalleCarritosCN.Insertar(detalleCarritosCE);
                }

            
            /***************************************************************/
            /*if (Session["nombre"] == null)
            {
                Response.Redirect("login.aspx?status=required");
            }
            else
            {
                CarritosCN carritoCN = new CarritosCN();
                CarritosCE carritoCE;

                string nombreProducto = lblNombreProducto.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                double precio = Convert.ToDouble(lblPrecio.Text);

                List<DetalleCarritosCE> Carrito = new List<DetalleCarritosCE>();
                Carrito = (List<DetalleCarritosCE>)Session["Carrito"];
                //DetalleCarritosCE detalleCarritosCE = new DetalleCarritosCE();
                DetalleCarritosCE detalleCarritosCE;
                DetalleCarritosCN detalleCarritosCN = new DetalleCarritosCN();
                ProductoCE productoCE;

                if (Carrito == null)
                {
                    carritoCE = new CarritosCE();
                    carritoCE.CodCliente = Convert.ToInt32(Session["codCliente"]);
                    carritoCE.FechaGuardado = DateTime.Today;
                    carritoCE.MontoTotal = 0;
                    carritoCE.Estado = false;
                    Session["codCarrito"] = carritoCN.Insertar(carritoCE);

                    productoCE = new ProductoCE();
                    Carrito = new List<DetalleCarritosCE>();
                    detalleCarritosCE = new DetalleCarritosCE();
                    //Carrito = new List<DetalleCarritosCE>();
                    productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                    productoCE.Nombre = nombreProducto;
                    productoCE.Precio = precio;
                    detalleCarritosCE.CodCarritos = Convert.ToInt32(Session["codCarrito"]);
                    detalleCarritosCE.CantidadProducto = cantidad;
                    detalleCarritosCE.ProductoCE = productoCE;
                    //producto.ProductoCE.ImgReferencial = imgReferencial;
                    detalleCarritosCE.Subtotal = cantidad * precio;
                    Carrito.Add(detalleCarritosCE);
                    Session["Carrito"] = Carrito;
                    detalleCarritosCN.Insertar(detalleCarritosCE);
                }
                else
                {
                    productoCE = new ProductoCE();
                    detalleCarritosCE = new DetalleCarritosCE();
                    productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                    productoCE.Nombre = nombreProducto;
                    productoCE.Precio = precio;
                    detalleCarritosCE.CodCarritos = Convert.ToInt32(Session["codCarrito"]);
                    detalleCarritosCE.CantidadProducto = cantidad;
                    detalleCarritosCE.ProductoCE = productoCE;
                    //producto.ProductoCE.ImgReferencial = imgReferencial;
                    detalleCarritosCE.Subtotal = cantidad * precio;
                    Carrito.Add(detalleCarritosCE);
                    Session["Carrito"] = Carrito;
                    detalleCarritosCN.Insertar(detalleCarritosCE);
                }*/
                
                /***************************************************************/



























                /**************************************************************************************/
                /*if (Session["nombre"] == null)
                {
                    Response.Redirect("login.aspx?status=required");
                }
                else
                {
                    string nombreProducto = lblNombreProducto.Text;
                    int cantidad = Convert.ToInt32(txtCantidad.Text);
                    double precio = Convert.ToDouble(lblPrecio.Text);

                    List<DetalleCarritosCE> Carrito = new List<DetalleCarritosCE>();
                    Carrito = (List<DetalleCarritosCE>)Session["Carrito"];
                    DetalleCarritosCE detalleCarritosCE = new DetalleCarritosCE();
                    DetalleCarritosCN detalleCarritosCN = new DetalleCarritosCN();
                    ProductoCE productoCE;

                    if (Carrito == null)
                    {
                        productoCE = new ProductoCE();
                        Carrito = new List<DetalleCarritosCE>();
                        //Carrito = new List<DetalleCarritosCE>();
                        productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                        productoCE.Nombre = nombreProducto;
                        productoCE.Precio = precio;
                        detalleCarritosCE.CantidadProducto = cantidad;
                        detalleCarritosCE.ProductoCE = productoCE;
                        //producto.ProductoCE.ImgReferencial = imgReferencial;
                        detalleCarritosCE.Subtotal = cantidad * precio;
                        Carrito.Add(detalleCarritosCE);
                        Session["Carrito"] = Carrito;
                    }
                    else
                    {
                        productoCE = new ProductoCE();
                        productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                        productoCE.Nombre = nombreProducto;
                        productoCE.Precio = precio;
                        detalleCarritosCE.CantidadProducto = cantidad;
                        detalleCarritosCE.ProductoCE = productoCE;
                        //producto.ProductoCE.ImgReferencial = imgReferencial;
                        detalleCarritosCE.Subtotal = cantidad * precio;
                        Carrito.Add(detalleCarritosCE);
                        Session["Carrito"] = Carrito;
                    }*/



                /**************************************************************************************/
                /*if (idCarrito > 0)
                    {
                        detalleCarritosCE.CodCarritos = idCarrito;
                        detalleCarritosCN.Insertar(detalleCarritosCE);
                    }*/




                //detalleCarritosCE.CodCarritos = idCarrito;
                //detalleCarritosCN.Insertar(detalleCarritosCE);
                /*string nombreProducto = lblNombreProducto.Text;
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                double precio = Convert.ToDouble(lblPrecio.Text);
                string imgReferencial = imgProducto.ImageUrl.ToString();

                List<DetalleCarritosCE> Carrito = new List<DetalleCarritosCE>();
                Carrito = (List<DetalleCarritosCE>)Session["Carrito"];
                DetalleCarritosCE detalleCarritosCE = new DetalleCarritosCE();
                ProductoCE productoCE;


                if (Carrito == null)
                {
                    productoCE = new ProductoCE();
                    Carrito = new List<DetalleCarritosCE>();
                    productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                    productoCE.Nombre = nombreProducto;
                    productoCE.Precio = precio;
                    detalleCarritosCE.CantidadProducto = cantidad;
                    detalleCarritosCE.ProductoCE = productoCE;
                    //producto.ProductoCE.ImgReferencial = imgReferencial;
                    detalleCarritosCE.Subtotal = cantidad * precio;
                    Carrito.Add(detalleCarritosCE);
                    Session["Carrito"] = Carrito;
                }

                else
                {
                    productoCE = new ProductoCE();
                    productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                    productoCE.Nombre = nombreProducto;
                    productoCE.Precio = precio;
                    detalleCarritosCE.CantidadProducto = cantidad;
                    detalleCarritosCE.ProductoCE = productoCE;
                    //producto.ProductoCE.ImgReferencial = imgReferencial;
                    detalleCarritosCE.Subtotal = cantidad * precio;
                    Carrito.Add(detalleCarritosCE);
                    Session["Carrito"] = Carrito;
                    /*for (int i = 0; i < Carrito.Count; i++)
                    {
                        if (Convert.ToInt32(Request.QueryString["cod"]) == Carrito[i].ProductoCE.CodProducto)
                        {
                            Carrito[i].Cantidad += cantidad;
                            Carrito[i].Subtotal += precio * cantidad;
                        }
                        else
                        {
                            productoCE = new ProductoCE();
                            productoCE.CodProducto = Convert.ToInt32(Request.QueryString["cod"]);
                            productoCE.Nombre = nombreProducto;
                            productoCE.Precio = precio;
                            detalleCarritosCE.Cantidad = cantidad;
                            detalleCarritosCE.ProductoCE = productoCE;
                            //producto.ProductoCE.ImgReferencial = imgReferencial;
                            detalleCarritosCE.Subtotal = cantidad * precio;
                            Carrito.Add(detalleCarritosCE);
                            Session["Carrito"] = Carrito;
                        }
                    }*/
                /*}*/
            }
        }
    }
}