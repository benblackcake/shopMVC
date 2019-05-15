(function () {
    window.inputNumber = function (el) {
        var min = el.attr('min') || false;
        var max = el.attr('max') || false;

        var els = {};
        els.dec = el.prev();
        els.inc = el.next();
        el.each(function () {
            init($(this));
        });
        function init(el) {
            els.dec.on('click', decrement);
            els.inc.on('click', increment);
            function decrement() {
                var value = el[0].value;
                value--;
                if (!min || value >= min) {
                    el[0].value = value;
                }
            }
            function increment() {
                var value = el[0].value;
                value++;
                if (!max || value <= max) {
                    el[0].value = value++;
                }
            }
        }
    }
    inputNumber($('.input-number'));
})();


//$(function () {
//    // This button will increment the value
//    $('.quantity_plus').click(function (e) {
//        // Stop acting like a button
//        e.preventDefault();
//        // Get the field name
//        fieldName = $(this).attr('field');
//        // Get its current value
//        var currentVal = parseInt($('input[name=' + fieldName + ']').val());
//        // If is not undefined
//        if (!isNaN(currentVal)) {
//            // Increment
//            $('input[name=' + fieldName + ']').val(currentVal + 1);
//        } else {
//            // Otherwise put a 0 there
//            $('input[name=' + fieldName + ']').val(0);
//        }
//    });
//    // This button will decrement the value till 0
//    $(".quantity_minus").click(function (e) {
//        // Stop acting like a button
//        e.preventDefault();
//        // Get the field name
//        fieldName = $(this).attr('field');
//        // Get its current value
//        var currentVal = parseInt($('input[name=' + fieldName + ']').val());
//        // If it isn't undefined or its greater than 0
//        if (!isNaN(currentVal) && currentVal > 0) {
//            // Decrement one
//            $('input[name=' + fieldName + ']').val(currentVal - 1);
//        } else {
//            // Otherwise put a 0 there
//            $('input[name=' + fieldName + ']').val(0);
//        }
//    });
//});