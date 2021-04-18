$(document).ready(function(){
    const stripe = Stripe("pk_test_h42gpj1blpgs022h5XnrFcKr00aiZ5puL3");


    //Parameters needed for request
    
    const courseId = $("#Course_Id").val();
    const invoiceNumber = $("#InvoiceToPay_Number").val();
    const reason = $("#Reason").val();
    
    
    const elements = stripe.elements();
    const cardError = $("#card-error");


    const style = {
        base: {
            color: "#4E54A4",
            fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
            fontSmoothing: "antialiased",
            fontSize: "0.9rem",
            "::placeholder": {
                color: "#aab7c4"
            }
        },
        invalid: {
            color: "#fa755a",
            iconColor: "#fa755a"
        },
    };

    const cardElement = elements.create('card', {style: style, hidePostalCode: true});
    
    cardElement.mount('#card-element');

    cardElement.on('change',function(){
        if(cardError.text().length)
            $(cardError).hide(300);

        // document.querySelector("#stripe-submit-button").disabled = event.empty;
        // document.querySelector("#card-error").textContent = event.error ? event.error.message : "";
    });
    


    const form = $("#payment-form");
    

    $(form).on('submit', function(event) {
        // We don't want to let default form submission happen here,
        // which would refresh the page.
        event.preventDefault();
        loading(true);
        stripe.createPaymentMethod({
            type: 'card',
            card: cardElement,
            billing_details: {
                // Include any additional collected billing details.
                name: $("#card-holder").val(),
            },
        }).then(stripePaymentMethodHandler);
    });

    

    function stripePaymentMethodHandler(result) {
        if (result.error) {
            handleError(result.error.message);
            // Show error in payment form
        } else {
            
            //Facebook Track InitiateCheckout
            const facebookElm = $("#facebook-track");
            if(reason === 'Register')
                FacebookTrack().InitiateCheckout('Course', facebookElm.attr('course-id'), facebookElm.attr('course-name') + ' / ' + facebookElm.attr('course-code'), facebookElm.attr('course-price'));
            
            
            // Otherwise send paymentMethod.id to your server (see Step 4)
            fetch('/Payment/Stripe', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    payment_method_id: result.paymentMethod.id,
                    courseId: courseId, invoiceNumber: invoiceNumber, reason: reason,  payAllNow: $("#pay-all-hidden").val(),
                    Ip: $("#ip").val(),OperatingSystem: $("#operatingSystem").val(),AuthCookies: $("#authCookies").val(),DeviceType: $("#deviceType").val()
                })
            }).then(function(result) {
                // Handle server response (see Step 4)
                result.json().then(function(json) {
                    handleServerResponse(json);
                })
            });
        }
    }




    function handleServerResponse(response) {
        if (response.error) {
            handleError(response.error);
            // Show error from server on payment form
            window.location = "/Payment/Result/"+response['orderId']
        } else if (response.requires_action) {
            // Use Stripe.js to handle required card action
            stripe.handleCardAction(
                response.payment_intent_client_secret
            ).then(handleStripeJsResult);
        } else {
            
            //Here the payment is done (Response from server)
            window.location = "/Payment/Result/"+response['orderId']
        }
    }

    function handleStripeJsResult(result) {
        if (result.error) {
            handleError(result.error.message);
            // Show error in payment form
        } else {
            // The card action has been handled
            // The PaymentIntent can be confirmed again on the server
            fetch('/Payment/Stripe', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ payment_intent_id: result.paymentIntent.id })
            }).then(function(confirmResult) {
                return confirmResult.json();
            }).then(handleServerResponse);
        }
    }








    const loading = function(isLoading) {
        if (isLoading) {
            // Disable the button and show a spinner
            document.querySelector("#stripe-submit-button").disabled = true;
            document.querySelector("#spinner").classList.remove("hidden");
            document.querySelector("#button-text").classList.add("hidden");
        } else {
            document.querySelector("#stripe-submit-button").disabled = false;
            document.querySelector("#spinner").classList.add("hidden");
            document.querySelector("#button-text").classList.remove("hidden");
        }
    };
    
    const handleError = function(text){

        $(cardError).text(JSLanguage('error') +': ' +text).hide().show(300);
        loading(false)
    }




















});