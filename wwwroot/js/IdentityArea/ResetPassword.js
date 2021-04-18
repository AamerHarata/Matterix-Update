$(document).ready(function(){
    
    const email = $("#Input_Email");
    const password = $("#Input_Password");
    const passwordConfirm = $("#Input_ConfirmPassword");
    const resetValidation = $("#reset-password-validation");


    $("input").keypress(function(event){
        if(event.keyCode === 13)
            $("#update-password").click()
    });
    
    
    
    $("#update-password").unbind().bind('click', function(){
        
        const continueSubmit = {yes: true};
        
        //Empty fields validation
        const listToEmptyValidation = [email, password, passwordConfirm];
        $(listToEmptyValidation).each(function(i,e){
            if($(e).val().length<1)
                validationNewInput($(e), $(resetValidation), 'fieldsInRedNotEmpty', continueSubmit)
        });

        //Valid email
        if(!validateEmail($(email).val()))
            validationNewInput($(email), $(resetValidation), 'notValidEmail', continueSubmit);


        //Password Letter case validation
        if(continueSubmit && !/^(?=.*[A-Z])/.test($(password).val()) && $(password).val().length>0)
            validationNewInput($(password), $(resetValidation), 'atLeastUppercase', continueSubmit);
        if(continueSubmit && !/^(?=.*[a-z])/.test($(password).val()) && $(password).val().length>0)
            validationNewInput($(password), $(resetValidation), 'atLeastLowercase', continueSubmit);

        //Password length validation
        if(continueSubmit && $(password).val().length < 6 && $(password).val().length>0)
            validationNewInput($(password), $(resetValidation), 'passwordMore6', continueSubmit);


        //Passwords match validation
        if(continueSubmit.yes && $(password).val() !== $(passwordConfirm).val())
            validationNewInput($(password).add($(passwordConfirm)), $(resetValidation), 'passwordDoesNotMatch', continueSubmit);
        
        
        
        if(continueSubmit.yes){
            $.post('', $("#reset-form").serialize(), function(){
                $("#reset-password-section").fadeOut(200);
                setTimeout(function(){$("#reset-confirmed-section").fadeIn(100)}, 300);
            }).fail(function(){
                $("#reset-password-validation").text(JSLanguage('errorRefresh'))
            })
        }
            
        
        
        
    });
    
});