$(document).ready(function(){
    let applicationId = "";
    
    let updateResponse;

    //*** Set Shared Variables ***///
    const sharedModal = $("#shared-modal");
    const modalContent = $("#shared-modal-content");
    const modalTitle = $("#shared-modal-title");
    const modalConfirm = $("#shared-modal-btn-yes");
    const modalCancel = $("#shared-modal-btn-no");
    
    
    //Buttons
    const acceptApplication = $(".accept-application");
    const updateApplication = $(".update-application");
    const deleteApplication = $(".delete-application");
    const sendDocuments = $(".send-documents");
    
    
    //Accept application
    $(acceptApplication).unbind().bind('click', function(){
        applicationId = $(this).parents().closest('.application-container').attr('id');
        updateResponse = $(`#${applicationId}`).find('.update-response');
        
        
        $(modalContent).text('Are you sure accept the application '+applicationId+'?');
        $(sharedModal).modal('show');
        
        $(modalConfirm).unbind().bind('click', function(){
            $.ajax({
                url: "/Admin/PlusApplicationAccepted",
                type: "POST",
                data:{applicationId: applicationId},
                success: function(){
                    updateResponse.removeClass('text-danger').addClass('text-success').text('Accepted Successfully');
                    $(sharedModal).modal('hide');
                },
                error: function(response){
                    $(updateResponse).removeClass('text-success').addClass('text-danger').text('Error happened: '+ response.responseText);
                    $(sharedModal).modal('hide');

                }
            });
        });

        $(modalCancel).unbind().bind('click', function(){
            $(sharedModal).modal('hide');
        });
        
        
        
    });
    
    //Update application
    $(updateApplication).unbind().bind('click', function(){
        applicationId = $(this).parents().closest('.application-container').attr('id');
        updateResponse = $(`#${applicationId}`).find('.update-response');
        const status = $("#status"+applicationId).val();
        
        $.ajax({
            url: "/Admin/EditPlusApplication",
            type: "POST",
            data:{applicationId: applicationId, status: status},
            success: function(){
                updateResponse.removeClass('text-danger').addClass('text-success').text('Updated Successfully');
            },
            error: function(response){
                $(updateResponse).removeClass('text-success').addClass('text-danger').text('Error happened: '+ response.responseText);

            }
        });
        
        
        
    });

    //Delete application
    $(deleteApplication).unbind().bind('click', function(){
        applicationId = $(this).parents().closest('.application-container').attr('id');
        updateResponse = $(`#${applicationId}`).find('.update-response');


        $(modalContent).text('Are you sure delete the application '+applicationId+'?');
        $(sharedModal).modal('show');

        $(modalConfirm).unbind().bind('click', function(){
            $.ajax({
                url: "/Admin/DeletePlusApplication",
                type: "POST",
                data:{applicationId: applicationId},
                success: function(){
                    updateResponse.removeClass('text-danger').addClass('text-success').text('Deleted Successfully');
                    $(sharedModal).modal('hide');                    
                },
                error: function(response){
                    $(updateResponse).removeClass('text-success').addClass('text-danger').text('Error happened: '+ response.responseText);
                    $(sharedModal).modal('hide');
                }
            });
        });

        $(modalCancel).unbind().bind('click', function(){
            $(sharedModal).modal('hide');
        });



    });


    //Send documents application
    $(sendDocuments).unbind().bind('click', function(){
        applicationId = $(this).parents().closest('.application-container').attr('id');
        updateResponse = $(`#${applicationId}`).find('.update-response');
        
        const documentType = $(this).attr('document');

        $(modalContent).text('Are you sure sending '+documentType+' for the application '+applicationId+'?');
        $(sharedModal).modal('show');

        $(modalConfirm).unbind().bind('click', function(){
            $.ajax({
                url: "/Admin/SendPlusApplicationDocument",
                type: "POST",
                data:{applicationId: applicationId, document: documentType},
                success: function(){
                    updateResponse.removeClass('text-danger').addClass('text-success').text(documentType+ ' Sent Successfully');
                    $(sharedModal).modal('hide');
                    RevokeNotifications('Email');
                },
                error: function(response){
                    $(updateResponse).removeClass('text-success').addClass('text-danger').text('Error happened: '+ response.responseText);
                    $(sharedModal).modal('hide');
                }
            });
        });

        $(modalCancel).unbind().bind('click', function(){
            $(sharedModal).modal('hide');
        });



    });
    
    
    
    
});