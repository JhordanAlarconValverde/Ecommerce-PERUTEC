<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Admin.Master" AutoEventWireup="true" CodeBehind="AdminClientes.aspx.cs" Inherits="CapaPresentacion.Administrador.AdminClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
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
            <div class="row">
                <div class="col-sm-3">
                    <div class="d-flex flex-column">
                        <label style="font-size:20px">Nombres y Apellidos</label>
                        <asp:TextBox ID="txtBuscarByNombre" runat="server" CssClass="form-control"></asp:TextBox><br />
                        <asp:Button ID="btnBuscarByNombre" runat="server" Text="Buscar" CssClass="btn btn-primary"  />
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="d-flex flex-column">
                         <label style="font-size:20px">Departamento</label>
                        <asp:DropDownList ID="ddlBuscarByDepartamento" runat="server" CssClass="form-select"></asp:DropDownList><br />
                        <asp:Button ID="btnBuscarByDepartamento" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByDepartamento_Click"/>
                    </div>
                </div>
                 <div class="col-sm-3">
                    <div class="d-flex flex-column">
                         <label style="font-size:20px">Provincia</label>
                        <asp:DropDownList ID="ddlBuscarByProvincia" runat="server" CssClass="form-select"></asp:DropDownList><br />
                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select"></asp:DropDownList><br />
                        <asp:Button ID="btnBuscarByProvincia" runat="server" Text="Seleccionar" CssClass="btn btn-primary" OnClick="btnBuscarByProvincia_Click"/>
                    </div>
                </div>
                <div class="col-sm-3">
                    <div class="d-flex flex-column">
                         <label style="font-size:20px">Distrito</label>
                        <div style="display:flex; flex-direction:row">
                            <asp:DropDownList ID="ddlBuscarByDistrito" runat="server" CssClass="form-select"></asp:DropDownList>
                            <asp:Button ID="btnSeleccionarProvincia" runat="server" Text="Seleccionar" CssClass="btn btn-primary"/>
                        </div>
                            <br />
                        <div style="display:flex; flex-direction:row">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select"></asp:DropDownList>
                             <asp:Button ID="Button1" runat="server" Text="Seleccionar" CssClass="btn btn-primary"/>
                        </div>
                        <br />
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select"></asp:DropDownList><br />
                        <asp:Button ID="btnBuscarByDistrito" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByProvincia_Click"/>
                    </div>
                </div>-->
            </div>
            <br />
        </div>
        <div class="container">
            <asp:Button ID="btnNuevoCliente" runat="server" Text="Nuevo Cliente" CssClass="btn btn-primary"  />
            <asp:Button ID="btnExcel" runat="server" Text="Generar Excel" CssClass="btn btn-success" />
            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" CssClass="btn btn-warning"  />
        </div>
        <br />
        <div class="container">
            <div class="table-responsive">
                <asp:GridView ID="GvClientes" runat="server" CssClass="table table-hover" OnSelectedIndexChanged="GvProdDisponibles_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/remove.png" ShowDeleteButton="True" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/clipboard.png" ShowSelectButton="True" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="table-dark" />

                </asp:GridView>
            </div>
        </div>
        <br />


        <!--<asp:Panel ID="panelRegistro" runat="server">
            <div class="container w-50">
                <div class="row">
                    <div class="col-sm-6">
                        <label>Código de producto</label>
                        <asp:TextBox ID="txtCodProducto" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <label>Producto</label>
                        <asp:TextBox ID="txtNomProducto" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <br />
                    <div class="col-sm-6">
                        <label>Categoría</label>
                        <asp:DropDownList ID="ddlRegProducto" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <label>Descripción</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Height="80px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <label>Precio</label>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-sm-6">
                        <label>Stock</label>
                        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" TextMode="Number" min="1" max="100" value="1"></asp:TextBox>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <label>Imagen del producto</label>
                        <asp:FileUpload ID="imgProducto" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-12">
                        <asp:Image ID="imgUsu" runat="server" CssClass="w-100" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger"  />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="btnRegistrar" runat="server" Text="Regitrar" CssClass="btn btn-primary"/>
                    </div>
                </div>
        </asp:Panel>-->

    </section>
</asp:Content>
