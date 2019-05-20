var $filter = $('.filter');
$filter.on('change', function (e) {
    e.preventDefault();
    var filterList = [];

    for (var i = 0; i < $filter.length; i++) {

        var $this = $($filter[i]);
        var $dataFilter = $($this).attr('data-filter');
        if ($this.prop('checked')) {

            filterList.push($dataFilter);

        }
    }
    if (filterList.length == 0) {
        $('.product-item').fadeIn();

    }
    else {
        $('.product-item').hide();
        filterList.forEach(function (element) {
            $("." + element).fadeIn();
        })


    }

})

