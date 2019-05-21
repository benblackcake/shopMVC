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
    $("#mySidenav .a1").click(function () {
        if ($(".hidden1").hasClass("hidden-list")) {
            $(".hidden1").removeClass("hidden-list");
        } else {
            $(".hidden1").addClass("hidden-list");
        }
    })
    $("#mySidenav .a2").click(function () {
        if ($(".hidden2").hasClass("hidden-list")) {
            $(".hidden2").removeClass("hidden-list");
        } else {
            $(".hidden2").addClass("hidden-list");
        }
    })
    $("#mySidenav .a3").click(function () {
        if ($(".hidden3").hasClass("hidden-list")) {
            $(".hidden3").removeClass("hidden-list");
        } else {
            $(".hidden3").addClass("hidden-list");
        }
    })
    $("#mySidenav .a4").click(function () {
        if ($(".hidden4").hasClass("hidden-list")) {
            $(".hidden4").removeClass("hidden-list");
        } else {
            $(".hidden4").addClass("hidden-list");
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

   
})
