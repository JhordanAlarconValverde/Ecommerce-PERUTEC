<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CapaPresentacion.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <div class="container m-auto">
                <%
                    if (Request.QueryString["compra"] == "success")
                    {
                        Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>" +
                                       "<b>La compra se realízó correctamente</b>" +
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                    }
                %>
                <div class="row body">
                    <div class="col-sm-12">
                        <div class="row">
                            <div class="swiper mySwiper">
                                <div class="swiper-wrapper"> 
                                    <div class="swiper-slide"><img src="img/oferta1.jpg"/></div>
                                    <div class="swiper-slide"><img src="img/oferta2.jpg"></div>
                                    <div class="swiper-slide"><img src="img/oferta3.jpg" /></div>
                                </div>
                                <div class="swiper-button-next"></div>
                                <div class="swiper-button-prev"></div>
                                <div class="swiper-pagination"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="container m-auto">
                <h1> Últimos Productos</h1>
                <div class="table-responsive">
                    <asp:DataList ID="DlUltimosProductos" runat="server" RepeatColumns = "4" CellPadding = "1" CellSpacing="15" CssClass="table table-responsive table-borderless" >
                        <ItemTemplate>
                            <a href="detalleProducto?cod=<%# Eval("codProducto")%>"><asp:Image ID="imgProducto" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("imgReferencial")) %>' Height="200" Width="200" />
                            <br />  
                            <asp:Label ID="nomProducto" runat="server" Text='<%# Eval("nombre") %>' /> <br />
                             <asp:Label ID="precioProducto" runat="server" Text='<%# Eval("precio") %>' />
                            </a>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
            </div>
        </div>
</asp:Content>
