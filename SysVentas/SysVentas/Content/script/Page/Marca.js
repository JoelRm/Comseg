function cargarTablaMarca() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreMarcaFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Marca/ListaMarca',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsMarca.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsMarca[i].IdMarca + '</td>';
                rows += '<td>' + data.lsMarca[i].NombreMarca + '</td>';
                rows += '<td>' + data.lsMarca[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsMarca[i].UsuarioCreacion + '</td>';
                if (data.lsMarca[i].EstadoMarca) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsMarca[i].IdMarca + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsMarca[i].IdMarca + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerMarca(' + data.lsMarca[i].IdMarca + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarMarca(' + data.lsMarca[i].IdMarca + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbMarca").innerHTML = rows;
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

function limpiarValoresMarca() {
    $("#NombreMarca").val('');
};

function validarMarca() {
    var NombreMarca = $("#NombreMarca").val();

    if (NombreMarca == '') {
        toastr.error('Se requiere del campo Nombre Marca', 'Error');
        return false;
    }

    return true;
};

function validarMarcaEditar() {
    var NombreUnidad = $("#NombreMarcaEditar").val();

    if (NombreUnidad == '') {
        toastr.error('Se requiere del campo Nombre Marca', 'Error');
        return false;
    }

    return true;
}

function agregarMarca() {
    mostrarLoader();
    if (validarMarca()) {
        var mca = {};
        mca.NombreMarca = $("#NombreMarca").val();

        $.ajax({
            type: "POST",
            url: "/Marca/AgregarMarca",
            data: '{mca: ' + JSON.stringify(mca) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 2) {
                    toastr.error('Ya existen registros con un nombre similar, intente otro', 'Error');
                    ocultarLoader();
                }
                else {
                    if (response.Code == 1) {
                        $('#modalNuevaMarca').modal('hide');
                        limpiarValoresMarca();
                        cargarTablaMarca();
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

function cambiarEstado(idMarca) {
    mostrarLoader();
    var mca = {};
    mca.IdMarca = idMarca;
    $.ajax({
        type: "POST",
        url: "/Marca/CambiarEstadoMarca",
        data: '{mca: ' + JSON.stringify(mca) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaMarca();
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

function eliminarMarca(idMarca) {
    mostrarLoader();
    var mca = {};
    mca.IdMarca = idMarca;
    $.ajax({
        type: "POST",
        url: "/Marca/EliminarMarca",
        data: '{mca: ' + JSON.stringify(mca) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaMarca();
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

function obtenerMarca(idMarca) {
    mostrarLoader();
    $('#modalEditarMarca').modal('show');
    var IdMarca = idMarca;
    $.ajax({
        type: "POST",
        url: "/Marca/ObtenerMarcaPorId",
        data: '{mca: ' + IdMarca + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idMarcaEditar").val(response.marcaCLS.IdMarca);
            $("#NombreMarcaEditar").val(response.marcaCLS.NombreMarca);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function editarMarca() {
    mostrarLoader();
    if (validarMarcaEditar()) {
        var mca = {};
        mca.IdMarca = $("#idMarcaEditar").val();
        mca.NombreMarca = $("#NombreMarcaEditar").val();
        $.ajax({
            type: "POST",
            url: "/Marca/EditarMarca",
            data: '{mca: ' + JSON.stringify(mca) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaMarca();
                    $('#modalEditarMarca').modal('hide');
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
