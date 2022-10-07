<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="CapaPresentacion.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btnEnviarConsulta{
            padding:5px 30px;
            font-size:1.2rem;
        }
    </style>

    <div>
        <br /> <br />

        <div class="container w-50">
            <div style="border: 3px solid #AEB6BF ; border-radius: 5px; background: #fff; padding: 25px 25px;">
                <div>
                    <h2 style="text-align: center">Contacto</h2>
                    <br />

                    <div class="row">
                        <div class="col-sm-6">
                            <label for="txtNombre">Nombre </label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label for="txtApellido">Apellido </label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm-6">
                            <label for="txtCelular">Celular </label>
                            <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label for="txtCelular">Correo </label>
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-sm-12">
                            <label for="txtMensaje">Mensaje </label>
                            <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" Height="80"></asp:TextBox>
                        </div>
                    </div>
                    <br />

                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-success btnEnviarConsulta" />
                </div>
            </div>
        </div>
        <br /> <br />
    </div>
</asp:Content>