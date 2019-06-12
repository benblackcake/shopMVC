

table = $('#datatables').DataTable({
    "processing": true,
    // "serverSide": true,
    "ajax": {
        "url": "/api/dashboardMember/getProduct",
        "type": "GET"
    },
    "columns": [
        // {"data":"id"},
        { "data": "Product_Name" },
        { "data": "UnitPrice" },
        { "data": "Sub_Category_Name" },
        { "data": "CategoryGroup_Name" },
        {
            "data": "Product_Image",
            "render": function (Items, type, row) {
                return '<img src="' + Items + '" style="height:180px;width:120px;"/>';
            }
        },
        {
            "data": null,
            "defaultContent": '<button type="button" class="btn btn-dark">Edit</button>'
            + '&nbsp;&nbsp' +
            '<button type="button" class="btn btn-danger">Delete</button>'
        }
    ]

});


ID = "";
$('#datatables tbody').on('click', '.btn-dark', function () {
    data = table.row($(this).parents('tr')).data();
    $("#Product_Name").val(data['Product_Name']);
    $("#UnitPrice").val(data['UnitPrice']);
    $("#Sub_Category_Name").val(data['Sub_Category_Name']);
    $("#CategoryGroup_Name").val(data['CategoryGroup_Name']);
    $("#imagePreview").css("background-image", "url(" + data['Product_Image']+")");
    $("#myModal").modal();
    ID = data['Product_Id'];
});

$("#create").click(function () {
    $("#newModal").modal();

});


//$('#formNew').on('submit', function (event) {
//    console.log("new submit");
//    event.preventDefault();
//    // $this=
//    url = '/api/dashboardMember/UpdateProduct';
//    method = 'post';

//    $.ajax({
//        url: url,
//        contentType: false,
//        processData: false,
//        method: method,
//        data: $(this).serialize(),
//        success: function (data) {
//            console.log(data);
//            location.reload();
//        }
//    });
//});

