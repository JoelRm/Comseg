function cargarTablaProducto() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreProductoFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Producto/ListarProducto',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsProducto.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsProducto[i].IdProducto + '</td>';
                rows += '<td>' + data.lsProducto[i].NombreProducto + '</td>';
                rows += '<td>' + data.lsProducto[i].NombreProveedor + '</td>';
                rows += '<td>' + data.lsProducto[i].NombreLinea + '</td>';
                rows += '<td>' + data.lsProducto[i].NombreMarca + '</td>';
                if (data.lsProducto[i].EstadoProducto) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsProducto[i].IdProducto + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsProducto[i].IdProducto + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerAlmacen(' + data.lsProducto[i].IdProducto + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarAlmacen(' + data.lsProducto[i].IdProducto + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbProducto").innerHTML = rows;
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
    $("#nombreLineaNuevo").val(nombreLinea);
    $("#idLineaNuevo").val(idLinea);
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
    $("#nombreMarcaNuevo").val(nombreMarca);
    $("#idMarcaNuevo").val(idMarca);
    document.getElementById("divPredictivoMarca").style.display = "none";
    ocultarLoader();
};

function buscarProveedor() {
    var txt = $("#ProveedorProdNuevo").val();
    if (txt.length >= 3) {
        mostrarLoader();
        var fil = {};
        fil.Nombre = txt;
        fil.Estado = 1;
        document.getElementById("divPredictivoProveedor").style.display = "block";

        var li = "";
        $.ajax({
            type: 'POST',
            url: '/Producto/ListarProveedor',
            data: '{fil: ' + JSON.stringify(fil) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                for (var i = 0; i < data.lsProveedor.length; i++) {
                    li += '<li class="liPredictivo" role="presentation">';
                    li += '<div onclick="seleccionarProveedor(\'' + data.lsProveedor[i].NombreProveedor + '\',' + data.lsProveedor[i].IdProveedor + ');" class="lidivPredictivo">' + data.lsProveedor[i].NombreProveedor + '</div>';
                    li += '</li>';
                }
                document.getElementById("ulPredictivoProveedorJRM").innerHTML = li;
                ocultarLoader();
            }
        });

    } else {
        document.getElementById("divPredictivoProveedor").style.display = "none";
        ocultarLoader();
    }
};

function seleccionarProveedor(nombreProveedor, idProveedor) {
    $("#ProveedorProdNuevo").val(nombreProveedor);
    $("#nombreProveedorNuevo").val(nombreProveedor);
    $("#idProveedorNuevo").val(idProveedor);
    document.getElementById("divPredictivoProveedor").style.display = "none";
    ocultarLoader();
};

function agregarProducto() {

    mostrarLoader();
    if (validarProducto()) {
        var prod = {};
        prod.CodigoProducto = $("#codProductoNuevo").val();
        prod.NombreProducto = $("#nombreProductoNuevo").val();
        prod.IdLinea = $("#idLineaNuevo").val();
        prod.IdMarca = $("#idMarcaNuevo").val();
        prod.IdMoneda = $("#idMonedaNuevo").val();
        prod.IdImpuesto = $("#idImpuestoNuevo").val();
        prod.IdProveedor = $("#idProveedorNuevo").val();

        var validadorCountFilasAlm = document.getElementById('bodytbProductoAlmacen');
        var validadorCountFilasUnd = document.getElementById('bodytbProductoUnidad');

        var almacenes = "";
        for (var i = 0; i < validadorCountFilasAlm.rows.length; i++) {
            var IdAlm = validadorCountFilasAlm.rows[i].cells[4].innerText;
            var IdSuc = validadorCountFilasAlm.rows[i].cells[5].innerText;
            var Esta = document.getElementById("chkEstaAlm" + IdAlm).checked;

            if (almacenes == "") {
                almacenes += IdAlm + "," + IdSuc + "," + Esta;
            } else {
                almacenes += "|" + IdAlm + "," + IdSuc + "," + Esta;
            }
        }

        var unidades = "";
        for (var i = 0; i < validadorCountFilasUnd.rows.length; i++) {
            var idUnd = validadorCountFilasUnd.rows[i].cells[6].innerText;
            var base = document.getElementById("chkBase" + idUnd).checked;
            var Vent = document.getElementById("chkVent" + idUnd).checked;
            var Esta = document.getElementById("chkEsta" + idUnd).checked;

            if (unidades == "") {
                unidades += idUnd + "," + base + "," + Vent + "," + Esta;
            } else {
                unidades += "|" + idUnd + "," + base + "," + Vent + "," + Esta;
            }
        }

        prod.CadenaAlm = almacenes;
        prod.CadenaUnd = unidades;

        $.ajax({
            type: "POST",
            url: "/Producto/AgregarProducto",
            data: '{prod: ' + JSON.stringify(prod) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 2) {
                    toastr.error('Ya existen registros con un nombre similar, intente otro', 'Error');
                    ocultarLoader();
                }
                else {
                    if (response.Code == 1) {
                        $('#modalNuevoProducto').modal('hide');
                        //limpiarValoresAlmacen();
                        cargarTablaProducto();
                        toastr.success('Se agregaron los datos correctamente', 'Éxito');
                        ocultarLoader();
                    }
                    else {
                        toastr.error('Error al agregar los datos', 'Error');
                        ocultarLoader();
                    }
                }
            },
            error: function () {
                toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
                ocultarLoader();
            }
        });
    }
    ocultarLoader();
};

