
var datatable;

$(document).ready(function () {
    CargarTabla();
});

function CargarTabla() {
    datatable = $("#tblpropiedad").DataTable({
        "ajax": {
            "url": "/Admin/Propiedades/ObtenerTodos"
        },
        "columns": [
            {"data": "titulo", "width": "2%"},
            {"data": "vendedor.nombre", "width": "2%"},
            { "data": "habitaciones", "width": "2%" },
            { "data": "bano", "width": "5%" },
            { "data": "estacionamiento", "width": "2%" },
            { "data": "fechaCreacion", "width": "2%" },
            { "data": "precio", "width": "2%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Propiedades/Edit/${data}" class="btn btn-warning btn-sm"><i class="fa-solid fa-pen-to-square"></i></a>
                                <a onclick=Delete("/Admin/Propiedades/Delete/${data}") class="btn btn-danger btn-sm"><i class="fa-solid fa-trash"></i></a>
                            </div>`;
                },"width": "2%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Estas Seguro?',
        text: "No podras recuperar este registro!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'SI, Eliminar!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    })
}