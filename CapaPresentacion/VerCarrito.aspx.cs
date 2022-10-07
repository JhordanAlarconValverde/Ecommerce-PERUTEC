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

namespace CapaPresentacion
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListarCarrito();
        }



        private void ListarCarrito()
        {
            //DetalleCarritosCE detalleCarritoCE = new DetalleCarritosCE();
            DetalleCarritosCN detalleCarritoCN = new DetalleCarritosCN();
            int codCarrito = Convert.ToInt32(Session["codCarrito"]);
            DataTable dt = detalleCarritoCN.ListarDetalleCarritoByCodCarrito(codCarrito);

            
            /*DataTable tbl = new DataTable();
            tbl.Columns.Add("Imagen");
            tbl.Columns.Add("Producto");
            tbl.Columns.Add("Precio");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Subtotal");*/


            /*for (int i = 0; dt.Columns.Count < i; i++)
            {
                DataRow dr = tbl.NewRow();
                dr["Imagen"] = dt.Columns[i].
                dr["Producto"] = listaCarrito[i].ProductoCE.Nombre;
                dr["Precio"] = listaCarrito[i].ProductoCE.Precio;
                dr["Cantidad"] = listaCarrito[i].CantidadProducto;
                dr["Subtotal"] = listaCarrito[i].Subtotal;
                tbl.Rows.Add(dr);
            }*/
            GvProductosCarrito.DataSource = dt;
            GvProductosCarrito.DataBind();
            /*List<DetalleCarritosCE> listaCarrito = (List<DetalleCarritosCE>)Session["Carrito"];
            DataTable tbl = new DataTable();
            tbl.Columns.Add("Imagen");
            tbl.Columns.Add("Producto");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio");
            tbl.Columns.Add("Subtotal");

            for (int i = 0; i < listaCarrito.Count; i++)
            {
                DataRow dr = tbl.NewRow();
                dr["Imagen"] = listaCarrito[i].ProductoCE.ImgReferencial;
                dr["Producto"] = listaCarrito[i].ProductoCE.Nombre;
                dr["Precio"] = listaCarrito[i].ProductoCE.Precio;
                dr["Cantidad"] = listaCarrito[i].CantidadProducto;
                dr["Subtotal"] = listaCarrito[i].Subtotal;
                tbl.Rows.Add(dr);
            }

            GvProductosCarrito.DataSource = tbl;
            GvProductosCarrito.DataBind();*/


            /*if (tbl.Rows.Count == 0)
            {
                for (int i = 0; i < listaCarrito.Count; i++)
                {
                    DataRow dr = tbl.NewRow();
                    dr["Producto"] = listaCarrito[i].ProductoCE.Nombre;
                    dr["Precio"] = listaCarrito[i].ProductoCE.Precio;
                    dr["Cantidad"] = listaCarrito[i].CantidadProducto;
                    dr["Subtotal"] = listaCarrito[i].Subtotal;
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
            */
        }
    }
}