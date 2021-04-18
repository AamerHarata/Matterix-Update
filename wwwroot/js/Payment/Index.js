$(document).ready(function(){

    const sections = $(".section");
    const changeBtn = $(".change-section");
    let currentPhase = 'intro';
    // let currentPhase = 'terms';
    
    
    //Other variables
    const termsRow = $("#terms-row");

    $(document).keypress(function(event){
        if(event.keyCode === 13)
            $(".change-section").click()
    });

    styleStages();
    
    //Payer options (student / org)    
    const payerOptions = $(".payer-option");
    let organization = false;
    
    $(payerOptions).unbind().bind('click', function(){
        $(payerOptions).find('input').prop('checked', false);
        $(this).find('input').prop('checked', true);
        organization = $(this).attr('payer') === 'organization';
        
    });
    
    //Terms clicked
    $(termsRow).unbind().bind('click', function(){$(this).find('input').attr('checked', true)});
    
    
    //Payment options (month / all)
    const generatedInvoice = $(".generated-invoice");
    generatedInvoice.hide();
    const paymentOptions = (".payment-option");
    
    const totalToPay = parseInt($("#total-to-pay").text());
    const partAmount = parseInt($("#invoice-amount").text());
    $(".to-pay-now").text(totalToPay);
    let toPayNow = totalToPay;
    
    $(paymentOptions).unbind().bind('click', function(){
        
        if($(this).attr('id') === 'pay-month-row'){
            // alert('Create Info Modal if declined return false');
            
            $(generatedInvoice).fadeIn(1000);
            toPayNow = partAmount;
            $("#pay-all-hidden").val(false);
            $(".remaining-row").fadeIn(500)
        }else{
            $(generatedInvoice).fadeOut(1000);
            toPayNow = totalToPay;
            $(".remaining-row").fadeOut(500);
            $("#pay-all-hidden").val(true);
        }

        $(paymentOptions).find('input').prop('checked', false);
        $(this).find('input').prop('checked', true);
        updateAmounts();
        
    });
    
    function updateAmounts(){
        const restToPay = totalToPay - toPayNow;
        $(".to-pay-now").text(toPayNow);
        $("#to-pay-later").text(restToPay);
    }
    
    
    
    //Payment method show hide
    const taskContainer = $('#payment-method');
    taskContainer.on('show.bs.collapse','.collapse', function() {
        if($(this).hasClass('modal-collapse'))
            return false;
        taskContainer.find('.collapse.show').collapse('hide');
    });
    


    $(changeBtn).unbind().bind('click', function (e) {
        e.preventDefault();

        const target = $(this).attr('target');
        
        switch (currentPhase) {
            case 'intro':
                break;

            case 'who-pays':
                if(organization){

                    InformationModal.SetHtml("<div class='w-75 text-center m-auto'>"+JSLanguage('youWillBeRedirectedTo')+"</div><div class='mt-4'><a href='/plus' class='m-button m-button-primary'>"+JSLanguage('continue')+"</a></div>");
                    InformationModal.Show(JSLanguage('enrollmentWithPlus') + ' ' + "", 'center no-footer');
                                        
                    
                    return false;
                }
                break;
                
            case 'terms':
                const terms = $(termsRow).find('input').attr('checked') === 'checked';
                
                if(!terms){
                    $(termsRow).attr("style", "background-color: rgba(255,0,0,0.5)");
                    setTimeout(function(){$(termsRow).removeAttr("style")}, 1500);
                    
                    return false;
                    
                }
                break;
                
            

        }

        $(sections).fadeOut(200);
        setTimeout(function(){$("#"+target).fadeIn(100)}, 300);
        updatePhase(target)

        

    });
























    function updatePhase(target){

        $(".step[phase="+currentPhase+"]").attr('completed', true);
        currentPhase = target;

        styleStages();



    }







    function styleStages(){
        $(".step").each(function(i, e){


            if(e.hasAttribute('completed')){
                $(e).html("<i class=\"far fa-check-circle text-success\"></i>")
            }

            if($(e).attr('phase') === currentPhase){
                $(e).html("<i style=\"box-shadow: 0 0 5pt 1pt lightgray; border-radius: 50%\" class=\"fa fa-circle matterix-color\"></i>")
            }

        })
    }


    //Complete Free Registration
    const freeRegister = $("#free-register-btn");
    $(freeRegister).unbind().bind('click',function(){
        $(freeRegister).attr('disabled', 'disabled');

        const courseId = $("#Course_Id").val();

        const userDevice={
            Ip: $("#ip").val(),
            OperatingSystem: $("#operatingSystem").val(),
            AuthCookies: $("#authCookies").val(),
            DeviceType: $("#deviceType").val()
        };

        $.ajax({
            type:"POST",
            url:"/Payment/CreateFreeRegistration",
            data: {courseId: courseId, ip: userDevice.Ip, deviceType: userDevice.DeviceType, operatingSystem: userDevice.OperatingSystem, authCookies: userDevice.AuthCookies},
            success: function(response){
                // console.log(response);
                // console.log(response.result + ' - ' + response.courseId + ' - ' + response.message)
                window.location = "/payment/result/"+response.orderId;
            },
            error: function(error){
                window.location = "/payment/result/"+error.responseJSON['orderId'];
            }

        });
    });
    
    
    
    
    
});