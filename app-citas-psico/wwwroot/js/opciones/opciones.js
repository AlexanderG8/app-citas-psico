var tablaData;
let bodyModal;

$(document).ready(function () {
    tablaData = $("#example1").DataTable({
        "ajax": {
            "url": "/Opciones/GetOpciones",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "iD_OPCION", "with": "20%" },
            { "data": "opcion", "with": "40%" },
            { "data": "controller", "with": "40%" },
            { "data": "accion", "with": "40%" },
            {
                "data": "iD_OPCION",
                "render": function (data, type, row, meta) {
                    return `
                        <div class="text-center">
                            <a class="btn btn-warning edit-dialog-window" href="Opciones/GetOpcionEdit?id=${data}">
                                <i class="fa-solid fa-pen-to-square"></i>
                            </a>
                            <a class="btn btn-danger" onclick="Delete(${data})">
                                <i class="fa-solid fa-trash"></i>
                            </a>
                        </div>
                    `;
                }
            }
        ],
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "initComplete": function () {
            tablaData.buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
            $("#example1").show();
        },
        "buttons": ["excel", "pdf"],
        "language": {
            "lengthMenu": "Mostrar _MENU_ Registros Por Pagina",
            "zeroRecords": "Ningun Registro",
            "info": "Mostrar page _PAGE_ de _PAGES_",
            "infoEmpty": "no hay registros",
            "infoFiltered": "(filtered from _MAX_ total registros)",
            "search": "Buscar",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });
    LoadModals();
});

const LoadModals = () => {
    $("body").on("click", "a.crear-dialog-window", null, function (e) {
        e.preventDefault();
        var $link = $(this);
        var url = $(this).attr('href');
        if (url.indexOf('#') == 0) {
            $('#Crear').modal('show');
        }
        else {
            $.get(url, function (data) {
                $('#Crear .teeee').html(data);
                $('#Crear').modal('show');
            })
        }
    });

    $("body").on("click", "a.edit-dialog-window", null, function (e) {
        e.preventDefault();
        var $link = $(this);
        var url = $(this).attr('href');
        if (url.indexOf('#') == 0) {
            $('#Edit').modal('show');
        }
        else {
            $.get(url, function (data) {
                $('#Edit .teeee').html(data);
                $('#Edit').modal('show');
            })
        }
    });
};

const Valid = (Objeto) => {
    let valor = false;
    $(".spanError").remove();

    if (Objeto.OPCION == "") {
        toastr.warning('El nombre de la opción es requerido');
        return false;
    }

    if (Objeto.CONTROLLER == "") {
        toastr.warning('El nombre del controllador es requerido');
        return false;
    }

    if (Objeto.ACCION == "") {
        toastr.warning('El nombre de la opción');
        return false;
    }

    return valor = true;
};

const SaveOption = async (accion) => {
    let objeto = {};
    let modal = "";
    let btn = "";
    if (accion == "C") {
        objeto = {
            ID_OPCION: $("#identificador").val(),
            OPCION: $("#opcion").val().trim(),
            CONTROLLER: $("#controller").val().trim(),
            ACCION: $("#accion").val().trim()
        }
        modal = "#Crear";
        btn = "#btnGuardar";
    }
    if (accion == "E") {
        objeto = {
            ID_OPCION: $("#identificadorE").val(),
            OPCION: $("#opcionE").val().trim(),
            CONTROLLER: $("#controllerE").val().trim(),
            ACCION: $("#accionE").val().trim()
        }
        modal = "#Edit";
        btn = "#btnGuardarE";
    }
    
    let valor = await Valid(objeto);
    if (valor) {
        $(btn).prop('disabled', true);
        Save(objeto, modal);
        $(btn).prop('disabled', false);
    }
}

const Save = (objeto, modal) => {
    jQuery.ajax({
        type: "POST",
        url: "/Opciones/SaveOpcion",
        dataType: "json",
        data: objeto,
        success: function (data) {
            if (data.success) {
                $(`${modal}`).modal('hide');
                $('#example1').DataTable().ajax.reload();
                toastr.success(`${data.message}`);
            } else {
                toastr.error(`${data.message}`);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            // Manejo de errores
            toastr.error(`Error en la petición AJAX: ${textStatus}, ${errorThrown}`)
        }
    });
}

const Delete = (id) => {
    Swal.fire({
        title: "Estas seguro de eliminar este registro?",
        text: "No podrás revertir esto!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar!"
    }).then((result) => {
        if (result.isConfirmed) {
            jQuery.ajax({
                type: "DELETE",
                url: "/Opciones/DeleteOpcion",
                dataType: "json",
                data: { "id": id },
                success: function (data) {
                    if (data.success) {
                        $('#example1').DataTable().ajax.reload();
                        toastr.success(`${data.message}`);
                    } else {
                        toastr.error(`${data.message}`);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    // Manejo de errores
                    toastr.error(`Error en la petición AJAX: ${textStatus}, ${errorThrown}`)
                }
            });
        }
    });
}