function validarProducto() {

    var validadorCountFilasProv = document.getElementById('bodytbProductoAlmacen');
    var validadorCountFilas = document.getElementById('bodytbProductoUnidad');
    var CodigoProducto = $("#codProductoNuevo").val();
    var NombreProducto = $("#nombreProductoNuevo").val();
    var IdLinea = $("#idLineaNuevo").val();
    var IdMarca = $("#idMarcaNuevo").val();
    var IdMoneda = $("#idMonedaNuevo").val();
    var IdImpuesto = $("#idImpuestoNuevo").val();
    var IdProveedor = $("#idProveedorNuevo").val();

    if (validarFilasProductoUnidad() == false || validadorCountFilas.rows.length == 0  ) {
        toastr.error('Se necesita que almenos haya 1 unidad asociada al producto', 'Error');
        return false;
    }
    if (validarFilasProductoAlmacen() == false || validadorCountFilasProv.rows.length == 0) {
        toastr.error('Se necesita que almenos haya 1 almacén asociado al producto', 'Error');
        return false;
    }
    if (CodigoProducto == '') {
        toastr.error('Se requiere del campo Código Producto', 'Error');
        return false;
    }
    if (NombreProducto == '') {
        toastr.error('Se requiere del campo Nombre Producto', 'Error');
        return false;
    }
    if (IdLinea == '') {
        toastr.error('Se requiere del campo Linea', 'Error');
        return false;
    }
    if (IdMarca == '') {
        toastr.error('Se requiere del campo Marca', 'Error');
        return false;
    }
    if (IdMoneda == '0') {
        toastr.error('Se requiere que seleccione un tipo de moneda', 'Error');
        return false;
    }
    if (IdImpuesto == '0') {
        toastr.error('Se requiere que seleccione un Tipo de Impuesto', 'Error');
        return false;
    }
    if (IdProveedor == '0') {
        toastr.error('Se requiere del campo Proveedor', 'Error');
        return false;
    }

    return true;
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
        var validadorCountFilas = document.getElementById('bodytbProductoUnidad');

        if (validadorPrimeraFila == "Agregue unidades") {
            document.getElementById("bodytbProductoUnidad").innerHTML = "";
        }
        for (var i = 0; i < arrayDeCadenas.length; i++) {
            arrayDeCadenas2 = arrayDeCadenas[i].split('|');

            if (validadorCountFilas.rows.length == 0) {
                $("#row" + arrayDeCadenas2[0]).remove();
                rows += '<tr>';
                rows += '<td>' + arrayDeCadenas2[1] + '</td>';
                rows += '<td>' + arrayDeCadenas2[2] + '</td>';
                rows += '<td><input type="checkbox" class="custom-control-input" id="chkBase' + arrayDeCadenas2[0] + '" checked></td>';
                rows += '<td><input type="checkbox" class="custom-control-input" id="chkVent' + arrayDeCadenas2[0] + '" checked></td>';
                rows += '<td><input type="checkbox" class="custom-control-input" id="chkEsta' + arrayDeCadenas2[0] + '" checked></td>';
                rows += '<td><span  title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Quitar</span></td>';
                rows += '<td style="display:none">' + arrayDeCadenas2[0] + '</td>';
                rows += '</tr>';
            } else {
                $("#row" + arrayDeCadenas2[0]).remove();
                rows += '<tr>';
                rows += '<td>' + arrayDeCadenas2[1] + '</td>';
                rows += '<td>' + arrayDeCadenas2[2] + '</td>';
                rows += '<td><input type="checkbox" class="custom-control-input" id="chkBase' + arrayDeCadenas2[0] + '"></td>';
                rows += '<td><input type="checkbox" class="custom-control-input" id="chkVent' + arrayDeCadenas2[0] + '"></td>';
                rows += '<td><input type="checkbox" class="custom-control-input" id="chkEsta' + arrayDeCadenas2[0] + '" checked></td>';
                rows += '<td><span  title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Quitar</span></td>';
                rows += '<td style="display:none">' + arrayDeCadenas2[0] + '</td>';
                rows += '</tr>';
            }
            
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
                rows += '<td style="display:none">' + data.lsAlmacen[i].IdSucursal + '</td>';
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
        var idSucursal = document.getElementById('bodytbAlmacen').rows[i].cells[4].innerText;
        if (document.getElementById("chkAlm" + idAlmacen).checked) {
            if (eliminate == "") {
                eliminate += idAlmacen + "|" + sucursal + "|" + almacen + "|" + idSucursal;
            } else {
                eliminate += "," + idAlmacen + "|" + sucursal + "|" + almacen + "|" + idSucursal;
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
            rows += '<td><input type="checkbox" class="custom-control-input" id="chkEstaAlm' + arrayDeCadenas2[0] + '" checked></td>';
            rows += '<td><span  title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Quitar</span></td>';
            rows += '<td style="display:none">' + arrayDeCadenas2[0] + '</td>';
            rows += '<td style="display:none">' + arrayDeCadenas2[3] + '</td>';
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