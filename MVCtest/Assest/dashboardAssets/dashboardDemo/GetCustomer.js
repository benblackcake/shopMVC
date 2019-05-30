

table = $('#datatable').DataTable({
    "processing": true,
    // "serverSide": true,
    "ajax": {
        "url": "/api/dashboardCustomer/GetCustomer",
        "type": "GET"
    },
    "columns": [
        { "data": "Customer_ID" },
        { "data": "Customer_Name" },
        { "data": "Customer_Email" },
        { "data": "Customer_Phone" },
        {
            "data": null,
            "defaultContent": '<button type="button" class="btn btn-dark">停權</button>'
            + '&nbsp;&nbsp' +
            '<button type="button" class="btn btn-danger">查看</button>'
        }
    ]

});


ID = "";
$('#datatable tbody').on('click', '.btn-dark', function () {
    data = table.row($(this).parents('tr')).data();
    $("#Customer_ID").val(data['Customer_ID']);
    $("#Customer_Name").val(data['Customer_Name']);
    $("#Customer_Email").val(data['Customer_Email']);
    $("#Customer_Phone").val(data['Customer_Phone']);
    $("#myModal").modal();
    ID = data['Customer_ID'];
});
