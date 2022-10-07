var Http = (function () {
    function Http() {
    }
    Http.get = function (url, callBack) {
        requestServer(url, "get", callBack);
    }
    Http.getBytes = function (url, callBack) {
        requestServer(url, "get", callBack, null, "arraybuffer");
    }
    Http.post = function (url, callBack, data) {
        requestServer(url, "post", callBack, data);
    }
    function requestServer(url, metodoHttp, callBack, data, tipoRpta) {
        var xhr = new XMLHttpRequest();
        xhr.open(metodoHttp, hdfRaiz.value + url);
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
})();

var GUI = (function () {
    function GUI() {
    }
    GUI.Combo = function (cbo, lista, primerItem) {
        var html = "";
        if (primerItem != null) {
            html += "<option value=''>";
            html += primerItem;
            html += "</option>";
        }
        var nRegistros = lista.length;
        var campos = [];
        for (var i = 0; i < nRegistros; i++) {
            campos = lista[i].split("|");
            html += "<option value='";
            html += campos[0];
            html += "'>";
            html += campos[1];
            html += "</option>";
        }
        cbo.innerHTML = html;
    }

    GUI.Grilla = function (div, lista, id, botones, mensajeRegistros) {
        var matriz = [];
        var nRegistros = lista.length;
        var nCampos;
        botones = (botones == null ? [] : botones);
        var nBotones = botones.length;

        iniciarGrilla();

        function iniciarGrilla() {
            crearTabla();
            crearMatriz();
            mostrarMatriz();
        }

        function crearTabla() {
            var html = "<div class='Mensaje'>";
            html += "<span>";
            html += mensajeRegistros;
            html += "</span>&nbsp;";
            html += "<span id='spnTotal";
            html += id;
            html += "'></span>";
            html += "</div>";
            html += "<table>";
            var cabeceras = lista[0].split("|");
            var anchos = lista[1].split("|");
            nCampos = cabeceras.length;
            html += "<thead>";
            html += "<tr class='FilaCabecera ";
            html += id;
            html += "'>";
            for (var j = 0; j < nCampos; j++) {
                html += "<th style='width:";
                html += (+anchos[j]);
                html += "px'>";
                html += cabeceras[j];
                html += "</th>";
            }
            if (nBotones > 0) {
                for (var j = 0; j < nBotones; j++) {
                    html += "<th style='width:100px'>";
                    html += botones[j].cabecera;
                    html += "</th>";
                }
            }
            html += "</tr>";
            html += "</thead>";
            html += "<tbody id='tbData";
            html += id;
            html += "'>";
            html += "</tbody>";
            html += "</table>"
            div.innerHTML = html;
        }

        function crearMatriz() {
            matriz = [];
            var campos = [];
            var fila = [];
            for (var i = 3; i < nRegistros; i++) {
                campos = lista[i].split("|");
                fila = [];
                for (var j = 0; j < nCampos; j++) {
                    if (campos[j] == "") fila.push("");
                    else {
                        if (isNaN(campos[j])) fila.push(campos[j]);
                        else fila.push(+campos[j]);
                    }
                }
                matriz.push(fila);
            }
        }

        function mostrarMatriz() {
            var html = "";
            var nRegMatriz = matriz.length;
            for (var i = 0; i < nRegMatriz; i++) {
                html += "<tr class='FilaDatos ";
                html += id;
                html += "'>";
                for (var j = 0; j < nCampos; j++) {
                    html += "<td>";
                    html += matriz[i][j];
                    html += "</td>";
                }
                if (nBotones > 0) {
                    for (var j = 0; j < nBotones; j++) {
                        html += "<td>";
                        html += "<button class='BotonGrilla ";
                        html += id;
                        html += "'>";
                        html += botones[j].texto;
                        html += "</button>";
                        html += "</td>";
                    }
                }
                html += "</tr>";
            }
            var tbData = document.getElementById("tbData" + id);
            if (tbData != null) tbData.innerHTML = html;
            var spTotal = document.getElementById("spnTotal" + id);
            if (spTotal != null) spTotal.innerHTML = matriz.length;
            if (nBotones > 0) configurarBotones();
        }

        function configurarBotones() {
            var btns = document.getElementsByClassName("BotonGrilla " + id);
            var nBtns = btns.length;
            for (var j = 0; j < nBtns; j++) {
                btns[j].onclick = function () {
                    var fila = this.parentNode.parentNode;
                    var idRegistro = fila.childNodes[0].innerText;
                    seleccionarBoton(id, idRegistro, this.innerText);
                }
            }
        }
    }
    return GUI;
})();

var Validacion = (function () {
    function Validacion() {
    }
    Validacion.ValidarRequeridos = function (claseReq, span) {
        if (claseReq == null) claseReq = "R";
        if (span == null) span = spnMensaje
        var controles = document.getElementsByClassName(claseReq);
        var nControles = controles.length;
        var c = 0;
        for (var i = 0; i < nControles; i++) {
            if (controles[i].value == "") {
                controles[i].style.borderColor = "red";
                c++;
            }
            else {
                controles[i].style.borderColor = "";
            }
        }
        if (c > 0) span.innerHTML = "Los campos en Borde Rojo son Requeridos";
        else span.innerHTML = "";
        return(c == 0);
    }
    Validacion.ValidarNumeros = function (claseNum, span) {
        if (claseNum == null) claseNum = "N";
        if (span == null) span = spnMensaje
        var controles = document.getElementsByClassName(claseNum);
        var nControles = controles.length;
        var c = 0;
        for (var i = 0; i < nControles; i++) {
            if (isNaN(controles[i].value)) {
                controles[i].style.borderColor = "blue";
                c++;
            }
            else {
                controles[i].style.borderColor = "";
            }
        }
        if (c > 0) span.innerHTML = "Los campos en Borde Azul son Numeros";
        else span.innerHTML = "";
        return (c == 0);
    }
    Validacion.ObtenerDatos = function (claseGrab) {
        var data = "";
        if (claseGrab == null) claseGrab = "G";
        var controles = document.getElementsByClassName(claseGrab);
        var nControles = controles.length;
        
        for (var i = 0; i < nControles; i++) {
            data += controles[i].value;
            if (i < nControles-1) data += "|";
        }
        return (data);
    }
    Validacion.LimpiarDatos = function (claseBorrar) {
        if (claseBorrar == null) claseBorrar = "R";
        var controles = document.getElementsByClassName(claseBorrar);
        var nControles = controles.length;
        for (var i = 0; i < nControles; i++) {
            controles[i].value = "";
        }
    }
    return Validacion;
})();