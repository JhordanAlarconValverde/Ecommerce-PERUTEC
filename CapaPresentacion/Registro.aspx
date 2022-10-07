<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CapaPresentacion.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrarse</title>
    <link rel="stylesheet" href="css/registro.css"/>
    <link href="libraries/Bootrstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="body">
    <form id="form1" runat="server">
        <br />
        <div class="container-primary__">
            <h1 class="tittle-container-page">Registrar</h1>
            <%
                if (Request.QueryString["registro"] == "failed")
                {
                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                                       "No se pudo realizar el registro" +
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                    "</div>");
                }
                else if (Request.QueryString["clave"] == "failed")
                {
                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                                       "Las contraseñas no coinciden" +
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                    "</div>");
                }
            %>

            <div class="row">

                <div class="form-group col-sm-12 col-md-6 mb-sm-2 mb-md-3">
                    <label>Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-sm-12 col-md-6 mb-sm-2 mb-md-3">
                    <label>Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>DNI</label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="8"></asp:TextBox>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Teléfono / Celular</label>
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" AutoCompleteType="Disabled" MaxLength="9"></asp:TextBox>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Departamento</label>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Provincia</label>
                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Distrito</label>
                    <asp:DropDownList ID="ddlDistrito" CssClass="form-select" runat="server"></asp:DropDownList>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-sm-12 col-md-6  mb-sm-2 mb-md-3">
                    <label>Fecha de Nacimiento</label>
                    <asp:TextBox ID="txtFecNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group col-sm-12 col-md-6  mb-sm-2 mb-md-3">
                    <label>Correo Electronico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Contraseña</label>
                    <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

                <div class="form-group col-sm-6 col-md-6  mb-sm-2 mb-md-3">
                    <label>Confirmar ontraseña</label>
                    <asp:TextBox ID="txtClave2" runat="server" CssClass="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </div>

            <label class="form-check-label">
                <input class="form-check-input input-check-show-pass" type="checkbox" />
                Mostrar Contraseña
            </label>
            <div class="content-footer_form__">
                <label class="form-check-label">
                    <input class="form-check-input" type="checkbox" />
                    Aceptar Terminos y Condiciones
                </label>
                <p class="text-end"><small>Ya tienes una Cuenta? </small><a href="login.aspx">Login</a></p>
            </div>
            <br />
            <div class="d-flex flex-row justify-content-between flex-wrap">
                <a class="btn btn-danger" href="index.aspx">Cancelar</a>
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />
            </div>
        </div>
        <br />
    </form>

    <script src="js/registro.js"></script>
</body>
</html>