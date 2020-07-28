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
    flt.Nombre = "";
    flt.Estado = "";

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Producto/ListarUnidades',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsUnidades.length; i++) {
                rows += '<tr>';
                rows += '<td>' + '<input type="checkbox" class="custom-control-input" id="tableDefaultCheck3">' + '</td>';
                rows += '<td>' + data.lsUnidades[i].NombreUnidad + '</td>';
                rows += '<td>' + data.lsUnidades[i].Factor + '</td>';
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
