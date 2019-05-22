var $filter = $('.filter');
var $categoryFilter = $('.category-filter');
var $colorFilter = $('.color-filter');
var $sizeFilter = $('.size-filter');
var $productItem = $('.productItem'); 
var filterList = []

$categoryFilter.on('change', function () {
    fnFilter('category');
});
$colorFilter.on('change', function () {
    fnFilter('color');
});
$sizeFilter.on('change', function () {
    fnFilter('size');
});


function fnFilter(condition) {

    $($productItem).removeClass('show show-' + condition);



    filterList = [];
    for (var i = 0; i < $filter.length; i++) {
        var $this = $($filter[i]);
        var $dataFilter = $($this).attr('data-' + condition);
        if ($this.prop('checked')) {
            filterList.push($dataFilter);
        }
    }
    filterList.forEach(function (element) {
        for (var i = 0; i < $productItem.length; i++) {
            alert('a');
 //           var isAnyExist = ($($productItem[i]).hasClass('show-category') || $($productItem[i]).hasClass('show-color') || $($productItem[i]).hasClass('show-size'));
            if ($($productItem[i]).attr('data-' + condition) == element && ($($productItem[i]).hasClass('show-category') || $($productItem[i]).hasClass('show-size'))) {
                $($productItem[i]).addClass('show show-' +condition);
            }
        }
    }) 

    if ($($productItem).hasClass('show')) {
        if ($($productItem).hasClass('show') == false && isAnyExist) {
            $('.show-category').addClass('show');
            $('.show-color').addClass('show');
            $('.show-size').addClass('show');
            $($productItem).hide();
            $('.show').fadeIn();
            return;
        }
    }

    $($productItem).hide();
    $('.show').fadeIn();

    if (filterList.length != 0) {
        return;
    }
    $($productItem).fadeIn();
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