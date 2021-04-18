$(document).ready(function(){

    //Prevent from submit form on page refresh
    if ( window.history.replaceState ) {
        window.history.replaceState( null, null, window.location.href );
    }
    
    const email = $("#Input_Email");
    const emailForReset = $("#email-for-reset");
    const password = $("#Input_Password");
    const continueSubmit = { yes: true, loginClicked: false};


    const sections = $(".section");
    const changeBtn = $(".change-section");
    let currentPhase = 'intro';
    
    
    
    $(changeBtn).unbind().bind('click', function(e){

        e.preventDefault();

        const target = $(this).attr('target');
        $(".validation").fadeOut(0);
        
        switch (target) {
            
            case 'complete':
                validate().login();
                break;
                
            case 'forget-password':
                break;
                
            case 'send-reset-link':
                validate().sendResetLink();
                break;
                
            
        }

        
        if(target !== 'complete' && target !== 'send-reset-link'){
            $(sections).fadeOut(200);
            setTimeout(function(){$("#"+target).fadeIn(100)}, 300);
        }
        
        
        
        
        
    });








    const validate = function() {
        return {

            emailExists(_email = null){
                const emailValue = _email === null? $(email).val() : _email;
                const emailSelector = _email === null? $(email) : $(emailForReset);
                $.ajax({
                    type: "GET",
                    url: "/EmailNameValidation/",
                    async: false,
                    data: {email: emailValue, firstName : "none", lastName: "none"},
                    success: function(response){
                        //Here the email is not taken so it is not exists Add the html here and send as variable
                        const emailNotExistHtml = 
                            `<div class="direction">
                                <p class="ml-4 mr-4" ">هذا البريد الالكتروني غير مسجل لدينا</p>
                                <ul class="dashed-list">
                                     <li class="mb-2">تأكد من كتابة البريد بشكل صحيح</li>
                                    <li>إذا لم يكن لديك حساب مسبقاً يرجى إنشاء حساب جديد</li>
                                </ul>
                            </div>`;
                        validationNewInput(emailSelector, $(".email-not-exist-validation"), emailNotExistHtml, continueSubmit, true);
                    },
                    error: function(response){
                        // If response text emailIsTaken then everything is fine, otherwise print error
                        if(response.responseText !== 'emailIsTaken')
                            validationNewInput($(null), $(".login-validation"), response.responseText, continueSubmit);

                    }
                });
                
            },
            
            login(){

                if(continueSubmit.loginClicked)
                    return false;
                
                continueSubmit.yes = true;

                $(email).val($(email).val().toString().trim());
                
                //Email empty validation
                if($(email).val().length <1)
                    validationNewInput($(email), $(".login-validation"), "fieldsInRedNotEmpty" ,continueSubmit);

                if(continueSubmit.yes && !validateEmail($(email).val()))
                    validationNewInput($(email), $(".login-validation"), "notValidEmail" ,continueSubmit);

                //Password validation
                if(continueSubmit.yes && $(password).val() <1)
                    validationNewInput($(password), $(".login-validation"), "fieldsInRedNotEmpty" ,continueSubmit);

                if(continueSubmit.yes && $(password).val().length <6)
                    validationNewInput($(password), $(".login-validation"), "passwordMore6" ,continueSubmit);
                
                //Email exists validation
                if(continueSubmit.yes)
                    validate().emailExists();
                
                if(continueSubmit.yes){
                    continueSubmit.loginClicked = true;
                    $(".change-section").attr('disabled', 'disabled');
                    $("#account").submit();
                }else{
                    continueSubmit.loginClicked = false;
                }
                
            },
            
            sendResetLink(){
                continueSubmit.yes = true;

                if($(emailForReset).val().length <1)
                    validationNewInput($(emailForReset), $(".login-validation"), "fieldsInRedNotEmpty" ,continueSubmit);

                if(continueSubmit.yes && !validateEmail($(emailForReset).val()))
                    validationNewInput($(emailForReset), $(".login-validation"), "notValidEmail" ,continueSubmit);
                
                if(continueSubmit.yes)
                    validate().emailExists($(emailForReset).val());

                if(continueSubmit.yes){
                    $(".change-section").attr('disabled', 'disabled');
                    $("#reset-link-form").submit();
                }
                
            }
        }
    };
    
    
    
    
    
    
    

    $("input").keypress(function(event){
        if(event.keyCode === 13)
            $("#login-btn").click()
    });
    
    let alreadyClicked = false;

    
    
    // $("#login-btn").click(function(e){
    //
    //     if(alreadyClicked)
    //         return false;
    //    
    //     const continueSubmit = { yes: true
    //     };
    //    
    //    
    //     //Email empty validation
    //     if($(email).val().length <1)
    //         validation($(email), $("#email-validation"), "fieldsInRedNotEmpty" ,continueSubmit);
    //
    //     if(!validateEmail($(email).val()))
    //         validation($(email), $("#email-validation"), "notValidEmail" ,continueSubmit);
    //    
    //     if($(password).val() <1)
    //         validation($(password), $("#password-validation"), "fieldsInRedNotEmpty" ,continueSubmit);
    //    
    //     if(continueSubmit.yes && $(password).val().length <6)
    //         validation($(password), $("#password-validation"), "passwordMore6" ,continueSubmit);
    //    
    //    
    //
    //
    //     if(continueSubmit.yes){
    //         $("#login-btn").attr('disabled', 'disabled');
    //         alreadyClicked = true;
    //         $("#account").submit();
    //     }else{
    //         alreadyClicked = false;
    //     }
    //
    //
    // });

    $(email).add($(password)).click(function(){
        if($(email).val().length>0)
            $("#wrongValidation").fadeOut(300);
    });
    
    
    
    
});