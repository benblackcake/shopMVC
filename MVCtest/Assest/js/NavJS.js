$(function () {

    // layout上方的category 各個hover展開
    $("#2 .subnav-content").addClass("subnav-content2");
    $("#2 .subnav-content").removeClass("subnav-content");
    $("#3 .subnav-content").addClass("subnav-content3");
    $("#3 .subnav-content").removeClass("subnav-content");    
    $("#4 .subnav-content").addClass("subnav-content4");
    $("#4 .subnav-content").removeClass("subnav-content");
    
    //RWD後 右上角三條線 點擊展開sidebar  
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

    // RWD後 右側的sidebar 右上角的x
   
    $(".closebtn").click(function () {
        var x = document.getElementById("testnav");
        x.className = "top-menu";
        $(".idk").removeClass("responsive");
        $(".sidenav ").removeClass("responsive");
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        document.body.style.backgroundColor = "white";
        
    })

    // 右上角 會員和購物車 hover特效
    $("#two-btn .userhover").hover(function () {
        $("#two-btn #user-img").css("opacity","0.5");
    }, function () { $("#two-btn #user-img").css("opacity", "1"); })

    $("#two-btn .carthover").hover(function () {
        $("#two-btn #cart-img").css("opacity", "0.5");
    }, function () { $("#two-btn #cart-img").css("opacity", "1"); })


    //RWD後 右側的sidebar各個hover展開 
    $("#mySidenav .1").hover(function () {
        if ($("#mySidenav #11").hasClass("hidden-list")) {
            $("#mySidenav #11").removeClass("hidden-list");
        } else {
            $("#mySidenav #11").addClass("hidden-list");
        }
    })
    $("#mySidenav .2").hover(function () {
        if ($("#mySidenav #12").hasClass("hidden-list")) {
            $("#mySidenav #12").removeClass("hidden-list");
        } else {
            $("#mySidenav #12").addClass("hidden-list");
        }
    })
    $("#mySidenav .3").hover(function () {
        if ($("#mySidenav #13").hasClass("hidden-list")) {
            $("#mySidenav #13").removeClass("hidden-list");
        } else {
            $("#mySidenav #13").addClass("hidden-list");
        }
    })
    $("#mySidenav .4").hover(function () {
        if ($("#mySidenav #14").hasClass("hidden-list")) {
            $("#mySidenav #14").removeClass("hidden-list");
        } else {
            $("#mySidenav #14").addClass("hidden-list");
        }
    })

    //忘了

    $(".search-block1 input").focusin(function () {
        $(".search-block1").css("border", "1px solid #fff").css("padding","2px 2px 4px 2px");
    })
    $(".search-block1 input").focusout(function () {
        $(".search-block1").css("border", "").css("padding","");
    })

   
})
