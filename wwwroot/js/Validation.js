//Used in Course Create


function validation(selector, validationSelector, key, boolObjectToFlip) {
    //selector is the element to mark in red
    //validationSelector is the element to push the text to
    //key is the language key for the translation
    //boolObjectToFlip is an object has member 'yes' to make it false to prevent to submit a form
    
    boolObjectToFlip.yes = false;
    $(validationSelector).text(JSLanguage(key));
    $(validationSelector).fadeIn(400);
    selector.css("border", "1px solid red").addClass('invalid').click(function() {
        $(this).css("border", "").removeClass('invalid');
        $(validationSelector).fadeOut(400);
    });
}

function validationNewInput(selector, validationSelector, key, boolObjectToFlip, isHtml = false) {
    //selector is the element to mark in red
    //validationSelector is the element to push the text to
    //key is the language key for the translation
    //boolObjectToFlip is an object has member 'yes' to make it false to prevent to submit a form

    boolObjectToFlip.yes = false;
    $(validationSelector).text(JSLanguage(key));
    if(isHtml)
        $(validationSelector).html(key);
    $(validationSelector).fadeIn(400);
    const labelSelector = $(selector).parent().find('.matterix-input-label');
    const contentSelector = $(selector).parent().find('.matterix-input-content');
    
    contentSelector.css("color", "red").addClass('invalid');
    $(labelSelector).css('border-bottom-color', 'red').addClass('invalid');
    $(selector).click(function() {
        contentSelector.css("color", '').removeClass('invalid');
        labelSelector.css('border-bottom-color', '').removeClass('invalid');
        $(validationSelector).fadeOut(400);
    });
}


function validateEmail($email) {
    const emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test( $email );
}