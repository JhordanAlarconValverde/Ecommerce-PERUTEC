<%@ Page Title="Nuestros Locales" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="NuestrosLocales.aspx.cs" Inherits="CapaPresentacion.NuestrosLocales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server"></asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <h1 class="display-2 text-center">Encuentranos en Nuestros Siguientes Locales</h1>

        <div style="padding: 15px;margin: 0 0 20px 0;">
            <div>
                <iframe style="width: 100%;height: 600px;border: 0;" 
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d16739.09368806295!2d-79.03127790049587!3d-8.111628005258504!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x91ad3d814eef50d9%3A0xaa9b658553db5556!2sMega%20Computo!5e0!3m2!1ses!2spe!4v1637787585299!5m2!1ses!2spe">
                </iframe>
            </div>

            <div>
                <h3 class="mb-3 mt-3 d-inline-block mr-3">Direccion:</h3>
                <span style="font-size: 1.4rem;">Jr. Junin 701, Trujillo 13001</span><br>
                <h3 class="mb-3 d-inline-block mr-3">Atencion:</h3>
                <span style="font-size: 1.4rem;">10:00AM - 21:00PM</span><br>
                <h3 class="mb-3 d-inline-block mr-3">Telefono:</h3>
                <span style="font-size: 1.4rem;">(044) 547937</span>
            </div>
        </div>

        <div style="padding: 15px;margin: 0 0 20px 0;">
            <div>
                <iframe style="width: 100%;height: 600px;border: 0;" 
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d26640.818352237402!2d-76.99478069146915!3d-11.946387827202512!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x9105dbbb3e2748c1%3A0xa507e2802e061270!2sPerutec!5e0!3m2!1ses!2spe!4v1637789181710!5m2!1ses!2spe">
                </iframe>
            </div>

            <div>
                <h3 class="mb-3 mt-3 d-inline-block mr-3">Direccion:</h3>
                <span style="font-size: 1.4rem;"">Av el muero MZ M9 LT 30 Urb mariscal caceres Sec II 3 y 4 E, San Juan de Lurigancho 15446</span><br>
                <h3 class="mb-3 d-inline-block mr-3">Atencion:</h3>
                <span style="font-size: 1.4rem;">9:00AM - 23:00PM</span><br>
                <h3 class="mb-3 d-inline-block mr-3">Telefono:</h3>
                <span style="font-size: 1.4rem;">(51) 16985578</span>
            </div>
        </div>
    </div>
</asp:Content>