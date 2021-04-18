$(document).ready(function() {
    const chooseFile = $("#choose-file");
    const deleteFile = $("#delete-file");
    const hiddenFile = $("#File");
    const fileName = $("#file-name");
    const reasonInfo = $("#reason-info");
    const reasonList = $("#reason-list");
    const contactValidation = $("#contact-validation");
    let file;

    $(reasonInfo).text(JSLanguage('weWillAnswer'));
    // setTimeout(function() { $(reasonInfo.fadeOut(3000)) }, 1000);


    $(reasonList).unbind().bind('change',
        function() {
            const val = parseInt($(this).val());
            if (val === 0) $(reasonInfo).fadeIn(500).text(JSLanguage('weWillAnswer'));
            if (val === 1) reasonInfo.fadeIn(500).text(JSLanguage('weThankYourCooperation'));
            if (val === 2) reasonInfo.fadeIn(500).text(JSLanguage('weAreSorryIfSomethingWrong'));
            else if (val === 3) reasonInfo.fadeIn(500).text(JSLanguage('youCanCancelWithin14'));
            else if (val === 4) reasonInfo.fadeIn(500).text(JSLanguage('attachInvoiceNumber'));
            else if (val === 5) reasonInfo.fadeIn(500).text(JSLanguage('weWillAnswerWithIn'));
            else if (val === 6)reasonInfo.fadeIn(500).text(JSLanguage('weThankYourCooperation'));
            else if (val === 7)reasonInfo.fadeIn(500).text(JSLanguage('weCanHelp'));
            else if (val === 8)reasonInfo.fadeIn(500).text(JSLanguage('weWillProcessYourRequest'));


        });









    $(chooseFile).click(function() {
        $(hiddenFile).click();


    });

    $(hiddenFile).unbind().bind('change',function(e) {
        file = e.target.files[0];
        $(fileName).text(file.name);
        $(deleteFile).css('display', 'inline-block');
    });

    $(deleteFile).click(function() {
        $(fileName).text('');
        $(hiddenFile).val(null);
        file = null;
        $(this).css('display', 'none');
        $("#file-validation").text('');

    });


    const contactForm = $("#contact-form");
    const fullName = $("#FullName");
    const phoneNumber = $("#User_PhoneNumber");
    const email = $("#User_Email");
    const message = $("#Message");

    const listToEmptyValidation = [fullName, phoneNumber, email];

    $("#submit-contact-form").unbind().bind('click', function () {
        const continueSubmit = {yes: true};
        $(listToEmptyValidation).each(function (i, e) {
            if ($(e).val().length < 1)
                validationNewInput($(e), $(contactValidation), "fieldsInRedNotEmpty", continueSubmit);

        });
        
        if(continueSubmit.yes && $(message).val().length < 1)
            validation($(message), $(contactValidation), "fieldsInRedNotEmpty", continueSubmit);


        //Email validation
        if (continueSubmit && !validateEmail($(email).val()))
            validationNewInput($(email), $(contactValidation), 'notValidEmail', continueSubmit);

        //Phone number
        if (continueSubmit && (!/^[0-9]+$/.test($(phoneNumber).val()) || $(phoneNumber).val().length < 8) && $(phoneNumber).val().length > 0)
            validationNewInput($(phoneNumber), $(contactValidation), 'phoneNumberNotValid', continueSubmit);

        //Phone number no zero validation
        if(continueSubmit.yes && (!/^[1-9][0-9]*$/.test($(phoneNumber).val())))
            validationNewInput($(phoneNumber), $(contactValidation), 'phoneNumberNoZero', continueSubmit);


        //Large file
        if (continueSubmit.yes) {
            if (file != null && file.size > 25 * 1024 * 1024) {
                validationNewInput($(hiddenFile), $(contactValidation), 'largeFileMax25', continueSubmit);
                file = null;
                $(hiddenFile).val(null);
                return false;
            }

            const formData = new FormData;
            formData.append("File", file);
            formData.append("reason", $(reasonList).val());
            formData.append("FullName", $(fullName).val());
            formData.append("User.PhoneNumber", $(phoneNumber).val());
            formData.append("User.Email", $(email).val());
            formData.append("Message", $(message).val());
            formData.append("Device.AuthCookies", $("#authCookies").val());
            formData.append("Device.Ip", $("#ip").val());


            $.ajax({
                type: "POST",
                url: "/home/ContactUs",
                contentType: false,
                processData: false,
                async: false,
                data: formData,
                success: function (resp) {
                    $("#contact-section").fadeOut(200);
                    setTimeout(function () {
                        $("#case-id").text(resp)
                        $("#response-section").fadeIn(100);

                    }, 300);


                },
                error: function (error) {
                    $(contactValidation).text(JSLanguage(error.responseText));
                }
            });


        }

    });


});