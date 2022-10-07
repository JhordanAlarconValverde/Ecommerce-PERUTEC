<%@ Page Title="Nosotros" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Nosotros.aspx.cs" Inherits="CapaPresentacion.Nosotros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .carousel-inner {
            height: 600px;
            width: 100%;
        }

        body {
            background: skyblue;
        }
    </style>

    <header class="container-fluid bg-primary d-flex justify-content-center">
        <h4 class="text-light mb-2 p-2 fs-1">Enterate m&aacute;s de nosotros, enterate de <b>"PeruTec"</b> </h4>
    </header>

    <div class="container h-50">
         <div class="row">
             <div class="swiper mySwiper">
                <div class="swiper-wrapper"> 
                    <div class="swiper-slide"><img src="img/oferta1.jpg"/></div>
                    <div class="swiper-slide"><img src="img/oferta2.jpg"></div>
                    <div class="swiper-slide"><img src="img/oferta3.jpg" /></div>
                </div>

                <div class="swiper-button-next"></div>
                <div class="swiper-button-prev"></div>
                <div class="swiper-pagination"></div>
            </div>
        </div>
     </div>

    <section class="w-50 mx-auto text-center pt-5" id="nosotros">
        <h1 class="p-4 fs-2 border-top border-bottom border-4"> <b>¿Qu&eacute; es PeruTec?</b> </h1>
        <p class="p-3 fs-4">
            Es una Empresa peruana que se dedica y/o esta orientado a la venta de productos
            electr&oacute;nicos y m&aacute;s a disposici&oacute;n del p&uacute;blico en general. En donde podr&aacute;
            obtener los mejores productos al mejor precio. Realizamos ventas vía online y pr&oacute;ximamente
            estar&aacute; a su disposici&oacute;n nuestras tiendas fisicas, donde podr&aacute; acudir y recibir la mejor
            atenci&oacute;n por parte de nuestro personal.
        </p>
    </section>

    <section>
        <div class="container px-4 overflow-hidden">
            <div class="row gx-5">
                <div class="col">
                    <div class="p-3 border bg-light text-center"><b>MISION</b></div>
                </div>

                <div class="col">
                    <div class="p-3 border bg-light text-center"><b>VISION</b></div>
                </div>
            </div>

            <div class="row gx-5">
                <div class="col">
                    <div class="p-4 fs-5 bg-darck text-center">
                        “Ser el referente en el mercado tecnológico - informático
                        hacia productos de calidad, contribuyendo al desarrollo del país con el apoyo de nuestros
                        clientes y proveedores, brindando un servicio de excelencia“.
                    </div>
                </div>

                <div class="col">
                    <div class="p-4 fs-5 bg-darck text-center"">
                        “Lideramos el sector tecnológico - informático 
                        peruano y buscamos exceder las expectativas de nuestros clientes en los servicios de 
                        comercialización y Post Venta dentro de un ambiente que propicia el trabajo en 
                        equipo y la realización de nuestro personal”.
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section>
        <svg xmlns=" http://www.w3.org/2000/svg" viewBox="0 0 1440 320">
            <path 
                fill="#000b76" fill-opacity="1" 
                d="M0,160L80,154.7C160,149,320,139,480,154.7C640,171,800,213,960,213.3C1120,213,1280,171,1360,149.3L1440,128L1440,320L1360,320C1280,320,1120,320,960,320C800,320,640,320,480,320C320,320,160,320,80,320L0,320Z">
             </path>
        </svg>
    </section>
</asp:Content>