function cargarTablaProveedor() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreProveedorFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Proveedor/ListaProveedor',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsProveedor.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsProveedor[i].IdProveedor + '</td>';
                rows += '<td>' + data.lsProveedor[i].NroDocumento + '</td>';
                rows += '<td>' + data.lsProveedor[i].NombreProveedor + '</td>';
                rows += '<td>' + data.lsProveedor[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsProveedor[i].UsuarioCreacion + '</td>';
                if (data.lsProveedor[i].EstadoProveedor) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsProveedor[i].IdProveedor + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsProveedor[i].IdProveedor + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerAlmacen(' + data.lsProveedor[i].IdProveedor + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarAlmacen(' + data.lsProveedor[i].IdProveedor + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbProveedor").innerHTML = rows;
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

function agregarProveedor() {

    mostrarLoader();
    if (validarProveedor()) {
        var prov = {};
        prov.NroDocumento = $("#numDocumentoNuevo").val();
        prov.IdTipoPersona = $("#idTipoPersonaNuevo").val();
        prov.NombreProveedor = $("#NombreProveedorNuevo").val();
        prov.DireccionProveedor = $("#DireccionProveedorNuevo").val();
        prov.NombreContacto = $("#nombreContactoNuevo").val();
        prov.NumeroContacto = $("#numeroContactoNuevo").val();

        $.ajax({
            type: "POST",
            url: "/Proveedor/AgregarProveedor",
            data: '{prov: ' + JSON.stringify(prov) + '}',
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
                        limpiarValoresProveedor();
                        cargarTablaProveedor();
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

function limpiarValoresProveedor() {
    $("#numDocumento").val('');
    $("#idTipoPersonaNuevo").val('');
    $("#NombreProveedorNuevo").val('');
    $('#DireccionProveedorNuevo').val('');
    $("#nombreContactoNuevo").val('');
    $("#numeroContactoNuevo").val('');
};

function validarProveedor() {

    //var NombreAlmacen = $("#NombreAlmacen").val();
    //var DireccionAlmacen = $("#DireccionAlmacen").val();
    //var idSucursal = $("#idSucursal").val();

    //if (NombreAlmacen == '') {
    //    toastr.error('Se requiere del campo Nombre Almacén', 'Error');
    //    return false;
    //}
    //if (DireccionAlmacen == '') {
    //    toastr.error('Se requiere del campo Dirección Almacén', 'Error');
    //    return false;
    //}
    //if (idSucursal == '') {
    //    toastr.error('Se requiere del campo Id Sucursal', 'Error');
    //    return false;
    //}

    return true;
};

function obtenerAlmacen(idAlmacen) {
    mostrarLoader();
    $('#modalEditar').modal('show');
    var IdAlmacen = idAlmacen;
    $.ajax({
        type: "POST",
        url: "/Almacen/ObtenerAlmacenPorId",
        data: '{alm: ' + IdAlmacen + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#NombreAlmacenEditar").val(response.almacenCLS.NombreAlmacen);
            $("#DireccionAlmacenEditar").val(response.almacenCLS.DireccionAlmacen);
            $("#idSucursalEditar").val(response.almacenCLS.IdSucursal);
            $("#nombreSucursalEditar").val(response.almacenCLS.NombreSucursal);
            $("#sucursalEditar").val(response.almacenCLS.NombreSucursal);
            $("#idAlmacenEditar").val(response.almacenCLS.IdAlmacen);

            if (response.almacenCLS.IsPrincipal == 'S') {
                document.getElementById('IsPrincipalEditar').checked = true;
            } else {
                document.getElementById('IsPrincipalEditar').checked = false;
            }


            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
};

function cambiarEstado(idAlmacen) {
    mostrarLoader();
    var alm = {};
    alm.IdAlmacen = idAlmacen;
    $.ajax({
        type: "POST",
        url: "/Almacen/CambiarEstadoAlmacen",
        data: '{alm: ' + JSON.stringify(alm) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaAlmacen();
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

function eliminarAlmacen(idAlmacen) {
    mostrarLoader();
    var alm = {};
    alm.IdAlmacen = idAlmacen;
    $.ajax({
        type: "POST",
        url: "/Almacen/EliminarAlmacen",
        data: '{alm: ' + JSON.stringify(alm) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaAlmacen();
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

function validarAlmacenEditar() {

    var NombreAlmacen = $("#NombreAlmacenEditar").val();
    var DireccionAlmacen = $("#DireccionAlmacenEditar").val();
    var idSucursal = $("#idSucursalEditar").val();

    if (NombreAlmacen == '') {
        toastr.error('Se requiere del campo Nombre Almacén', 'Error');
        return false;
    }
    if (DireccionAlmacen == '') {
        toastr.error('Se requiere del campo Dirección Almacén', 'Error');
        return false;
    }
    if (idSucursal == '') {
        toastr.error('Se requiere del campo Id Sucursal', 'Error');
        return false;
    }

    return true;
};

function editarAlmacen() {
    mostrarLoader();
    if (validarAlmacenEditar()) {
        var alm = {};
        alm.IdAlmacen = $("#idAlmacenEditar").val();
        alm.NombreAlmacen = $("#NombreAlmacenEditar").val();
        alm.DireccionAlmacen = $("#DireccionAlmacenEditar").val();
        alm.IdSucursal = $("#idSucursalEditar").val();

        var isChecked = document.getElementById('IsPrincipalEditar').checked;
        if (isChecked) {
            alm.IsPrincipal = "S";
        } else {
            alm.IsPrincipal = "N";
        }

        $.ajax({
            type: "POST",
            url: "/Almacen/EditarAlmacen",
            data: '{alm: ' + JSON.stringify(alm) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaAlmacen();
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