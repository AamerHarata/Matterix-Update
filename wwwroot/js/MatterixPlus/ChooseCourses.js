let selectedCourses = [];

const ChooseCourses = function(){
    return {
        init(){
            this.bindEvents();
        },

        selectCourse(courseId) {
            const courseBox = $(`#${courseId}`);

            courseBox.toggleClass('selected');

            $(`.selected-course[courseId=${courseId}]`).toggleClass('d-none');
            $(`.select-course[courseId=${courseId}]`).find('.select-course-text').toggleClass('d-none');


            ChooseCourses().updateSelectedCourses(courseId)

        },



        bindEvents() {

            //Select Course
            $(".select-course").unbind().bind('click', function(){
                const courseId = $(this).attr('courseId');
                ChooseCourses().selectCourse(courseId);
            });
            
            //Submit Application
            $("#continue-button").unbind().bind('click', function(){
                const clicked = $(this);
                if(clicked.hasClass('disabled') || selectedCourses.length <= 0)
                    return false;
                
                
                let courseIds = "";
                for(let i = 0; i < selectedCourses.length; i++){
                    courseIds+= selectedCourses[i];
                    if(i < (selectedCourses.length-1))
                        courseIds+=',';
                }
                
                $("#coursesIds").val(courseIds);
                $("#select-courses-form").submit();

                //ToDo :: Submit a form with application Id and with adding courseIds to an some input
                
            });
            
            
            //Get description by admin //ToDo :: Make it to all students
            $("#course-description").unbind().bind('click', function(){
                $("#description-form").submit();
            });

        },

        updateSelectedCourses(courseId){
            if(selectedCourses.includes(courseId))
                selectedCourses = selectedCourses.filter(x=>x !== courseId);
            else
                selectedCourses.push(courseId);

            ChooseCourses().updateResults();
            ChooseCourses().getDescriptionDocument();
        },

        updateResults(){
            const selectionResults = $("#selected-courses");
            selectionResults.html('');

            if(selectedCourses.length === 0){
                $("#select-statement").fadeIn(300);
                $("#continue-button").attr('disabled', 'disabled').addClass('disabled');
            }else{
                $("#select-statement").fadeOut(300);
                $("#continue-button").removeAttr('disabled').removeClass('disabled');

                selectionResults.html('');

                $(selectedCourses).each(function(i, e){
                    selectionResults.append($(`#${e}`).clone().removeAttr('id'));
                    $(`.selected-course[courseid=${e}]`).fadeIn(300);

                })

            }

            ChooseCourses().bindEvents();
        },
        
        getDescriptionDocument(){
            let courseIds;
            $(selectedCourses).each(function(i, e){
                courseIds+= e+',';
            });
            
            $("#courseIds").val(selectedCourses)
            
        },
    };
};

$(document).ready(function () {

    
    




    ChooseCourses().init();
    
    $("input").keydown(function () {
        ChooseCourses().bindEvents();
    });
    
    
    
    
});