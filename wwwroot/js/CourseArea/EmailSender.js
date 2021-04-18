$(document).ready(function(){


    //Shared Modal
    const sharedModal = $("#shared-modal");
    const sharedModalConfirm = $("#shared-modal-btn-yes");
    const sharedModalCancel = $("#shared-modal-btn-no");
    const sharedModalContent = $("#shared-modal-content");
    const sharedModalTitle = $("#shared-modal-title");
    const waitModal = $("#wait-modal");
    const courseId = $("#courseId").val();


    //*** Send Lecture Reminder ***//
    const lectureReminderBtn = $("#lecture-reminder-btn");
    $(lectureReminderBtn).unbind().bind('click', function(){
        $(sharedModalTitle).text(JSLanguage("sendLectureReminder"));


        const htmlSenderData = "" +
            "<br/>"+
            "<div class='un-select text-center'>" +
            "<div class='text-success small font-cairo'>"+JSLanguage('addTitleAndDescriptionBefore')+"</div>"+
            "<br/>"+
            "<div id='e-s-response' style='display: none' class='text-success'>"+JSLanguage('theProcessIsDone')+"</div>"+
            "</div>";


        $(sharedModalContent).html(htmlSenderData);


        $(sharedModalConfirm).removeClass("btn btn-success").addClass("m-button m-button-danger").text(JSLanguage('send'));
        $(sharedModalCancel).removeClass("btn btn-dark btn-danger").addClass("m-button m-button-success").text(JSLanguage('cancel'));
        $(sharedModal).modal('show');

        $(sharedModalCancel).unbind().bind('click', function () {
            $(sharedModal).modal('hide');
        });

        $(sharedModalConfirm).unbind().bind('click', function(){
            const senderResponse = $("#e-s-response");


            $(sharedModalConfirm).attr('disabled', 'disabled').addClass('disabled');
            
            $.ajax({
                type: "post",
                url: "/Lecture/SendLectureReminder",
                data: {courseId : courseId},
                success: function(){
                    $(senderResponse).addClass('text-success').removeClass('text-danger').text(JSLanguage('theProcessIsDone')).fadeIn(200);
                    // $(waitModal).modal('hide');

                    setTimeout(function(){
                        $(sharedModal).modal('hide');
                        $(lectureReminderBtn).attr('disabled', 'disabled');
                        $(sharedModalConfirm).removeAttr('disabled');
                        
                        //ToDo :: When notification sent, revoke notifications
                        
                        RevokeNotifications("Email");
                        RevokeNotifications("Sms");
                    }, 1000);

                },
                error: function(response){
                    $(waitModal).modal('hide');
                    alert(response.responseText)
                }


            });


        });

    });
    //*** END OF Send Lecture Reminder ***//
    
    
    
    
})