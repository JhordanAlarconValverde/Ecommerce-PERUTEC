<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="busquedaProducto.aspx.cs" Inherits="CapaPresentacion.busquedaProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <div class="table-responsive text-center">
            <asp:DataList ID="DlProductos" runat="server" RepeatColumns="4" CellPadding="1" CellSpacing="15" CssClass="table table-responsive table-borderless">
                <ItemTemplate>
                    <a href="detalleProducto?cod=<%# Eval("codProducto")%>">
                        <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("imgReferencial")) %>' Height="200" Width="200" />
                        <br />
                        <asp:Label ID="nomProducto" runat="server" Text='<%# Eval("nombre") %>' />
                        <br />
                        <asp:Label ID="precioProducto" runat="server" Text='<%# Eval("precio") %>' />
                    </a>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <br />
    </div>
</asp:Content>