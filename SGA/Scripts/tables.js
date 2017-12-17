//DataTable
'use strict';


function createTable(tableId, url,editUrl,deleteUrl) {

    var options = {
        "paging": true,
        "scrollX": true,
        "scrollY": true,
        "ajax": {
            "url": url,
            "error": erroCallBack,
            "dataType": "json"
        },
        "columnDefs": [
            {
                "targets": -1,
                "data": null,
                "defaultContent": '<td class="text-center"><a class="btn btn-primary" title="Editar" href="@Url.Action("Edit","Voluntario",new { id = item.VoluntarioId})"><i class="fa fa-pencil" style="font-size:20px "></i></a><span></span><a class="btn btn-danger" title="Excluir" href="@Url.Action("Delete","Voluntario",new { id = item.VoluntarioId})"><i class="fa fa-times" style="font-size:20px "></i></a></td>'
            }
        ]

    };

    $('#tableId').DataTable(options);

}

function erroCallBack(error) {

    console.log(error);
}