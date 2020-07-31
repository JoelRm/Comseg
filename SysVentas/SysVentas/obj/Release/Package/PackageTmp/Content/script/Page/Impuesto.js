function cargarTablaImpuesto() {
    mostrarLoader();
    var flt = {};
    flt.Nombre = $("#NombreImpuestoFiltro").val();
    flt.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Impuesto/ListarImpuesto',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsImpuesto.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsImpuesto[i].IdImpuesto + '</td>';
                rows += '<td>' + data.lsImpuesto[i].NombreImpuesto + '</td>';
                rows += '<td>' + data.lsImpuesto[i].ValorImpuestoJS + '%' + '</td>';
                rows += '<td>' + data.lsImpuesto[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsImpuesto[i].UsuarioCreacion + '</td>';
                if (data.lsImpuesto[i].EstadoImpuesto) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsImpuesto[i].IdImpuesto + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsImpuesto[i].IdImpuesto + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerImpuesto(' + data.lsImpuesto[i].IdImpuesto + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarImpuesto(' + data.lsImpuesto[i].IdImpuesto + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbImpuesto").innerHTML = rows;
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

function limpiarValoresImpuesto() {
    $("#NombreImpuesto").val('');
    $("#Impuesto").val('');
};

function validarImpuesto() {
    var NombreImpuesto = $("#NombreImpuesto").val();
    var Impuesto = $("#Impuesto").val();
    if (NombreImpuesto == '') {
        toastr.error('Se requiere del campo Nombre Impuesto', 'Error');
        return false;
    }
    if (Impuesto == '') {
        toastr.error('Se requiere del campo Impuesto', 'Error');
        return false;
    }
    return true;
};

function validarImpuestoEditar() {
    var NombreImpuesto = $("#NombreImpuestoEditar").val();
    var Impuesto = $("#ImpuestoEditar").val();
    if (NombreImpuesto == '') {
        toastr.error('Se requiere del campo Nombre Impuesto', 'Error');
        return false;
    }
    if (Impuesto == '') {
        toastr.error('Se requiere del campo Impuesto', 'Error');
        return false;
    }
    return true;
}

function abrirFiltros() {
    $('#modalFiltros').modal('show');
};

function agregarImpuesto() {
    mostrarLoader();
    if (validarImpuesto()) {
        var imp = {};
        imp.NombreImpuesto = $("#NombreImpuesto").val();
        imp.ValorImpuestoJS = $("#Impuesto").val();
        $.ajax({
            type: "POST",
            url: "/Impuesto/AgregarImpuesto",
            data: '{imp: ' + JSON.stringify(imp) + '}',
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
                        limpiarValoresImpuesto();
                        cargarTablaImpuesto();
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

function cambiarEstado(idImpuesto) {
    mostrarLoader();
    var imp = {};
    imp.IdImpuesto = idImpuesto;
    $.ajax({
        type: "POST",
        url: "/Impuesto/CambiarEstado",
        data: '{imp: ' + JSON.stringify(imp) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaImpuesto();
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

function eliminarImpuesto(idImpuesto) {
    mostrarLoader();
    var imp = {};
    imp.IdImpuesto = idImpuesto;
    $.ajax({
        type: "POST",
        url: "/Impuesto/EliminarImpuesto",
        data: '{imp: ' + JSON.stringify(imp) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaImpuesto();
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

function obtenerImpuesto(idImpuesto) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdImpuesto = idImpuesto;
    $.ajax({
        type: "POST",
        url: "/Impuesto/ObtenerImpuestoPorId",
        data: '{imp: ' + IdImpuesto + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idImpuestoEditar").val(response.ImpuestoCLS.IdImpuesto);
            $("#NombreImpuestoEditar").val(response.ImpuestoCLS.NombreImpuesto);
            $("#ImpuestoEditar").val(response.ImpuestoCLS.ValorImpuestoJS);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function editarImpuesto() {
    mostrarLoader();
    if (validarImpuestoEditar()) {
        var imp = {};
        imp.IdImpuesto = $("#idImpuestoEditar").val();
        imp.NombreImpuesto = $("#NombreImpuestoEditar").val();
        imp.ValorImpuestoJS = $("#ImpuestoEditar").val();
        $.ajax({
            type: "POST",
            url: "/Impuesto/EditarImpuesto",
            data: '{imp: ' + JSON.stringify(imp) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaImpuesto();
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
