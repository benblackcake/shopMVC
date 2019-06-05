

table = $('#datatables').DataTable({
    "processing": true,
    // "serverSide": true,
    "ajax": {
        "url": "/api/dashboardIndex/GetMaster",
        "type": "GET"
    },
    "columns": [
        { "data": "master_id" },
        { "data": "master_account" },
        { "data": "master_password" },
        {
            "data": null,
            "defaultContent":'<button type="button" class="btn btn-danger">查看</button>'
        }
    ]

});


ID = "";
$('#datatables tbody').on('click', '.btn-dark', function () {
    data = data.row($(this).parents('tr')).data();
    $("#master_id").val(data['master_id']);
    $("#master_account").val(data['master_account']);
    $("#master_password").val(data['master_password']);
    $("#myModal").modal();
    ID = data['master_id'];
});

$("#create").click(function () {
    $("#newModal").modal();

});