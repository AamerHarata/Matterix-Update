
$(document).ready(function(){

    
    
    const choosePicture = $("#choose-picture-btn");
    const uploadPicture = $("#upload-picture-btn");
    const fileInput = $("#file-input");
    const fileName = $("#file-name");
    const deletePicture = $("#delete-picture-btn");
    const pictureModal = $("#picture-modal");
    
    
    $(choosePicture).unbind().bind("click", function (){
        $(fileInput).click();
    });
    
    $(fileInput).change(function(e) {
        const file = e.target.files[0];
        
        if($(this).val() !== null && file !== undefined){
            // console.log(file);
            uploadPicture.prop("disabled", false);
            fileName.text(file.name);
            deletePicture.css("display", "none");
        }else{
            uploadPicture.prop("disabled", "disabled" );
            deletePicture.css("display", "block");
            fileName.text("");
        }
    });
    
    
});