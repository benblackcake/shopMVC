
var MAX_VAL = 0;
var table = $('#datatables').DataTable({
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

$('#createCate').on('click', function () {
    var li = [];
    var cateID = $("")
    var data = table.rows().data();
    for (var i = 0; i < data.length;i++) {
        li.push(data[i].master_id);
    }
    console.log(li);
    MAX_VAL = Math.max.apply(Math,li)+1; 
    console.log(MAX_VAL);
    $('#master_id').val(MAX_VAL);


});

$("#create").click(function () {
    $("#newModal").modal();

});


