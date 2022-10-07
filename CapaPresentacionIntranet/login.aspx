<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CapaPresentacionIntranet.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesion</title>
    <link href="libraries/Bootrstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="bodyBG">
            <div class="container">
                <div class="container w-50">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="loginContent" style="padding: 30px 30px;">
                        <img src="img/Logo.png" class="imgLogin" style="width:150px;height:100px;"/>
                        <div class="row">
                            <span class="loginTextWelcome text-center">Bienvenido</span>
                            <span class="loginText text-center">Ingresa tus datos para acceder al sistema</span>
                            <%
                                if (Request.QueryString["login"]=="failed")
                                {
                                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>"+
                                                   "La cuenta ingresada es incorrecta"+
                                                   "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                                }
                            %>
                        </div>
                        <br />
                        <br />
                        <div class="row formTextBox">
                            <div>
                                <div class="form-floating">
                                    <asp:TextBox type="text" ID="txtEmpCorreo" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
                                    <label for="txtEmpCorreo">Correo Electrónico</label>
                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="row formTextBox">
                            <div>
                                <div class="form-floating">
                                    <asp:TextBox type="text" ID="txtEmpClave" runat="server" CssClass="form-control" placeholder="Password" TextMode="password" AutoCompleteType="Disabled"></asp:TextBox>
                                    <label for="txtEmpClave">Clave</label>
                                </div>
                            </div>
                        </div>
                        <div class="mt-2">
                            <input type="checkbox" id="show-pass" class="show-pass form-check-input"/>
                            <label class="form-check-inline" for="show-pass">Mostrar Contraseña</label>
                        </div>
                        <br />
                        <div class="row">
                            <div class="form-floating">
                                <asp:Button ID="btnEmpIniciarSesion" runat="server" CssClass="btn btn-success w-100" Text="Iniciar Sesión" OnClick="btnEmpIniciarSesion_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        document.querySelector(".show-pass").onclick = () => {
            let clave = document.querySelector("#txtEmpClave");
            let tipo = clave.type;
            if (tipo == "password") {
                clave.setAttribute("type", "text");
            }
            else {
                clave.setAttribute("type", "password")
            }
        }
    </script>
</body>
</html>