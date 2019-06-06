/* =================================
------------------------------------
	Divisima | eCommerce Template
	Version: 1.0
 ------------------------------------
 ====================================*/


'use strict';


$(window).on('load', function() {
	/*------------------
		Preloder
	--------------------*/
	$(".loader").fadeOut();
	$("#preloder").delay(400).fadeOut("slow");

});

(function($) {
	/*------------------
		Navigation
	--------------------*/
	$('.main-menu').slicknav({
		prependTo:'.main-navbar .container',
		closedSymbol: '<i class="flaticon-right-arrow"></i>',
		openedSymbol: '<i class="flaticon-down-arrow"></i>'
	});


	/*------------------
		ScrollBar
	--------------------*/
	$(".cart-table-warp, .product-thumbs").niceScroll({
		cursorborder:"",
		cursorcolor:"#afafaf",
		boxzoom:false
	});


	/*------------------
		Category menu
	--------------------*/
	//$('.category-menu > li').hover( function(e) {
	//	$(this).addClass('active');
	//	e.preventDefault();
	//});
	//$('.category-menu').mouseleave( function(e) {
	//	$('.category-menu li').removeClass('active');
	//	e.preventDefault();
	//});

    $('.group').on('click', function () {
        $(this).next().toggle(400);
    })

    $('.color-radio').on('click', function () {
        var $this = $(this);
        $this.prev().click();
        var hasStyle = $this.attr('style') != undefined;
        if (hasStyle) {
            $this.removeAttr('style');
            return;
        }
        //$this.css('outline', '#d30e6e solid 2px');
        $this.css('box-shadow', '0 0 3px 3px #d30e6e');

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
                    $($productItem[$productItem.length - 1]).addClass('show-' + condition)
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
            if ($($productItem[i]).hasClass('show-price')) {
                count++;
            }

            value.push(count);
        }

        var classCout = Math.max(...value);

        for (var i = 0; i < value.length - 1; i++) {
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




    $("#priceBtn").on('click', function () {
        //var minPrice = +$("#minamount").val().split('$')[0];
        //var maxPrice = +$('#maxamount').val().split('$')[0];

        var minPrice = rangeSlider.slider("values", 0);
        var maxPrice = rangeSlider.slider("values", 1);

        console.log(minPrice, maxPrice);

        if (minPrice == 0 && maxPrice == 0) {
            return;
        }

        for (var i = 0; i < $productItem.length; i++) {
            var $dataPrice = $($productItem[i]).attr('data-price');
            if ($dataPrice >= minPrice && $dataPrice <= maxPrice) {
                $($productItem[i]).addClass('show-price');
            }
            else {
                $($productItem[$productItem.length - 1]).addClass('show-price');
            }
        }
        fnShow();
        $($productItem).hide();
        $('.show').fadeIn();

    });

    $('#reset').on('click', function () {
        $($filter).prop('checked', false);
        $('.color-radio').removeAttr('style');
        $("#minamount").val("$0");
        $('#maxamount').val("$5000");
        resetSlider();
        $($productItem).removeClass('show show-category show-color show-size show-price');
        $($productItem).hide();
        $($productItem).fadeIn();
    })

    function resetSlider() {
        var $slider = $(".price-range");
        $slider.slider("values", 0, 0);
        $slider.slider("values", 1, 5000);
    }






	/*------------------
		Background Set
	--------------------*/
	$('.set-bg').each(function() {
		var bg = $(this).data('setbg');
		$(this).css('background-image', 'url(' + bg + ')');
	});



	/*------------------
		Hero Slider
	--------------------*/
	var hero_s = $(".hero-slider");
    hero_s.owlCarousel({
        loop: true,
        margin: 0,
        nav: true,
        items: 1,
        dots: true,
        animateOut: 'fadeOut',
    	animateIn: 'fadeIn',
        navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
        smartSpeed: 1200,
        autoHeight: false,
        autoplay: true,
        onInitialized: function() {
        	var a = this.items().length;
            $("#snh-1").html("<span>1</span><span>" + a + "</span>");
        }
    }).on("changed.owl.carousel", function(a) {
        var b = --a.item.index, a = a.item.count;
    	$("#snh-1").html("<span> "+ (1 > b ? b + a : b > a ? b - a : b) + "</span><span>" + a + "</span>");

    });

	hero_s.append('<div class="slider-nav-warp"><div class="slider-nav"></div></div>');
	$(".hero-slider .owl-nav, .hero-slider .owl-dots").appendTo('.slider-nav');



	/*------------------
		Brands Slider
	--------------------*/
	$('.product-slider').owlCarousel({
		loop: true,
		nav: true,
		dots: false,
		margin : 30,
		autoplay: true,
		navText: ['<i class="flaticon-left-arrow-1"></i>', '<i class="flaticon-right-arrow-1"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			480 : {
				items: 2,
			},
			768 : {
				items: 3,
			},
			1200 : {
				items: 4,
			}
		}
	});


	/*------------------
		Popular Services
	--------------------*/
	$('.popular-services-slider').owlCarousel({
		loop: true,
		dots: false,
		margin : 40,
		autoplay: true,
		nav:true,
		navText:['<i class="fa fa-angle-left"></i>','<i class="fa fa-angle-right"></i>'],
		responsive : {
			0 : {
				items: 1,
			},
			768 : {
				items: 2,
			},
			991: {
				items: 3
			}
		}
	});


	/*------------------
		Accordions
	--------------------*/
	$('.panel-link').on('click', function (e) {
		$('.panel-link').removeClass('active');
		var $this = $(this);
		if (!$this.hasClass('active')) {
			$this.addClass('active');
		}
		e.preventDefault();
	});


	/*-------------------
		Range Slider
	--------------------- */
	var rangeSlider = $(".price-range"),
		minamount = $("#minamount"),
		maxamount = $("#maxamount"),
		minPrice = rangeSlider.data('min'),
		maxPrice = rangeSlider.data('max');
	rangeSlider.slider({
		range: true,
		min: minPrice,
		max: maxPrice,
		values: [minPrice, maxPrice],
		slide: function (event, ui) {
			minamount.val('$' + ui.values[0]);
            maxamount.val('$' + ui.values[1]);

		}
	});
    minamount.val('$' + rangeSlider.slider("values", 0));
	maxamount.val('$' + rangeSlider.slider("values", 1));


	/*-------------------
		Quantity change
	--------------------- */
    var total = 0;
    var $proQty = $('.pro-qty');
	$proQty.prepend('<span class="dec qtybtn">-</span>');
    $proQty.append('<span class="inc qtybtn">+</span>');
    $(document).ready(function () {
        $('.qty').change();
    })
	$proQty.on('click', '.qtybtn', function () {
        var $this = $(this);
        var $value = +$this.parent().find('input[type="text"]').val();

		if ($this.hasClass('inc')) {
			$value += 1 ;
        }

        if ($this.hasClass('dec')) {
			if ($value > 0) {
                $value -= 1;    
			} else {
				$value = 0;
			}
        }
        $this.parent().find('input[type="text"]').attr('value', $value);
        $('.qty').change();
    });

    $('.qty').on('change', function () {
        var $this = $(this);

        if (isNaN($this.val())) {
            $this.val(0);
        }

        var $index = $('.qty').index(this);
        var $eachPrice = $('.eachPrice');
        var $unitPrice = $('.unitPrice');
        var $value = $this.val() * $($unitPrice[$index]).text();

        updateQuantity($this.next().val(), $this.val());
        $($eachPrice[$index]).text('$' + $value);
        $($eachPrice[$index]).val($value);
        updateTotal();
    })

    $('.delete').on('click', function () {
        var $this = $(this);
        var $cardID = $this.next().val();
        remove($cardID);
  //      history.go(0)
    })

    function updateTotal() {
        total = 0;
        var $eachprice = $('.eachPrice');
        for (var i = 0; i < $eachprice.length; i++) {
            var $value = $($eachprice[i]).val().split("$")[0]
            total += +$value;
        }
        $('#total').text('$' + total); 
    }


    function updateQuantity(cartID, newQuantity) {
        $.ajax({
            cache: "false",
            type: "POST",
            url: "/shopCart/UpdateQuantity",
            data: { cartID: cartID, quantity: newQuantity },
        });

    }


    function remove(ID) {
        $.ajax({
            cache: "false",
            type: "POST",
            url: "/shopCart/DeleteCart",
            data: { cartID: ID },
            success: 
                function () {
                    history.go(0)
                }
            
        });
    }


    $('#nextStep').on('click', function () {
        $('.step1').hide();
        $('.step2').fadeIn();
    })
    $('#preStep').on('click', function () {
        $('.step2').hide();
        $('.step1').fadeIn();
    })

	/*------------------
		Single Product
	--------------------*/
	$('.product-thumbs-track > .pt').on('click', function(){
		$('.product-thumbs-track .pt').removeClass('active');
		$(this).addClass('active');
		var imgurl = $(this).data('imgbigurl');
		var bigImg = $('.product-big-img').attr('src');
		if(imgurl != bigImg) {
			$('.product-big-img').attr({src: imgurl});
			$('.zoomImg').attr({src: imgurl});
		}
	});


	$('.product-pic-zoom').zoom();



})(jQuery);





