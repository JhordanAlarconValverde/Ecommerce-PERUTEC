
window.onload = function () {

    //get("AdminDashboard.aspx", prueba, "GetData");
    get("AdminDashboard.aspx", prueba, "GetData");
    /*var data = document.getElementById("data").value;
    document.getElementById("EnviarData").onclick = function () { post("AdminProdDisponibles.aspx", prueba, "PruebaPost", data) }; */

}

/*document.getElementById("btnData").onclick = function (event) {
    var data = document.getElementById("data").value;
    post("AdminProdDisponibles.aspx", printPrueba, "PruebaPost", data);
}*/

function prueba(rpta) {
    var infoHeadres = rpta.split("¬");
    var dataInfo = infoHeadres[0].split("¦");
    var totalUsuarios = dataInfo[0];
    var totalVenta = dataInfo[1];
    var montoVendido = "S/." + dataInfo[2];

    var Categorias = infoHeadres[1].split("¦");
    var catLaptops = Categorias[0].toString();
    var catComputadoras = Categorias[1].toString();
    var catSmartphones = Categorias[2].toString();
    var catTablets = Categorias[3].toString();

    document.getElementById("montoVendido").innerHTML = montoVendido;
    document.getElementById("totalUsuarios").innerHTML = totalUsuarios;
    document.getElementById("totalProductosVendidos").innerHTML = totalVenta;

    /*document.getElementById("catLaptops").innerHTML = catLaptops;
    document.getElementById("catComputadoras").innerHTML = catComputadoras;
    document.getElementById("catSmartphones").innerHTML = catSmartphones;
    document.getElementById("catTablets").innerHTML = catTablets;*/

    var titulo = "Ventas";
    const labels = [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
    ];
    const data = {
        labels: labels,
        datasets: [{
            label: titulo,
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: [20, 10, 5, 2, 20, 1200, 45],
        }]
    };
    const config = {
        type: 'bar',
        data: data,
        options: {}
    };
    var myChart = new Chart(
        document.getElementById('myChart'),
        config
    );

    const dataPie = {
        labels: [
            catLaptops,
            catComputadoras,
            catSmartphones,
            catTablets
        ],
        datasets: [{
            label: 'My First Dataset',
            data: [300, 50, 100,50],
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(54, 162, 235)',
                'rgb(255, 205, 86)',
                'rgb(255, 100, 86)'
            ],
            hoverOffset: 4
        }]
    };
    const configPie = {
        type: 'doughnut',
        data: dataPie,
    };
    var myChartPie = new Chart(
        document.getElementById('circleChart'),
        configPie
    );




}

var get = function (url, callBack, metodoServidor) {
    requestServer(url, "get", callBack, metodoServidor);
}

var post = function(url, callBack, metodoServidor,data) {
    requestServer(url, "post", callBack, metodoServidor,data);
}

function requestServer(url, metodoHttp, callBack ,metodoServidor,data) {
    var xhr = new XMLHttpRequest();
    xhr.open(metodoHttp, hdfRaiz.value + url);
    xhr.setRequestHeader("xhr", metodoServidor);
    //if (tipoRpta != null) xhr.responseType = tipoRpta;
    xhr.onreadystatechange = function () {
        if (xhr.status == 200 && xhr.readyState == 4) {
            //if (tipoRpta != null) callBack(xhr.response);
            callBack(xhr.responseText);
        }
    }
    if (data != null) xhr.send(data);
    else xhr.send();
}










/*var Http = (function () {
    function Http() {
    }
    Http.get = function (url, callBack, metodoServidor) {
        requestServer(url, "get", callBack, metodoServidor);
    }
    Http.getBytes = function (url, callBack) {
        requestServer(url, "get", callBack, null, "arraybuffer");
    }
    Http.post = function (url, callBack, metodoServidor ,data) {
        requestServer(url, "post", callBack, metodoServidor ,data);
    }
    function requestServer(url, metodoHttp, callBack,metodoServidor ,data, tipoRpta) {
        var xhr = new XMLHttpRequest();
        xhr.open(metodoHttp, hdfRaiz.value + url);
        xhr.setRequestHeader("xhr", metodoServidor);
        if (tipoRpta != null) xhr.responseType = tipoRpta;
        xhr.onreadystatechange = function () {
            if (xhr.status == 200 && xhr.readyState == 4) {
                if (tipoRpta != null) callBack(xhr.response);
                else callBack(xhr.responseText);
            }
        }
        if (data != null) xhr.send(data);
        else xhr.send();
    }
    return Http;
})();*/


/*if (rpta) {
    var lista = rpta.split("¬");
    GUI.Grilla(divProducto, lista, "prod", null, "Numero de Productos:");
}*/