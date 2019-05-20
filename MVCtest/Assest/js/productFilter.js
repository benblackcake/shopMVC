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
    $('.product-item').hide();

    filterList.forEach(function (element) {
        $("." + element).fadeIn();
    })

})

