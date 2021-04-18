const messages = {
    en: {
        message:{}
    },
    no: {
        message:{}
    },
    ar: {
        message:{}
    }
};

function JSLanguage(key){
    let localLang = $cookies.get('language');
    if(localLang === null) // This is just the javascript translation
        localLang = 'no'; //Set Norwegian here as default
    return messages[localLang]["message"][key];
}
//Parse English File
// $.getJSON("/js/Language/en.json", function(json){
//     messages.en.message = json;
// });
$.ajax({
    type:"GET",
    url:"/js/Language/en.json?nocache"+ (new Date()).getTime(),
    async: false,
    datatype:"json",
    success: function(json){
        messages.en.message = json;
    }
});
//Parse Arabic File
$.ajax({
    type:"GET",
    url:"/js/Language/ar.json?nocache"+ (new Date()).getTime(),
    async: false,
    datatype:"json",
    success: function(json){
        messages.ar.message = json;
    }
});
//Parse Norwegian File
$.ajax({
    type:"GET",
    url:"/js/Language/no.json?nocache"+ (new Date()).getTime(),
    async: false,
    datatype:"json",
    success: function(json){
        messages.no.message = json;
    }
});


$(document).ready(function(){
    
    
    
    
    



// Create VueI18n instance with options
    const i18n = new VueI18n({

        locale: $cookies.get('language'), // set local language from the Cookies
        fallbackLocale: 'en', // If the cookies is not set yet, use English //
        messages, // set locale messages
        silentTranslationWarn: true

    });

    new Vue({i18n,
        el: "#internationalization-vue",
        created: function(){
        const lang = $cookies.get('language');
            if(lang === null){
                // i18n.locale = getBrowserLanguage();
                // this.$cookies.set('language', getBrowserLanguage()); // First: set the default language for safety
                $("#language-modal").css('display', 'block');
            }
            changeDirection(lang)
            
        },
        methods:{
            changeLang: function (lang, modal = false) {
                if(modal)
                    $("#language-modal").fadeOut(500);

                i18n.locale = lang;
                this.$cookies.set('language', i18n.locale, 100000*2*365);
                
                changeDirection(lang);
                
            }
        }
    });
    
    function changeDirection(lang) {
        const setMyDirection = $(".set-my-direction");
        const sideTask = $("#tasks-container");
        const vertBar = $(".top-nav-vertical-bar");
        const direction = $(".direction:not(.not-direction)");
        const directionReserve = $(".direction-reserve:not(.not-direction)");
        const directionText = $(".direction-text");
        const courseDivPicBorder = $(".course-div-pic");
        const courseFullDiv = $(".full-course-body ");
        const floatDirection =$(".float-direction");
        const floatDirectionReserve = $(".float-direction-reserve");
        const videoIcon =$(".video-icon");
        const sideNav= $("#side-nav");
        const closeNav = $("a#close-nav");
        const openNav = $("#open-nav");
        
        if(lang === 'ar'){
            $(setMyDirection).attr('dir', 'rtl');
            $(direction).css("direction", "rtl").addClass("text-right").removeClass('text-left');
            $(directionReserve).css("direction", "ltr").addClass("text-left").removeClass("text-right");
            $(directionText).css("text-align", 'right!important');
            $(sideTask).css("right", "").css("left", 0);
            $(vertBar).css("border-right", "").css("border-left", "1px solid #4e54a4");
            $(courseDivPicBorder).css("border-right", "").css("border-left", "1px solid gray");
            $(courseFullDiv).css("border-left", "").css("border-right", "1px solid lightgray").css("margin-left", "").css("margin-right", "1rem");
            $(floatDirectionReserve).css("float", "left");
            $(floatDirection).css("float", "right");
            $(videoIcon).removeClass('text-left').addClass('video-right');
            $(sideNav).css("right", 0).css("left", "");
            $(closeNav).css("left", "2%").css("right", "");
            $(openNav).css("margin-left", "0.5rem").css("margin-right", "");
            
        }else{
            $(setMyDirection).attr('dir', 'ltr');
            $(direction).css("direction", "ltr").removeClass("text-right").addClass('text-left');
            $(directionReserve).css("direction", "rtl").addClass("text-right").removeClass("text-left");
            $(directionText).css("text-align", 'left!important');
            $(sideTask).css("left", "").css("right", 0);
            $(vertBar).css("border-left", "").css("border-right", "1px solid #4e54a4");
            $(courseDivPicBorder).css("border-left", "").css("border-right", "1px solid gray");
            $(courseFullDiv).css("border-right", "").css("border-left", "1px solid lightgray").css("margin-right", "").css("margin-left", "1rem");;
            $(floatDirectionReserve).css("float", "right");
            $(floatDirection).css("float", "left");
            $(videoIcon).removeClass('text-right').addClass('text-left');
            $(sideNav).css("right", "").css("left", 0);
            $(closeNav).css("right", "2%").css("left", "");
            $(openNav).css("margin-right", "0.5rem").css("margin-left", "");
        }
    }
    
    // .$mount('#internationalization-vue');



});