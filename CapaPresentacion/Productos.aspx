<%@ Page Title="Productos" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CapaPresentacion.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-1"></div>
            <!--<div class="col-sm-2">
                <div class="container">
                    <ul style="//list-style-type:none">
                        <li style="font-size:1.3rem">Categorias</li>
                        <br />
                        <a href="#" ><li>Tablet</li></a>
                        <a href="#"><li>Computadoras</li></a>
                        <a href="#"><li>Smartphones</li></a>
                        <a href="#"><li>Tablets</li></a>
                    </ul>
                </div>
            </div>-->

            <div class="col-sm-10">
                <div class="container">
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
                </div>
            </div>
            <div class="col-1"></div>
        </div>
    </div>
</asp:Content>