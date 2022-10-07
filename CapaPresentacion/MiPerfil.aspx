<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="CapaPresentacion.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
        <div class="container pt-3 shadow">
             <%
                 if (!IsPostBack)
                 {
                     if (Request.QueryString["cambio"]=="success") {
                         Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                            "La modificación se realizó correctamente"+
                                            "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                        "</div>");
                     }
                     else if (Request.QueryString["cambio"] == "failed")
                     {
                         Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>"+
                                            "La modificación no se pudo realizar"+
                                            "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                        "</div>");
                     }
                 }
             %>

            <div class="row">
                <div class="col-md-8 offset-md-2">
                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                        <li class="nav-item" role="presentation">
                          <button class="nav-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true">Mi Perfil</button>
                        </li>

                        <li class="nav-item" role="presentation">
                          <button class="nav-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false">Password</button>
                        </li>
                    </ul>

                    <div class="tab-content" id="myTabContent">

                        <!-- MI PERFIL -->
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                            <div class="row">
                                <div class="col-5"><br><br><br><br><br><br>
                                    <img src="https://cdn.icon-icons.com/icons2/2506/PNG/512/user_icon_150670.png" alt="" class="img-thumbnail">
                                </div>

                                <div class="col-7"><br>
                                    <div class="form-group row">
                                        <label for="name" class="col-4">Nombre:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"  ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-group row">
                                        <label for="name" class="col-4">Apellido:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"  ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-group row">
                                        <label for="name" class="col-4">Correo:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtCorreo" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-group row">
                                        <label for="name" class="col-4">DNI:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"  ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-group row">
                                        <label for="name" class="col-4">Celular:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtCelular" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-group row">
                                        <label for="name" class="col-4">Fecha de Nacimiento:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtFecNacimiento" CssClass="form-control" runat="server"  ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-group row">
                                        <label for="name" class="col-4">Direcci&oacute;n:</label>
                                        <div class="col-8">
                                            <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div><br>

                                    <div class="form-gruop text-center">
                                        <asp:Button ID="btnActualizarPerfil" runat="server" CssClass="btn btn-success btn-lg" Text="Aceptar" OnClick="btnActualizarPerfil_Click" />
                                        <a type="button" class="btn btn-danger btn-lg" href="index.aspx">Cancelar</a>
                                    </div><br>                    
                                </div>
                            </div>
                        </div>

                        <!-- Actualizar Contraseña -->
                        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                            <div class="col-md-6 offset-md-3"><br>

                                <h3 class="text-center">Actualizar Password</h3><br>
                                <div class="form-group row">
                                    <label for="txtCorreoTab" class="col-4">Correo:</label>
                                    <div class="col-8">
                                        <asp:TextBox ID="txtCorreoTab" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="txtClave" class="col-4">Password Actual:</label>
                                    <div class="col-8"> 
                                        <asp:TextBox ID="txtClave" class="form-control" runat="server"></asp:TextBox>
                                        <br>
                                    </div>
                                </div>

                                <div class="form-group row">
                                    <label for="txtNuevaClave" class="col-4">Password Nuevo:</label>
                                    <div class="col-8">
                                        <asp:TextBox ID="txtNuevaClave" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <br />

                                <div class="form-gruop text-center">
                                    <asp:Button ID="btnActualizarClave" runat="server" CssClass="btn btn-success btn-lg" Text="Actualizar" OnClick="btnActualizarClave_Click" />
                                    <a type="button" class="btn btn-danger btn-lg" href="index.aspx">Cancelar</a>
                                </div><br> 
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>