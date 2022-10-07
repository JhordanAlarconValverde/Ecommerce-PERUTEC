<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPedidos.aspx.cs" Inherits="CapaPresentacionIntranet.AdminPedidos" %>

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
                <label style="font-size: 1.2rem">Cliente</label>
                <div class="mt-4 mb-4">
                    <asp:TextBox ID="txtBuscarByNombreCliente" runat="server" CssClass="form-control col-8" OnTextChanged="txtBuscarByNombreCliente_TextChanged">
                    </asp:TextBox><asp:Button ID="btnBuscarByNombreCliente" runat="server" Text="Buscar" CssClass="btn btn-primary"/>
                </div>
            </div>
        </div>
        <div class="container">
          
        </div>
        <br />
        <div class="container">
            <div class="table-responsive text-center">
                <asp:GridView ID="GvPedidos" runat="server" CssClass="table table-hover">
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