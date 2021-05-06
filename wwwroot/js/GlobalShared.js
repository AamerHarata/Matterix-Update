const getBrowserLanguage = function(){
    const lang = navigator.language;
    
    if(lang.includes('ar'))
        return 'ar';
    else if(lang.includes('en'))
        return 'en';
    else if (lang.includes('sw'))
        return 'sw';
    else if (lang.includes('de'))
        return 'ge';
    else
        return 'no';
    
};



let InformationModal;

class modalObject {
    constructor(name){
        const modalName = name+'-modal';
        this.Modal= $("#"+modalName);
        this.Title = $("#"+modalName+"-title");
        this.Content = $("#"+modalName+"-content");
        this.CloseBtn = $("#"+modalName+"-close")

        $(this.Modal).on('hidden.bs.modal', function () {
            //Destroy the included data, in case any video is played for example
            $("#"+modalName+"-content").html('');
            $(this).data('bs.modal', null);
        });
    }
    
    Modal;
    Title;
    Content;
    CloseBtn;
    
    Init(){
        const modal = this;
        $(this.CloseBtn).unbind().bind('click', function(){
            modal.Hide();
        })
    }
    
    Show(title, mode = ''){
        this.SetTitle(title);
        $(this.Modal).modal('show');
        this.Init();
        
        if(mode.includes('center'))
            $(this.Modal).find('.modal-dialog').addClass('modal-dialog-centered');
        else
            $(this.Modal).find('.modal-dialog').removeClass('modal-dialog-centered');
        
        if(mode.includes('no-footer'))
            $(this.Modal).find('.modal-footer').addClass('d-none');
        else
            $(this.Modal).find('.modal-footer').removeClass('d-none');
    }
    
    SetTitle(title){
        $(this.Title).text(title)
    }
    
    SetText(text){
        $(this.Content).text(text)
    }
    
    SetHtml(html){
        $(this.Content).html(html)
    }
    
    Hide(){
        $(this.Content).text('');
        $(this.Modal).modal('hide');
        
    }
    
    
    
    
}

//Initiate global function to revoke notifications
let RevokeNotifications;


$(document).ready(function () {
   
    //Implement function to revoke notifications
    RevokeNotifications = function(method, force = false) {
        if(method === undefined)
            method  = "Email";
        
        $.ajax({
            type: "POST",
            url: "/Settings/RevokeNotifications/",
            data: {method: method}
        });
        
        if(force){
            $.ajax({
                type: "POST",
                url: "/Settings/RevokeNotificationsForce/",
            });
        }
    };

    //Init information modal
    InformationModal = new modalObject('information')
});