$(document).ready(function () {

    let allCourses = [];
    let desiredCourses = [];
    let chosenCourses = [];
    const searchInput = $("#search-courses-input");
    const courseResultsHtml = $("#course-results");
    const chosenCoursesHtml = $("#chosen-courses");
    const choices = $(".choice");
    const onlyLiveCoursesCheck = $("#only-live-courses-check");
    
    
    //Get all courses -- put them in allCourses array
    $.ajax({
        type: "GET",
        url: "/Search/GetAllCourses",
        success: function(response){
            $(response).each(function(i, e){
                allCourses.push(e)
            })
        }
    });

    
    
    //Choice event
    $(choices).unbind().bind('click', function () {
        const chosen = $(this);
        
        $(chosen).attr('style', 'text-shadow: 1px 1px 1px 1px black; border-bottom: 0.01rem gray solid; max-width: max-content;');
        
        setTimeout(function(){$(chosen).attr('style', '')}, 600);
        
        $(choices).each(function(i, e){
            $(e).find('input').prop('checked', '')
        });
        $(chosen).find('input').prop('checked', 'checked')
    });
    
    //
    
    
    $(searchInput).unbind().bind('keyup', function(){
        const pattern = $(this).val().toString();
        desiredCourses = [];
        
        $(allCourses).each(function(i, e){
            if(e["course"]["subject"].toUpperCase().includes(pattern.toUpperCase()))
                desiredCourses.push(e);
        });
        if(!pattern.length)
            desiredCourses = [];
        
        Search().updateResults();
    }).on('focusin', function(){
        //Focus on input will lead to scroll
        $(document).scrollTop($(searchInput).offset().offsetX)
    });




    const Search = function(){
        return{
            
            updateResults(){
                $(courseResultsHtml).html("");
                $(chosenCoursesHtml).html("");
                
                $(desiredCourses).each(function(i, e){
                    if($(onlyLiveCoursesCheck).prop('checked')){
                        if(!e['course']['ended'])
                            $(courseResultsHtml).append(Search().courseResultHtml(e)+Search().courseResultHtml(e))

                    }else{
                        $(courseResultsHtml).append(Search().courseResultHtml(e)+Search().courseResultHtml(e))
                    }
                    
                });
                



                if(chosenCourses.length > 0){
                    $(chosenCoursesHtml).append("<div class='direction matterix-color font-weight-bold'>الدورات التي قمت باختيارها</div><hr class=''/>");

                    $(chosenCourses).each(function(i, e){
                        $(chosenCoursesHtml).append(Search().chosenCoursesHtml(e))
                    });
                    
                    $(chosenCoursesHtml).append("<div id='continue' class='text-center m-auto'><button class='m-btn m-btn-primary mb-2'>المتابعة</button></div><hr/>")
                }
                
                
                
                
                
                
                

                Search().bindEvents();
            },
            
            courseResultHtml(courseObject){
                let html = "<div class='col-md-4 p-2'><div class='card p-2 w-100 d-inline-block text-center'><div>"+
                    courseObject['course']['subject']+" - "+courseObject['teacher']['firstName']
                    +"</div><span><button class='m-btn m-btn-small m-btn-primary d-inline-block'>صفحة الدورة</button></span>";
                
                if(courseObject['validRegistration']){
                    html+= "<div class='text-center'><button id='"+courseObject['course']['id']+"' class='m-btn m-btn-primary'>أنت مسجل في هذه الدورة</button></div>";
                }else
                    html+= "<div class='text-center'><button id='"+courseObject['course']['id']+"' class='m-btn m-btn-small m-btn-success choose-course'>اختر</button></div>";

                html += "</div></div>";
                
                return html;
            },

            chosenCoursesHtml(courseObject){
                return "<div class='card w-25 p-3 mb-2 d-inline-block text-center ml-2'><div>"+courseObject['course']['subject']+" - "+courseObject['teacher']['firstName']+"</div><span><button class='m-btn m-btn-small m-btn-primary d-inline-block'>صفحة الدورة</button></span><div class='text-center'><button id='"+courseObject['course']['id']+"' class='m-btn m-btn-small m-btn-danger remove-course'>حذف</button></div></div>"
            },
            
            
            courseChosen(courseId){
                const chosenCourseObject = allCourses.find(it=>it['course']['id'] === courseId);
                if(chosenCourseObject === null)
                    return false;
                
                allCourses = allCourses.filter(it=>it['course']['id'] !== courseId);
                desiredCourses = desiredCourses.filter(x=>x['course']['id'] !== courseId);
                chosenCourses.push(chosenCourseObject);
                
                Search().updateResults();
                
            },
            
            courseRemoved(courseId){

                const chosenCourseObject = chosenCourses.find(it=>it['course']['id'] === courseId);
                if(chosenCourseObject === null)
                    return false;

                chosenCourses = chosenCourses.filter(it=>it['course']['id'] !== courseId);
                
                allCourses.push(chosenCourseObject);
                desiredCourses.push(chosenCourseObject);

                Search().updateResults();
                
            },
            
            bindEvents(){
                const chooseCourse = $(".choose-course");
                const removeCourse = $(".remove-course");
                $(chooseCourse).unbind().bind('click', function(){
                    const courseId = $(this).attr('id');
                    Search().courseChosen(courseId);
                });
                $(removeCourse).unbind().bind('click', function(){
                    const courseId = $(this).attr('id');
                    Search().courseRemoved(courseId);
                });
                
            }
            
        }
    };




    
//     let doc = new jsPDF();
//
//     // doc.setFont("courier");
//     // doc.setFontType("normal");
//    
//     let elementHTML = $('#content').html();
//     let specialElementHandlers = {
//         '#elementH': function (element, renderer) {
//             return true;
//         }
//     };
//     doc.fromHTML(elementHTML, 15, 15, function(){});
//    
// // Add new page
//    
//
// // Save the PDF
//     doc.save('document.pdf');
//    
    
    
    
    
});









class Course {
    constructor() {
        
    }
    
    Id;
    Live;
    Owned;
    
    
}