$(function () {
    if ($(".show-menu").css("display") != "none") {
        $(".col-10").addClass("col-12").addClass("container");
        $(".col-10").removeClass("col-10");
        //$("#card").removeClass("col-lg-3 col-md-4 col-sm-6");
        //$("#card").addClass("col-lg-4 col-md-6 col-sm-12");
    }

    $(".show-menu").click(function () {
        if ($(".drop-list").css("display") == "none") {
            $(".drop-list").css("display", "block");
        } else {
            $(".drop-list").css("display", "none");
        }

    })

})




var $filter = $('.filter');
var $categoryFilter = $('.category-filter');
var $colorFilter = $('.color-filter');
var $sizeFilter = $('.size-filter');
var $productItem = $('.productItem'); 
var filterList = [];
var valueFiter = [];


$categoryFilter.on('change', function () {
    valueFiter = $categoryFilter;
    fnFilter('category');
});
$colorFilter.on('change', function () {
    valueFiter = $colorFilter;
    fnFilter('color');
});
$sizeFilter.on('change', function () {
    valueFiter = $sizeFilter;
    fnFilter('size');
});

function fnFilter(condition) {

    $($productItem).removeClass('show show-' + condition);

    filterList = [];
    //重新確認打勾數量
    for (var i = 0; i < valueFiter.length; i++) {
        var $this = $(valueFiter[i]);
        var $dataFilter = $($this).attr('data-' + condition);
        if ($this.prop('checked')) {
            filterList.push($dataFilter);
        }
    }
    //篩選 
    filterList.forEach(function (element) {
        for (var i = 0; i < $productItem.length; i++) {
            if ($($productItem[i]).attr('data-' + condition) == element) {
                $($productItem[i]).addClass('show show-' + condition);
            }
            else {
                $($productItem[$productItem.length-1]).addClass('show-' + condition)
            }
        }
    })

    if ($($productItem).hasClass('show') || filterList.length == 0) {
        fnShow();
    }

    $($productItem).hide();
    $('.show').fadeIn();

    if (fnIsNoItemChoose()) {

      $($productItem).fadeIn();

    }

}

function fnShow() {
    var value = []

    for (var i = 0; i < $productItem.length; i++) {
        var count = 0;
        if ($($productItem[i]).hasClass('show-category')) {
            count++;
        }
        if ($($productItem[i]).hasClass('show-color')) {
            count++;
        }
        if ($($productItem[i]).hasClass('show-size')) {
            count++;
        }
        value.push(count);
    }
    var classCout = -1;

    if (value.indexOf(1) != -1) {
        classCout = 1;
    }
    if (value.indexOf(2) != -1) {
        classCout = 2;
    }
    if (value.indexOf(3) != -1) {
        classCout = 3;
    }

    for (var i = 0; i < value.length; i++) {
        if (value[i] == classCout) {
            $($productItem[i]).addClass('show');
        }
        else {
            $($productItem[i]).removeClass('show');

        }
    }
}

function fnIsNoItemChoose() {
    var bool = true;
    for (var i = 0; i < $filter.length; i++) {
        if ($($filter[i]).prop('checked')) {
            bool = false;
            break;
        }
    }
    return bool;
}

//$(".price").on('change', function () {
//    var $minPrice = 0;
//    var $maxPrice = 0;
//    var $price1 = $("#price1").val();
//    var $price2 = $('#price2').val();

//    if ($price1 == 0 || $price2 == 0) {
//        return;
//    }
//    if ($price1 >= $price2) {
//        $maxPrice = +$price1;
//        $minPrice = +$price2;
//    }
//    else {
//        $maxPrice = +$price2;
//        $minPrice = +$price1;
//    }


//});