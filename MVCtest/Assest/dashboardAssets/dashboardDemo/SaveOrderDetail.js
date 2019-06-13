$('.save').on('click', function () {
    var $this = $(this);
    var odId = $this.parent().find('.odId').val();
    var pdId = $this.parent().find('.option-pdId').val();
    var quantity = $this.prev().val();
    console.log(odId, pdId, quantity);
    $.ajax({
        type: "POST",
        url: "/dashboardUpdateOd/UpdateOrderDrtail",
        cache: "false",
        data: { odId: odId, pdId: pdId, quantity: quantity },
        success: function () {
            history.go(0);
        }

    });
})

$('.delete-od').on('click', function () {
    var $this = $(this);
    var odId = $this.parent().find('.odId').val();
    $.ajax({
        type: "POST",
        url: "/dashboardUpdateOd/DeleteOrderDetail",
        cache: "false",
        data: { odId: odId },
        success: function () {
            history.go(0);
        }

    });

})