function cargarTablaLinea() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreLineaFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Linea/ListarLinea',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsLinea.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsLinea[i].IdLinea + '</td>';
                rows += '<td>' + data.lsLinea[i].NombreLinea + '</td>';
                rows += '<td>' + data.lsLinea[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsLinea[i].UsuarioCreacion + '</td>';
                if (data.lsLinea[i].EstadoLinea) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsLinea[i].IdLinea + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsLinea[i].IdLinea + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerLinea(' + data.lsLinea[i].IdLinea + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarLinea(' + data.lsLinea[i].IdLinea + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbLinea").innerHTML = rows;
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

function limpiarValoresLinea() {
    $("#NombreLinea").val('');
};

function validarLinea() {
    var NombreLinea = $("#NombreLinea").val();
    
    if (NombreLinea == '') {
        toastr.error('Se requiere del campo Nombre Linea', 'Error');
        return false;
    }
    
    return true;
};

function validarLineaEditar() {
    var NombreUnidad = $("#NombreLineaEditar").val();
    var Factor = $("#FactorLineaEditar").val();
    if (NombreUnidad == '') {
        toastr.error('Se requiere del campo Nombre Linea', 'Error');
        return false;
    }
    
    return true;
};

function agregarLinea() {
    mostrarLoader();
    if (validarLinea()) {
        var lna = {};
        lna.NombreLinea = $("#NombreLinea").val();
        
        $.ajax({
            type: "POST",
            url: "/Linea/AgregarLinea",
            data: '{lna: ' + JSON.stringify(lna) + '}',
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
                        limpiarValoresLinea();
                        cargarTablaLinea();
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

function cambiarEstado(idLinea) {
    mostrarLoader();
    var lna = {};
    lna.IdLinea = idLinea;
    $.ajax({
        type: "POST",
        url: "/Linea/CambiarEstadoLinea",
        data: '{lna: ' + JSON.stringify(lna) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaLinea();
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

function eliminarLinea(idLinea) {
    mostrarLoader();
    var lna = {};
    lna.IdLinea = idLinea;
    $.ajax({
        type: "POST",
        url: "/Linea/EliminarLinea",
        data: '{lna: ' + JSON.stringify(lna) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaLinea();
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

function obtenerLinea(idLinea) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdLinea = idLinea;
    $.ajax({
        type: "POST",
        url: "/Linea/ObtenerLineaPorId",
        data: '{lna: ' + IdLinea + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idLineaEditar").val(response.lineaCLS.IdLinea);
            $("#NombreLineaEditar").val(response.lineaCLS.NombreLinea);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
};

function editarLinea() {
    mostrarLoader();
    if (validarLineaEditar()) {
        var lna = {};
        lna.IdLinea = $("#idLineaEditar").val();
        lna.NombreLinea = $("#NombreLineaEditar").val();
        $.ajax({
            type: "POST",
            url: "/Linea/EditarLinea",
            data: '{lna: ' + JSON.stringify(lna) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaLinea();
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
};
