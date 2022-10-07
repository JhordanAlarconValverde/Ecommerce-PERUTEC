<%@ Page Title="Vendedores" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminEmpleadosVendedor.aspx.cs" Inherits="CapaPresentacionIntranet.AdminEmpleadosVendedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../css/adminDashboard.css"/>
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
                <div class="col-6 mt-4 mb-4">
                    <label style="font-size: 1.2rem">Nombre</label>
                    <asp:TextBox ID="txtBuscarByNombre" runat="server" CssClass="form-control"></asp:TextBox><br />
                    <asp:Button ID="btnBuscarByNombre" runat="server" Text="Buscar" CssClass="btn btn-primary col-12" OnClick="btnBuscarByNombre_Click"/>
                </div>
                <div class="col-6 mt-4 mb-4">
                    <label style="font-size: 1.2rem">Apellido</label>
                    <asp:TextBox ID="txtBuscarByApellido" runat="server" CssClass="form-control"></asp:TextBox><br />
                    <asp:Button ID="btnBuscarByApellido" runat="server" Text="Buscar" CssClass="btn btn-primary col-12" OnClick="btnBuscarByApellido_Click"/>
                </div>
            </div>
        </div>
        <div class="container">
            <asp:Button ID="btnNuevoEmpleado" runat="server" Text="Nuevo Empleado" CssClass="btn btn-primary" OnClick="btnNuevoEmpleado_Click" />
            <!--<asp:Button ID="btnExcel" runat="server" Text="Generar Excel" CssClass="btn btn-success" />
            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" CssClass="btn btn-warning" />-->
        </div>
        <br />
        <div class="container">
            <%
                if (!IsPostBack)
                {
                    if(Request.QueryString["registro"]=="success") 
                    {
                        Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                       "El registro se realizó exitosamente"+
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                    }
                    else if (Request.QueryString["actualizar"] == "success")
                    {
                        Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                       "El registro se actualizó exitosamente"+
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                    }
                    else if(Request.QueryString["eliminar"] == "success")
                    {
                        Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                       "El registro se eliminó exitosamente"+
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                    }
                }                          
             %>
            <div class="table-responsive text-center">
                <asp:GridView ID="GvEmpleadoVendedor" runat="server" CssClass="table table-hover" OnSelectedIndexChanged="GvEmpleadoVendedor_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/remove.png" ShowDeleteButton="True" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/clipboard.png" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="table-dark" />
                </asp:GridView>
            </div>
            <br />
            <asp:Panel ID="panelRegistro" runat="server">
                <div class="container w-50">
                    <div class="row">
                        <div class="col-sm-6">
                            <label>Código de Empleado:</label>
                            <asp:TextBox ID="txtcodEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-6">
                            <label>Nombre:</label>
                            <asp:TextBox ID="txtNomEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <br />
                        <div class="col-sm-6">
                            <label>Apellido:</label>
                            <asp:TextBox ID="txtApeEmpleado" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-6">
                            <label>DNI:</label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label>Celular:</label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-6">
                            <label>Cargo:</label>
                            <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-select" AutoPostBack="true"></asp:DropDownList>
                        </div>
                        <div class="col-sm-6">
                            <label>Fecha de Nacimiento:</label>
                            <asp:TextBox ID="txtFecNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-6">
                            <label>Correo:</label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-sm-6">
                            <label>Clave:</label>
                            <asp:TextBox ID="txtClave" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-6">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click"/>
                        </div>
                        <div class="col-sm-6 text-end">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click"/>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </section>
</asp:Content>