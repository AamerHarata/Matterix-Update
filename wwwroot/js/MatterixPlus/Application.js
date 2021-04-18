$(document).ready(function() {
    const chooseFile = $("#choose-file");
    const hiddenFile = $("#hidden-file-input");
    const uploadFile = $("#upload-file");
    const fileResponse = $("#file-response");
    let file;

    //Upload File clicked
    $(chooseFile).unbind().bind('click', function () {
            $(hiddenFile).click();
    });

    //Actual file input changed
    $(hiddenFile).unbind().bind('change', function(e) {
        file = e.target.files[0];
        
        $(fileResponse).fadeOut(500);
        
        if(file !== undefined && file.size !== 0){
            $(uploadFile).removeClass('disabled').removeAttr('disabled');
        }
        
    });
    
    $(uploadFile).unbind().bind('click', function(e){
        
        if(file === null || $(this).hasClass('disabled')){
            return false;
        }
        
        $(this).addClass('disabled').attr('disabled', 'disabled');
        
        const formData = new FormData;
        const applicationId = $(this).attr('applicationId');
        
        formData.append('file', file, file.name);
        formData.append('applicationId', applicationId);
        
        $.ajax({
            type: "post",
            url :"/plus/application/UploadFile/",
            data: formData,
            contentType: false,
            processData: false,
            success: function () {
                window.location.reload()
            },
            error: function (response) {
                $(fileResponse).text(JSLanguage(response.responseText)).fadeIn(500);
            }
            
        })
        
        
        
    })





});