$(document).ready(function () {
    
    let applier = 'Student';

    //Prevent from submit form on page refresh
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }


    //Disable switch input when one is active
    const choice = $(".choice");
    $(choice).unbind().bind('click', function () {
        const clickedChoice = $(this);
        if ($(clickedChoice).find('input').prop('checked') === true) {
            $(choice).each(function (i, e) {
                if ($(e).attr('id') !== $(clickedChoice).attr('id'))
                    $(e).find('input').prop('checked', false).val('false');
            })
        }
        
        //Set applier
        applier = $(clickedChoice).find('input').attr('applier');
        $("#Applier").val(applier);
    });

    
    //Validation variables
    
    //Org
    const contactPersonName = $("#ContactPersonName");
    const contactPersonEmail = $("#ContactPersonEmail");
    const contactPersonPhone = $("#ContactPersonPhone");
    const organization = $("#Organization");
    const program = $("#Program");
    const City = $("#City");
    let studentId = "";
    
    //student
    const phone = $("#Student_PhoneNumber");
    const email = $("#Student_Email");
    
    //Other
    const sendCodeBtn = $("#send-code");


    //Change section
    const changeSection = $(".change-section");
    const sections = $(".section");
    const continueSubmit = {yes: true};

    $(changeSection).unbind().bind('click', function (e) {
        
        if($(this).hasClass('disabled'))
            return false;

        const target = $(this).attr('target');
        continueSubmit.yes = true;

        switch (target) {
            case 'complete':
                validate().organization();
                break;
            case 'code-sent-section':
                validate().student();
                break;
                
            case 'identity-verification-success':
                validate().verificationCode();
                break;
                
            case 'student-identity':
                validate().identity();
        }


        if (continueSubmit.yes) {

            if (target === 'complete') {
                $("#plus-identity-form").submit();
            } else {
                $(sections).fadeOut(200);
                setTimeout(function () {
                    $("#" + target).fadeIn(100)
                }, 300);
            }
        }
    });


    const validate = function () {
        return {

            organization() {

                if ($(contactPersonEmail).val().length > 0 && !validateEmail($(contactPersonEmail).val()))
                    validationNewInput($(contactPersonEmail), $("#organization-identity-validation"), 'notValidEmail', continueSubmit);


                if (continueSubmit.yes) {

                    $(contactPersonEmail).val($(contactPersonEmail).val().toString().trim());
                    
                    //Email validation
                    const listToEmptyFieldValidate = [contactPersonName, contactPersonEmail, contactPersonPhone, organization, program, City];
                    $(listToEmptyFieldValidate).each(function (i, e) {
                        if ($(e).val().length < 1)
                            validationNewInput($(e), $("#organization-identity-validation"), 'fieldsInRedNotEmpty', continueSubmit);
                    });
                }


                if (continueSubmit.yes) {
                    //Phone number validation
                    if ((!/^[0-9]+$/.test($(contactPersonPhone).val()) || $(contactPersonPhone).val().length < 8) && $(contactPersonPhone).val().length > 0)
                        validationNewInput($(contactPersonPhone), $("#organization-identity-validation"), 'phoneNumberNotValid', continueSubmit);

                    //Phone number no zero validation
                    if (continueSubmit.yes && (!/^[1-9][0-9]*$/.test($(contactPersonPhone).val())))
                        validationNewInput($(contactPersonPhone), $("#organization-identity-validation"), 'phoneNumberNoZero', continueSubmit);
                }
                
                if(continueSubmit.yes)
                    $(`.change-section[target=complete]`).attr('disabled', 'disabled').addClass('disabled');
                else
                    $(`.change-section[target=complete]`).removeAttr('disabled').removeClass('disabled');


            },
            
            student(){

                $(email).val($(email).val().toString().trim());
                
                if ($(email).val().length > 0 && !validateEmail($(email).val()))
                    validationNewInput($(email), $("#student-identity-validation"), 'notValidEmail', continueSubmit);


                if (continueSubmit.yes) {
                    //Email validation
                    const listToEmptyFieldValidate = [phone, email];
                    $(listToEmptyFieldValidate).each(function (i, e) {
                        if ($(e).val().length < 1)
                            validationNewInput($(e), $("#student-identity-validation"), 'fieldsInRedNotEmpty', continueSubmit);
                    });
                }


                if (continueSubmit.yes) {
                    //Phone number validation
                    if ((!/^[0-9]+$/.test($(phone).val()) || $(phone).val().length < 8) && $(phone).val().length > 0)
                        validationNewInput($(phone), $("#student-identity-validation"), 'phoneNumberNotValid', continueSubmit);

                    //Phone number no zero validation
                    if (continueSubmit.yes && (!/^[1-9][0-9]*$/.test($(phone).val())))
                        validationNewInput($(phone), $("#student-identity-validation"), 'phoneNumberNoZero', continueSubmit);
                }
                
                if(continueSubmit.yes){
                    $(`.change-section[target=code-sent-section]`).attr('disabled', 'disabled').addClass('disabled');
                    
                    $.ajax({
                        type: "get",
                        url: "/plus/GetStudentIdentity",
                        data: {phoneCode: $("#Student_PhoneCode").val(), phoneNumber: $(phone).val(), email: $(email).val()},
                        async: false,
                        success: function(response){
                            $(sendCodeBtn).attr('disabled', 'disabled').addClass('disabled');
                            
                            //Set studentId
                            studentId = response['studentId'];
                            $("#StudentId").val(studentId).text(studentId);
                            
                            //Send the code
                            $.ajax({
                                type: "get",
                                url: "/plus/SendVerificationCode",
                                data: {studentId: studentId},
                                async: false,
                                success: function(){
                                    
                                },
                                error: function(){
                                    //Error may be happened inside send code controller
                                    validationNewInput(null, $("#student-identity-validation"), 'errorRefresh', continueSubmit);
                                }
                            })
                        },
                        error: function(){
                            continueSubmit.yes = false;
                            validationNewInput($(phone).add($(email)).add($("#Student_PhoneCode")), $("#student-identity-validation"), 'studentWithInfoNotExist', continueSubmit);
                            $(`.change-section[target=${'code-sent-section'}]`).removeAttr('disabled').removeClass('disabled');
                        }
                    })
                    
                }
                
                
            },

            verificationCode(){
                if ($(codeInput).val().length !== 4){
                    continueSubmit.yes = false;
                    return false;
                }
                $(checkBtn).attr('disabled', 'disabled').addClass('disabled');
                
                $.ajax({
                    type: "get",
                    url: "/plus/CheckVerificationCode",
                    async: false,
                    data:{studentId: studentId, code: $(codeInput).val()},
                    success: function(response){
                        $("#checked-name").text(response['name']);
                        $("#checked-email").text(response['email']);
                    },
                    error: function(error){
                        validationNewInput($(codeInput), $("#code-check-validation"), 'wrongCode', continueSubmit);
                        $(checkBtn).removeAttr('disabled').removeClass('disabled');
                    }
                })
            },
            
            identity(){
                const loginRequired = $("#login-required");
                if(applier === 'Student' && $(loginRequired).length){
                    continueSubmit.yes = false;
                    window.location = "/Identity/Account/Login?returnUrl=/plus/apply/Identity"
                }
            },


        }
    }
    
    
    //Verification input
    const allowedNumber = [8, 37, 38, 39, 40, 46, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105];
    const codeInput = $('#code-input');
    const checkBtn = $(`.change-section[target=identity-verification-success]`);

    $(codeInput).keydown(function(e) {
        const key = e.keyCode;
        if(!allowedNumber.includes(e.keyCode))
            e.preventDefault();

        if (key === 13)
            $(checkBtn.click());


    });

    $(codeInput).keyup(function() {
        if($(codeInput).val().length === 4)
            $(checkBtn).removeAttr('disabled').removeClass('disabled');
        else
            $(checkBtn).attr('disabled', 'disabled').addClass('disabled');

    });


});