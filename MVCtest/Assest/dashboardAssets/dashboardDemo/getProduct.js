

table = $('#datatables').DataTable({
    "processing": true,
    // "serverSide": true,
    "ajax": {
        "url": "/dashboardMember/getProduct",
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


