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
       } // else {
        //    x.className = "top-menu";
        //    $(".idk").removeClass("responsive");
        //    $(".sidenav ").removeClass("responsive");
        //    document.getElementById("mySidenav").style.width = "0";
        //    document.getElementById("main").style.marginLeft = "0";
        //    document.body.style.backgroundColor = "white";
            
        //}
       
    })
   
    $("#mySidenav").click(function () {
        var x = document.getElementById("testnav");
        x.className = "top-menu";
        $(".idk").removeClass("responsive");
        $(".sidenav ").removeClass("responsive");
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        document.body.style.backgroundColor = "white";
    })
    function closeNav() {
        
    }
        
})
