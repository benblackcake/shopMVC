$(function () {
    $(".icon").click(function () {
        var x = document.getElementById("testnav");
        if (x.className === "top-menu") {
            x.className += " responsive";
            $(".idk").addClass("responsive");
            $(".sidenav ").addClass("responsive");
            document.getElementById("mySidenav").style.width = "250px";
            document.getElementById("main").style.marginLeft = "250px";
            document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
            $("body").css("background-color","rgba(0,0,0,0.4)")
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
    
        
})
