$(document).ready(function(){
   
   //Set Different Devices to RED if more than 2
   //Set Student Body to RED if blocked
   const userDevices = $(".user-devices-count");
   const userBody = $(".full-user-div");
   userDevices.each(function(index, element){
      if(parseInt($(element).text())>=2){
         $(userDevices[index]).attr("style", "background-color: red; color: white; padding: 0.2rem; border-radius: 0.2rem")
      }
   });
   
   
   userBody.each(function(index, element){
      if($(element).attr("blocked") === "True"){
         $(element).css("background-color", "rgba(255, 0, 0, 0.2)");
      }
   });


   //*** Set Shared Variables ***///
   const sharedModal = $("#shared-modal");
   const modalContent = $("#shared-modal-content");
   const modalTitle = $("#shared-modal-title");
   const modalConfirm = $("#shared-modal-btn-yes");
   const modalCancel = $("#shared-modal-btn-no");


   //*** END OF Set Shared Variables ***///
   
   
   
   
   //*** Send Email To User Area ***//

   const emailBtn = $(".admin-send-email-btn");

   //Email Button Clicked
   $(emailBtn).unbind().bind("click", function(){
      
      $(modalTitle).text("Send Email");
      
      const userId= $(this).attr("user-id");
      

      $(modalConfirm).text("Send Email").removeClass("btn-danger").addClass("btn-success");
      $(modalCancel).text("Cancel");
      const modalBody = "<input id='email-to' class='form-control' style='margin-bottom: 0.3rem' placeholder='email' value='" + $(this).attr("email") + "'/>" +
          "<input id='email-subject' class='form-control' style='margin-bottom: 0.3rem' placeholder='Subject'/>" +
          "<input id='email-language' class='form-control' style='margin-bottom: 0.3rem' placeholder='Language'/>" +
          "<textarea id='email-body' style='width: 100%; height: 10rem; resize: none' placeholder='Write a text..'></textarea>";
      $(modalContent).html(modalBody);
      
      //Handle Send Email Confirmed or Cancelled
      $(modalCancel).unbind().bind("click", function(){
         $(sharedModal).modal("hide");
      });
      
      $(modalConfirm).unbind().bind("click", function () {
         const subject = $("#email-subject").val();
         const body = $("#email-body").val();
         const language = $("#email-language").val();
         
         $.ajax({
            url:'/Admin/SendEmail/',
            type: "POST",
            data:{userId: userId, subject: subject, language: language, body: body},
            success:function(){
               RevokeNotifications("Email");
               $(modalContent).append("<div style='color: green'>Email Sent Successfully!</div>");
               setTimeout(function(){$(sharedModal).modal("hide");}, 2000)
            },
            error: function(){
               $(modalContent).append("<div style='color: red'>Error: Refresh and try again!</div>");
            }
         })
      });
      
      
      $(sharedModal).modal("show");
      
      
   });
   //*** END OF SEND EMAIL TO USER AREA ***//
   
   
   
   
   
   
   
   
   
   //*** Block User Area ***///
   
   //Variables
   const blockBtn = $(".admin-block-btn");
   const unblockBtn = $(".admin-unblock-btn");
   
   $(blockBtn).add($(unblockBtn)).unbind().bind("click", function(){
      const userId = $(this).attr("userId");
      let isUserBlocked = $(this).closest(".full-user-div").attr("blocked");
      isUserBlocked = isUserBlocked === "True";
      const theModalOn = $(this).text();

      $(modalTitle).text("The User Will Be: "+ theModalOn+"ed");
      $(modalConfirm).text("Confirm").removeClass("btn-danger").addClass("btn-success");
      $(modalCancel).text("Cancel");
      let modalBody;
      if(isUserBlocked)
         modalBody = "<input disabled class='form-control' style='margin-bottom: 0.3rem' placeholder='email' value='the user is blocked now'/>";
      else
         modalBody = "<input disabled class='form-control' style='margin-bottom: 0.3rem' placeholder='email' value='the user is NOT blocked now'/>";
      
      if(theModalOn === "Block")
         modalBody += "<input disabled class='form-control' style='margin-bottom: 0.3rem' placeholder='email' value='The user will be BLOCKED'/>";
      else
         modalBody += "<input disabled class='form-control' style='margin-bottom: 0.3rem' placeholder='email' value='the user will be UNBLOCKED'/>";
      
      modalBody+=
          "<select style='margin-bottom: 0.3rem' id='block-type' class='form-control'><option value='SharedAccount'>Shared Account</option><option value='FakeAccount'>Fake Account</option>" +
          "<option value='Misused'>Misused Account</option><option value='WrongInfo'>Wrong Information</option><option value='UnPaid'>Unpaid Invoices</option><option value='Other'>Other Reason</option></select>"+
          "<input id='block-message' class='form-control' style='margin-bottom: 0.3rem' placeholder='Message'/>";
      
      $(modalContent).html(modalBody);
      $(sharedModal).modal("show");
      const userWillBeBlocked = theModalOn === "Block";
      
      //Block or unblock confirmed
      $(modalConfirm).unbind().bind("click", function(){
         changeBlockStatus(userId, userWillBeBlocked, $("#block-type").val(), $("#block-message").val())
      })
      
      //Cancel clicked
      $(modalCancel).unbind().bind("click", function(){
         $(sharedModal).modal("hide");
      })
      
      
      
   });
   
   function changeBlockStatus(userId, willBeBlocked, blockType, message){
      $.ajax({
         type: "POST",
         url:"/Admin/BlockUser",
         data:{userId: userId, blockTheUser: willBeBlocked, blockType: blockType, message: message},
         success:function(){
            if(willBeBlocked)
               $(modalContent).append("<div style='color: red'><strong>User is Blocked Now!</strong></div>");
            else
               $(modalContent).append("<div style='color: green'>User is Unblocked Successfully!</div>");
            $(modalConfirm).attr("disabled", "disabled");
            setTimeout(function(){$(sharedModal).modal("hide");}, 2000)
         },
         error: function(response){
            $(modalContent).append("<div style='color: red'>"+response.responseText+"</div>");
         }
      })
   }



   //*** END OF Block User Area ***///
   
   
   //*** SEARCH FORM ***//
   
   //Prevent confirmation on refresh
   if ( window.history.replaceState ) {
      window.history.replaceState( null, null, window.location.href );
   }
   
   const searchForm = $("#admin-user-search");
   $("#admin-user-search-btn").unbind().bind("click", function(){searchForm.submit()});
   $("#admin-user-all-btn").unbind().bind("click", function(){searchForm.children("input").val(""); searchForm.submit();});

   

   //*** END OF SEARCH FORM ***//
   
   
   
   
   //*** EDIT USER FORM ***//

   //Just make sure to border changed in red for more attention and security
   $(".admin-edit-user-container :input").change(function(){
      $(this).css("border", "1px solid red");
   });
   
   
   
   
   //*** Delete User Picture ***//
   const deletePicResponse = $("#admin-delete-pic-response");
   $("#admin-delete-user-pic").unbind().bind("click", function () {
      const userId = $(this).attr("user-id");
      $(modalContent).text("Are you sure to delete the picture?");
      $(sharedModal).modal("show");
      $(modalCancel).click(function(){$(sharedModal).modal("hide")});
      $(modalConfirm).unbind().bind("click", function(){
         $.ajax({
            type: "POST",
            url: "/Admin/DeletePicture",
            data:{userId: userId},
            success: function(){
               $(modalContent).append("<div style='color: green'>Removed successfully</div>");
               setTimeout(function(){$(sharedModal).modal("hide")}, 3000);
            },
            error: function(response){
               $(modalContent).append("<div style='color: red'>Error: " + response.responseText+"</div>");
            }
         });
      });
   })
   

   //*** END OF EDIT USER FORM ***//
   
   
   
   
   
   
   
   
   
   
   
});