var $checkList1 = $(".checkList1");
var $checkList2 = $(".checkList2");
var $checkList3 = $(".checkList3");

$(".checkList1").on('change', function () {
    var checkList1Value = [];

    for (var i = 0; i < $checkList1.length; i++) {
        if ($checkList1[i].checked) {
            checkList1Value.push($($checkList1[i]).val());
        }
    }
    $("#checkList1Value").val(checkList1Value);
    $.ajax({
        type: "POST",
        url: "~/Product/Index",
        data: "name=John&location=Boston",
        dataType: "json",
        success: function (response) {
            alert("xx");
        }
    });
    $("#form1").submit();
})
$(".checkList2").on('change', function () {
    var checkList2Value = [];

    for (var i = 0; i < $checkList2.length; i++) {
        if ($checkList2[i].checked) {
            checkList2Value.push($($checkList2[i]).val());
        }
    }
    $("#checkList2Value").val(checkList2Value);
    $("#form2").submit();

})
$(".checkList3").on('change', function () {
    var checkList3Value = [];

    for (var i = 0; i < $checkList3.length; i++) {
        if ($checkList3[i].checked) {
            checkList3Value.push($($checkList3[i]).val());
        }
    }
    $("#checkList3Value").val(checkList3Value);
    $("#form3").submit();

})