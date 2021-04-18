$(document).ready(function(){


    const nextBtn = $(".payment-next-section");
    const termsRow = $("#terms-row");
    const termsBtn = $("#terms-btn");

    
    const invoices = $("#additional-invoices");
    const monthRow = $("#pay-month-row");
    const allRow = $("#pay-all-row");
    const chooseAllBtn = $("#choose-all");
    const chooseMonthlyBtn = $("#choose-month");
    
    
    const freeRegister = $("#free-register-btn");
    
    
    // Set the device info to terms board
    // const userDeviceInfo = userDevice();
    
    
    
    
    $(nextBtn).unbind().bind("click", function(){
        const section= {
            current: $(this).attr("current-section"),
            next: $(this).attr("next-section")
        };

        if(section.current === "terms"){
            if(!$(termsBtn).prop("checked")){
                $(termsRow).attr("style", "background-color: rgba(255,0,0,0.5)");
                setTimeout(function(){$(termsRow).removeAttr("style")}, 1500);
                return false;
            }
        }



        if(section.next==="pay-with-stripe" || section.next==="pay-with-vipps"){
            if(!$(chooseAllBtn).prop("checked") && !$(chooseMonthlyBtn).prop("checked")){
                $(allRow).add($(monthRow)).attr("style", "background-color: rgba(255,0,0,0.5)");
                setTimeout(function(){$(allRow).add(monthRow).removeAttr("style")}, 1500);
                return false;
            }
        }

        // console.log("Current: " + section.current);
        // console.log("Next: " + section.next);

        $("#" + section.current).fadeOut(2000).hide();
        $("#"+section.next).fadeIn(1000);

        if($(this).attr("id") === "pay-with-vipps-btn")
            PayWithVipps();

    });



    $(monthRow).unbind().bind("click", function(){
        $(chooseAllBtn).prop("checked", false);
        $(chooseMonthlyBtn).prop("checked", true);
        $(invoices).fadeIn(1000);
        $("#total-to-pay").text($("#month-amount").text());
        $("#pay-with-stripe-btn").text($("#month-amount").text());
        $("#pay-all-hidden").attr("value", false);
    });

    $(allRow).unbind().bind("click", function(){
        $(chooseAllBtn).prop("checked", true);
        $(chooseMonthlyBtn).prop("checked", false);
        $(invoices).fadeOut(1000);
        $("#total-to-pay").text($("#all-amount").text());
        $("#pay-with-stripe-btn").text($("#all-amount").text());
        $("#pay-all-hidden").attr("value", true);
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
                window.location = "/payment/result/"+response.result+"?reason=Register"+"&courseId="+response.courseId+"&message="+response.message+"&userId="+response.userId;
            },
            error: function(error){
                window.location = "/payment/result/"+error.responseJSON['result']+"?reason=Register&courseId="+error.responseJSON['courseId']+"&message="+error.responseJSON['message'];
            }

        });
    });
    
    
    
    
    
    
});