function cargarTablaAlmacen() {
    mostrarLoader();
    var fil = {};
    fil.Nombre = $("#NombreAlmacenFiltro").val();
    fil.Estado = $('input[name="estado"]:checked').val();

    var rows = "";
    $.ajax({
        type: 'POST',
        url: '/Almacen/ListaAlmacen',
        data: '{fil: ' + JSON.stringify(fil) + '}',
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            for (var i = 0; i < data.lsAlmacen.length; i++) {
                rows += '<tr>';
                rows += '<td>' + data.lsAlmacen[i].IdAlmacen + '</td>';
                rows += '<td>' + data.lsAlmacen[i].NombreAlmacen + '</td>';
                rows += '<td>' + data.lsAlmacen[i].NombreSucursal + '</td>';
                rows += '<td>' + data.lsAlmacen[i].FechaCreacionJS + '</td>';
                rows += '<td>' + data.lsAlmacen[i].UsuarioCreacion + '</td>';
                if (data.lsAlmacen[i].EstadoAlmacen) {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsAlmacen[i].IdAlmacen + ')" title="Cambiar estado" class="label label-sm label-success" style="cursor: pointer;"> Activado</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsAlmacen[i].IdAlmacen + ')" title="Cambiar estado" class="label label-sm label-danger" style="cursor: pointer;">Desactivado</span></td>';
                }
                rows += '<td align="center">';
                rows += '<span onclick="obtenerAlmacen(' + data.lsAlmacen[i].IdAlmacen + ')" class="fa fa-edit" style="font-size:20px; cursor: pointer;" title="Editar"></span>';
                rows += '<span onclick="eliminarAlmacen(' + data.lsAlmacen[i].IdAlmacen + ')" class="fa fa-trash-o" style="font-size:20px; cursor: pointer;" title="Eliminar"></span></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbAlmacen").innerHTML = rows;
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

function buscarSucursal() {
    var txt = $("#sucursalNuevo").val();
    if (txt.length >= 3) {
        mostrarLoader();
        var fil = {};
        fil.Nombre = txt;
        fil.Estado = 1;
        document.getElementById("divPredictivoSucursal").style.display = "block";

        var li = "";
        $.ajax({
            type: 'POST',
            url: '/Almacen/ListarSucursal',
            data: '{fil: ' + JSON.stringify(fil) + '}',
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                for (var i = 0; i < data.lsSucursal.length; i++) {
                    li += '<li class="liPredictivo" role="presentation">';
                    li += '<div onclick="seleccionarSucursal(\'' + data.lsSucursal[i].NombreSucursal + '\',' + data.lsSucursal[i].IdSucursal + ');" class="lidivPredictivo">' + data.lsSucursal[i].NombreSucursal + '</div>';
                    li += '</li>';
                }
                document.getElementById("ulPredictivoSucursalJRM").innerHTML = li;
                ocultarLoader();
            }
        });

    } else {
        document.getElementById("divPredictivoSucursal").style.display = "none";
        ocultarLoader();
    }
};

function seleccionarSucursal(NombreSucursal, idSucursal) {
    $("#sucursalNuevo").val(NombreSucursal);
    $("#nombreSucursal").val(NombreSucursal);
    $("#idSucursal").val(idSucursal);
    document.getElementById("divPredictivoSucursal").style.display = "none";
    ocultarLoader();
};

function agregarAlmacen() {

    mostrarLoader();
    if (validarAlmacen()) {
        var alm = {};
        alm.NombreAlmacen = $("#NombreAlmacen").val();
        alm.DireccionAlmacen = $("#DireccionAlmacen").val();
        alm.IdSucusal = $("#idSucursal").val();

        var isChecked = document.getElementById('IsPrincipal').checked;
        if (isChecked) {
            alm.IsPrincipal = "S";
        } else {
            alm.IsPrincipal = "N";
        }
        
        $.ajax({
            type: "POST",
            url: "/Almacen/AgregarAlmacen",
            data: '{alm: ' + JSON.stringify(alm) + '}',
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
                        limpiarValoresAlmacen();
                        cargarTablaAlmacen();
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

function limpiarValoresAlmacen() {
    $("#NombreAlmacen").val('');
    $("#DireccionAlmacen").val('');
    $("#idSucursal").val('');
    $('.IsPrincipal').prop('checked', false);
    $("#nombreSucursal").val('');
    $("#sucursalNuevo").val('');
};

function validarAlmacen() {

    var NombreAlmacen = $("#NombreAlmacen").val();
    var DireccionAlmacen = $("#DireccionAlmacen").val();
    var idSucursal = $("#idSucursal").val();

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
                $('.IsPrincipalEditar').prop('checked', true);
            } else {
                $('.IsPrincipalEditar').prop('checked', false);
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