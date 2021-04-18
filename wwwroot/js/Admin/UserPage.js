$(document).ready(function(){
    
   
   const sharedModel = $("#shared-modal");
   const modalTitle = $("#shared-modal-title");
   const modalContent = $("#shared-modal-content");
   const modalConfirm = $("#shared-modal-btn-yes");
   const modalCancel = $("#shared-modal-btn-no");
   
    
    
   //*** Nav Links ***//
   
   //If href is empty
   if(window.location.href.split("#").length<2){
      window.location.href = window.location.href+"#payments";
      $("#payments").css("display", "block");
      $(".tab-link[href='#payments']").addClass("active-tab");
   }
   //On refresh the page, the href is not empty
   else{
      const currentTab = window.location.href.split("#")[1]; 
      $("#"+ currentTab).css("display", "block");
      $(".tab-link[href='#"+currentTab+"']").addClass("active-tab");
   }
   
   //On click to move the tab
   $(".tab-link").unbind().bind("click", function(){
      $(".tab-div").css("display", "none");
      $(".tab-link").removeClass("active-tab");
      $($(this).attr("href")).css("display", "block");
      $(".tab-link[href='"+$(this).attr("href")+"']").addClass("active-tab");
   });


   //*** END OF Nav Links ***//
   
   
   //*** Delete Feedback *** //
   $(".feedback-delete").unbind().bind("click", function(){
      const feedback = $(this).parent().parent();
      const feedbackId = $(this).attr("feedback-id");
      const courseId = $(this).attr("course-id");
      $.ajax({
         type: "POST",
         url: "/Course/DeleteFeedBack",
         data: {courseId: courseId, feedbackId : feedbackId},
         success: function(){
            $(feedback).remove();
            const feedBackContainer = $("#feedback-container");
            if($(feedBackContainer).find(".feedback-div").length === 0){
               $(feedBackContainer).append("<div class=\"text-center\" id=\"no-comment-yet\"style=\"margin: 1rem;\">لا يوجد تعليقات بعد! بادر بنشر رأيك</div> ");
            }

         }
      });
   });

   //*** END OF Delete Feedback *** //
   
   
   //*** Edit Registration ***//
   
   $(".auth-cookies").unbind().bind("click", function(){
      $(sharedModel).modal("show").removeClass("un-select");
      $(modalTitle).text("Auth - Cookies");
      $(modalContent).text($(this).attr("full-auth"));
      $(modalConfirm).add($(modalCancel)).click(function(){$(sharedModel).modal("hide");});
   });
   
   $(".edit-reg").change(function(){
      $(this).css("border", "1px solid red");
      if($(this).hasClass("exp")){
         $(this).parent().css("border", "1px solid red");
      }
   });
   const applyReg = $(".admin-apply-registration");
   $(applyReg).unbind().bind("click", function(){
      const row = $(this).closest("tr");
      const studentId = $(this).attr("student-id");
      const courseId = $(this).attr("course-id");
      const price = $(this).parent().parent().find("#reg_Price").val();
      const comment = $(this).parent().parent().find("#reg_AdminComment").val();
      const exp = $(this).parent().parent().find("#reg_Expire").prop("checked");
      const canceled = $(this).parent().parent().find("#reg_Canceled").prop("checked");
      const expDate = $(this).parent().parent().find("#reg_ExpireDate").val();
      
      
      $.ajax({
         type:"POST",
         url: "/Admin/EditReg",
         data: {courseId: courseId, userId: studentId,cancel: canceled, exp:exp, expDate:expDate, price: price, comment: comment},
         success: function (response) {
            $(row).attr("style", "background-color: rgba(18 , 160, 20, 0.5)");
            setTimeout(function(){$(row).removeAttr("style")}, 1500);
            $(".edit-reg").removeAttr("style");
         },
         error: function(){
            $(row).attr("style", "background-color: rgba(255 , 10, 20, 0.5)");
            setTimeout(function(){$(row).removeAttr("style")}, 1500);
         }
      })
      
      
      
   });
   
   //*** END OF Edit Registration ***//
   
   
   //*** Add new registration ***//

   $(".inv-edit").change(function(){
      $(this).css("border", "1px solid red");
      if($(this).hasClass("paid-invoice")){
         $(this).parent().css("border", "1px solid red");
      }
   });
   
   
   const createRegForm = $("#admin-create-reg");
   $("#new-reg").unbind().bind("click", function(){$(createRegForm).removeAttr("hidden")});
   $("#admin-create-reg-btn").unbind().bind("click", function () {
      const courseId = $(createRegForm).find("select[name=courseId]").val();
      const studentId = $("#user-id-main-page").text();
      const price = $(createRegForm).find("input[name=price]").val();
      const comment = $(createRegForm).find("input[name=comment]").val();
      const expDate = $(createRegForm).find("input[name=expDate]").val();
      
      
      $.ajax({
         type:"POST",
         url: "/Admin/AddReg",
         data: {courseId: courseId, userId: studentId, price: price, comment: comment, expDate: expDate},
         success: function(){
            $("#add-reg-response").text("Added successfully").css("color", "green");
            setTimeout(function(){$(createRegForm).hide()}, 3000);
            // location.reload();
         },
         error: function(response){
            $("#add-reg-response").text("Error: " + response.responseText).css("color", "red");
         }
      })
   });
   //*** END OF ADD REGISTRATION ***//


   //*** Open Lecture ***//


   const openLectureForm = $("#admin-open-lecture");
   $("#new-open-lecture").unbind().bind("click", function(){$(openLectureForm).removeAttr("hidden")});
   $("#admin-open-lecture-btn").unbind().bind("click", function () {
      const courseId = $(openLectureForm).find("select[name=courseId]").val();
      const studentId = $("#user-id-main-page").text();
      const lectureNumber = $(openLectureForm).find("input[name=lectureNumber]").val();
      const expDate = $(openLectureForm).find("input[name=expDate]").val();
      

      $.ajax({
         type:"POST",
         url: "/Admin/OpenLecture",
         data: {courseId: courseId, userId: studentId, lectureNumber: lectureNumber, expDate: expDate},
         success: function(){
            $("#open-lecture-response").text("Added successfully").css("color", "green");
            setTimeout(function(){$(openLectureForm).hide(); window.location.reload();}, 1000);
            // location.reload();
         },
         error: function(response){
            $("#open-lecture-response").text("Error: " + response.responseText).css("color", "red");
         }
      })
   });
   
   
   //Remove open lecture
   $("#remove-open-lecture").unbind().bind('click', function(){
      const lectureId = $(this).attr("lecture-id");
      const studentId = $("#user-id-main-page").text();

      $.ajax({
         type:"POST",
         url: "/Admin/RemoveOpenLecture/",
         data: {userId: studentId, lectureId: lectureId},
         success: function(){
            $("#remove-open-lecture").parent().parent().css("background-color", "gray");
            window.location.reload();
            // location.reload();
         },
         error: function(response){
            alert(response.responseText)
            
         }
      })
   });
   
   //*** END OF OPEN LECTURE ***//
   
   
   //*** REMOVE INCREMENT *** //
   
   $(".remove-increment").unbind().bind('click',function(){
      const incrementId = $(this).attr("increment-id");
      const element = $(this);

      $.ajax({
         type:"POST",
         url: "/Admin/RemoveIncrement/",
         data: {incrementId: incrementId},
         success: function(){
            $(element).parent().parent().css("background-color", "gray");
            window.location.reload();
         },
         error: function(response){
            alert(response.responseText)

         }
      })
      
   });




   //*** END OF REMOVE INCREMENT *** //
   
   
   
   //*** Edit Invoice ***//
   $(".admin-edit-invoice-btn").unbind().bind("click", function(){
      const parentElement = $(this).parent().parent();
      const invoiceNumber = $(parentElement).find(".invoice-number").text();
      const invoiceAmount =$(parentElement).find("input[name='invoice.Amount']").val();
      const dueDate =$(parentElement).find("input[name='invoice.OriginalDueDate']").val();
      const deadline =$(parentElement).find("input[name='invoice.OriginalDeadline']").val();
      const description =$(parentElement).find("input[name='invoice.ExtraDescription']").val();
      const paid =$(parentElement).find("input[name='invoice.Paid']").prop("checked");
      const reason =$(parentElement).find(".invoice-reason").val();
      const invoiceType =$(parentElement).find(".invoice-type").val();
      
      
      
      $.ajax({
         type:"POST",
         url: "/Admin/EditInvoice",
         data: {invoiceNumber: invoiceNumber,amount: invoiceAmount, deadline: deadline, dueDate: dueDate, description: description, paid: paid, reason: reason, invoiceType: invoiceType},
         success: function(){
            $(parentElement).attr("style", "background-color: rgba(18 , 160, 20, 0.5)");
            setTimeout(function(){$(parentElement).removeAttr("style")}, 1500);
            $(".inv-edit").removeAttr("style");
            $(".paid-invoice").parent().removeAttr("style");
         },
         error: function(){
            $(parentElement).attr("style", "background-color: rgba(255 , 10, 20, 0.5)");
            setTimeout(function(){$(parentElement).removeAttr("style")}, 1500);
         }
      })
      
   });
   
   //*** END OF Edit Invoice ***//
   
   //*** Show Payment Id ***//
   $(".invoice-done-paid").click(function(){
      const paymentId = $(this).attr("inv-payment-id");
      
      $(modalContent).html("<div class='text-center'><p>Payment ID:</p><p>"+paymentId+"</p></div>");
      $(sharedModel).modal("show");
   });
   
   $(".payment-row").children().not(".not-this").unbind().bind("click", function(e){
      

      const paymentId = $(this).parent().attr("id");
      $(modalContent).html("<div class='text-center'><p>Payment ID:</p><p>"+paymentId+"</p></div>");
      $(sharedModel).modal("show");
      
   });
   
   
   
   //*** END OF Show Payment Id
   
   
   //*** Delete Invoice ***//
   $(".admin-delete-invoice").unbind().bind("click", function(){
      const parentElement = $(this).parent().parent();
      const invoiceNumber = $(parentElement).find(".invoice-number").text();
      
      $(sharedModel).modal("show");
      $(modalContent).html("<div>Do you Really want to remove the invoice with number:</div></br><div>"+invoiceNumber+"</div>");
      
      $(modalConfirm).unbind().bind("click", function(){
         $.ajax({
            type: "POST",
            url: "/Admin/DeleteInvoice",
            data: {invoiceNumber: invoiceNumber},
            success: function(){
               
               $(parentElement).remove();
               $(sharedModel).modal("hide");
               
            }
         });
      });
      $(modalCancel).click(function(){$(sharedModel).modal("hide");});
      
      
   });
   
   
   //*** END OF Delete Invoice ***//
   
   
   //*** Create New Invoice ***//
   const createInvForm = $("#admin-create-inv");
   
   $("#new-inv").unbind().bind("click", function(){
      $(createInvForm).removeAttr("hidden");
   });

   $("#admin-create-inv-btn").unbind().bind("click", function () {
      const courseId = $(createInvForm).find("select[name=courseId]").val();
      const studentId = $("#user-id-main-page").text();
      const amount = $(createInvForm).find("input[name=amount]").val();
      const description = $(createInvForm).find("input[name=description]").val();
      const invReason = $(createInvForm).find("#create-inv-reason").val();
      const dueDate = $(createInvForm).find("input[name=dueDate]").val();
      
      console.log(invReason);


      $.ajax({
         type:"POST",
         url: "/Admin/CreateInvoice",
         data: {courseId: courseId, userId: studentId, amount: amount, description: description, dueDate: dueDate, reason: invReason},
         success: function(){
            $("#add-inv-response").text("Added successfully").css("color", "green");
            $("#admin-create-inv-btn").attr("disabled", "disabled");
            setTimeout(function(){$(createInvForm).hide(); location.reload();}, 2000);

         },
         error: function(response){
            $("#add-reg-response").text("Error: " + response.responseText).css("color", "red");
         }
      })
   });
   
   //*** Send Invoice Reminder Email ***//
   
   $(".admin-invoice-email").unbind().bind("click", function () {
      const adminInvoiceEmailBtn = $(this);
      const invoiceNumber = $(this).attr("invoice-number");
      const studentId = $("#user-id-main-page").text();
      
      $.ajax({
         type:"POST",
         url: "/Admin/SendInvoiceReminder/",
         data: {userId: studentId, invoiceNumber: invoiceNumber},
         success: function(){
            adminInvoiceEmailBtn.attr('disabled', 'disabled');
         },
         error:function(){
            alert("error happened");
         }
      });
      
      
      
      
   });
   
   
   //*** END OF Send Invoice Reminder Email ***//
   
   
   
   //*** END OF INVOICE HANDLER ***//
   
   
   
   //*** Add New Payment ***//
   const createPaymentForm = $("#admin-create-payment");
   $("#new-payment").unbind().bind("click", function(){
      $(createPaymentForm).removeAttr("hidden");
   });

   $("#admin-create-payment-btn").unbind().bind("click", function () {
      const studentId = $("#user-id-main-page").text();
      const amount = $(createPaymentForm).find("input[name=amount]").val();
      const paymentReason = $(createPaymentForm).find("#create-payment-reason").val();
      const paymentMethod = $(createPaymentForm).find("#create-payment-method").val();
      const description = $(createPaymentForm).find("input[name=description]").val();
      const paymentDate = $(createPaymentForm).find("input[name=paymentDate]").val();
      const invoiceNumber = $(createPaymentForm).find("input[name=invoiceNumber]").val();
      
      



      $.ajax({
         type:"POST",
         url: "/Admin/CreatePayment",
         data: {userId: studentId, amount: amount, description: description, paymentDate: paymentDate, reason: paymentReason, method: paymentMethod, invoiceNumber: invoiceNumber},
         success: function(){
            $("#add-payment-response").text("Added successfully").css("color", "green");
            $("#admin-create-payment-btn").attr("disabled", "disabled");
            setTimeout(function(){$(createPaymentForm).hide(); location.reload();}, 3000);
            // 
         },
         error: function(response){
            $("#add-payment-response").text("Error: " + response.responseText).css("color", "red");
         }
      })
   });
   
   
   
   //*** END OF Add New Payment ***//
   
   
   
   //*** Refund Payment ***//
   $(".admin-refund-payment").unbind().bind("click", function(){
      const amount = $(this).attr("amount");
      const parentElement = $(this).parent().parent();
      const paymentId = parentElement.attr("id");
      const serviceId = parentElement.find(".payment-service-id").text();
      const paymentMethod = $(this).attr("payment-method")
      
      const htmlData = "<div class='text-center'><p>Payment ID: "+paymentId+"</p><p>Service ID (order number): "+serviceId+"</p><input style='width: max-content; margin:auto;' class='form-control' id='new-amount-to-refund' value='"+amount+"'/></div><code>"+paymentMethod+"</code><br/><div id='refund-response'></div>";
      $(modalContent).html(htmlData);
      $(sharedModel).modal("show");
      
      $(modalCancel).unbind().bind("click", function(){$(sharedModel).modal("hide");});
      
      $(modalConfirm).unbind().bind("click", function(){
         const newAmount = $("#new-amount-to-refund").val();
         const responseDiv = $("#refund-response");
         
         if(paymentMethod === "Vipps")
            VippsRefund();
         else if(paymentMethod === "Stripe")
            StripeRefund();
         
         
         
         function VippsRefund(){
            $.ajax({
               type: "POST",
               url:"/VippsRefund",
               data: {paymentId: paymentId, orderId: serviceId, amount: newAmount},
               success: function () {
                  responseDiv.text("Refunded successfully").css("color", "green");
                  setTimeout(function(){$(sharedModel).modal("hide");}, 3000);
               },
               error: function (response) {
                  responseDiv.text("Error: " + response.responseText).css("color", "red");
               }
            });
         }
         
         
         function StripeRefund() {
            $.ajax({
               type: "POST",
               url:"/StripeRefund",
               data: {paymentRef: serviceId},
               success: function () {
                  responseDiv.text("Refunded successfully").css("color", "green");
                  setTimeout(function(){$(sharedModel).modal("hide");}, 3000);
               },
               error: function (response) {
                  responseDiv.text("Error: " + response.responseText).css("color", "red");
               }
            });
            
         }
         
         
      });
      
      
   });
   
   
   
   //*** END OF REFUND PAYMENT
   
   
   
   //*** Cancel Invoice
   $(".admin-cancel-invoice").unbind().bind('click', function(){
      const invoiceNumber= $(this).attr("invoice-number");

      const htmlData = "<div class='text-center'><p>Invoice Nr: "+invoiceNumber+"</p></div><br/><div id='cancel-response'></div>";
      $(modalContent).html(htmlData);
      $(sharedModel).modal("show");

      $(modalCancel).unbind().bind("click", function(){$(sharedModel).modal("hide");});

      const responseDiv = $("#cancel-response");
      
      $(modalConfirm).unbind().bind('click', function(){
         $.ajax({
            type: "POST",
            url:"/Admin/CancelInvoice",
            data: {invoiceNumber: invoiceNumber},
            success: function () {
               responseDiv.text("Canceled successfully").css("color", "green");
               setTimeout(function(){$(sharedModel).modal("hide");}, 3000);
            },
            error: function (response) {
               responseDiv.text("Error: " + response.responseText).css("color", "red");
            }
         });
      });
      
      
   });
   
   
   
   
   
   //*** INCREMENT OF INVOICE ***//
   
   $(".invoice-increment-btn").unbind().bind("click", function(){
      
      const invoiceNumber = $(this).attr("invoice-number");
      
      $(modalTitle).text("Increment the invoice: "+invoiceNumber);
      $(modalContent).html(
          "<div><strong>" + invoiceNumber + "</strong></div>" +
          "<div><label'>Fixed</label>&nbsp;<input checked='true' id='fixed-increment' type='radio'/>&emsp;<label>Percent</label>&nbsp;<input id='percent-increment' type='radio'/></div>" +
          "<div><input style='width: 50%; display: inline' id='increment-amount' class='form-control' type='number' placeholder='amount'/><span id='percent-sign' style='display: none'>%</span></div>" +
          "<div><label'>Paper</label>&nbsp;<input id='paper-increment' type='radio'/>&emsp;<label>Latency</label>&nbsp;<input checked='true' id='latency-increment' type='radio'/></div>" +
          "<div><input style='width: 50%; display: inline' id='new-due-date' class='form-control' type='date' /></div>"
      );
      
      $("#shared-modal-btn-yes").text("Apply").addClass("btn-success").removeClass("btn-danger").click(function(){
         
         let incrementType = "Fixed";
         let incrementReason = "Latency";
         
         if(!$("#fixed-increment").prop("checked")){
            incrementType = "Percent";
         }
         
         if(!$("#latency-increment").prop("checked")){
            incrementReason = "PaperInvoice";
         }
         const incrementAmount = $("#increment-amount").val();
         const newDueDate = $("#new-due-date").val();
         
         $(this).attr('disabled', 'disabled');
         
         $.ajax({
            type: "POST",
            url: "/Admin/AddInvoiceIncrement",
            data: {invoiceNumber: invoiceNumber, incrementType: incrementType, incrementReason:incrementReason, amount: incrementAmount, newDueDate: newDueDate},
            success: function(response){
               console.log(response);
            }
         });
         $(sharedModel).modal("hide");
      });
      
      $("#shared-modal-btn-no").text("Cancel").click(function(){$(sharedModel).modal("hide")});
      
      
      $("#fixed-increment").click(function() {
         $("#percent-increment").prop("checked", false);
         $("#percent-sign").css("display", "none")
      });
      $("#percent-increment").click(function() {
         $("#fixed-increment").prop("checked", false);
         $("#percent-sign").css("display", "inline")
      });
      $("#paper-increment").click(function() {
         $("#latency-increment").prop("checked", false);
      });
      $("#latency-increment").click(function() {
         $("#paper-increment").prop("checked", false);
      });
      
      
      
      
      
      $(sharedModel).modal("show");
   });
   
   
   
   
   
   
   
   //** END OF INVOICE INCREMENT **//
   
   
   
   
   //** Modify User Device **//
   
   const modifyDeviceBtn = $(".modify-device");
   
   $(modifyDeviceBtn).unbind().bind("click", function(){
      const deviceId = $(this).attr("device-id");
      const isNew = $(this).parent().parent().find(".is-new-device").prop("checked");
      const groupNumber = $(this).parent().parent().find(".device-group-number").val();
      const toResponse = $(this);
      
      $.ajax({
         type:"POST",
         url:"/Admin/ModifyDevice/",
         data :{deviceId: deviceId, isNew: isNew, groupNumber: groupNumber},
         success: function(){
            $(toResponse).css("background-color", "green");
            $(toResponse).attr('disabled', 'disabled');
         },
         error: function(e){
            console.log(e);
            console.log(e.responseText)
         }
      })
      
   });



   //** Modify User Device **//

   const deleteDeviceBtn = $(".delete-device");

   $(deleteDeviceBtn).unbind().bind("click", function(){
      const deviceId = $(this).attr("device-id");
      const toResponse = $(this);

      $.ajax({
         type:"POST",
         url:"/Admin/DeleteDevice/",
         data :{deviceId: deviceId},
         success: function(){
            $(toResponse).css("background-color", "green");
            $(toResponse).attr('disabled', 'disabled');
         },
         error: function(e){
            console.log(e);
            console.log(e.responseText)
         }
      })

   });










   
   
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
});