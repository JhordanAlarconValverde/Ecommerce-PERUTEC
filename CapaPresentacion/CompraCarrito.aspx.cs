using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;

// LIBRERIAS
using CapaEntidad;
using System.Data;

namespace CapaPresentacion
{
    public partial class CompraCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarCarrito();
                CalcularTotal();
            }
        }

        private void ListarCarrito()
        {
            List<DetalleCarritosCE> listaCarrito = (List<DetalleCarritosCE>)Session["Carrito"];
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Producto");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio");
            tbl.Columns.Add("Subtotal");

            if (tbl.Rows.Count == 0)
            {
                for (int i = 0; i < listaCarrito.Count; i++)
                {
                    DataRow dr = tbl.NewRow();
                    dr["Producto"] = listaCarrito[i].ProductoCE.Nombre;
                    dr["Precio"] = listaCarrito[i].ProductoCE.Precio;
                    dr["Cantidad"] = listaCarrito[i].CantidadProducto;
                    dr["Subtotal"] = listaCarrito[i].Subtotal;

                    /*if(tbl.Rows.Count > 0)
                    {
                        foreach (DataRow drt in tbl.Rows)
                        {
                            if (drt["Producto"].ToString() != listaCarrito[i].ProductoCE.Nombre)
                            {
                              
                            }
                            //else
                            //{
                            //    dr["Cantidad"] = Convert.ToInt32(dr["Cantidad"]) + listaCarrito[i].Cantidad;
                            //    dr["Subtotal"] = Convert.ToDouble(dr["Subtotal"]) + listaCarrito[i].Subtotal;
                            //}
                        }
                    }*/
                    tbl.Rows.Add(dr);
                }
            }
            else
            {
                for (int i = 0; i < listaCarrito.Count; i++)
                {
                    DataRow dr = tbl.NewRow();
                    dr["Producto"] = listaCarrito[i].ProductoCE.Nombre;
                    dr["Producto"] = listaCarrito[i].ProductoCE.Precio;
                    dr["Cantidad"] = listaCarrito[i].CantidadProducto;
                    dr["Subtotal"] = listaCarrito[i].Subtotal;

                    foreach (DataRow drt in tbl.Rows)
                    {
                        if (drt["Producto"].ToString() != listaCarrito[i].ProductoCE.Nombre)
                        {
                            tbl.Rows.Add(dr);
                        }
                        //else
                        //{
                        //    dr["Cantidad"] = Convert.ToInt32(dr["Cantidad"]) + listaCarrito[i].Cantidad;
                        //    dr["Subtotal"] = Convert.ToDouble(dr["Subtotal"]) + listaCarrito[i].Subtotal;
                        //}
                    }
                }
            }

            GvProductos.DataSource = tbl;
            GvProductos.DataBind();
        }

        private void CalcularTotal()
        {
            List<DetalleCarritosCE> Carrito = (List<DetalleCarritosCE>)Session["Carrito"];
            double subtotal = 0,total=0,subtotalIGV=0;

            for (int i = 0; i < Carrito.Count; i++)
            {
                subtotal += Carrito[i].Subtotal;
            }

            lblSubtotal.Text = subtotal.ToString();
            subtotalIGV = (subtotal * 17)/100;
            lblIGV.Text = subtotalIGV.ToString();
            total = subtotal + subtotalIGV;
            Session["MontoTotalPago"] = total;
            lblTotal.Text = total.ToString();
        }
    }
}