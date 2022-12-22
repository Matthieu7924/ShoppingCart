var dtable;
$(document).ready(function () {

    dtable = $('#myTable').DataTable({

        "ajax": { "url": "Produit/AllProducts" },
        "columns": [
            { "data": "nom" },
            { "data": "description" },
            { "data": "prix" },
            { "data": "categorie.nom" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <a href="Produit/CreateUpdate?id=${data}"></a>
                    <a onclick=RemoveProduit("Produit/Delete/${data}")></a>
                        `
                }
            }
        ]
    });
});

function RemoveProduct(url) {

    Swal.fire({
        title: 'Etes vous sur?',
        text: 'impossible de faire machine arrière',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        confirmButtonText: 'oui supprimer',
    }).then((result) => {
        if (resultisConfirmed) {
            $ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success)
                    {
                        dtable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else
                    {
                        toastr.error(data.message);
                    }
                }
                })
        }
    })
}