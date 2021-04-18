$(document).ready(function(){
    
    //To be sure that verification email is sent from here
    RevokeNotifications("Email");
    
    
    
    //*** Personal Info Section ***// 


    const username = $("#Input_UserName");
    const firstName = $("#Input_FirstName");
    const lastName = $("#Input_LastName");
    const gender = $("#Input_Gender");
    const birthDate = $("#Input_BirthDate");
    const language = $("#Input_Language");
    const email = $("#Input_Email");
    const phone = $("#Input_PhoneNumber");
    const address = $("#Input_Address");
    const zipCode = $("#Input_ZipCode");
    const city = $("#Input_City");
    const middleName = $("#Input_MiddleName");
    const phoneCode = $("#Input_PhoneCode");

//Live Username Change
    $(username).keyup(function(){
        $("#username-template").text($(this).val())

    });


//Click Action
    $("#update-profile-button").unbind().bind('click',function(){

        
        if(validateProfile())
            $("#profile-form").submit();
        
        

    });
    
    $("#email-verification-btn").unbind().bind('click',function(){


        if(validateProfile()) {
            $("#email-verification").click();
            
            //Give time while the verification link is created and saved as notification to the database
            setTimeout(function(){
                RevokeNotifications("Email");
            }, 3000);
        }
        else
            return false;



    });
    
    function validateProfile(){
        const continueSubmit = { yes: true
        };


        // Empty Fields Validation
        const listToEmptyFieldValidate = [firstName, lastName, gender, birthDate, language, email, phone, address, zipCode, city, username];

        $(listToEmptyFieldValidate).each(function(i,e){
            if($(e).val().length < 1)
                validation($(e), $("#empty-field-validation"), 'fieldsInRedNotEmpty', continueSubmit);
        });
        
        
        //Short fields Validation
        const listForShortNameValidation =[firstName, lastName];
        $(listForShortNameValidation).each(function(i,e){
            if($(e).val().length < 3)
                validation($(e), $("#empty-field-validation"), 'nameAreTooShort', continueSubmit);
            
        });


        $(email).val($(email).val().toString().trim());
        
        //Valid email
        if(!validateEmail($(email).val()))
            validation($(email), $("#email-validation"), 'notValidEmail', continueSubmit);

        //Phone number validation
        $(phone).val($(phone).val().toString().trim());
        if(!/^[0-9]{8,10}$/.test($(phone).val()))
            validation($(phone), $(".phone-validation"), 'phoneNumberNotValid', continueSubmit);
        if((!/^[1-9][0-9]*$/.test($(phone).val())))
            validation($(phone), $(".phone-validation"), 'phoneNumberNoZero', continueSubmit);


        //Valid username        
        if(!/^[a-zA-Z0-9]{1,20}[.-]{0,1}[a-zA-Z0-9]{1,20}$/.test($(username).val())){
            validation($(username), $("#username-validation"), 'userNameFormat', continueSubmit);
        }

        //No characters validation
        if(!/^[a-zA-Z0-9\sÅåØøæÆ]{0,40}$/.test($(address).val())){
            validation($(address), $("#name-char-validation"), 'noChar', continueSubmit);
        }

        //No characters or numbers validation
        const listToNumberCharValidation = [firstName, middleName, lastName, city];
        $(listToNumberCharValidation).each(function(i,e){
            if(!/^[a-zA-Z\sÅåØøæÆ]{0,40}$/.test($(e).val()))
                validation($(e), $("#name-char-validation"), 'noCharOrNumbers', continueSubmit);
        });

        //zipcode validation
        if(!/^[0-9]{4}$/.test($(zipCode).val()))
            validation($(zipCode), $("#zipcode-validation"), 'zipcodeIsNotValid', continueSubmit);
        
        return continueSubmit.yes;
    }
    
    
    
    //Change listener
    const listToChangeSaveValues = [$(firstName).val(), $(middleName).val(), $(lastName).val(), $(username).val(), $(email).val(), $(phone).val(), $(gender).val(), $(birthDate).val(), $(language).val(), $(address).val(), $(zipCode).val(), $(city).val(), $(phoneCode).val()];
    const listToChangeEvent = [firstName, middleName, lastName, username, email, phone, gender, birthDate, language, address, zipCode, city, phoneCode];
    
    $(listToChangeEvent).each(function(i,e){
        $(e).change(function(){
            if($(e).val() !== listToChangeSaveValues[i]){
                $(e).css('border', '1px solid #28a745');
                $(e).attr('changed', true);
                changeLabel();
            }
            else{
                $(e).css('border', '');
                $(e).attr('changed', false);
                changeLabel();
            }

        });
    });
    
    
    function changeLabel(){
        let show = false;
        $(listToChangeEvent).each(function(i,e){
            if($(e).attr('changed') === 'true')
                show = true;
            else
                $(e).css('border', '')
        });
        
        if(show){
            $("#fields-changed").fadeIn(300);
        }
        else
            $("#fields-changed").fadeOut(300);

    }
    
    // function resetAllEvent(){
        $("#reset-profile").unbind().bind('click', function(){
            $(listToChangeEvent).each(function (i, e) {
                $(e).val(listToChangeSaveValues[i]);
                $(e).attr('changed', 'false')
                changeLabel();
            });
        });
    // }
    
    
    
    
    
    
    
    
});