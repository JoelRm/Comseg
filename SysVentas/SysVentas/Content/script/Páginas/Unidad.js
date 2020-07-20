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
                    rows += '<td><span onclick="cambiarEstado('+data.lsUnidades[i].IdUnidad+')" class="label label-sm label-success" > Activo</span></td>';
                }
                else {
                    rows += '<td><span onclick="cambiarEstado(' + data.lsUnidades[i].IdUnidad +')" class="label label-sm label-danger">Desactivo</span></td>';
                }
                rows += '<td align="center">';
                rows += '<i class="fa fa-edit" style="font-size:20px;" title="Editar"></i>';
                rows += '<i class="fa fa-trash-o" style="font-size:20px;" title="Eliminar"></i></td>';
                rows += '</tr>';
            }
            document.getElementById("bodytbUnidad").innerHTML = rows;
            $("#CerrarPopUpFiltros").trigger("click");
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

function AgregarUnidad() {
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
                    cargarTablaUnidades();
                }
                else {
                    if (response.Code == 1) {
                        $("#CerrarPopUpUnidad").trigger("click");
                        limpiarValoresUnidad();
                        cargarTablaUnidades();
                        toastr.success('Se agregaron los datos correctamente', 'Éxito');
                    }
                    else {
                        toastr.error('Error al agregar los datos', 'Error');
                    }
                }
                ocultarLoader();
            },
            error: function () {
                toastr.error('Ocurrió un error, vuelve a intentar', 'Error');
                ocultarLoader();
            }
        });
    }
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

function abrirFiltros() {
    $('#modalFiltros').modal('show');
};
