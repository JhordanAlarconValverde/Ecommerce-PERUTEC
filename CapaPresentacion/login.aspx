<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="CapaPresentacion.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Iniciar Sesion</title>
    <link href="libraries/Bootrstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="libraries/fontawesome/css/all.min.css" rel="stylesheet" />
    <link href="css/login.css" rel="stylesheet" />
    <style>
        .group_control_pass {
    position: relative;
}

.btn-show-eye {
    position: absolute;
    top: 7px;
    right: 6px;
}

.fa-eye {
    margin-right: 1px;
}

.fa-eye-slash, .fa-eye {
    margin-top: 3px;
    font-size: 1.2rem;
    color: #222;
}


.body {
    background: #B0E3FC;
    height: 100vh;
}

.container_primary__ {
    padding-top: 90px;
    margin: auto;
    width: 75%;
    border-radius: 30px;
    height: 450px;
}

.container_banner_login {
    background-image: url('img/loginBG.jpg');
    position: relative;
    background-size: cover;
    background-repeat: no-repeat;
    height: 450px;
    width: 50%;
    border-bottom-left-radius: 20px;
    border-top-left-radius: 20px;
}

.banner_img_login {
    width: 400px;
    position: absolute;
    top: 92px;
    left: 70px;
}

.text-banner-login {
    padding: 30px 30px;
    height: 400px;
    position: relative;
    z-index: 100;
}

.container_content_login {
    background: #fff;
    height: 450px;
    width: 50%;
    padding-top: -40px;
    padding-right: 40px;
    padding-left: 40px;
    border-bottom-right-radius: 20px;
    border-top-right-radius: 20px;
}

@media only screen and (max-width: 1258px) {
    .banner_img_login {
        width: 300px;
        top: 100px;
        left: 50px;
        transition: all 300ms;
    }
}
@media only screen and (max-width: 970px) {
    .alert-dismissible{
        font-size: 0.9rem;
    }
}

@media only screen and (max-width: 940px) {
    .banner_img_login {
        width: 300px;
        top: 102px;
        left: 35px;
        transition: all 300ms;
    }
}

@media only screen and (max-width: 889px) {
    .container_banner_login {
        display: none;
    }

    .container_primary__ {
        position: relative;
        margin: auto;
        width: 75%;
        border-radius: 30px;
        height: 450px;
    }

    .container_content_login {
        border-radius: 20px;
        width: 100%;
    }
}

@media only screen and (max-width: 550px) {
    .body {
        background: #fff;
    }

    .container-primary__ {
        width: 100%;
    }
}

    </style>
</head>
<body class="body">
    
    <form id="form1" runat="server">
        <div class="container_primary__ d-flex flex-row align-items-center">
            <div class="container_banner_login">
                <br />
                <div class="text-banner-login">
                    <span>Bienvenido a PeruTec
                    </span>
                    <br />
                    <span>Ahora puedes realizar tus compras desde cualquier lado del país.
                    </span>
                    <img class="banner_img_login" src="img/loginImage.png" />
                </div>
            </div>

            <div class="container_content_login">
                <br />

                <h1 class="text-center mt-sm-0">Login</h1>
                <%
                    if (Request.QueryString["status"] == "failed")
                    {
                        Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                                            "La cuenta ingresada es incorrecta" +
                                            "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                       "</div>");
                    }
                    else if (Request.QueryString["status"] == "required")
                    {
                        Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                                            "Debe iniciar sesión para poder agregar productos al carrito" +
                                            "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                       "</div>");
                    }
                    else if (Request.QueryString["status"] == "empty")
                    {
                        Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                                            "Debe iniciar sesion con un correo electronico y una clave" +
                                            "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                       "</div>");
                    }
                    else if (Request.QueryString["registro"] == "success")
                    {
                        Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>" +
                                            "<b>El registro se realizó correctamente</b> Inicie sesión." +
                                            "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                       "</div>");
                    }
                %>

                <div class="form-group">
                    <label>Correo</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
                <br />
                <div class="form-group">
                    <label>Contraseña</label>
                    <div class="group_control_pass">
                        <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" AutoCompleteType="Disabled" TextMode="Password" MaxLength="54"></asp:TextBox>
                        <span class="btn-show-eye"><i class="fas fa-eye-slash"></i></span>
                    </div>
                </div>
                <br />

                <div style="display: flex; flex-direction: row; justify-content: space-between">
                    <a href="#">Olvidé mi contraseña</a>
                    <a href="Registro.aspx">Registrarme</a>
                </div>

                <br />
                <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="btn btn-primary" OnClick="btnIniciarSesion_Click" />
            </div>
        </div>
    </form>
    <script src="js/login.js"></script>
</body>
</html>
