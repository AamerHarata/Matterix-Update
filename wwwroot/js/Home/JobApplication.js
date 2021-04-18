$(document).ready(function(){


    const videoLink = $("#Application_VideoLink");
    const courseName = $("#Application_CourseName");
    const chooseFile = $("#choose-file");
    const deleteFile = $("#delete-file");
    const hiddenFile = $("#file");
    const fileName = $("#file-name");
    let file;
    
    const jobApplicationValidation = $("#job-application-validation");

    
    $("#has-previous").unbind().bind('click', function(){
        $("#application-section").fadeOut(200);
        setTimeout(function () {
            $("#previous-applications-section").fadeIn(100);

        }, 300);
    });

    $("#new-application").unbind().bind('click', function(){
        $("#previous-applications-section").fadeOut(200);
        setTimeout(function () {
            $("#application-section").fadeIn(100);

        }, 300);
    });
    
    
    $(chooseFile).click(function() {
        $(hiddenFile).click();
    });

    $(hiddenFile).unbind().bind('change',function(e) {
        file = e.target.files[0];
        $(fileName).text(file.name);
        $(deleteFile).css('display', 'inline-block');
    });

    $(deleteFile).click(function() {
        $(fileName).text('');
        $(hiddenFile).val(null);
        file = null;
        $(this).css('display', 'none');
        $("#file-validation").text('');

    });

    const continueSubmit = {yes: true, submitClicked: false};
    const listToEmptyValidation = [videoLink, courseName];
    $("#submit-job-application-form").unbind().bind('click', function(){
        const submit = $(this);
        
        if(continueSubmit.submitClicked)
            return false;
        continueSubmit.submitClicked = true;
        
        $(listToEmptyValidation).each(function (i, e) {
            if ($(e).val().length < 1)
                validationNewInput($(e), $(jobApplicationValidation), "fieldsInRedNotEmpty", continueSubmit);

        });

        if (continueSubmit.yes && $(hiddenFile).val().length < 1)
            validation($(chooseFile), $(jobApplicationValidation), "fieldsInRedNotEmpty", continueSubmit);
        
        if(continueSubmit.yes){
            if (file != null && file.size > 25 * 1024 * 1024) {
                validationNewInput($(chooseFile), $(jobApplicationValidation), 'largeFileMax25', continueSubmit);
                file = null;
                $(hiddenFile).val(null);
            }
        }

        if(continueSubmit.yes){
            $(submit).attr('disabled', true);
                        
            const formData = new FormData;
            formData.append("file", file);
            formData.append("Application.CourseName", $(courseName).val());
            formData.append("Application.VideoLink", $(videoLink).val());
            formData.append("Application.ExtraMessage", $("#Application_ExtraMessage").val());
            
            
            $.ajax({
                type: "POST",
                url: "/Home/JobApplication",
                contentType: false,
                processData: false,
                async: false,
                data: formData,
                success: function (resp) {
                    $("#application-section").fadeOut(200);
                    setTimeout(function () {
                        $("#application-completed-section").fadeIn(100);

                    }, 300);
                    
                    RevokeNotifications("Email");



                },
                error: function () {
                    $("#job-application-validation").text(JSLanguage('errorRefresh'))
                    $(submit).removeAttr('disabled');
                    continueSubmit.submitClicked = false;
                }
            });
            
            
        }
    })
    
    
});