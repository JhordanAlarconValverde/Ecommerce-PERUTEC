<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="detalleProducto.aspx.cs" Inherits="CapaPresentacion.detalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container_detail_prod{
            overflow-x: hidden
        }
    </style>
    <div class="container_detail_prod">
        <br />
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-6 col-sm-6 col-lg-6">
                <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("imgReferencial")) %>' Width="100%" />
            </div>

            <div class="col-6 col-sm-6 col-lg-4">
                <span><b>Marca del Producto: </b>
                    <asp:Label ID="lblNombreProducto" runat="server" Text='<%# Eval("nombre") %>' />
                </span>
                <br />

                <span><b>Categoria: </b>
                    <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("nomCategoria") %>' />
                </span><br />

                <span><b>Descripción:</b></span><br />
                <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("descripcion") %>' />
                <br />

                <!--<span>Stock:
                    <asp:Label ID="lblStock" runat="server" Text='<%# Eval("stock") %>' />
                </span><br />-->

                <span><b>Precio: </b>S/
                    <asp:Label ID="lblPrecio" runat="server" Text='<%# String.Format("{0:0.00}",Eval("precio")) %>' />
                </span><br />
                <br />

                <div class="form-floating w-25">
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" placeholder="1" TextMode="Number" MaxLength="2" min="1" max="10"></asp:TextBox>
                    <asp:RangeValidator runat="server" ControlToValidate="txtCantidad" ErrorMessage="Enter number between 1 to 10" Type="Integer" MinimumValue="1" MaximumValue="10" ForeColor="Red"></asp:RangeValidator>
                    <label class="form-label" for="ContentPlaceHolder1_txtCantidad">Cantidad</label>
                </div>
                <br />

                <div>
                    <a class="btn btn-danger" href="index.aspx">Volver</a>
                    <asp:Button ID='btnAgregarCarrito' runat='server' CssClass='btn btn-success' Text='Agregar al carrito' OnClick='btnAgregarCarrito_Click' />
                </div>
            </div>
            <div class="col-lg-1"></div>
        </div>
    </div>
</asp:Content>