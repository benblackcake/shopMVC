table = $('#datatables').DataTable({
    "processing": true,
    // "serverSide": true,
    "ajax": {
        "url": "/api/dashboardSale/GetSale",
        "type": "GET"
    },
    "columns": [
        { "data": "Sale_ID" },
        { "data": "Sale_Product" },
        { "data": "Sale_UnPrice" },
        {
            "data": "Sale_FristDate",
            "type": "date ",
            "render": function (value) {
                if (value === null) return "";

                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var dt = new Date(parseFloat(results[1]));

                return dt.toLocaleDateString();
                //return dt.getFullYear()  + "-" + (dt.getMonth()+1) + "-" + dt.getDate();
            }
        },
        {
            "data": "Sale_LastDate",
            "type": "date ",
            "render": function (value) {
                if (value === null) return "";

                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(value);
                var dt = new Date(parseFloat(results[1]));
                return dt.toLocaleDateString();
                //return dt.getFullYear() + "-" + (dt.getMonth() + 1) + "-" + dt.getDate();
            }
        },
        {
            "data": null,
            "defaultContent": '<button type="button" class="btn btn-primary">Edit</button>'
                + '&nbsp;&nbsp' +
                '<button type="button" class="btn btn-danger delete">Delete</button>'
        }
    ]
});
var value = "";
var value2 = "";
$('#datatables tbody').on('click', '.btn-danger', function () {
    var $this = $(this);
    value = $this.parent().parent().find('td:first-child').text();
    value2 = $this.parent().parent().find('td:first-child').next().text();
    deleteSale(value, value2);
    
    
});

function deleteSale(value,value2) {
    $.ajax({
        cache: "false",
        type: "POST",
        url: "/dashboardSale/DeleteSale",
        data: { Sale_ID: value,Sale_Product: value2 },
        success:
            function () {
                history.go(0)
            }
    });

}
