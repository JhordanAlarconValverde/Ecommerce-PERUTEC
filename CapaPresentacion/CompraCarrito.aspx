<%@ Page Title="Proceso de Compra" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="CompraCarrito.aspx.cs" Inherits="CapaPresentacion.CompraCarrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container w-50">
        <div class="row">
            <div class="col-sm-6">
                <h2>Carrito de Compras</h2>
                <div class="table-responsive">
                    <asp:GridView ID="GvProductos" runat="server" CssClass="table table-hover table-borderless" CellPadding="10" CellSpacing="15" Width="100%">
                        <HeaderStyle CssClass="table-light" />
                    </asp:GridView>
                </div>
            </div>

            <div class="col-sm-6">
                <div style="padding: 15px 15px">
                    <div style="padding: 20px 20px; background: #F2F3F7">
                        <h2>Resumen</h2>
                        <div class="row">
                            <div class="col-sm-6">
                                <span>Subtotal: </span>
                            </div>
                            <div class="col-sm-6 text-end fw-bold">
                                <span>S/. </span>
                                <asp:Label ID="lblSubtotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-6">
                                <span>IGV: </span>
                            </div>
                            <div class="col-sm-6 text-end fw-bold">
                                <span>S/. </span>
                                <asp:Label ID="lblIGV" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>

                    <div style="padding: 20px 20px; background: #E4E5E7">
                        <div class="row">
                            <div class="col-sm-6">
                                <span>Total</span>
                            </div>
                            <div class="col-sm-6 text-end fw-bold" style="font-size: 1.2rem">
                                <span>S/. </span>
                                <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <a href="ProcesarCompra.aspx" class="btn btn-success" style="width: 100%">Procesar Compra</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>