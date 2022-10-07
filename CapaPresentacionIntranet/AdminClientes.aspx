<%@ Page Title="Clientes" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true" CodeBehind="AdminClientes.aspx.cs" Inherits="CapaPresentacion.Administrador.AdminClientes" %>

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
                    <div class="d-flex flex-column">
                        <label style="font-size: 1.2rem">Nombre</label>
                        <asp:TextBox ID="txtBuscarByNombre" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <asp:Button ID="btnBuscarByNombre" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByNombre_Click" />
                    </div>
                    <br />
                    <br />
                    <div class="d-flex flex-column" style="margin-top: 10px">
                        <label style="font-size: 1.2rem">Apellido</label>
                        <asp:TextBox ID="txtBuscarByApellido" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <asp:Button ID="btnBuscarByApellido" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByApellido_Click" />
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="d-flex flex-column">
                        <label style="font-size: 20px">Departamento</label>
                        <div style="display: flex; flex-direction: row">
                            <asp:DropDownList ID="ddlBuscarByDepartamento" runat="server" CssClass="form-select"></asp:DropDownList>
                            <asp:Button ID="btnSeleccionarDepartamento" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="btnSeleccionarDepartamento_Click" />
                        </div>
                        <br />
                        <label style="font-size: 20px">Provincia</label>
                        <div style="display: flex; flex-direction: row">
                            <asp:DropDownList ID="ddlBuscarByProvincia" runat="server" CssClass="form-select"></asp:DropDownList>
                            <asp:Button ID="btnSeleccionarProvincia" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="btnSeleccionarProvincia_Click" />
                        </div>
                        <br />
                        <label style="font-size: 20px">Distrito</label>
                        <div style="display: flex; flex-direction: row">
                            <asp:DropDownList ID="ddlBuscarByDistrito" runat="server" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <br />
                        <asp:Button ID="btnBuscarByUbigeo" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByUbigeo_Click" />
                    </div>
                </div>
            </div>
        </div>
        <br />

        <div class="container">
            <%
                if (Request.QueryString["registro"] == "success")
                {
                    Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>" +
                      "El registro puedo crearse exitosamente" +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
                else if (Request.QueryString["registro"] == "failed")
                {
                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                      "<b>Error.</b> El registro no pudo crearse" +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
                else if (Request.QueryString["update"] == "success")
                {
                    Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>" +
                      "El registro se actualizó exitosamente" +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
                else if (Request.QueryString["update"] == "failed")
                {
                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                      "<b>Error.</b> El registro no pudo actualizarse" +
                      "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
            %>
        </div>
        <div class="container">
            <asp:Button ID="btnNuevoCliente" runat="server" Text="Nuevo Cliente" CssClass="btn btn-primary" OnClick="btnNuevoCliente_Click" />
            <asp:Button ID="btnExcel" runat="server" Text="Generar Excel" CssClass="btn btn-success" />
            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" CssClass="btn btn-warning" />
        </div>
        <br />
        <div class="container">
            <div class="table-responsive text-center" style="height: 600px;">
                <asp:GridView ID="GvClientes" runat="server" CssClass="table table-hover" OnSelectedIndexChanged="GvClientes_SelectedIndexChanged" OnRowDeleted="GvClientes_RowDeleted">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/remove.png" ShowDeleteButton="True"/>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/clipboard.png" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="table-dark" />
                </asp:GridView>
            </div>
        </div>
        <br />

        <asp:Panel ID="panelRegistro" runat="server">
            <div class="container w-50">
                <div class="row">
                    <div class="col-sm-6">
                        <label>Código de cliente:</label>
                        <asp:TextBox ID="txtCodCliente" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <label>Nombre:</label>
                        <asp:TextBox ID="txtNomCliente" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div class="col-sm-6">
                        <label>Apellido:</label>
                        <asp:TextBox ID="txtApeCliente" runat="server" CssClass="form-control"></asp:TextBox>
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
                        <label>Departamento: </label>
                        <asp:DropDownList ID="ddlRegCliDepartamento" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlRegCliDepartamento_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                    <div class="col-sm-6">
                        <label>Provincia: </label>
                        <asp:DropDownList ID="ddlRegCliProvincia" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlRegCliProvincia_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <label>Distrito: </label>
                        <asp:DropDownList ID="ddlRegCliDistrito" runat="server" CssClass="form-select" OnSelectedIndexChanged="ddlRegCliDistrito_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                    <div class="col-sm-6">
                        <label>Dirección: </label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <label>DNI: </label>
                        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-6">
                        <label>Fecha de nacimiento:</label>
                        <asp:TextBox ID="txtFecNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <label>Celular:</label>
                        <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                    </div>
                    <div class="col-sm-6 text-end">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>
    </section>
       
    <%--<script>
        document.querySelector(".fa-bars").onclick = () => {
            let container = document.querySelector(".container_primary__");
            container.style.marginLeft = "90px";
            container.style.transition = "all 500ms";
            console.log(container);
        }
    </script>--%>
</asp:Content>