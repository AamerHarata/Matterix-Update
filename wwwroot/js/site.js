function f() {

    const nav = document.getElementById("main-nav");
    const classList = nav.classList;


    if (window.scrollY >= 0 && window.scrollY < 4) {
        if (classList.contains("border-bottom") && classList.contains("box-shadow")) {
            nav.classList.remove("border-bottom");
            nav.classList.remove("box-shadow");
        }
    } else {
        if (!classList.contains("border-bottom")  && !classList.contains("box-shadow")) {
            nav.classList.add("border-bottom");
            nav.classList.add("box-shadow");
        }
    }
}
if(!window.location.href.includes("Course/CourseArea")){
    window.addEventListener("scroll", f);
}

$(document).ready(function () {
    
    //Facebook function
    window.fbAsyncInit = function() {
        FB.init({
            xfbml            : true,
            version          : 'v6.0'
        });
    };

    (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = 'https://connect.facebook.net/ar_AR/sdk/xfbml.customerchat.js';
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));



    //Set direction of the selected language //ToDo :: Turn of this together with get browser language in Language.js when you want to set a default language
    // const lang = $cookies.get('language');
    // switch (lang) {
    //     case 'ar':
    //         $("button[title='عربي']").click();
    //         break;
    //     case 'en':
    //         $("button[title='English']").click();
    //         break;
    //     default:
    //         $("button[title='Norsk']").click();
    //        
    //        
    // }
    
    
    
    // Cookies ASP  
    const cookiesAcceptBtn= $("#cookieConsent button[data-cookie-string]");
    $(cookiesAcceptBtn).unbind().bind("click", function () {
        document.cookie = cookiesAcceptBtn.attr("data-cookie-string");
    });

    // END OF COOKIES



    // *** Open and close side nav *** //

    //Get the nav element
    const sideNav = $("#side-nav");
    //Check the status, opened / closed
    let isNavOpened = $(sideNav).css("width") > "10px";

    //Open and Close Nav Functions
    function openNav(){
        adjustSideNav();
        sideNav.css("width", "15rem");
        isNavOpened = true;
    }

    function closeNav(){
        sideNav.css("width", "0");
        isNavOpened = false;
    }

    function adjustSideNav(){
        //Get the header and footer position to adjust the SideNav
        const headHeight = $("#main-nav").css("height");
        sideNav.css("top", headHeight);
        const footerHeight = $("footer").css("height");
        const screenHeight = $(document).height() - parseInt(headHeight) - parseInt(footerHeight);


    }

    //Open button clicked
    $("#open-nav, #close-nav").click(function () {
        if(!isNavOpened)
            openNav();
        else
            closeNav();
    });

    // Readjust the sideNav in case the window size changed
    $(window).resize(function () {
        adjustSideNav();
    });
    
    //Logout clicked
    $(".logout").click(function(){
        $("#logout-form").submit();
    });
    
    
    //Open Profile Global
    const openProfileBtn = $('.open-profile');
    $(openProfileBtn).unbind().bind('click', function(){
        //ToDo :: Check if the path is correct
        const path = $(this).attr('src');
        //ToDo :: Open the page in new window
    });
    
    //Set body bottom margin relative to footer
    $("body").css({marginBottom: $('footer').css('height')});
    
    
    //Toggle custom switch on click
    $(".matter-switch-input").val($(this).prop('checked'));
    $(".matterix-switch").unbind().bind('click', function(){
        const input = $(this).find("input");
        let checked = $(input).prop('checked');
        $(input).prop('checked', !checked).val(!checked);
    });
    

    $(function () {
        $('[data-toggle="tooltip"]').tooltip({
            delay: {show: 300, hide: 100},
            trigger: 'hover',
        })
    })

});