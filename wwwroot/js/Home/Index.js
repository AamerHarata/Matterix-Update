$(document).ready(function() {

    //Prevent from submit form on page refresh
    if (window.history.replaceState) {
        window.history.replaceState(null, null, window.location.href);
    }
    

    //*** PARTIAL UPDATE ***//

    //Live Courses Partial Update
    const liveCourses = $(".live-course");
    const showMoreLiveBtn = $("#none-log-live-course-show-more-btn");
    const showAllLiveBtn = $("#none-log-live-course-show-all-btn");
    const showLiveContain = $("#none-log-live-course-show");
    let toShowLive = 3;
    showMoreCourses(liveCourses, toShowLive, showLiveContain);

    $(showMoreLiveBtn).click(function() { toShowLive += 3; showMoreCourses(liveCourses, toShowLive, showLiveContain) });
    $(showAllLiveBtn).click(function() { toShowLive = liveCourses.length; showMoreCourses(liveCourses, toShowLive, showLiveContain) });


    //Recorded Courses Partial Update
    const recordedCourses = $(".recorded-course");
    const showMoreRecordBtn = $("#none-log-recorded-course-show-more-btn");
    const showAllRecordBtn = $("#none-log-recorded-course-show-all-btn");
    const showRecordContain = $("#none-log-recorded-course-show");
    let toShowRecorded = 3;
    showMoreCourses(recordedCourses, toShowRecorded, showRecordContain);

    $(showMoreRecordBtn).click(function() { toShowRecorded += 3; showMoreCourses(recordedCourses, toShowRecorded, showRecordContain); });
    $(showAllRecordBtn).click(function() { toShowRecorded = recordedCourses.length; showMoreCourses(recordedCourses, toShowRecorded, showRecordContain); });

    
    //Recommended Courses Partial Update
    const recommendedCourses = $(".recommended-course");
    const showMoreRecommendBtn = $("#none-log-recommended-course-show-more-btn");
    const showAllRecommendBtn = $("#none-log-recommended-course-show-all-btn");
    const showRecommendContain = $("#none-log-recommended-course-show");
    let toShowRecommended = 3;
    showMoreCourses(recommendedCourses, toShowRecommended, showRecommendContain);

    $(showMoreRecommendBtn).click(function() { toShowRecommended += 3; showMoreCourses(recommendedCourses, toShowRecommended, showRecommendContain); });
    $(showAllRecommendBtn).click(function() { toShowRecommended = recommendedCourses.length; showMoreCourses(recommendedCourses, toShowRecommended, showRecommendContain); });
    
    
    

    function showMoreCourses(element, count, container) {
        for (let i = 0; i < count; i++) {
            $(element[i]).css("display", "inline");
        }

        if (count >= element.length)
            $(container).css("display", "none");
    }

    //*** END OF PARTIAL UPDATE ***//


    //*** LIVE LECTURE TIMING ***//
    
    const startWithin = $(".start-within");
    // const diff = parseInt(startWithin.attr('start-time')) - parseInt(startWithin.attr('now-time'));
    
    

     const update = function(diff, div){
         diff -= 1000;
         $(div).attr('diff', diff);
         let s=diff;

         let divTxt = '';
         diff > 0 ? divTxt = JSLanguage('startsWithin')+': ' : divTxt = JSLanguage('startedFor')+': ';

         let ms = s % 1000;
         s = (s - ms) / 1000;
         let seconds = s % 60;
         s = (s - seconds) / 60;
         let minutes = s % 60;
         let hours = (s - minutes) / 60;


         let hrsTxt = '';
         let minTxt = '';
         let secTxt = '';

         Math.abs(hours) < 10 ? hrsTxt = '0' + Math.abs(hours) + ':' : hrsTxt = Math.abs(hours).toString() + ':';
         Math.abs(minutes) < 10 ? minTxt = '0'+Math.abs(minutes) + ':' : minTxt = Math.abs(minutes).toString() + ':';
         Math.abs(seconds) < 10 ? secTxt = '0' + Math.abs(seconds) : secTxt = Math.abs(seconds).toString();

         Math.abs(hours) > 0 ? divTxt += hrsTxt + minTxt + secTxt : divTxt += minTxt + secTxt;

         $(div).text(divTxt);
    };

    
    
    setInterval(function(){
        $(startWithin).each(function(i, e){

            let diff = parseInt($(e).attr('diff'));

            update(diff, e)
        });
        
    },1000)
    
    
    
    
    //*** END OF LIVE LECTURE TIMING ***//


});