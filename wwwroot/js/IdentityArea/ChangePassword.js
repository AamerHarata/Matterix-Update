$(document).ready(function(){
    
    const currentPassword = $("#Input_OldPassword");
    const password = $("#Input_NewPassword");
    const passwordConfirm = $("#Input_ConfirmPassword");


    $("input").keypress(function(event){
        if(event.keyCode === 13)
            $("#update-password").click()
    });
    
    
    
    $("#update-password").unbind().bind('click', function(){
        
        const continueSubmit = {yes: true};
        
        //Empty fields validation
        const listToEmptyValidation = [currentPassword, password, passwordConfirm];
        $(listToEmptyValidation).each(function(i,e){
            if($(e).val().length<1)
                validation($(e), $("#no-match-validation"), 'fieldsInRedNotEmpty', continueSubmit)
        });


        //Password Letter case validation
        if(!/^(?=.*[A-Z])/.test($(password).val()) && $(password).val().length>0)
            validation($(password), $("#password-validation"), 'atLeastUppercase', continueSubmit);
        if(!/^(?=.*[a-z])/.test($(password).val()) && $(password).val().length>0)
            validation($(password), $("#password-validation"), 'atLeastLowercase', continueSubmit);

        //Password length validation
        if($(password).val().length < 6 && $(password).val().length>0)
            validation($(password), $("#password-validation"), 'passwordMore6', continueSubmit);


        //Passwords match validation
        if(continueSubmit.yes && $(password).val() !== $(passwordConfirm).val())
            validation($(password).add($(passwordConfirm)), $("#no-match-validation"), 'passwordDoesNotMatch', continueSubmit);
        
        
        
        if(continueSubmit.yes)
            $("#change-password-form").submit();
        
        
        
    });
    
});