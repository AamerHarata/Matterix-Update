$(document).ready(function(){
    
    $("#pay-with-vipps-container").unbind().bind('click', function(){
        PayWithVipps();
        $(this).attr('disabled', 'disabled')
    });






    function PayWithVipps(){
        const courseId = $("#Course_Id").val();
        const payAllNow = $("#pay-all-hidden").val();
        const reason = $("#Reason").val();
        const invoiceNumber = $("#InvoiceToPay_Number").val();
        const userDevice={
            Ip: $("#ip").val(),
            OperatingSystem: $("#operatingSystem").val(),
            AuthCookies: $("#authCookies").val(),
            DeviceType: $("#deviceType").val()
        };

        //Facebook Track InitiateCheckout
        const facebookElm = $("#facebook-track");
        if(reason === 'Register')
            FacebookTrack().InitiateCheckout('Course', facebookElm.attr('course-id'), facebookElm.attr('course-name') + ' / ' + facebookElm.attr('course-code'), facebookElm.attr('course-price'));

        // console.log("InvoiceNumber = " +invoiceNumber);


        $.ajax({
            type:"POST",
            url:"/Payment/CreateVipps/",
            data: {courseId: courseId, reason: reason, payAllNow: payAllNow, invoiceNumber: invoiceNumber, ip: userDevice.Ip, deviceType: userDevice.DeviceType, operatingSystem: userDevice.OperatingSystem, authCookies: userDevice.AuthCookies},
            success: function(response){
                // console.log(response);
                window.location = response;
            },
            error: function(response){
                // console.log(response);
                window.location = response;
            }

        });
    }
    
});