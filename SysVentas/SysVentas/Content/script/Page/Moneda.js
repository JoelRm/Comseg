function cargarTablaMoneda() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreMonedaFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Moneda/ListarMoneda',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsMoneda.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsMoneda[i].IdMoneda + '</td>';
                rows += '<td>' + data.lsMoneda[i].NombreMoneda + '</td>';
                rows += '<td>' + data.lsMoneda[i].SimboloMoneda + '</td>';
                rows += '<td>' + data.lsMoneda[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsMoneda[i].UsuarioCreacion + '</td>';
                if (data.lsMoneda[i].EstadoMoneda) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsMoneda[i].IdMoneda + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsMoneda[i].IdMoneda + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerMoneda(' + data.lsMoneda[i].IdMoneda + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarMoneda(' + data.lsMoneda[i].IdMoneda + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbMoneda").innerHTML = rows;
            $('#modalFiltros').modal('hide');
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

function limpiarValoresMoneda() {
    $("#NombreMoneda").val('');
    $("#SimboloMoneda").val('');
};

function validarMoneda() {
    var NombreMoneda = $("#NombreMoneda").val();
    var SimboloMoneda = $("#SimboloMoneda").val();
    if (NombreMoneda == '') {
        toastr.error('Se requiere del campo Nombre Moneda', 'Error');
        return false;
    }
    if (SimboloMoneda == '') {
        toastr.error('Se requiere del campo Simbolo Moneda', 'Error');
        return false;
    }
    return true;
};

function validarMonedaEditar() {
    var NombreMoneda = $("#NombreMonedaEditar").val();
    var SimboloMoneda = $("#SimboloMonedaEditar").val();
    if (NombreMoneda == '') {
        toastr.error('Se requiere del campo Nombre Moneda', 'Error');
        return false;
    }
    if (SimboloMoneda == '') {
        toastr.error('Se requiere del campo SimboloMOneda', 'Error');
        return false;
    }
    return true;
}

function abrirFiltros() {
    $('#modalFiltros').modal('show');
};

function agregarMoneda() {
    mostrarLoader();
    if (validarMoneda()) {
        var mod = {};
        mod.NombreMoneda = $("#NombreMoneda").val();
        mod.SimboloMoneda = $("#SimboloMoneda").val();
        $.ajax({
            type: "POST",
            url: "/Moneda/AgregarMoneda",
            data: '{mod: ' + JSON.stringify(mod) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 2) {
                    toastr.error('Ya existen registros con un nombre similar, intente otro', 'Error');
                    ocultarLoader();
                }
                else {
                    if (response.Code == 1) {
                        $('#modal-nuevo').modal('hide');
                        limpiarValoresMoneda();
                        cargarTablaMoneda();
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

function cambiarEstado(idMoneda) {
    mostrarLoader();
    var mod = {};
    mod.IdMoneda = idMoneda;
    $.ajax({
        type: "POST",
        url: "/Moneda/CambiarEstadoMoneda",
        data: '{mod: ' + JSON.stringify(mod) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaMoneda();
                ocultarLoader();
            }
            else {
                toastr.error('Ocurrió un error al realizar el cambio de estado, inténtelo de nuevo', 'Error');
                ocultarLoader();
            }
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function eliminarMoneda(idMoneda) {
    mostrarLoader();
    var mod = {};
    mod.IdMoneda = idMoneda;
    $.ajax({
        type: "POST",
        url: "/Moneda/EliminarMoneda",
        data: '{mod: ' + JSON.stringify(mod) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaMoneda();
                ocultarLoader();
            }
            else {
                toastr.error('Ocurrió un error al realizar la eliminación, inténtelo de nuevo', 'Error');
                ocultarLoader();
            }
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function obtenerMoneda(idMoneda) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdMoneda = idMoneda;
    $.ajax({
        type: "POST",
        url: "/Moneda/ObtenerMonedaPorId",
        data: '{mod: ' + IdMoneda + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idMonedaEditar").val(response.MonedaCLS.IdMoneda);
            $("#NombreMonedaEditar").val(response.MonedaCLS.NombreMoneda);
            $("#SimboloMonedaEditar").val(response.MonedaCLS.SimboloMoneda);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function editarMoneda() {
    mostrarLoader();
    if (validarMonedaEditar()) {
        var mod = {};
        mod.IdMoneda = $("#idMonedaEditar").val();
        mod.NombreMoneda = $("#NombreMonedaEditar").val();
        mod.SimboloMoneda = $("#SimboloMonedaEditar").val();
        $.ajax({
            type: "POST",
            url: "/Moneda/EditarMoneda",
            data: '{mod: ' + JSON.stringify(mod) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaMoneda();
                    $('#modalEditar').modal('hide');
                    ocultarLoader();
                }
                else {
                    toastr.error('Error al agregar los datos', 'Error');
                    ocultarLoader();
                }
            },
            error: function () {
                toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
                ocultarLoader();
            }
        });
    }
    ocultarLoader();
}
