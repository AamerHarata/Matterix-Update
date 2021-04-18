$(document).ready(function(){





// Test public Key
//     const stripe = Stripe('pk_test_h42gpj1blpgs022h5XnrFcKr00aiZ5puL3');
    
    
    //ToDo :: Live publish Key
    const stripe = Stripe('pk_live_zQnXfYfkgYeYN6a2PqpEaNt000iKT3zppZ');
    
    
// Create an instance of Elements.
    const elements = stripe.elements();

// Custom styling can be passed to options when creating an Element.
// (Note that this demo uses a wider set of styles than the guide below.)
    const style = {
        base: {
            color: '#32325d',
            fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
            fontSmoothing: 'antialiased',
            fontSize: '16px',
            '::placeholder': {
                color: '#aab7c4'
            }
        },
        invalid: {
            color: '#fa755a',
            iconColor: '#fa755a'
        }
    };




// Create an instance of the card Element.
    const card = elements.create('cardNumber',
        {
            classes: {
                base: "form-control",

                invalid: "error"

            },
            style: style,
            
        });
    const cvc = elements.create('cardCvc',
        {
            classes: {
                base: "form-control",
                
                invalid: "error",
            },
            placeholder:'CVC'
        });

    const exp = elements.create('cardExpiry',
        {
            classes: {
                base: "form-control",

                invalid: "error"

            },
            placeholder: 'MM/YY'
        });


// Add an instance of the card Element into the `card-element` <div>.
    card.mount('#card-number');
    cvc.mount('#card-cvc');

    exp.mount('#card-exp');

    // console.log(card)




// Handle real-time validation errors from the card Element.
    card.addEventListener('change',
        function(event) {
            const displayError = document.getElementById('card-errors');
            if (event.error) {
                displayError.textContent = event.error.message;
            } else {
                displayError.textContent = '';
            }
        });

// Handle form submission.
    let alreadyClicked = false;
    const payBtn = document.getElementById('pay-with-stripe-btn');
    payBtn.addEventListener('click',
        function(event) {
            event.preventDefault();

            stripe.createToken(card).then(function(result) {
                if (result.error) {
                    // Inform the user if there was an error.
                    var errorElement = document.getElementById('card-errors');
                    errorElement.textContent = result.error.message;
                    alreadyClicked = false;
                } else {
                    // Send the token to your server.
                    stripeTokenHandler(result.token.id);
                }
            });
        });

// Submit the form with the token ID.
    function stripeTokenHandler(token) {
        if(alreadyClicked)
            return false;
        
        const courseId = $("#Course_Id").val();
        const userId = $("#Student_Id").val();
        const payAllNow = $("#pay-all-hidden").val();
        const invoiceNumber = $("#InvoiceToPay_Number").val();
        const reason = $("#Reason").val();
        payBtn.disabled = true;
        alreadyClicked = true;


        const userDevice={
            Ip: $("#ip").val(),
            OperatingSystem: $("#operatingSystem").val(),
            AuthCookies: $("#authCookies").val(),
            DeviceType: $("#deviceType").val()
        };
        
        
        
        
        
        $.ajax({
            type: "Post",
            url:"/Payment/Stripe/",
            data: {reason: reason, invoiceNumber: invoiceNumber, stripeAccessToken: token, courseId: courseId, payAllNow: payAllNow, ip: userDevice.Ip, operatingSystem: userDevice.OperatingSystem, authCookies: userDevice.AuthCookies, deviceType: userDevice.DeviceType},
            success: function (response) {
                window.location = "/payment/result/"+response.result+"?userId="+userId+"&reason="+reason+"&courseId="+response.courseId+"&invoiceNumber="+response.invoiceNumber+"&message="+response.message;
            },
            error: function (error) {
                window.location = "/payment/result/"+error.responseJSON['result']+"?userId="+error.responseJSON['userId']+"&reason="+reason+"&courseId="+error.responseJSON['courseId']+"&invoiceNumber="+error.responseJSON['invoiceNumber']+"&message="+error.responseJSON['message'];
            }
        })
        
        
        
        // $.ajax({
        //     type:"POST",
        //     url:"/Payment/ProcessPayment/",
        //     data: {courseId: courseId, studentId: studentId, accessToken: token, reason: reason, method: "Stripe", payAllNow: payAllNow, invoiceNumber: invoiceNumber, ip:userDeviceInfo.ip, deviceType: userDeviceInfo.deviceType, operatingSystem: userDeviceInfo.OSName, authCookies: userDeviceInfo.ulisp},
        //     success: function(response){
        //         console.log(response);
        //
        //
        //         const resultLink = document.createElement("a");
        //         resultLink.setAttribute("href", "payment?courseId="+response.courseId+"&reason="+response.type+"&section="+response.section+"&invoiceNumber="+response.invoiceNumber);
        //         resultLink.click();
        //
        //     }
        //
        // });

    }
    
    
    
    
});