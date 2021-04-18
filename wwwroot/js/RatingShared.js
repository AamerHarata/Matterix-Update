//This prevent to show some hidden elements while refreshing or moving / before the document is ready
$("#body-container").css("display", "none");

$(document).ready(function(){
    $("#body-container").css("display", "block");

    const courseId = $("#courseId").val();
    
    
    const eachAverageStarsContainer= $(".average-stars");
    const allStars = $(".stars li");
    const averageAllStars = $(".average-stars li");
    let onStar = parseInt(allStars.data('value'), 10); // The star currently selected
    let stars = allStars.parent().children('li.star');
    let averageStars = averageAllStars.parent().children('li.star');


    //Updateable variables
    const averageValue = $(".average-value");
    const voteCount = $(".votes-count");
    const ratingResponse = $("#rating-response");
    
    getRating();


    $(".fa-star").each(function (i,e) {
        $(e).removeAttr('title');
    });
    


    /* 1. Visualizing things on Hover - See next part for action on click */
    $(allStars).on('mouseover',function() {
        onStar = parseInt($(this).data('value'), 10); // The star currently mouse on

        // Now highlight all the stars that's not after the current hovered star
        $(this).parent().children('li.star').each(function(e) {
            if (e < onStar) {
                $(this).addClass('hover');
            } else {
                $(this).removeClass('hover');
            }
        });

    }).on('mouseout',
        function() {
            $(this).parent().children('li.star').each(function(e) {
                $(this).removeClass('hover');
            });
        });


    /* 2. Action to perform on click */
    $(allStars).on('click',
        function(e) {
        if($(ratingResponse).css("display")!=="none"){
            e.stopPropagation();
            return;
        }
            onStar = parseInt($(this).data('value'), 10); // The star currently selected
            stars = $(this).parent().children('li.star');

            for (let i = 0; i < stars.length; i++) {
                $(stars[i]).removeClass('selected');
            }

            for (let i = 0; i < onStar; i++) {
                $(stars[i]).addClass('selected');
            }
            
            const lang = $cookies.get('lang');
            let dir = '';
            if(lang === 'ar')
                dir = 'rtl';
            else
                dir = 'ltf';
            
            
            let ratingValue = parseInt($('.stars li.selected').last().data('value'), 10);
            let msg = "";
            if (ratingValue > 2) {
                $(ratingResponse).css("background-color", "rgba(46, 139, 87, 0.8)");
                msg = '<span>'+JSLanguage('youRatedCourseAs')+' '+ ratingValue + '.. '+JSLanguage('thanksYouCanWriteComment')+'</span>';
            } else {
                $(ratingResponse).css("background-color", "red");
                msg = '<span>'+JSLanguage('youRatedCourseAs')+ ' '+ratingValue +'.. '+JSLanguage('weWillWorkToImprove')+'</span>';
            }

            addRating(ratingValue, msg);
            // ratingResult = getRating();
            // $("#rating-value").text(ratingResult.count);


        });

    function addRating(value, msg) {
        $.ajax({
            type: "POST",
            url: "/Course/AddRating",
            data: { courseId: courseId, rating: value },
            success: function (response){
                getRating();
                ratingResponse.html(msg);
                ratingResponse.fadeIn(500);
                ratingResponse.fadeOut(8000);
            },
            error: function(response) {
                
            }
        });

    }

    function getRating() {
        $.ajax({
            type: "GET",
            url: "/Course/GetRating",
            data:{courseId: courseId},
            success: function(response) {
                $(averageValue).text(response.average);
                $(voteCount).text(response.count);
                SetDefaultRating(parseInt(response.average), parseInt(response.count), parseInt(response.userRating));
            }
        });
    }
    
    function SetDefaultRating(average, count, userRating){
        //ToDo :: Move those to be in a async get function, wait response then set values
        //Add Stars default values to ratable stars
        for (let i = 0; i < stars.length; i++) {
            $(stars[i]).removeClass('selected');
        }
        for (let i = 0; i < userRating; i++) {
            $(stars[i]).addClass('selected');
        }

        //Add Stars default values to average stars
        $(eachAverageStarsContainer).each(function(index, element){
            const oneContainer = $(element).find($(averageStars));
            for (let i = 0; i < stars.length; i++)
                $(oneContainer[i]).removeClass('selected');

            for (let i = 0; i < average; i++)
                $(oneContainer[i]).addClass('selected');
        });
    }


//*** End of Rating Script ***//








});