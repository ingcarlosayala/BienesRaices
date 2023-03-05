
var datatable;

$(document).ready(function () {
    CargarTabla();
});

function CargarTabla() {
    datatable = $("#tblvendedor").DataTable({
        "ajax": {
            "url": "/Admin/Vendedores/ObtenerTodos"
        },
        "columns": [
            {"data": "nombre", "width": "30%"},
            {"data": "apellido", "width": "30%"},
            { "data": "telefono", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Vendedores/Edit/${data}" class="btn btn-warning btn-sm"><i class="fa-solid fa-pen-to-square"></i></a>
                                <a onclick=Delete("/Admin/Vendedores/Delete/${data}") class="btn btn-danger btn-sm"><i class="fa-solid fa-trash"></i></a>
                            </div>`;
                },"width": "20%"
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