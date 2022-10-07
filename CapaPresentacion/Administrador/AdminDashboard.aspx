<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="CapaPresentacion.Administrador.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="../css/adminDashboard.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-section">
                <div class="home-content">
                    <i class="fas fa-bars"></i>
                    <span class="text">Menú</span>
                </div>     
                <div class="analitycs-section">
                    <div class="home-user-welcome">
                        <img src="profile.jpg" class="home-content-profileimg">
                        <span class="welcome-text"><b>Bienvenido</b>,&nbspAdministrador</span>
                    </div>
                    <br>
                    <div class="row">
                        <div class="col-sm-7">
                            <div class="analytics-content">
                                
                                <!--<span class="txtResumen">Resumen</span><br>-->
                                <div class="row analytics-content-row">
                                    <div class="col-sm-4">
                                        <div class="analytics">
                                            <span>Venta </span>
                                            <h4 id="montoVendido"></h4>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="analytics">
                                            <span>Usuarios registrados</span>
                                            <h4 id="totalUsuarios"></h4>
                                        </div>
                                    </div>
                                    <div class="col-sm-4">
                                        <div class="analytics">
                                            <span>Productos vendidos</span>
                                            <h4 id="totalProductosVendidos"></h4>
                                       </div>
                                    </div>
                                </div>
                            </div>
                            <div class="analytics-chart">
                                <div style="width: 100%;">
                                    <canvas id="myChart"></canvas>
                                </div>
                            </div>
                            <div class="table-reports">
                                <span>Reportes de stock</span><br><br>
                                <div class="table-responsive-sm">
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>Producto</th>
                                                <th>Código</th>
                                                <th>Fecha</th>
                                                <th>Precio</th>
                                                <th>Estado</th>
                                                <th>Cantidad</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>Iphone 12</td>
                                                <td>P005</td>
                                                <td>12/09/2021</td>
                                                <td>S/1250</td>
                                                <td>Stock</td>
                                                <td>10</td>
                                            </tr>
                                            <tr>
                                                <td>Iphone 12</td>
                                                <td>P005</td>
                                                <td>12/09/2021</td>
                                                <td>S/1250</td>
                                                <td>Stock</td>
                                                <td>10</td>
                                            </tr>
                                            <tr>
                                                <td>Iphone 12</td>
                                                <td>P005</td>
                                                <td>12/09/2021</td>
                                                <td>S/1250</td>
                                                <td>Stock</td>
                                                <td>10</td>
                                            </tr>          
                                        </tbody>
                                    </table>
                                </div>
                            </div>  
                        </div>
                        <div class="col-sm-5">
                            <br>
                            <div class="recent-sells">
                                <span>Productos más vendidos</span><br><br>
                                <div >
                                <table class="table table-responsive table-hover">
                                    <thead>
                                        <tr>
                                            <th>Producto</th>
                                            <th>Código</th>
                                            <th>Fecha</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                          <td>Iphone 12</td>
                                          <td>P005</td>
                                          <td>2021</td>
                                        </tr>
                                        <tr>
                                            <td>Iphone 12</td>
                                            <td>P005</td>
                                            <td>2021</td>
                                          </tr>
                                          <tr>
                                            <td>Iphone 12</td>
                                            <td>P005</td>
                                            <td>2021</td>
                                          </tr>
                                          <tr>
                                            <td>Iphone 12</td>
                                            <td>P005</td>
                                            <td>2021</td>
                                          </tr>
                                          <tr>
                                            <td>Iphone 12</td>
                                            <td>P005</td>
                                            <td>2021</td>
                                          </tr>
                                      </tbody>
                                </table>
                                </div>
                            </div>   <br>
                            <div class="analytics-chartPie">
                                <span> Categoria más comprada</span>
                                <div style="width: 100%;">
                                    <canvas id="circleChart"></canvas>
                                </div>
                            </div>    
                        </div>
                    </div>
                    <!--<div class="row">
                        <div class="col-sm-12">
                            <div style="width: 100%; background: #fff;">
                                
                                <canvas id="circleChart"></canvas>
                            </div>
                        </div>    
                    </div>-->    
                    <br><br><br>
                </div>
        <h1 id="catLaptops"></h1>
        <h1 id="catComputadoras"></h1>
        <p id="catSmartphones"></p>
        <p id="catTablets"></p>

            </section>
    <script src="../js/Consulta.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    
    <input value="<% Page.ResolveUrl("~­"); %>" name="hdfRaiz" id="hdfRaiz" hidden="true" />
    <script>
        /*var cat1 = document.getElementById("catComputadoras");
        alert(cat1);*/
     
        

        //var titulo = "Ventas";
        //const labels = [
        //    'January',
        //    'February',
        //    'March',
        //    'April',
        //    'May',
        //    'June',
        //];
        //const data = {
        //    labels: labels,
        //    datasets: [{
        //        label: titulo,
        //        backgroundColor: 'rgb(255, 99, 132)',
        //        borderColor: 'rgb(255, 99, 132)',
        //        data: [20, 10, 5, 2, 20, 1200, 45],
        //    }]
        //};
        //const config = {
        //    type: 'bar',
        //    data: data,
        //    options: {}
        //};
        //var myChart = new Chart(
        //    document.getElementById('myChart'),
        //    config
        //);

     
        //var r = 'red'
        //const dataPie = {
        //    labels: [
        //        cat1,
        //        'Blue',
        //        'Yellow'
        //    ],
        //    datasets: [{
        //        label: 'My First Dataset',
        //        data: [300, 50, 100],
        //        backgroundColor: [
        //            'rgb(255, 99, 132)',
        //            'rgb(54, 162, 235)',
        //            'rgb(255, 205, 86)'
        //        ],
        //        hoverOffset: 4
        //    }]
        //};
        //const configPie = {
        //    type: 'doughnut',
        //    data: dataPie,
        //};
        //var myChartPie = new Chart(
        //    document.getElementById('circleChart'),
        //    configPie
        //);
        
    </script>
</asp:Content>
