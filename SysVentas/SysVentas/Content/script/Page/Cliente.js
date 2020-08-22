function cargarTablaClientes() {
    mostrarLoader();
    var flt = {};
    flt.Nombre = $("#NombreClienteFiltro").val();
    flt.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Cliente/ListarCliente',
        data: '{flt: ' + JSON.stringify(flt) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsCliente.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsCliente[i].IdCliente + '</td>';
                rows += '<td>' + data.lsCliente[i].NroDocumentoCliente + '</td>';
                rows += '<td>' + data.lsCliente[i].NombreCliente + '</td>';
                rows += '<td>' + data.lsCliente[i].NombreTipoCliente + '</td>';
                rows += '<td>' + data.lsCliente[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsCliente[i].UsuarioCreacion + '</td>';
                if (data.lsCliente[i].EstadoCliente) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsCliente[i].IdCliente + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsCliente[i].IdCliente + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerCliente(' + data.lsCliente[i].IdCliente + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarCliente(' + data.lsCliente[i].IdCliente + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbCliente").innerHTML = rows;
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

function limpiarValoresCliente() {
    $("#NombreCliente").val('');
    $("#NroDocumentoCliente").val('');
    $("#DireccionCliente").val('');
    $("#NumeroContactoCliente").val('');
};

function validarCliente() {
    var IdTipoPersona = $("#IdTipoPersona").val();
    var NroDocumentoCliente = $("#NroDocumentoCliente").val();
    var NombreCliente = $("#NombreCliente").val();
    var DireccionCliente = $("#DireccionCliente").val();
    var NumeroContactoCliente = $("#NumeroContactoCliente").val();
    
    if (NombreCliente == '') {
        toastr.error('Se requiere del campo Nombre Cliente', 'Error');
        return false;
    }
    if (IdTipoPersona == '') {
        toastr.error('Se requiere del campo Tipo Cliente', 'Error');
        return false;
    }
    if (NroDocumentoCliente == '') {
        toastr.error('Se requiere el numero de documento', 'Error');
        return false;
    }
    if (DireccionCliente == '') {
        toastr.error('Se requiere la direccion del cliente', 'Error');
        return false;
    }
    if (NumeroContactoCliente == '') {
        toastr.error('Se requiere el numero de contacto', 'Error');
    }
    return true;
};

function agregarCliente() {
    mostrarLoader();
    if (validarCliente()) {
        var cli = {};
        cli.IdTipoPersona = $("#IdTipoPersona").val();
        cli.NroDocumentoCliente = $("#NroDocumentoCliente").val();
        cli.NombreCliente = $("#NombreCliente").val();
        cli.DireccionCliente = $("#DireccionCliente").val();
        cli.NumeroContactoCliente = $("#NumeroContactoCliente").val();
        $.ajax({
            type: "POST",
            url: "/Cliente/AgregarCliente",
            data: '{cli: ' + JSON.stringify(cli) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 2) {
                    toastr.error('Ya existen registros con un nombre similar, intente otro', 'Error');
                    ocultarLoader();
                }
                else {
                    if (response.Code == 1) {
                        $('#modalNuevoCliente').modal('hide');
                        limpiarValoresCliente();
                        cargarTablaClientes();
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

function cambiarEstado(idCliente) {
    mostrarLoader();
    var cli = {};
    cli.IdCliente = idCliente;
    $.ajax({
        type: "POST",
        url: "/Cliente/CambiarEstado",
        data: '{cli: ' + JSON.stringify(cli) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se cambió el estado con éxito', 'Éxito');
                cargarTablaClientes();
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

function eliminarCliente(idCliente) {
    mostrarLoader();
    var cli = {};
    cli.IdCliente = idCliente;
    $.ajax({
        type: "POST",
        url: "/Cliente/EliminarCliente",
        data: '{cli: ' + JSON.stringify(cli) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (response.Code == 1) {
                toastr.success('Se eliminó con éxito', 'Éxito');
                cargarTablaClientes();
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

function obtenerCliente(idCliente) {

    $('#modalEditarCliente').modal('show');
    var IdCliente = idCliente;
    $.ajax({
        type: "POST",
        url: "/Cliente/ObtenerClientePorId",
        data: '{cli: ' + IdCliente + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            $("#idClienteEditar").val(response.clienteCLS.IdCliente);
            $("#NombreClienteEditar").val(response.clienteCLS.NombreCliente);
            $("#NroDocumentoClienteEditar").val(response.clienteCLS.NroDocumentoCliente);
            $("#DireccionClienteEditar").val(response.clienteCLS.DireccionCliente);
            $("#NumeroContactoClienteEditar").val(response.clienteCLS.NumeroContactoCliente);
            $("#IdTipoPersonaEditar").val(response.clienteCLS.IdTipoPersona);
            ocultarLoader();
        },
        error: function () {
            toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
            ocultarLoader();
        }
    });
};

function validarClienteEditar() {
    var NombreCliente = $("#NombreClienteEditar").val();
    var NroDocumentoCliente = $("#NroDocumentoClienteEditar").val();
    var DireccionCliente = $("#DireccionClienteEditar").val();
    var NumeroContactoCliente = $("#NumeroContactoClienteEditar").val();
    var IdTipoPersona = $("#IdTipoPersonaEditar").val();

    if (NombreCliente == '') {
        toastr.error('Se requiere del campo Nombre Cliente', 'Error');
        return false;
    }
    if (IdTipoPersona == '') {
        toastr.error('Se requiere del campo Tipo Cliente', 'Error');
        return false;
    }
    if (NroDocumentoCliente == '') {
        toastr.error('Se requiere el numero de documento', 'Error');
        return false;
    }
    if (DireccionCliente == '') {
        toastr.error('Se requiere la direccion del cliente', 'Error');
        return false;
    }
    if (NumeroContactoCliente == '') {
        toastr.error('Se requiere el numero de contacto', 'Error');
    }
    return true;
}

function editarCliente() {
    mostrarLoader();
    if (validarClienteEditar()) {
        var cli = {};
        cli.IdCliente = $("#idClienteEditar").val();
        cli.NombreCliente = $("#NombreClienteEditar").val();
        cli.NroDocumentoCliente = $("#NroDocumentoClienteEditar").val();
        cli.DireccionCliente = $("#DireccionClienteEditar").val();
        cli.NumeroContactoCliente = $("#NumeroContactoClienteEditar").val();
        cli.IdTipoPersona = $("#IdTipoPersonaEditar").val();
        $.ajax({
            type: "POST",
            url: "/Cliente/EditarCliente",
            data: '{cli: ' + JSON.stringify(cli) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (response) {
                if (response.Code == 1) {
                    toastr.success('Se realizaron los cambios con éxito', 'Éxito');
                    cargarTablaClientes();
                    $('#modalEditarCliente').modal('hide');
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
