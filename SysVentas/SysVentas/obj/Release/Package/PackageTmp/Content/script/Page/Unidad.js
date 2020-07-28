function cargarTablaUnidades() {
    mostrarLoader();
    var flt = {};
    flt.Nombre = $("#NombreUnidadFiltro").val();
    flt.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Unidad/ListarUnidades',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsUnidades.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsUnidades[i].IdUnidad + '</td>';
                rows += '<td>' + data.lsUnidades[i].NombreUnidad + '</td>';
                rows += '<td>' + data.lsUnidades[i].Factor + '</td>';
                rows += '<td>' + data.lsUnidades[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsUnidades[i].UsuarioCreacion + '</td>';
                if (data.lsUnidades[i].EstadoUnidad) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsUnidades[i].IdUnidad +')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsUnidades[i].IdUnidad +')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerUnidad(' + data.lsUnidades[i].IdUnidad +')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarUnidad(' + data.lsUnidades[i].IdUnidad +')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbUnidad").innerHTML = rows;
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

function limpiarValoresUnidad() {
    $("#NombreUnidad").val('');
    $("#FactorUnidad").val('');
};

function validarUnidades() {
    var NombreUnidad = $("#NombreUnidad").val();
    var Factor = $("#FactorUnidad").val();
    if (NombreUnidad == '') {
        toastr.error('Se requiere del campo Nombre Unidad', 'Error');
        return false;
    }
    if (Factor == '') {
        toastr.error('Se requiere del campo Factor', 'Error');
        return false;
    }
    return true;
};

function validarUnidadesEditar() {
    var NombreUnidad = $("#NombreUnidadEditar").val();
    var Factor = $("#FactorUnidadEditar").val();
    if (NombreUnidad == '') {
        toastr.error('Se requiere del campo Nombre Unidad', 'Error');
        return false;
    }
    if (Factor == '') {
        toastr.error('Se requiere del campo Factor', 'Error');
        return false;
    }
    return true;
}

function abrirFiltros() {
    $('#modalFiltros').modal('show');
};

function agregarUnidad() {
    mostrarLoader();
    if (validarUnidades()) {
        var und = {};
        und.NombreUnidad = $("#NombreUnidad").val();
        und.Factor = $("#FactorUnidad").val();
        $.ajax({
            type: "POST",
            url: "/Unidad/AgregarUnidad",
            data: '{und: ' + JSON.stringify(und) + '}',
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
                        limpiarValoresUnidad();
                        cargarTablaUnidades();
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

function cambiarEstado(idUnidad) {
    mostrarLoader();
    var und = {};
    und.IdUnidad = idUnidad;
    $.ajax({
        type: "POST",
        url: "/Unidad/CambiarEstado",
        data: '{und: ' + JSON.stringify(und) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaUnidades();
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

function eliminarUnidad(idUnidad) {
    mostrarLoader();
    var und = {};
    und.IdUnidad = idUnidad;
    $.ajax({
        type: "POST",
        url: "/Unidad/EliminarUnidad",
        data: '{und: ' + JSON.stringify(und) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaUnidades();
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

function obtenerUnidad(idUnidad) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdUnidad = idUnidad;
    $.ajax({
        type: "POST",
        url: "/Unidad/ObtenerUnidadPorId",
        data: '{und: ' + IdUnidad + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idUnidadEditar").val(response.unidadCLS.IdUnidad);
            $("#NombreUnidadEditar").val(response.unidadCLS.NombreUnidad);
            $("#FactorUnidadEditar").val(response.unidadCLS.Factor);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function editarUnidad() {
    mostrarLoader();
    if (validarUnidadesEditar()) {
        var und = {};
        und.IdUnidad = $("#idUnidadEditar").val();
        und.NombreUnidad = $("#NombreUnidadEditar").val();
        und.Factor = $("#FactorUnidadEditar").val();
        $.ajax({
            type: "POST",
            url: "/Unidad/EditarUnidad",
            data: '{und: ' + JSON.stringify(und) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaUnidades();
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
