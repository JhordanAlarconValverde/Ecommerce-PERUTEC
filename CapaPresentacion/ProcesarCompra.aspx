<%@ Page Title="Proceso de Compra" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="ProcesarCompra.aspx.cs" Inherits="CapaPresentacion.ProcesarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container-sm">
        <div class=" card">
            <%
                if (Request.QueryString["compra"] == "failed")
                {
                    Response.Write("<div class='alert alert-danger alert-dismissible fade show' role='alert'>" +
                                        "<b>La compra no pudo realizarse</b>" +
                                        "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>" +
                                   "</div>");
                }
                else if (Request.QueryString["compra"] == "success")
                {
                    Response.Write("<div class='alert alert-success alert-dismissible fade show' role='alert'>" +
                                       "<b>La compra se realízó correctamente</b>" +
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>");
                }
            %>>

            <div class="card-header">
                <h3 class="card-title">Metodo de Pago</h3>
            </div>

            <div class="card-body">
                <div class="form-group row">

                    <div class="col-sm-6">
                        <label for="ddlMetodosPago" class="col-form-label">Forma de pago:</label>
                        <asp:DropDownList ID="ddlMetodosPago" CssClass="form-select form-select-sm" runat="server"></asp:DropDownList>
                    </div>

                    <div class="col-sm-6">
                        <label for="txtNumeroTarjeta" class="col-form-label">N&uacute;mero de Tarjeta:</label>
                        <asp:TextBox ID="txtNumeroTarjeta" CssClass="form-control form-control-sm" runat="server" placeholder="4557 9908 6543 4154"></asp:TextBox>
                    </div>
                </div>
                <br />

                <div class="form-group row">
                    <div class="col-sm-6">
                        <label for="txtCodigoCCV" class="col-form-label">Codigo CCV:</label>
                        <asp:TextBox ID="txtCodigoCCV" CssClass="form-control form-control-sm" runat="server" placeholder="Revisar la parte posterior de la Tarjeta"></asp:TextBox>
                    </div>

                    <div class="col-sm-6">
                        <label for="txtDireccion" class="col-form-label">Direcci&oacute;n:</label>
                        <asp:TextBox ID="txtDireccion" CssClass="form-control form-control-sm" runat="server" placeholder="Av Los Angeles Mz D Lte 13 - Ref: Frente al grifo Repsol"></asp:TextBox>
                    </div>
                </div>
                <br />

                <div class="form-group row">
                    <div class="col-sm-6">
                        <label for="txtReferencia" class="col-form-label">Referencia:</label>
                        <asp:TextBox ID="txtReferencia" CssClass="form-control form-control-sm" runat="server"></asp:TextBox>
                    </div>
                </div>
                <br />

                <div class="form-group row">
                    <div class="col-sm-6">
                        <label for="nombre" class="col-form-label">Monto a Pagar:</label>
                        <asp:Label ID="lblMontoTotal" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <br />

                <div class="d-flex flex-row justify-content-between flex-wrap">
                    <button class="btn btn-danger">Regresar</button>
                    <asp:Button ID="btnRealizarPago" CssClass="btn btn-success" runat="server" Text="Realizar Pago" OnClick="btnRealizarPago_Click" />
                </div>
            </div>

            <div class="card-footer">
                <div style="text-align:center">
                    <i>PeruTec</i>
                </div>
            </div>
        </div>
    </div>
</asp:Content>