function cargarTablaSucursales() {
    mostrarLoader();
    var flt = {};
    flt.Nombre = $("#NombreSucursalFiltro").val();
    flt.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Sucursal/ListarSucursales',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsSucursales.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsSucursales[i].IdSucursal + '</td>';
                rows += '<td>' + data.lsSucursales[i].NombreSucursal + '</td>';
                rows += '<td>' + data.lsSucursales[i].NombreTipoTienda + '</td>';
                rows += '<td>' + data.lsSucursales[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsSucursales[i].UsuarioCreacion + '</td>';
                if (data.lsSucursales[i].EstadoSucursal) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsSucursales[i].IdSucursal + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsSucursales[i].IdSucursal + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerSucursal(' + data.lsSucursales[i].IdSucursal + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarSucursal(' + data.lsSucursales[i].IdSucursal + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbSucursal").innerHTML = rows;
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

function limpiarValoresSucursal() {
    $("#NombreSucursal").val('');
};

function validarSucursales() {
    var NombreSucursal = $("#NombreSucursal").val();
    var IdTipoTienda = $("#IdTipoTienda").val();
    if (NombreSucursal == '') {
        toastr.error('Se requiere del campo Nombre Sucursal', 'Error');
        return false;
    }
    if (IdTipoTienda == '') {
        toastr.error('Se requiere del campo Tipo Tienda', 'Error');
        return false;
    }
    return true;
};

function validarSucursalesEditar() {
    var NombreSucursal = $("#NombreSucursalEditar").val();
    var Factor = $("#FactorSucursalEditar").val();
    if (NombreSucursal == '') {
        toastr.error('Se requiere del campo Nombre Sucursal', 'Error');
        return false;
    }
    if (Factor == '') {
        toastr.error('Se requiere del campo Factor', 'Error');
        return false;
    }
    return true;
}

function agregarSucursal() {
    mostrarLoader();
    if (validarSucursales()) {
        var scl = {};
        scl.NombreSucursal = $("#NombreSucursal").val();
        scl.IdTipoTienda = $("#IdTipoTienda").val();
        $.ajax({
            type: "POST",
            url: "/Sucursal/AgregarSucursal",
            data: '{scl: ' + JSON.stringify(scl) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 2) {
                    toastr.error('Ya existen registros con un nombre similar, intente otro', 'Error');
                    ocultarLoader();
                }
                else {
                    if (response.Code == 1) {
                        $('#modalNuevaSucursal').modal('hide');
                        limpiarValoresSucursal();
                        cargarTablaSucursales();
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

function cambiarEstado(idSucursal) {
    mostrarLoader();
    var scl = {};
    scl.IdSucursal = idSucursal;
    $.ajax({
        type: "POST",
        url: "/Sucursal/CambiarEstado",
        data: '{scl: ' + JSON.stringify(scl) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaSucursales();
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

function eliminarSucursal(idSucursal) {
    mostrarLoader();
    var scl = {};
    scl.IdSucursal = idSucursal;
    $.ajax({
        type: "POST",
        url: "/Sucursal/EliminarSucursal",
        data: '{scl: ' + JSON.stringify(scl) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaSucursales();
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

function obtenerSucursal(idSucursal) {
    mostrarLoader();
    $('#modalEditarSucursal').modal('show');
    var IdSucursal = idSucursal;
    $.ajax({
        type: "POST",
        url: "/Sucursal/ObtenerSucursalPorId",
        data: '{scl: ' + IdSucursal + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idSucursalEditar").val(response.SucursalCLS.IdSucursal);
            $("#NombreSucursalEditar").val(response.SucursalCLS.NombreSucursal);
            $("#IdTipoTiendaEditar").val(response.SucursalCLS.IdTipoTienda);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
}

function editarSucursal() {
    mostrarLoader();
    if (validarSucursalesEditar()) {
        var scl = {};
        scl.IdSucursal = $("#idSucursalEditar").val();
        scl.NombreSucursal = $("#NombreSucursalEditar").val();
        scl.Factor = $("#FactorSucursalEditar").val();
        $.ajax({
            type: "POST",
            url: "/Sucursal/EditarSucursal",
            data: '{scl: ' + JSON.stringify(scl) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaSucursales();
                    $('#modalEditarSucursal').modal('hide');
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
