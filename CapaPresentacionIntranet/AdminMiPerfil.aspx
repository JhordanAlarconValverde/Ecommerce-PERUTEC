<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminMiPerfil.aspx.cs" Inherits="CapaPresentacionIntranet.AdminMiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../css/adminProdDisponibles.css"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-section">
        <div class="home-content">
            <i class="fas fa-bars"></i>
            <span class="text">Menú</span>
        </div>
        <br />
        <div class="container">
            <%
                if (Request.QueryString["update"]=="success") 
                {
                    Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                   "La modificación se realizó correctamente"+
                                   "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
                else if (Request.QueryString["update"] == "failed")
                {
                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>"+
                                   "La modificación <b>NO</b> pudo realizarse"+
                                   "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
            %>

            <h1> Mi Perfil</h1><br />
            <div class="row">
                <div class="col-sm-6">
                    <label>Nombres</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label>Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div><br />
            <div class="row">
                <div class="col-sm-6">
                    <label>DNI:</label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label>Celular:</label>
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div><br />
            <div class="row">
                <div class="col-sm-6">
                    <label>Correo:</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-6">
                    <label>Clave:</label>
                    <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" required></asp:TextBox>
                </div>
            </div><br />
            <div class="row">
                <div class="col-sm-6">
                    <label>Fecha de Nacimiento:</label>
                    <asp:TextBox ID="txtFecNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
            </div><br />
            <asp:Button ID="btnActualizarPerfil" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnActualizarPerfil_Click" />
        </div>
    </section>
</asp:Content>