<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminProdSinStock.aspx.cs" Inherits="CapaPresentacionIntranet.AdminProdSinStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../css/adminProdDisponibles.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-section">
        <div class="home-content">
            <i class="fas fa-bars"></i>
            <span class="text">Menú</span>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <div class="d-flex justify-content-center">
                        <asp:TextBox ID="txtProducto" placeholder="Producto" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Button ID="btnBuscarByProducto" runat="server" Text="Buscar" CssClass="btn btn-primary"/>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="d-flex justify-content-center">
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                        <asp:Button ID="btnBuscarByCategoria" runat="server" Text="Buscar" CssClass="btn btn-primary"/>
                    </div>
                </div>
            </div>
            <br />
        </div>
        <div class="container">
            <asp:Button ID="btnNuevoProducto" runat="server" Text="Nuevo Producto" CssClass="btn btn-primary"/>
            <asp:Button ID="btnExcel" runat="server" Text="Generar Excel" CssClass="btn btn-success"/>
            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" CssClass="btn btn-warning"/>
        </div>
        <div class="container">
            <div class="table-responsive text-center">
                <asp:GridView ID="GvProdSinStock" runat="server" CssClass="table table-hover">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/remove.png" ShowDeleteButton="True" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/clipboard.png" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="table-dark" />
                </asp:GridView>
            </div>
            <br />
        </div>
    </section>
</asp:Content>