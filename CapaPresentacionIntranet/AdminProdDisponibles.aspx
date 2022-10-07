<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true" CodeBehind="AdminProdDisponibles.aspx.cs" Inherits="CapaPresentacion.Administrador.AdminProdDisponibles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
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
                        <div class="col-sm-6">
                            <div class="d-flex justify-content-center">
                                <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Button ID="btnBuscarByProducto" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByProducto_Click"/>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="d-flex justify-content-center">
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select"></asp:DropDownList>
                                <asp:Button ID="btnBuscarByCategoria" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscarByCategoria_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
                <div class="container">
                    <asp:Button ID="btnNuevoProducto" runat="server" Text="Nuevo Producto" CssClass="btn btn-primary" OnClick="btnNuevoProducto_Click" />
                    <asp:Button ID="btnExcel" runat="server" Text="Generar Excel" CssClass="btn btn-success" OnClick="btnExcel_Click" />
                    <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" CssClass="btn btn-warning" OnClick="btnPDF_Click" />
                </div>

                 <%
                     if (Request.QueryString["registro"]=="success")
                     {
                        Response.Write("<br/><div class = 'container' ><div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                      "Se ha registrado el producto de manera exitosa"+
                                      "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div></div>");
                     }
                     else if (Request.QueryString["actualizar"]=="success")
                     {
                        Response.Write("<br/><div class = 'container' ><div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                      "Se ha actualizado el producto de manera exitosa"+
                                      "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div></div>");
                     }
                     else if (Request.QueryString["eliminar"]=="success")
                     {
                        Response.Write("<br/><div class = 'container' ><div class='alert alert-success alert-dismissible fade show' role='alert'>"+
                                       "Se ha eliminado el producto de manera exitosa"+
                                       "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div></div>");
                     }
                 %>
                <br />

                <div class="container">
                     <div class="table-responsive text-center">
                        <asp:GridView ID="GvProdDisponibles" runat="server" CssClass="table table-hover" OnRowDeleting="GvProdDisponibles_RowDeleting"  OnSelectedIndexChanged="GvProdDisponibles_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/img/remove.png" ShowDeleteButton="True"   />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/clipboard.png" ShowSelectButton="True" />  
                                <asp:CommandField SelectText="Detalle" ShowSelectButton="True" />
                            </Columns>
                            <HeaderStyle CssClass="table-dark" />
                         </asp:GridView>
                    </div>
                </div>
                <br />

                <asp:Panel ID="panelRegistro" runat="server">
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
                                <asp:FileUpload ID="imgProducto" runat="server" CssClass="form-control"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Image ID="imgUsu" runat="server" CssClass="w-100"/>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm-6">
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" />
                            </div>
                            <div class="col-sm-6">
                                <asp:Button ID="btnRegistrar" runat="server" Text="Regitrar" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </section>
         <script>
            function init(){
                var inputFile = document.getElementById('ContentPlaceHolder1_imgProducto');
                inputFile.addEventListener('change',mostrarImagen,false);
                
            }
            function mostrarImagen(event){
                var file = event.target.files[0];
                var leer= new FileReader();
                leer.onload = function (event){
                    var img = document.getElementById('ContentPlaceHolder1_imgUsu');
                    img.src=event.target.result;
                }
                leer.readAsDataURL(file);
            }

            window.addEventListener('load',init,false);
            
             $(document).on("click","#ContentPlaceHolder1_imgUsu",function(){
                 $("ContentPlaceHolder1_imgProducto").click(); 
            });
        </script>
</asp:Content>