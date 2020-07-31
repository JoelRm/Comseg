function cargarTablaTipoTienda() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreTipoTiendaFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/TipoTienda/ListarTipoTienda',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsTipoTienda.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsTipoTienda[i].IdTipoTienda + '</td>';
                rows += '<td>' + data.lsTipoTienda[i].NombreTipoTienda + '</td>';
                rows += '<td>' + data.lsTipoTienda[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsTipoTienda[i].UsuarioCreacion + '</td>';
                if (data.lsTipoTienda[i].EstadoTipoTienda) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsTipoTienda[i].IdTipoTienda + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsTipoTienda[i].IdTipoTienda + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerTipoTienda(' + data.lsTipoTienda[i].IdTipoTienda + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarTipoTienda(' + data.lsTipoTienda[i].IdTipoTienda + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbTipoTienda").innerHTML = rows;
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


function limpiarValoresTipoTienda() {
    $("#NombreTipoTienda").val('');
};


function validarTipoTienda() {
    var NombreTipoTienda = $("#NombreTipoTienda").val();

    if (NombreTipoTienda == '') {
        toastr.error('Se requiere del campo Nombre TipoTienda', 'Error');
        return false;
    }

    return true;
};



function validarTipoTiendaEditar() {
    var NombreUnidad = $("#NombreTipoTiendaEditar").val();
    var Factor = $("#FactorTipoTiendaEditar").val();
    if (NombreUnidad == '') {
        toastr.error('Se requiere del campo Nombre TipoTienda', 'Error');
        return false;
    }

    return true;
}



function abrirFiltros() {
    $('#modalFiltros').modal('show');
};

function agregarTipoTienda() {
    mostrarLoader();
    if (validarTipoTienda()) {
        var tnd = {};
        tnd.NombreTipoTienda = $("#NombreTipoTienda").val();

        $.ajax({
            type: "POST",
            url: "/TipoTienda/AgregarTipoTienda",
            data: '{tnd: ' + JSON.stringify(tnd) + '}',
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
                        limpiarValoresTipoTienda();
                        cargarTablaTipoTienda();
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



function cambiarEstado(idTipoTienda) {
    mostrarLoader();
    var tnd = {};
    tnd.IdTipoTienda = idTipoTienda;
    $.ajax({
        type: "POST",
        url: "/TipoTienda/CambiarEstadoTipoTienda",
        data: '{tnd: ' + JSON.stringify(tnd) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaTipoTienda();
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



function eliminarTipoTienda(idTipoTienda) {
    mostrarLoader();
    var tnd = {};
    tnd.IdTipoTienda = idTipoTienda;
    $.ajax({
        type: "POST",
        url: "/TipoTienda/EliminarTipoTienda",
        data: '{tnd: ' + JSON.stringify(tnd) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaTipoTienda();
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



function obtenerTipoTienda(idTipoTienda) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdTipoTienda = idTipoTienda;
    $.ajax({
        type: "POST",
        url: "/TipoTienda/ObtenerTipoTiendaPorId",
        data: '{tnd: ' + IdTipoTienda + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idTipoTiendaEditar").val(response.TipoTiendaCLS.IdTipoTienda);
            $("#NombreTipoTiendaEditar").val(response.TipoTiendaCLS.NombreTipoTienda);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}




function editarTipoTienda() {
    mostrarLoader();
    if (validarTipoTiendaEditar()) {
        var tnd = {};
        tnd.IdTipoTienda = $("#idTipoTiendaEditar").val();
        tnd.NombreTipoTienda = $("#NombreTipoTiendaEditar").val();
        $.ajax({
            type: "POST",
            url: "/TipoTienda/EditarTipoTienda",
            data: '{tnd: ' + JSON.stringify(tnd) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaTipoTienda();
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
