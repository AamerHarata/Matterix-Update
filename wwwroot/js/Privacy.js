$(document).ready(function(){
   const privacyBtn = $(".privacy-btn");
   privacyBtn.unbind().bind("click", function(){
      $(this).next().toggle(500);
      if($(this).hasClass("btn-light"))
         $(this).addClass("btn-primary").removeClass("btn-light").css("color", "white");
      else
         $(this).removeClass("btn-primary").addClass("btn-light").css("color", "#4e54a4");
   });
   
   
   const privacyTitle = $(".privacy-title");
   $(privacyTitle).unbind().bind('click', function(){
      $(this).next().toggle(500);
      if($(this).hasClass("active-privacy-title")){
         $(this).removeClass("active-privacy-title")
      }else{
         $(this).addClass("active-privacy-title")
      }
   })
   
   
});