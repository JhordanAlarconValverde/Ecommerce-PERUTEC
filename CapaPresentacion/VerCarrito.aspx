<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="VerCarrito.aspx.cs" Inherits="CapaPresentacion.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h2>Carrito de Compras</h2>
        <asp:GridView ID="GvProductosCarrito" runat="server" CssClass="table table-hover table-borderless text-center">
            <Columns>
                <asp:ButtonField Text="Eliminar" runat="server" ControlStyle-CssClass="btn btn-danger p-1"/>
                <asp:ButtonField Text="Actualizar" runat="server" ControlStyle-CssClass="btn btn-primary p-1"/>
                <asp:BoundField DataField="imgReferencial" HeaderText="Imagen" ControlStyle-BorderWidth="100px" DataFormatString="img"/>
                <asp:BoundField DataField="nombre" HeaderText="Producto" />
                <asp:BoundField DataField="precio" HeaderText="Precio" />
                <asp:BoundField DataField="cantidadProducto" HeaderText="Cantidad" />
                <asp:BoundField DataField="subtotal" HeaderText="Subtotal" />
            </Columns>
            <HeaderStyle CssClass="table-light" />
        </asp:GridView>

        <div class="col-lg-4 col-md-5 col-sm-7 mt-5 mb-5">
            <div style="padding: 20px 20px; background: #F2F3F7">
                <h2>Resumen</h2>
                <div class="row">
                    <div class="col-sm-6">
                        <span>Subtotal: </span>
                    </div>
                    <div class="col-sm-6 text-end fw-bold">
                        <span>S/. </span>
                        <asp:Label ID="lblSubtotal" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-6">
                        <span>IGV: </span>
                    </div>
                    <div class="col-sm-6 text-end fw-bold">
                        <span>S/. </span>
                        <asp:Label ID="lblIGV" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div style="padding: 20px 20px; background: #E4E5E7">
                <div class="row">
                    <div class="col-sm-6">
                        <span>Total</span>
                    </div>
                    <div class="col-sm-6 text-end fw-bold" style="font-size: 1.2rem">
                        <span>S/. </span>
                        <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>  
            <br />
        </div>
    </div>




</asp:Content>