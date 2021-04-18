$(document).ready(function(){
    const firstName = $("#Input_FirstName");
    const lastName = $("#Input_LastName");
    const gender = $("#Input_Gender");
    const day = $("#Input_Day");
    const month = $("#Input_Month");
    const year = $("#Input_Year");
    const language = $("#Input_Language");
    const email = $("#Input_Email");
    const phone = $("#Input_PhoneNumber");
    const password = $("#Input_Password");
    const passwordConfirm = $("#Input_ConfirmPassword");
    const address = $("#Input_Address");
    const zipCode = $("#Input_ZipCode");
    const city = $("#Input_City");
    const middleName = $("#Input_MiddleName");
    const continueSubmit = { yes: true};
    
    
    
    // $("footer").hide();
    
    
    
    const sections = $(".section");
    const changeBtn = $(".change-section");
    let currentPhase = 'intro';


    const notAllowedNumbersOrChars = ['0','1','2','3','4','5','6','7','8','9','-','!','~','@','#','$','%','^','&','*','(',')','_','+','=','?','؟',',','،', '/', '\\', '~','\"', '\'', '}','{'];
    const notAllowedArabic = ['أ', 'ب', 'ت', 'ث','ج','ح','خ','د','ذ','ر','ز','س','ش','ص','ض','ع','غ','ف','ق','ك','ل','م','ن','ه','و','ي', 'َ','ُ','ِ','ْ','َ','ً','ٌ','ـ','ئ','ْ','ا','إ', 'ٍ'];


    $(document).keypress(function(event){
        if(event.keyCode === 13)
            $(".change-section").click()
    });
    
    styleStages();

    $(changeBtn).unbind().bind('click', function (e) {
        e.preventDefault();

        const target = $(this).attr('target');
        continueSubmit.yes = true;
        
        switch (currentPhase) {
            case 'intro':
                break;
            case 'personal-info':
                validate().personalInfoSection();
                break;
            case 'contact-info':
                validate().contactInfoSection();
                break;

            case 'password':
                validate().passwordSection();
                break;

            case 'address':
                validate().addressSection();
                break;
                
        }
        
        if(continueSubmit.yes){
            $(sections).fadeOut(200);
            if(target !== 'complete'){
                setTimeout(function(){$("#"+target).fadeIn(100)}, 300);
                updatePhase(target)
            }else{

                // On submit double check all fields first
                validate().personalInfoSection();
                validate().contactInfoSection();
                validate().passwordSection();
                validate().addressSection();
                
                if(continueSubmit.yes){
                    
                    //Face book track registration complete
                    const name = $(firstName).val() + ' ' + $(lastName).val();
                    FacebookTrack().CompleteRegistration(name);
                    
                    $("#register-form").submit();
                }
                
                
            }
        }

    });
    
    
    
    const validate = function(){
        return{
            
            personalInfoSection(){

                
                //Arabic letters check
                const listToArabicChars = [firstName, lastName, email, password, address, middleName, city, address];

                $(listToArabicChars).each(function(i,e){
                    for(let i = 0; i<$(e).val().length; i++)
                        if(notAllowedArabic.includes($(e).val().toString()[i]))
                            validationNewInput($(e), $("#personal-info-validation"), 'noArabicLetters', continueSubmit);
                });



                //No numbers or char validation
                if(continueSubmit.yes){
                    const listToNameCharValidate = [firstName, lastName, middleName];
                    $(listToNameCharValidate).each(function(i,e){
                        for(let i = 0; i<$(e).val().length; i++)
                            if(notAllowedNumbersOrChars.includes($(e).val().toString()[i]) && !/^[a-zA-ZÅåØøÆæ\s]{1,40}$/.test($(e).val()))
                                validationNewInput($(e), $("#personal-info-validation"), 'nameCannotIncludeChar', continueSubmit);
                    });
                }
                


                
                //Name taken validation
                if(continueSubmit.yes && $(firstName).val().length > 0 && $(lastName).val().length > 0){
                    $.ajax({
                        type: "GET",
                        url: "/EmailNameValidation/",
                        async: false,
                        data: {email: "none@none.com", firstName : $(firstName).val(), lastName: $(lastName).val()},
                        success: function(response){

                        },
                        error: function(response){
                            continueSubmit.yes = false;
                            if(response.responseText === 'nameIsTaken')
                                validationNewInput($(firstName).add($(lastName)), $("#personal-info-validation"), response.responseText, continueSubmit);
                            else
                                validationNewInput($(null), $("#personal-info-validation"), response.responseText, continueSubmit);

                        }
                    });
                }

                //Relevant fields those cannot be empty
                if(continueSubmit.yes){
                    const listToEmptyFieldValidate = [firstName, lastName, gender, day, year, month];
                    $(listToEmptyFieldValidate).each(function(i,e){
                        if($(e).val().length < 1)
                            validationNewInput($(e), $("#personal-info-validation"), 'fieldsInRedNotEmpty', continueSubmit);
                    });
                }

                if(continueSubmit.yes){
                    //Short fields Validation
                    const listForShortNameValidation =[firstName, lastName];
                    $(listForShortNameValidation).each(function(i,e){
                        if($(e).val().length < 3)
                            validationNewInput($(e), $("#personal-info-validation"), 'nameAreTooShort', continueSubmit);

                    });
                }
                
                
                
                
                
                
            },
            
            contactInfoSection(){
                $(email).val($(email).val().toString().trim());
                
                //Email validation
                if($(email).val().length > 0 && !validateEmail($(email).val()))
                    validationNewInput($(email), $("#contact-info-validation"), 'notValidEmail', continueSubmit);

                //Arabic letters check
                const listToArabicChars = [email];

                $(listToArabicChars).each(function(i,e){
                    for(let i = 0; i<$(e).val().length; i++)
                        if(notAllowedArabic.includes($(e).val().toString()[i]))
                            validationNewInput($(e), $("#contact-info-validation"), 'noArabicLetters', continueSubmit);
                });


                // Email taken validation
                if($(email).val().length > 0 && continueSubmit.yes){
                    $.ajax({
                        type: "GET",
                        url: "/EmailNameValidation/",
                        async: false,
                        data: {email: $(email).val(), firstName : "none", lastName: "none"},
                        success: function(response){

                        },
                        error: function(response){
                            continueSubmit.yes = false;
                            if(response.responseText === 'emailIsTaken')
                                validationNewInput($(email), $("#contact-info-validation"), response.responseText, continueSubmit);
                            else
                                validationNewInput($(null), $("#contact-info-validation"), response.responseText, continueSubmit);

                        }
                    });
                }

                //Empty fields check
                if(continueSubmit.yes){
                    const listToEmptyFieldValidate = [language, email, phone];

                    $(listToEmptyFieldValidate).each(function(i,e){
                        if($(e).val().length < 1)
                            validationNewInput($(e), $("#contact-info-validation"), 'fieldsInRedNotEmpty', continueSubmit);
                    });
                }


                if(continueSubmit.yes){
                    $(phone).val($(phone).val().toString().trim());
                    //Phone number validation
                    if((!/^[0-9]+$/.test($(phone).val()) || $(phone).val().length <8) && $(phone).val().length >0)
                        validationNewInput($(phone), $("#contact-info-validation"), 'phoneNumberNotValid', continueSubmit);

                    //Phone number no zero validation
                    if(continueSubmit.yes && (!/^[1-9][0-9]*$/.test($(phone).val())))
                        validationNewInput($(phone), $("#contact-info-validation"), 'phoneNumberNoZero', continueSubmit);
                }

                
                
                
                
                
            },
            
            passwordSection(){
                
                
                
                //Arabic letters check
                    const listToArabicChars = [firstName, lastName, email, password, address, middleName, city, address];
                    $(listToArabicChars).each(function(i,e){
                        for(let i = 0; i<$(e).val().length; i++)
                            if(notAllowedArabic.includes($(e).val().toString()[i]))
                                validation($(e), $("#password-validation"), 'noArabicLetters', continueSubmit);
                    });

                //Password length validation
                if(continueSubmit.yes && $(password).val().length < 6 && $(password).val().length>0)
                    validationNewInput($(password), $("#password-validation"), 'passwordMore6', continueSubmit);


                //Password Letter case validation
                if(continueSubmit.yes &&  !/^(?=.*[A-Z])/.test($(password).val()) && $(password).val().length>0)
                    validationNewInput($(password), $("#password-validation"), 'atLeastUppercase', continueSubmit);
                if(continueSubmit.yes && !/^(?=.*[a-z])/.test($(password).val()) && $(password).val().length>0)
                    validationNewInput($(password), $("#password-validation"), 'atLeastLowercase', continueSubmit);

                //Empty fields check
                if(continueSubmit.yes){
                    const listToEmptyFieldValidate = [password, passwordConfirm];
                    $(listToEmptyFieldValidate).each(function(i,e){
                        if($(e).val().length < 1)
                            validationNewInput($(e), $("#password-validation"), 'fieldsInRedNotEmpty', continueSubmit);
                    });
                }

                //Passwords match validation
                if (continueSubmit.yes) {
                    if($(password).val() !== $(passwordConfirm).val())
                        validationNewInput($(password), $("#password-validation"), 'passwordDoesNotMatch', continueSubmit);                    
                }
                
                
                
                
                
            },
            
            addressSection(){
                
                //Empty field validation
                const listToEmptyFieldValidate = [address, zipCode, city];
                $(listToEmptyFieldValidate).each(function(i,e){
                    if($(e).val().length < 1)
                        validationNewInput($(e), $("#address-validation"), 'fieldsInRedNotEmpty', continueSubmit);
                });



                //Arabic letters check
                const listToArabicChars = [city, address];

                if(continueSubmit.yes){
                    $(listToArabicChars).each(function(i,e){
                        for(let i = 0; i<$(e).val().length; i++)
                            if(notAllowedArabic.includes($(e).val().toString()[i]))
                                validationNewInput($(e), $("#address-validation"), 'noArabicLetters', continueSubmit);
                    });
                }


                //No numbers or char validation
                if(continueSubmit.yes){
                    const listToNameCharValidate = [city];
                    $(listToNameCharValidate).each(function(i,e){
                        for(let i = 0; i<$(e).val().length; i++)
                            if(notAllowedNumbersOrChars.includes($(e).val().toString()[i]) && !/^[a-zA-ZÅåØøÆæ\s]{1,40}$/.test($(e).val()))
                                validationNewInput($(e), $("#address-validation"), 'nameCannotIncludeChar', continueSubmit);
                    });
                }
                
                
                
                
            }
            
        }
    };
    
    function updatePhase(target){

        $(".step[phase="+currentPhase+"]").attr('completed', true);
        currentPhase = target;
        
        styleStages();        
        
        
        
    }
    
    function styleStages(){
        $(".step").each(function(i, e){


            if(e.hasAttribute('completed')){
                $(e).html("<i class=\"far fa-check-circle text-success\"></i>")
            }

            if($(e).attr('phase') === currentPhase){
                $(e).html("<i style=\"box-shadow: 0 0 5pt 1pt lightgray; border-radius: 50%\" class=\"fa fa-circle matterix-color\"></i>")
            }

        })    
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    

//OLD VALIDATION
    // $("#register-submit").unbind().bind('click', function(){
    //    
    //    
    //     //Empty fields check
    //    
    //     const listToEmptyFieldValidate = [firstName, lastName, gender, language, email, phone, password, passwordConfirm, address, zipCode, city, day, year, month];
    //    
    //     $(listToEmptyFieldValidate).each(function(i,e){
    //         if($(e).val().length < 1)
    //             validation($(e), $("#empty-field-validation"), 'fieldsInRedNotEmpty', continueSubmit);
    //     });
    //
    //
    //     //Short fields Validation
    //     const listForShortNameValidation =[firstName, lastName];
    //     $(listForShortNameValidation).each(function(i,e){
    //         if(continueSubmit.yes && $(e).val().length < 3)
    //             validation($(e), $("#empty-field-validation"), 'nameAreTooShort', continueSubmit);
    //
    //     });
    //    
    //    
    //     // if(birthDate.val() === '')
    //     //     validation($(birthDate), $("#empty-field-validation"), 'fieldsInRedNotEmpty', continueSubmit);
    //    
    //     //Arabic letters check
    //     const listToArabicChars = [firstName, lastName, email, password, address, middleName, city, address];
    //    
    //     $(listToArabicChars).each(function(i,e){
    //         for(let i = 0; i<$(e).val().length; i++)
    //             if(notAllowedArabic.includes($(e).val().toString()[i]))
    //                 validation($(e), $(".name-char-validation"), 'noArabicLetters', continueSubmit);
    //     });
    //       
    //
    //    
    //     //No numbers or char validation
    //     const listToNameCharValidate = [firstName, lastName, middleName, city];
    //     $(listToNameCharValidate).each(function(i,e){
    //         for(let i = 0; i<$(e).val().length; i++)
    //             if(notAllowedNumbersOrChars.includes($(e).val().toString()[i]) && !/^[a-zA-Z0-9ÅåØøÆæ\s]{1,40}$/.test($(e).val()))
    //                 validation($(e), $(".name-char-validation"), 'nameCannotIncludeChar', continueSubmit);
    //     });
    //    
    //    
    //     //Email validation
    //     if(!validateEmail($(email).val()))
    //         validation($(email), $(".email-validation"), 'notValidEmail', continueSubmit);
    //    
    //     //Passwords match validation
    //     if($(password).val() !== $(passwordConfirm).val())
    //         validation($(password), $(".password-confirm-validation"), 'passwordDoesNotMatch', continueSubmit);
    //    
    //     //Password Letter case validation
    //     if(!/^(?=.*[A-Z])/.test($(password).val()) && $(password).val().length>0)
    //         validation($(password), $(".password-validation"), 'atLeastUppercase', continueSubmit);
    //     if(!/^(?=.*[a-z])/.test($(password).val()) && $(password).val().length>0)
    //         validation($(password), $(".password-validation"), 'atLeastLowercase', continueSubmit);
    //    
    //     //Password length validation
    //     if($(password).val().length < 6 && $(password).val().length>0)
    //         validation($(password), $(".password-validation"), 'passwordMore6', continueSubmit);
    //    
    //     //Phone number validation
    //     if((!/^[0-9]+$/.test($(phone).val()) || $(phone).val().length <8) && $(phone).val().length >0)
    //         validation($(phone), $(".phone-validation"), 'phoneNumberNotValid', continueSubmit);
    //    
    //     //Phone number no zero validation
    //     if((!/^[1-9][0-9]*$/.test($(phone).val())))
    //         validation($(phone), $(".phone-validation"), 'phoneNumberNoZero', continueSubmit);
    //    
    //     //Zipcode validation
    //     if((!/^[0-9]+$/.test($(zipCode).val()) || $(zipCode).val().length <4) && $(zipCode).val().length >0)
    //         validation($(zipCode), $("#zipcode-validation"), 'zipcodeIsNotValid', continueSubmit);
    //    
    //        
    //     // Email and Name taken validation
    //     if(continueSubmit.yes){
    //         $.ajax({
    //             type: "GET",
    //             url: "/EmailNameValidation/",
    //             async: false,
    //             data: {email: $(email).val(), firstName : $(firstName).val(), lastName: $(lastName).val()},
    //             success: function(response){
    //               
    //             },
    //             error: function(response){
    //                 continueSubmit.yes = false;
    //                 if(response.responseText === 'nameIsTaken')
    //                     validation($(firstName).add($(lastName)), $(".name-char-validation"), response.responseText, continueSubmit);
    //                 else if(response.responseText === 'emailIsTaken')
    //                     validation($(email), $(".email-validation"), response.responseText, continueSubmit);
    //                 else
    //                     validation($(null), $(".name-char-validation"), response.responseText, continueSubmit);
    //
    //             }
    //         });
    //     }
    //    
    //    
    //    
    //    
    //    
    //    
    //    
    //     if(continueSubmit.yes === true){
    //         $("#register-form").submit();
    //     }else{
    //         //Scroll to the last input with wrong
    //         const listToScroll = [];
    //         const allInputs = $(".form-control");
    //         $(allInputs).each(function(i,e){
    //             if($(e).hasClass('invalid')){
    //                 listToScroll.push($(e));
    //                
    //             }
    //         });
    //
    //         $([document.documentElement, document.body]).animate({
    //             scrollTop: parseInt($("#"+$(listToScroll[listToScroll.length-1]).attr('id')).offset().top) - 200 + 'px' 
    //         }, 2000);
    //        
    //     }
    //    
    //    
    //    
    // });
    
    //*** END OF REGISTER SECTION ***//
    
    
    
    
   
    
    
    
    
   
    
});