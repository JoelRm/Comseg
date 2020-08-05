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

//INI UNIDADES
function abrirListaunidades() {
    $('#modalUnidades').modal('show');
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
                rows += '<td>' + '<input id="chk' + data.lsUnidades[i].IdUnidad + '" type="checkbox" class="custom-control-input" id="tableDefaultCheck3">' + '</td>';
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
    if (eliminate != "") {
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
            rows += '<td><input type="checkbox" class="custom-control-input" id="tableDefaultCheck3" checked></td>';
            rows += '<td><span  title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Quitar</span></td>';
            rows += '<td style="display:none">' + arrayDeCadenas2[0] + '</td>';
            rows += '</tr>';
            $('#tbProductoUnidad').append(rows);
            rows = "";
        }
        toastr.success('Se agregó con éxito', 'Éxito');
    } else {
        toastr.error('Se debe seleccionar al menos una unidad', 'Error');
    }
};
//FIN UNIDADES

//INI ALMACEN
function abrirListaAlmacenes() {
    $('#modalAlmacenes').modal('show');
    cargarAlmacenes();
}

function cargarAlmacenes() {
    mostrarLoader();
    var flt = {};
    var cadena = "";
    if (validarFilasProductoAlmacen()) {
        var tableProductoAlmacen = document.getElementById('bodytbProductoAlmacen');

        for (var i = 0; i < tableProductoAlmacen.rows.length; i++) {

            var idAlmacen = document.getElementById('bodytbProductoAlmacen').rows[i].cells[6].innerText;
            if (cadena == "") {
                cadena += idAlmacen;
            } else {
                idAlmacen += "," + idAlmacen;
            }
        }
    }


    flt.Cadena = cadena;

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Producto/ListarAlmacenes',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsAlmacen.length; i++) {
                rows += '<tr id = "rowAlm' + data.lsAlmacen[i].IdAlmacen + '">';
                rows += '<td>' + '<input id="chkAlm' + data.lsAlmacen[i].IdAlmacen + '" type="checkbox" class="custom-control-input" id="tableDefaultCheck3">' + '</td>';
                rows += '<td>' + data.lsAlmacen[i].NombreSucursal + '</td>';
                rows += '<td>' + data.lsAlmacen[i].NombreAlmacen + '</td>';
                rows += '<td style="display:none">' + data.lsAlmacen[i].IdAlmacen + '</td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbAlmacen").innerHTML = rows;
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

function validarFilasProductoAlmacen() {
    var validadorPrimeraFila = document.getElementById('bodytbProductoAlmacen').rows[0].innerText;

    if (validadorPrimeraFila == "Agregue Almacenes") {
        return false;
    }
    return true;
}

function agregarProductoAlmacen() {
    var table = document.getElementById('bodytbAlmacen');
    var eliminate = "";
    for (var i = 0; i < table.rows.length; i++) {
        var sucursal = document.getElementById('bodytbAlmacen').rows[i].cells[1].innerText;
        var almacen = document.getElementById('bodytbAlmacen').rows[i].cells[2].innerText;
        var idAlmacen = document.getElementById('bodytbAlmacen').rows[i].cells[3].innerText;
        if (document.getElementById("chkAlm" + idAlmacen).checked) {
            if (eliminate == "") {
                eliminate += idAlmacen + "|" + sucursal + "|" + almacen;
            } else {
                eliminate += "," + idAlmacen + "|" + sucursal + "|" + almacen;
            }
        }
    }
    if (eliminate != "") {
        var arrayDeCadenas = eliminate.split(',');
        var arrayDeCadenas2 = "";
        var rows = "";
        var validadorPrimeraFila = document.getElementById('bodytbProductoAlmacen').rows[0].innerText;

        if (validadorPrimeraFila == "Agregue Almacenes") {
            document.getElementById("bodytbProductoAlmacen").innerHTML = "";
        }
        for (var i = 0; i < arrayDeCadenas.length; i++) {
            arrayDeCadenas2 = arrayDeCadenas[i].split('|');
            $("#rowAlm" + arrayDeCadenas2[0]).remove();
            rows += '<tr>';
            rows += '<td>' + arrayDeCadenas2[1] + '</td>';
            rows += '<td>' + arrayDeCadenas2[2] + '</td>';
            rows += '<td><input type="checkbox" class="custom-control-input" id="tableDefaultCheck3" checked></td>';
            rows += '<td><span  title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Quitar</span></td>';
            rows += '<td style="display:none">' + arrayDeCadenas2[0] + '</td>';
            rows += '</tr>';
            $('#tbProductoAlmacen').append(rows);
            rows = "";
        }
        toastr.success('Se agregó con éxito', 'Éxito');
    } else {
        toastr.error('Se debe seleccionar al menos un Almacén', 'Error');
    }
};
//FIN ALMACEN