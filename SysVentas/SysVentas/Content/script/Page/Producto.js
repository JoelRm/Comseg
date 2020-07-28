function buscarLinea() {
    var txt = $("#lineaProdNuevo").val();
    if (txt.length >= 3) {
        mostrarLoader();
        var fil = {};
        fil.Nombre = txt;
        fil.Estado = 1;
        document.getElementById("divPredictivoLinea").style.display = "block";

        var li = "";
        $.ajax({
            type: 'POST',
            url: '/Producto/ListarLinea',
            data: '{fil: ' + JSON.stringify(fil) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                for (var i = 0; i < data.lsLinea.length; i++) {
                    li += '<li class="liPredictivo" role="presentation">';
                    li += '<div onclick="seleccionarLinea(\'' + data.lsLinea[i].NombreLinea + '\',' + data.lsLinea[i].IdLinea+');" class="lidivPredictivo">' + data.lsLinea[i].NombreLinea + '</div>';
                    li += '</li>';
                }
                document.getElementById("ulPredictivoLineaJRM").innerHTML = li;
                ocultarLoader();
            }
        });

    } else {
        document.getElementById("divPredictivoLinea").style.display = "none";
        ocultarLoader();
    }
};

function seleccionarLinea(nombreLinea,idLinea) {
    $("#lineaProdNuevo").val(nombreLinea);
    $("#nombreLinea").val(nombreLinea);
    $("#idLinea").val(idLinea);
    document.getElementById("divPredictivoLinea").style.display = "none";
    ocultarLoader();
};

function buscarMarca() {
    var txt = $("#marcaProdNuevo").val();
    if (txt.length >= 3) {
        mostrarLoader();
        var fil = {};
        fil.Nombre = txt;
        fil.Estado = 1;
        document.getElementById("divPredictivoMarca").style.display = "block";

        var li = "";
        $.ajax({
            type: 'POST',
            url: '/Producto/ListaMarca',
            data: '{fil: ' + JSON.stringify(fil) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                for (var i = 0; i < data.lsMarca.length; i++) {
                    li += '<li class="liPredictivo" role="presentation">';
                    li += '<div onclick="seleccionarMarca(\'' + data.lsMarca[i].NombreMarca + '\',' + data.lsMarca[i].IdMarca + ');" class="lidivPredictivo">' + data.lsMarca[i].NombreMarca + '</div>';
                    li += '</li>';
                }
                document.getElementById("ulPredictivoMarcaJRM").innerHTML = li;
                ocultarLoader();
            }
        });

    } else {
        document.getElementById("divPredictivoMarca").style.display = "none";
        ocultarLoader();
    }
};

function seleccionarMarca(nombreMarca, idMarca) {
    $("#marcaProdNuevo").val(nombreMarca);
    $("#nombreMarca").val(nombreMarca);
    $("#idMarca").val(idMarca);
    document.getElementById("divPredictivoMarca").style.display = "none";
    ocultarLoader();
};

function abrirListaunidades() {
    $('#ModalAgregarNombre').modal('show');
    cargarUnidades();
}

function cargarUnidades() {
    mostrarLoader();
    var flt = {};
    var cadena = "";
    if (validarFilasProductoUnidad()) {
        var tableProductoUnidad = document.getElementById('bodytbProductoUnidad');

        for (var i = 0; i < tableProductoUnidad.rows.length; i++) {

            var idUnidad = document.getElementById('bodytbProductoUnidad').rows[i].cells[6].innerText;
            if (cadena == "") {
                cadena += idUnidad;
            } else {
                cadena += "," + idUnidad;
            }
        }
    }
    

    flt.Cadena = cadena;

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Producto/ListarUnidades',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsUnidades.length; i++) {
                rows += '<tr id = "row' + data.lsUnidades[i].IdUnidad + '">';
                rows += '<td>' + '<input id="chk' + data.lsUnidades[i].IdUnidad +'" type="checkbox" class="custom-control-input" id="tableDefaultCheck3">' + '</td>';
                rows += '<td>' + data.lsUnidades[i].NombreUnidad + '</td>';
                rows += '<td>' + data.lsUnidades[i].Factor + '</td>';
                rows += '<td style="display:none">' + data.lsUnidades[i].IdUnidad + '</td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbUnidad").innerHTML = rows;
            ocultarLoader();
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
            ocultarLoader();
        }
    });
    ocultarLoader();
};

function validarFilasProductoUnidad() {
    var validadorPrimeraFila = document.getElementById('bodytbProductoUnidad').rows[0].innerText;

    if (validadorPrimeraFila == "Agregue unidades") {
        return false;
    }
    return true;
}

function agregarProductoUnidad() {
    var table = document.getElementById('bodytbUnidad');
    var eliminate = "";
    for (var i = 0; i < table.rows.length; i++) {
        var unidad = document.getElementById('bodytbUnidad').rows[i].cells[1].innerText;
        var factor = document.getElementById('bodytbUnidad').rows[i].cells[2].innerText;
        var idUnidad = document.getElementById('bodytbUnidad').rows[i].cells[3].innerText;
        if (document.getElementById("chk" + idUnidad).checked) {
            if (eliminate == "") {
                eliminate += idUnidad + "|" + unidad + "|" + factor;
            } else {
                eliminate += "," + idUnidad + "|" + unidad + "|" + factor;
            }
        }
    }

    var arrayDeCadenas = eliminate.split(',');
    var arrayDeCadenas2 = "";
    var rows = "";
    var validadorPrimeraFila = document.getElementById('bodytbProductoUnidad').rows[0].innerText;

    if (validadorPrimeraFila == "Agregue unidades") {
        document.getElementById("bodytbProductoUnidad").innerHTML = "";
    } 
    for (var i = 0; i < arrayDeCadenas.length; i++) {
        arrayDeCadenas2 = arrayDeCadenas[i].split('|');
        $("#row" + arrayDeCadenas2[0]).remove();
        rows += '<tr>';
        rows += '<td>' + arrayDeCadenas2[1] + '</td>';
        rows += '<td>' + arrayDeCadenas2[2] + '</td>';
        rows += '<td><input type="checkbox" class="custom-control-input" id="tableDefaultCheck3"></td>';
        rows += '<td><input type="checkbox" class="custom-control-input" id="tableDefaultCheck3"></td>';
        rows += '<td><input type="checkbox" class="custom-control-input" id="tableDefaultCheck3"></td>';
        rows += '<td><span  title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Quitar</span></td>';
        rows += '<td style="display:none">' + arrayDeCadenas2[0] +'</td>';
        rows += '</tr>';
        $('#tbProductoUnidad').append(rows);
        rows = "";
    }
};
