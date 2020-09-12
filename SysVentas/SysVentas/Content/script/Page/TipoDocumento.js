function cargarTablaTipoDocumento() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreTipoDocumentoFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/TipoDocumento/ListaTipoDocumento',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsTipoDocumento.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsTipoDocumento[i].IdTipoDocumento + '</td>';
                rows += '<td>' + data.lsTipoDocumento[i].AbreviacionTipoDocumento + '</td>';
                rows += '<td>' + data.lsTipoDocumento[i].LongitudTipoDocumento + '</td>';
                rows += '<td>' + data.lsTipoDocumento[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsTipoDocumento[i].UsuarioCreacion + '</td>';
                if (data.lsTipoDocumento[i].EstadoTipoDocumento) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsTipoDocumento[i].IdTipoDocumento + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsTipoDocumento[i].IdTipoDocumento + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerTipoDocumento(' + data.lsTipoDocumento[i].IdTipoDocumento + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarTipoDocumento(' + data.lsTipoDocumento[i].IdTipoDocumento + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbTipoDocumento").innerHTML = rows;
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

function agregarTipoDocumento() {

    mostrarLoader();
    if (validarTipoDocumento()) {
        var tipoD = {};
        tipoD.DescripcionTipoDocumento = $("#DescripcionTipoDocumento").val();
        tipoD.AbreviacionTipoDocumento = $("#AbreviacionTipoDocumento").val();
        tipoD.LongitudTipoDocumento = $("#LongitudTipoDocumento").val();
        
        $.ajax({
            type: "POST",
            url: "/TipoDocumento/AgregarTipoDocumento",
            data: '{tipoD: ' + JSON.stringify(tipoD) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 2) {
                    toastr.error('Ya existen registros con un nombre similar, intente otro', 'Error');
                    ocultarLoader();
                }
                else {
                    if (response.Code == 1) {
                        $('#modalnuevoTipoDocumento').modal('hide');
                        //limpiarValoresAlmacen();
                        cargarTablaTipoDocumento();
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

function validarTipoDocumento() {

    var DescripcionTipoDocumento = $("#DescripcionTipoDocumento").val();
    var AbreviacionTipoDocumento = $("#AbreviacionTipoDocumento").val();
    var LongitudTipoDocumento = $("#LongitudTipoDocumento").val();

    if (DescripcionTipoDocumento == '') {
        toastr.error('Se requiere del campo Descripción Tipo Documento', 'Error');
        return false;
    }
    if (AbreviacionTipoDocumento == '') {
        toastr.error('Se requiere del campo Abreviación Tipo Documento', 'Error');
        return false;
    }
    if (LongitudTipoDocumento == '') {
        toastr.error('Se requiere del campo Longitud Tipo Documento', 'Error');
        return false;
    }

    return true;
};

function obtenerTipoDocumento(idTipoDocumento) {
    mostrarLoader();
    $('#modalEditarTipoDocumento').modal('show');
    var IdTipoDocumento = idTipoDocumento;
    $.ajax({
        type: "POST",
        url: "/TipoDocumento/ObtenerTipoDocumentoPorId",
        data: '{tipoDoc: ' + IdTipoDocumento + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#DescripcionTipoDocumentoEditar").val(response.tipoDocCLS.DescripcionTipoDocumento);
            $("#AbreviacionTipoDocumentoEditar").val(response.tipoDocCLS.AbreviacionTipoDocumento);
            $("#LongitudTipoDocumentoEditar").val(response.tipoDocCLS.LongitudTipoDocumento);
            $("#idTipoDocumentoEditar").val(response.tipoDocCLS.IdTipoDocumento);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
};

function editarTipoDocumento() {
    mostrarLoader();
    if (validarTipoDocumentoEditar()) {
        var tipoD = {};
        tipoD.IdTipoDocumento = $("#idTipoDocumentoEditar").val();
        tipoD.DescripcionTipoDocumento = $("#DescripcionTipoDocumentoEditar").val();
        tipoD.AbreviacionTipoDocumento = $("#AbreviacionTipoDocumentoEditar").val();
        tipoD.LongitudTipoDocumento = $("#LongitudTipoDocumentoEditar").val();

        $.ajax({
            type: "POST",
            url: "/TipoDocumento/EditarTipoDocumento",
            data: '{tipoD: ' + JSON.stringify(tipoD) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaTipoDocumento();
                    $('#modalEditarTipoDocumento').modal('hide');
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
};

function validarTipoDocumentoEditar() {

    var DescripcionTipoDocumento = $("#DescripcionTipoDocumentoEditar").val();
    var AbreviacionTipoDocumento = $("#AbreviacionTipoDocumentoEditar").val();
    var LongitudTipoDocumento = $("#LongitudTipoDocumentoEditar").val();

    if (DescripcionTipoDocumento == '') {
        toastr.error('Se requiere del campo Descripción Tipo Documento', 'Error');
        return false;
    }
    if (AbreviacionTipoDocumento == '') {
        toastr.error('Se requiere del campo Abreviación Tipo Documento', 'Error');
        return false;
    }
    if (LongitudTipoDocumento == '') {
        toastr.error('Se requiere del campo Longitud Tipo Documento', 'Error');
        return false;
    }

    return true;
};

function cambiarEstado(idTipoDocumento) {
    mostrarLoader();
    var tipoD = {};
    tipoD.IdTipoDocumento = idTipoDocumento;
    $.ajax({
        type: "POST",
        url: "/TipoDocumento/CambiarEstadoTipoDocumento",
        data: '{tipoD: ' + JSON.stringify(tipoD) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaTipoDocumento();
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
};

function eliminarTipoDocumento(idTipoDocumento) {
    mostrarLoader();
    var tipoD = {};
    tipoD.IdTipoDocumento = idTipoDocumento;
    $.ajax({
        type: "POST",
        url: "/TipoDocumento/EliminarTipoDocumento",
        data: '{tipoD: ' + JSON.stringify(tipoD) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaTipoDocumento();
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
};