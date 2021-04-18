$(document).ready(function(){
    const showNameContainer = $("#show-name-container");
    const showNameInput = $("#show-name-input");
    const nameToShow = $("#name-to-show");
    const realName = $("#full-name").val();
    const profileName = $("#profile-name").val();
    
    let disableAll =false;
    
    
    //Privacy
    $(showNameContainer).click(function(e){
        if (disableAll){
            e.stopPropagation();
            return false;
        }
        
        let showName = $(showNameInput).prop('checked');
        
        showName = !showName;
        
        $.ajax({
            type: "Post",
            url: "/Settings/ShowName/",
            data: {showName: showName},
            success: function(){
                $(showNameInput).prop('checked', !$(showNameInput).prop('checked'));
                if(showName)
                    $(nameToShow).text(realName);
                else
                    $(nameToShow).text(profileName);

                disableInputs(true);
                

            },
            error: function(response){
                disableInputs(false);
            }
        });
        
    });
    
    
    
    //Notifications
    
    // const beforeLectureContainer = $("#before-lecture-container");
    // const beforeLectureInput = $("#before-lecture-input");
    //
    // $(beforeLectureContainer).click(function(){
    //     updateNotification(beforeLectureInput)
    // });
    //
    // const courseUpdateContainer = $("#course-update-container");
    // const courseUpdateInput = $("#course-update-input");
    //
    // $(courseUpdateContainer).click(function(){
    //     updateNotification(courseUpdateInput)
    // });
    //
    // const importantUpdateContainer = $("#important-update-container");
    // const importantUpdateInput = $("#important-update-input");
    //
    // $(importantUpdateContainer).click(function(){
    //     updateNotification(importantUpdateInput)
    // });
    //
    // const otherUpdateContainer =$("#offer-other-container");
    // const otherUpdateInput = $("#offer-other-input");
    //
    // $(otherUpdateContainer).click(function(){
    //     updateNotification(otherUpdateInput)
    // });
    //
    
    $('.notification-switch').click(function(){
        const input = $(this).find('input');
        updateNotification(input)
    })
    
    
    
    
    function updateNotification(input) {
        if (disableAll)
            return false;
        
        
        //Determine notification type
        const type = $(input).attr('notify-type');
        const method = $(input). attr('notify-method');

        //Current value
        let receive = $(input).prop('checked');

        //Flip value
        receive = !receive;
        
        $.ajax({
            type: "POST",
            url:"/Settings/Notifications/",
            data: {type: type, receive: receive, method: method},
            success: function(){
                $(input).prop('checked', !$(input).prop('checked'));
                disableInputs(true);
            },
            error: function(){
                disableInputs(false);
            }
        })
        
        
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    function disableInputs(success){
        disableAll = true;
        
        if(success)
            $("#success-updating").fadeIn(300);
        else
            $("#error-updating").fadeIn(300);

        setTimeout(function () {
            disableAll = false;
            $("#success-updating").add($("#error-updating")).fadeOut(400);
        }, 2000);
        
    }
    
});