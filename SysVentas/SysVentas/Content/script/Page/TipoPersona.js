function cargarTablaTipoPersona() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreTipoPersonaFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/TipoPersona/ListarTipoPersona',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsTipoPersona.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsTipoPersona[i].IdTipoPersona + '</td>';
                rows += '<td>' + data.lsTipoPersona[i].NombreTipoPersona + '</td>';
                rows += '<td>' + data.lsTipoPersona[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsTipoPersona[i].UsuarioCreacion + '</td>';
                if (data.lsTipoPersona[i].EstadoTipoPersona) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsTipoPersona[i].IdTipoPersona + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsTipoPersona[i].IdTipoPersona + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerTipoPersona(' + data.lsTipoPersona[i].IdTipoPersona + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarTipoPersona(' + data.lsTipoPersona[i].IdTipoPersona + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbTipoPersona").innerHTML = rows;
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


function limpiarValoresTipoPersona() {
    $("#NombreTipoPersona").val('');
};


function validarTipoPersona() {
    var NombreTipoPersona = $("#NombreTipoPersona").val();

    if (NombreTipoPersona == '') {
        toastr.error('Se requiere del campo Nombre TipoPersona', 'Error');
        return false;
    }

    return true;
};



function validarTipoPersonaEditar() {
    var NombreUnidad = $("#NombreTipoPersonaEditar").val();
    var Factor = $("#FactorTipoPersonaEditar").val();
    if (NombreUnidad == '') {
        toastr.error('Se requiere del campo Nombre TipoPersona', 'Error');
        return false;
    }

    return true;
}



function abrirFiltros() {
    $('#modalFiltros').modal('show');
};

function agregarTipoPersona() {
    mostrarLoader();
    if (validarTipoPersona()) {
        var per = {};
        per.NombreTipoPersona = $("#NombreTipoPersona").val();

        $.ajax({
            type: "POST",
            url: "/TipoPersona/AgregarTipoPersona",
            data: '{per: ' + JSON.stringify(per) + '}',
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
                        limpiarValoresTipoPersona();
                        cargarTablaTipoPersona();
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



function cambiarEstado(idTipoPersona) {
    mostrarLoader();
    var per = {};
    per.IdTipoPersona = idTipoPersona;
    $.ajax({
        type: "POST",
        url: "/TipoPersona/CambiarEstadoTipoPersona",
        data: '{per: ' + JSON.stringify(per) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaTipoPersona();
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



function eliminarTipoPersona(idTipoPersona) {
    mostrarLoader();
    var per = {};
    per.IdTipoPersona = idTipoPersona;
    $.ajax({
        type: "POST",
        url: "/TipoPersona/EliminarTipoPersona",
        data: '{per: ' + JSON.stringify(per) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaTipoPersona();
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



function obtenerTipoPersona(idTipoPersona) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdTipoPersona = idTipoPersona;
    $.ajax({
        type: "POST",
        url: "/TipoPersona/ObtenerTipoPersonaPorId",
        data: '{per: ' + IdTipoPersona + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idTipoPersonaEditar").val(response.TipoPersonaCLS.IdTipoPersona);
            $("#NombreTipoPersonaEditar").val(response.TipoPersonaCLS.NombreTipoPersona);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}




function editarTipoPersona() {
    mostrarLoader();
    if (validarTipoPersonaEditar()) {
        var per = {};
        per.IdTipoPersona = $("#idTipoPersonaEditar").val();
        per.NombreTipoPersona = $("#NombreTipoPersonaEditar").val();
        $.ajax({
            type: "POST",
            url: "/TipoPersona/EditarTipoPersona",
            data: '{per: ' + JSON.stringify(per) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaTipoPersona();
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
