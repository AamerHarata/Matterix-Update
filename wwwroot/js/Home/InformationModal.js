let courseInfoBtn;
let registrationInfoBtn;
let joinLectureBtn;
let invoiceBtn;

function BindInformationButton(){
    courseInfoBtn = $(".course-info-btn");
    registrationInfoBtn = $(".registration-info-btn");
    joinLectureBtn = $(".join-lecture-btn");
    invoiceBtn = $(".invoice-btn");
    
    $(courseInfoBtn).unbind().bind('click', function(){
        const courseId = $(this).attr('courseId');
        Modal().CourseInfo(courseId);
    });

    $(registrationInfoBtn).unbind().bind('click', function(){
        const courseId = $(this).attr('courseId');
        Modal().RegistrationInfo(courseId);
    });
    
    $(joinLectureBtn).unbind().bind('click', function(){
        const lectureBtn = $(this);
        Modal().JoinLectureInfo(lectureBtn);
    });
    
    $(invoiceBtn).unbind().bind('click', function(){
        const invoiceNumber = $(this).attr('invoiceNumber');
        Modal().InvoiceInfo(invoiceNumber);
    });
    
}

const Modal = function(){
    return{

        CourseInfo(courseId){

            const courseInfo = $("#course-information-"+courseId).clone();
            const courseTitle = $(courseInfo).attr('courseTitle');
            InformationModal.SetHtml(courseInfo.removeAttr('hidden'));
            InformationModal.Show(JSLanguage('courseInfo') + ' ' + courseTitle, 'center no-footer');
            BindInformationButton();
        },
        RegistrationInfo(courseId){
            const registrationInfo = $("#registration-information-"+courseId).clone();
            const courseTitle = $(registrationInfo).attr('courseTitle');
            InformationModal.SetHtml(registrationInfo.removeAttr('hidden'));
            InformationModal.Show(JSLanguage('enrollmentInfo') + ' ' + courseTitle, 'center no-footer');
            BindInformationButton();
        },
        JoinLectureInfo(lectureBtn){
            const isLive = $(lectureBtn).attr('isLive') === 'True';
            const courseTitle = $(lectureBtn).attr('courseTitle');
            let classUrl = $(lectureBtn).attr('classUrl');
            classUrl = classUrl === undefined || classUrl === null ? '' : classUrl;
            
            let html;
            let title = JSLanguage('goToClassOf') +' ' + courseTitle;
            let mode = 'center no-footer';
            
            if(isLive && classUrl.length){
                window.open(classUrl, '_blank');
                return;
            }else if(isLive && !classUrl.length){
                html = "<div class='text-0-9'>"+JSLanguage('linkNotWorkContactNow')+"</div> <div class='text-center buttons-in-modal-container'><a style='margin: 1rem auto' href='https://matterix.no/home/ContactUs'>"+JSLanguage('contactUs')+"</a></div>";
                mode = 'no-footer';
            }
            else if (!isLive && !classUrl.length){
                html =  `<div class="text-center text-0-8 direction">
                            <div class="matterix-color text-0-9 font-cairo mb-2">${JSLanguage('lectureHasNotStarted')}</div>
                            <div>${JSLanguage('weStillCompletingCourseSettings')}</div>
                            
                            <div class='text-center buttons-in-modal-container m-auto'>
                                <a style='margin: 1rem 0.1rem' href='https://matterix.no/Instructions/LiveCourses' target="_blank">${JSLanguage('learnMethod')}</a>
                            </div>
                        </div>`
                
            }else if(!isLive && classUrl.length){
                
                
                html =  `<div class="text-center text-0-8 direction">
                            <div class="matterix-color text-0-9 font-cairo mb-2">${JSLanguage('lectureHasNotStarted')}</div>
                            <div>${JSLanguage('youCanStillTryJoin')}</div>
                            <div>${JSLanguage('orYouCanGetHelpForJoining')}</div>
                            <div class='text-center buttons-in-modal-container m-auto'>
                            <a style='margin: 1rem 0.1rem' href="${classUrl}" target="_blank">${JSLanguage('tryJoin')}</a>
                            <a style='margin: 1rem 0.1rem' href='https://matterix.no/Instructions/LiveCourses' target="_blank">${JSLanguage('learnMethod')}</a>
                            </div>
                        </div>`
            }
            
            InformationModal.SetHtml(html);
            InformationModal.Show(title, mode);
            // window.open(classUrl, '_blank');
        },
        InvoiceInfo(invoiceNumber){
            const invoiceInfo = $("#invoice-information-"+invoiceNumber).clone();
            InformationModal.SetHtml(invoiceInfo.removeAttr('hidden'));
            InformationModal.Show(JSLanguage('invoice') + ': ' + invoiceNumber, 'center no-footer');
            BindInformationButton();
        },
        



    }
};


$(document).ready(function(){
    
    BindInformationButton();
    
    
       
    
    
    
    
    
});