$(function () {
    $("#2 .subnav-content").addClass("subnav-content2");
    $("#2 .subnav-content").removeClass("subnav-content");
    //$("#2 .subnav-content-right img").attr("src", "~/Assest/images/layout_image/layout_hover02.jpg");
    $("#3 .subnav-content").addClass("subnav-content3");
    $("#3 .subnav-content").removeClass("subnav-content");
    //$("#3 .subnav-content-right img").attr("src", "~/Assest/images/layout_image/layout_hover03.jpg");
    $("#4 .subnav-content").addClass("subnav-content4");
    $("#4 .subnav-content").removeClass("subnav-content");
    //$("#4 .subnav-content-right img").attr("src", "~/Assest/images/layout_image/layout_hover04.jpg");
    
    
    
    $(".icon").click(function () {
        var x = document.getElementById("testnav");
        if (x.className === "top-menu") {
            x.className += " responsive";
            $(".idk").addClass("responsive");
            $(".sidenav ").addClass("responsive");
            document.getElementById("mySidenav").style.width = "250px";
            document.getElementById("mySidenav").style.zIndex = "20";
            document.getElementById("main").style.marginLeft = "250px";
            document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
            $("body").css("background-color", "rgba(0,0,0,0.4)");
            //$(".search-block1 input").css("display", "none");
            //if ($(".sidenav responsive").css("width") == "250px") {
            //    $(".search-block1 input").css("display", "");
            //}
       }
    })
   
    $(".closebtn").click(function () {
        var x = document.getElementById("testnav");
        x.className = "top-menu";
        $(".idk").removeClass("responsive");
        $(".sidenav ").removeClass("responsive");
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        document.body.style.backgroundColor = "white";
        
    })

    //for (var i = 1; i <= 4; i++) {
    //    $("#mySidenav .a" + i).click(function () {    
    //        if ($(".hidden"+i).hasClass("hidden-list")) {
    //            $(".hidden"+i).removeClass("hidden-list");
    //        } else {
    //            $(".hidden"+i).addClass("hidden-list");
    //        }
    //    })
    //}
    $("#mySidenav .1").hover(function () {
        if ($("#mySidenav #11 li").hasClass("hidden-list")) {
            $("#mySidenav #11 li").removeClass("hidden-list");
        } else {
            $("#mySidenav #11 li").addClass("hidden-list");
        }
    })
    $("#mySidenav .2").hover(function () {
        if ($("#mySidenav #12 li").hasClass("hidden-list")) {
            $("#mySidenav #12 li").removeClass("hidden-list");
        } else {
            $("#mySidenav #12 li").addClass("hidden-list");
        }
    })
    $("#mySidenav .3").hover(function () {
        if ($("#mySidenav #13 li").hasClass("hidden-list")) {
            $("#mySidenav #13 li").removeClass("hidden-list");
        } else {
            $("#mySidenav #13 li").addClass("hidden-list");
        }
    })
    $("#mySidenav .4").hover(function () {
        if ($("#mySidenav #14 li").hasClass("hidden-list")) {
            $("#mySidenav #14 li").removeClass("hidden-list");
        } else {
            $("#mySidenav #14 li").addClass("hidden-list");
        }
    })

    //if (("#nav").css("display") == "none") {
    //    $("#two-btn").removeClass("mt-2");
    //} else {
    //    $("#two-btn").addClass("mt-2");
    //}

    $(".search-block1 input").focusin(function () {
        $(".search-block1").css("border", "1px solid #fff").css("padding","2px 2px 4px 2px");
    })
    $(".search-block1 input").focusout(function () {
        $(".search-block1").css("border", "").css("padding","");
    })

    //$("#two-btn a").hover(function () {
    //    $(".useruser").css("display", "block");
    //})


    //$("#two-btn .userhover img").hover(function () {
    //    if ($(".useruser").css("display") == "none") {
    //        $(".useruser").css("display", "block");
    //    } else {
    //        $(".useruser").css("display", "none");
    //    }
        
    //})
   
})
