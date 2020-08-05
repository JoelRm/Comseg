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
                rows += '<span onclick="obtenerProveedor(' + data.lsProveedor[i].IdProveedor + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarProveedor(' + data.lsProveedor[i].IdProveedor + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
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

    var numDocumento = $("#numDocumentoNuevo").val();
    var idTipoPersona = $("#idTipoPersonaNuevo").val();
    var nombreProveedor = $("#NombreProveedorNuevo").val();
    var direccion = $("#DireccionProveedorNuevo").val();
    var nombreContacto = $("#nombreContactoNuevo").val();
    var numeroContacto = $("#numeroContactoNuevo").val();

    if (numDocumento == '') {
        toastr.error('Se requiere del campo Número Documento', 'Error');
        return false;
    }
    if (idTipoPersona == '0') {
        toastr.error('Se requiere del campo Tipo Persona', 'Error');
        return false;
    }
    if (nombreProveedor == '') {
        toastr.error('Se requiere del campo Nombre Proveedor', 'Error');
        return false;
    }
    if (direccion == '') {
        toastr.error('Se requiere del campo Dirección Proveedor', 'Error');
        return false;
    }
    if (nombreContacto == '') {
        toastr.error('Se requiere del campo Nombre Contacto', 'Error');
        return false;
    }
    if (numeroContacto == '') {
        toastr.error('Se requiere del campo Número Contacto', 'Error');
        return false;
    }

    return true;
};

function cambiarEstado(idProveedor) {
    mostrarLoader();
    var prov = {};
    prov.IdProveedor = idProveedor;
    $.ajax({
        type: "POST",
        url: "/Proveedor/CambiarEstadoProveedor",
        data: '{prov: ' + JSON.stringify(prov) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaProveedor();
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

function eliminarProveedor(idProveedor) {
    mostrarLoader();
    var prov = {};
    prov.IdProveedor = idProveedor;
    $.ajax({
        type: "POST",
        url: "/Proveedor/EliminarProveedor",
        data: '{prov: ' + JSON.stringify(prov) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaProveedor();
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

function obtenerProveedor(idProveedor) {
    mostrarLoader();
    $('#modalEditarProveedor').modal('show');
    var IdProveedor = idProveedor;
    $.ajax({
        type: "POST",
        url: "/Proveedor/ObtenerProveedorPorId",
        data: '{prov: ' + IdProveedor + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idProveedorEditar").val(response.proveedorCLS.IdProveedor);
            $("#numDocumentoEditar").val(response.proveedorCLS.NroDocumento);
            $("#NombreProveedorEditar").val(response.proveedorCLS.NombreProveedor);
            $("#DireccionProveedorEditar").val(response.proveedorCLS.DireccionProveedor);
            $("#nombreContactoEditar").val(response.proveedorCLS.NombreContacto);
            $("#numeroContactoEditar").val(response.proveedorCLS.NumeroContacto);
            $("#idTipoPersonaEditar").val(response.proveedorCLS.IdTipoPersona);

            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
};

function validarProveedorEditar() {

    var numDocumento = $("#numDocumentoEditar").val();
    var idTipoPersona = $("#idTipoPersonaEditar").val();
    var nombreProveedor = $("#NombreProveedorEditar").val();
    var direccion = $("#DireccionProveedorEditar").val();
    var nombreContacto = $("#nombreContactoEditar").val();
    var numeroContacto = $("#numeroContactoEditar").val();

    if (numDocumento == '') {
        toastr.error('Se requiere del campo Número Documento', 'Error');
        return false;
    }
    if (idTipoPersona == '0') {
        toastr.error('Se requiere del campo Tipo Persona', 'Error');
        return false;
    }
    if (nombreProveedor == '') {
        toastr.error('Se requiere del campo Nombre Proveedor', 'Error');
        return false;
    }
    if (direccion == '') {
        toastr.error('Se requiere del campo Dirección Proveedor', 'Error');
        return false;
    }
    if (nombreContacto == '') {
        toastr.error('Se requiere del campo Nombre Contacto', 'Error');
        return false;
    }
    if (numeroContacto == '') {
        toastr.error('Se requiere del campo Número Contacto', 'Error');
        return false;
    }

    return true;
};

function editarProveedor() {
    mostrarLoader();
    if (validarProveedorEditar()) {
        var prov = {};
        prov.NroDocumento = $("#numDocumentoEditar").val();
        prov.IdTipoPersona = $("#idTipoPersonaEditar").val();
        prov.NombreProveedor = $("#NombreProveedorEditar").val();
        prov.DireccionProveedor = $("#DireccionProveedorEditar").val();
        prov.NombreContacto = $("#nombreContactoEditar").val();
        prov.NumeroContacto = $("#numeroContactoEditar").val();
        prov.IdProveedor = $("#idProveedorEditar").val();

        $.ajax({
            type: "POST",
            url: "/Proveedor/EditarProveedor",
            data: '{prov: ' + JSON.stringify(prov) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaProveedor();
                    $('#modalEditarProveedor').modal('hide');
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