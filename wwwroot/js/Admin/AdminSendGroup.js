$(document).ready(function(){


    
    const modalTitle = $("#shared-modal-title");
    const modalContent = $("#shared-modal-content");
    const modalConfirm = $("#shared-modal-btn-yes");
    const modalCancel = $("#shared-modal-btn-no");
    let sharedModel = $("#shared-modal");


    //*** Send Email to Group Area ***//



    const emailGroupBtn = $("#admin-send-email-group-btn");
    
    
    
    
    
    
    
    $(emailGroupBtn).unbind().bind('click', function () {

        $(modalTitle).text("Send Email to All");
        const courseId= $(this).attr("course-id");

        $(modalConfirm).text("Send Email");
        $(modalCancel).text("Cancel");

        const modalBody =
            "<input id='email-subject' class='form-control' style='margin-bottom: 0.3rem' placeholder='Subject'/>" +
            "<input id='email-language' class='form-control' style='margin-bottom: 0.3rem' placeholder='Language'/>" +
            "<textarea id='email-group-body' style='width: 100%; height: 10rem; resize: none' placeholder='Write a text..'></textarea>";
        $(modalContent).html(modalBody);

        
        $(modalCancel).click(function(){
            $(sharedModel).modal('hide');
        });
        
        $(sharedModel).modal('show');



        $(modalConfirm).unbind().bind("click", function () {
            const subject = $("#email-subject").val();
            const body = $("#email-group-body").val();
            
            const language = $("#email-language").val();

            $.ajax({
                url:'/Admin/SendGroupEmail/',
                type: "POST",
                data:{courseId: courseId, subject: subject, language: language, body: body},
                success:function(){
                    $(modalContent).append("<div style='color: green'>Email Sent Successfully!</div>");
                    
                    setTimeout(function(){sharedModel.modal('hide');}, 2000);
                    
                },
                error: function(){
                    $(modalContent).append("<div style='color: red'>Error: Refresh and try again!</div>");
                }
            })
        });
        
        
        
        
        
        
        
        
        
        
        
        
    });
    
   
    //*** END OF SEND EMAIL TO GROUP AREA ***//



    
    
    

    //*** Send SMS to Group Area ***//
    const smsGroupBtn = $("#admin-send-sms-group-btn");


    $(smsGroupBtn).unbind().bind('click', function () {

        $(modalTitle).text("Send sms to All");
        const courseId = $(this).attr("course-id");

        $(modalConfirm).text("Send SMS");
        $(modalCancel).text("Cancel");

        const modalBody =
            "<div class='mb-4 mt-4'>Letters: <span id='letters-count'>0</span></div>"+
            "<textarea id='sms-group-body' style='width: 100%; height: 10rem; resize: none' placeholder='Write a text..'></textarea>";
        $(modalContent).html(modalBody);


        $(modalCancel).click(function () {
            $(sharedModel).modal('hide');
        });

        $(sharedModel).modal('show');

        const body = $("#sms-group-body");
        
        bindCounterEvent(body, $("#letters-count"));


        $(modalConfirm).unbind().bind("click", function () {
            
            
            $.ajax({
                url: "/Admin/SendGroupSms/",
                type: 'POST',
                data: {courseId: courseId, body: body.val()},
                success: function () {
                    $(modalContent).append("<div style='color: green'>SMS Sent Successfully!</div>");
                    RevokeNotifications("Sms");

                    setTimeout(function () {
                        sharedModel.modal('hide');
                    }, 2000);

                },
                error: function () {
                    $(modalContent).append("<div style='color: red'>Error: Refresh and try again!</div>");
                }
            })
            
        });


    });
    
    
    
    function bindCounterEvent(bodySelector, letterSelector) {
        
        
        $(bodySelector).on('keyup', function(){
            const length = bodySelector.val().length;
            $(letterSelector).text(length);
            
            
        });
        
        
    }




    //*** END OF SEND SMS TO GROUP AREA ***//
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
});