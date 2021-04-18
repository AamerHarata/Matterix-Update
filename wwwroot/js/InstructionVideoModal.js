$(document).ready(function(){
    
    const openModalBtn = $(".open-instruction-modal");
    
    $(openModalBtn).unbind().bind('click', function(){
        const topic =$(this).attr('topic');
        const device = $(this).attr('device');
        const targetVideo = $(this).attr('target');
        
        const instructionModal = $("#instruction-video-modal").clone();
        
        
        InformationModal.SetHtml(instructionModal.removeAttr('hidden'));
        
        $("#instruction-video-frame").prop('src', targetVideo);
        if(device === 'Mobile')
            $("#instruction-video-container").attr('style', 'height: 500px;');
        else
            $("#instruction-video-container").attr('style', 'height: 320px;');
        
        InformationModal.Show(JSLanguage(topic), 'center no-footer');
        
    });
        
});