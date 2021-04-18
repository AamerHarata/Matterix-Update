$(document).ready(function(){

    //Hide footer temporarily
    $("footer").css({display: 'none', height: '0'});
    $("body").css('margin-bottom', '0px');
    
    
    
    const lecturesHead = $(".lecture-head");
    
    $(lecturesHead).each(function(i,e){
        if($(e).children().hasClass('open-lecture')){
            $(e).addClass('open-lecture')
        }
    });
    
    //Shared Modal
    const sharedModal = $("#shared-modal");
    const sharedModalConfirm = $("#shared-modal-btn-yes");
    const sharedModalCancel = $("#shared-modal-btn-no");
    const sharedModalContent = $("#shared-modal-content");
    const sharedModalTitle = $("#shared-modal-title");
    
    //Wait Modal
    const waitModal = $("#wait-modal");
    
    
    const courseId = $("#courseId").val();
    const studentId = $("#studentId").val();

    //*** Set the height of the info divs to be equal ***//
    const courseDiv = $("#course-title-div");
    const infoDiv1 = $("#course-info-div1");
    const infoDiv2 = $("#course-info-div2");
    
    const mainInfoBox = $("#course-info-main-box");
    const array = [
        parseInt(courseDiv.css("height")), parseInt(infoDiv1.css("height")), parseInt(infoDiv2.css("height"))
    ];
    const max = Math.max.apply(Math, array) + "px";
    courseDiv.css("height", max);
    infoDiv1.css("height", max);
    infoDiv2.css("height", max);
    //*** End of Set the height of the info divs to be equal ***//


    //*** Set the position of the main info box and the nav ***///
    const tobNav = $("#main-nav");
    const tabNav = $("#course-nav-tab");
    const closeBtn = $("#close-info-box");



    adjustAll();


    $(closeBtn).click(function() {
        mainInfoBox.css("display", "none");
        // bodyDiv.css("margin-top", parseInt(tobNav.css("height")) + parseInt(tabNav.css("margin-bottom")) + "px");

    });

    function adjustAll() {
        tabNav.css("top", tobNav.css("height"));
        tabNav.offset().y = (tobNav.css("height"));
    }

    //*** End of Set the position of the main info box and the nav ***///




    //*** Nav Links ***//


    //If The href is empty, add lectures as default
    if(window.location.href.split("#").length<2)
        window.location.href = window.location.href + "#lectures";


    window.scrollTo(0,100);
    getTheActiveTab("#"+window.location.href.split("#")[1]);
    
    
    //On click to move the tab
    $(".tab-link").unbind().bind("click", function(e){
        e.preventDefault();
        const activeTab = $(this).attr("href");
        window.location.href = window.location.href.split("#")[0]+activeTab;
        getTheActiveTab(activeTab);
        
        const collapseCourseNavbar =$(".navbar-collapse-course"); 
        if(collapseCourseNavbar.hasClass("show"))
            $(collapseCourseNavbar.removeClass("show"));
                
    });
    
    
    function getTheActiveTab(tabName){
        
        $(window).scrollTop(0);
        $(".tab-div").css("display", "none");
        $(".tab-link").removeClass("active-tab");
        $(tabName).css("display", "block");
        $(".tab-link[href='"+tabName+"']").addClass("active-tab");

        
        if(tabName === "#rating")
            $(closeBtn).trigger("click");
        if(tabName === "#videos"|| tabName === "#class"){
            $(closeBtn).trigger("click");
            $("body").css("overflow", "hidden");
            return false;
        }else{
            $("body").css("overflow", "auto");
        }
        

        $(window).scrollTop(0);
    }
        
    
    //*** END OF Nav Links ***//
    
    
    
    
    //*** LECTURE ACTION ***//
    
    
    // Styling the lectures' actions
    $(lecturesHead).click(
        function() {

            //Prevent to open and close body on input click
            $(".no-move").click(function (event) {
                event.stopPropagation();
            });

            const lectureBody = $(this).next().next();
            const lecturesHead = $(this);
            const mainInfo = $("#course-info-main-box");
            const titleDiv = $(this).find(".lecture-title");
            const hLine = $(this).next();


            //Check if already expanded or not
            if (lectureBody.css("max-height") === '0px') {

                lectureBody.css("max-height", lectureBody.prop("scrollHeight") + "px");
                $(this).addClass("active-head");
                $(titleDiv).addClass("active-title");
                $(hLine).css("display", "block");

                $([document.documentElement, document.body]).animate({
                    scrollTop: $(lecturesHead).position().top - 2* parseInt($(lecturesHead).css("height"))-5
                }, 1500);
                
            } 
            else {
                lectureBody.css("max-height", "0");
                $(this).removeClass("active-head");
                $(titleDiv).removeClass("active-title");
                $(hLine).css("display", "none");
            }


        });

    //Editing the lecture
    
    //Initiate this variable outside, to prevent have it as null again
    let LECTURE={};
    $(".lecture-container").mouseover(function () {

        //Containers elements
        const lectureContainer = $(this);
        const editBtn = $(this).find(".edit-btn");
        const saveBtn = $(this).find(".save-btn");
        const deleteLectureBtn = $(this).find(".lecture-delete-btn");
        const cancelBtn = $(this).find(".cancel-btn");
        const lectureBody = $(this).find(".lecture-body");
        const lectureHead = $(this).find(".lecture-head");
        const successEditing = $(this).find(".success-edit");
        const successEditingText = $(this).find(".success-edit span.text-message");
        const titleContainer = $(this).find(".title-container");
        const editTitleContainer = $(this).find(".edit-title-container");

        //Editable elements
        const lectureTitle = lectureContainer.find(".lecture-title");
        const lectureDescription = lectureBody.find(".lecture-description");
        const lecturePreparation = lectureBody.find(".lecture-preparation");
        const lectureCompleted = lectureContainer.find(".lecture-completed");
        const lectureFree = lectureContainer.find(".lecture-free");
        const lectureFrom = lectureContainer.find(".lecture-from");
        const lectureTo = lectureContainer.find(".lecture-to");
        const lectureDay = lectureContainer.find(".lecture-day");
        const lectureDate = lectureContainer.find(".lecture-date");

        //ToDo:: Add lecture day, completed and time to be edited in edit mode

        //File upload download variables
        const filesContainer = $(this).find(".files-container");
        const selectFileBtn = $(this).find(".select-file-btn");
        const hiddenSelectFile = $(this).find(".hidden-select-file");
        const fileName = $(this).find(".file-name");
        const uploadBtn = $(this).find(".upload-btn");
        const deleteFile = $(this).find(".file-delete-btn");
        const fileBtn = $(this).find(".file-btn");
        const noFiles = $(this).find(".no-files");
        const makeHomework = $(this).find(".file-homework-btn");


        //Video variables
        const videosContainer = $(this).find(".videos-container");
        const addVideoBtn = $(this).find(".add-video-btn");



        //Other variables
        
        const courseId = $("#courseId").val();
        const lectureId = $(this).attr("id");
        const lectureNumber = parseInt($(this).attr("lecture-number"));


        //When Edit button clicked
        $(editBtn).unbind().bind("click",function(){
            const dontTouchData = saveBtn.css("display") !== "none";
            if(!dontTouchData){
                AddDataToLectureObject();
                OpenEditMode();
                // console.log(LECTURE)
            }


        });

        //When Cancel button clicked
        $(cancelBtn).unbind().bind('click', function(){

            lectureDescription.val(LECTURE.description);
            lecturePreparation.val(LECTURE.preparation);
            lectureCompleted.prop("checked", LECTURE.completed);
            lectureFree.prop("checked", LECTURE.free);
            lectureFrom.val(LECTURE.from);
            lectureTo.val(LECTURE.to);
            lectureDay.val(LECTURE.day);
            lectureDate.val(LECTURE.date);
            lectureTitle.val(LECTURE.title);


            CloseEditMode();
        });

        //When Save button clicked
        $(saveBtn).unbind().bind("click", function(e){
            const tempOldLECTURE = LECTURE;
            AddDataToLectureObject();

            //Check if the from time is bigger than to time
            const from = LECTURE.from.split(":");
            const to = LECTURE.to.split(":");

            if(parseInt(from[0]) > parseInt(to[0]) || (parseInt(from[0]) === parseInt(to[0]) && parseInt(from[1])>parseInt(to[1]))){
                //Set from time to red
                //Remove red after some seconds
                //ToDo :: Add More validation, to validate without close the editing box with red borders
                $(lectureFrom).add(lectureTo).attr("style", "width: 8rem; display: inline-block; border-color:red;");
                setTimeout(function(){
                    $(lectureFrom).add(lectureTo).removeAttr("style").attr("style", "width: 8rem; display: inline-block;");
                }, 4000);

                successEditing.fadeIn(500);
                successEditing.css("display", "inline-block");
                successEditingText.html("<span style='color: red'>&#10060; ERROR: The start time cannot be less than the end time</span>");
                successEditing.fadeOut(8000);

                return false;
            }


            $.ajax({
                type: "POST",
                url: "/Lecture/Update",
                data:{lectureId: LECTURE.id, courseId: courseId, title: LECTURE.title, description: LECTURE.description,
                    preparation: LECTURE.preparation, completed: LECTURE.completed, free: LECTURE.free, from: LECTURE.from, to: LECTURE.to,
                    day: LECTURE.day, lectureDate:LECTURE.date},
                success: function(){
                    successEditing.fadeIn(500);
                    successEditing.css("display", "inline-block");
                    successEditingText.html("<span class='p-1 font-cairo text-0-7 text-success'>&#10003;&nbsp;"+ JSLanguage('dataSavedSuccessfully') +"</span>");
                    successEditing.fadeOut(4000);

                    // const newData = GetNewData(courseId, LECTURE.number);

                    if(LECTURE.completed)
                        $(titleContainer).html("<span>" + LECTURE.title +" </span>" + "<span>&#10003; "+JSLanguage('completedIn')+": "+ LECTURE.date+"</span>");
                    else
                        $(titleContainer).html("<span>" + LECTURE.title +" </span>" +"<span>- "+ JSLanguage('startsOnDay') +": </span> <span>"+LECTURE.day +" - "+ LECTURE.date + " - "+JSLanguage('atClock')+": " + LECTURE.from +"</span>");

                },
                error: function(data){
                    LECTURE = tempOldLECTURE;
                    $(cancelBtn).trigger("click");
                    successEditing.fadeIn(500);
                    successEditing.css("display", "inline-block");
                    successEditingText.html("<span style='color: red'>&#10060; &nbsp;"+JSLanguage('error') + ": " + JSLanguage(data.responseText) +" " + JSLanguage('dataNotSaved') +"</span>");
                    successEditing.fadeOut(8000);
                }
            });


            CloseEditMode();
        });
        
        
        //Delete btn clicked
        $(deleteLectureBtn).unbind().bind('click', function(){
            $(sharedModalTitle).html("<div>"+JSLanguage('deleteLectureNr:')+ lectureNumber+"</div>");
            $(sharedModalContent).html("<div class='text-center text-danger'>"+JSLanguage('allFilesAndVideosRelatedToLectureDeleted')+"</div><div class='text-center text-danger'>"+JSLanguage('youCannotUndo')+"</div>");
            $(sharedModal).modal('show');

            $(sharedModalCancel).unbind().bind('click', function(){$(sharedModal).modal('hide')});
            
            $(sharedModalConfirm).unbind().bind('click', function(){
                $(deleteLectureBtn).attr('disabled', 'disabled');
                $.ajax({
                    type:"post",
                    url: "/Lecture/Delete",
                    data: {lectureNumber:lectureNumber, lectureId:lectureId},
                    success: function(e){
                        successEditing.fadeIn(500);
                        successEditing.css("display", "inline-block");
                        successEditingText.html("<span class='p-1 font-cairo text-0-7 text-success'>&#10003;&nbsp;"+ JSLanguage('dataSavedSuccessfully') +"</span>");
                        $(sharedModal).modal('hide');
                        successEditing.fadeOut(800);
                        window.location.reload();
                    },
                    error: function(e){
                        successEditing.fadeIn(500);
                        successEditing.css("display", "inline-block");
                        successEditingText.html("<span class='text-danger'>&nbsp;"+ JSLanguage('error') +"</span>");
                        successEditing.fadeOut(4000);
                        $(sharedModal).modal('hide');
                    },
                })
            })
            
            
        });
        
        


        //*** Upload file section ***//

        //Select file button selected
        $(selectFileBtn).unbind().bind("click",function(){
            hiddenSelectFile.trigger("click");
            fileName.css("color", "black");
        });

        //A file chosen
        $(hiddenSelectFile).unbind().bind("change", function(e){

            //Check if no file selected
            if(e.target.files.length === 0){
                $(fileName).text(JSLanguage('noFileSelected'));
                $(uploadBtn).attr("disabled", "disabled");
                return;
            }

            //Update the text to be the name of the file
            const file = e.target.files[0];
            $(fileName).text(file.name);
            $(uploadBtn).attr("disabled", false);

            $(uploadBtn).unbind().bind("click", function(){
                UploadFile(file);
            })
        });


        //Open file button clicked
        $(fileBtn).unbind().bind("click", function(){
            const path = $(this).parent().attr("path");
            const name = $(this).parent().attr("fileName").split(".");
            const ext = name[name.length-1];
            const accepted = ["pdf", "png", "jpg"];

            //Check if file type can be opened in browser
            if(accepted.includes(ext)){
                window.open(path, "_blank","newwindow");

                //If not, so download it
            }else{
                const download = $(this).next();
                $(download).trigger("click");
            }


        });

        


        //Delete button clicked
        $(deleteFile).unbind().bind("click", function(){
            const name = $(this).parent().attr("fileName");
            const thisDiv =$(this);
            sharedModalContent.html("<span><strong>"+JSLanguage('deleteFileConfirm')+"</br>"+name+"</strong></span>");
            sharedModalTitle.text(JSLanguage('confirm'));
            $(sharedModalConfirm).text(JSLanguage('yes'));
            $(sharedModalCancel).text(JSLanguage('no'));
            $(sharedModal).modal('show');


            $(sharedModalConfirm).on("click", function(){
                DeleteFile(lectureId, name, thisDiv);
                $(sharedModal).modal('hide');
            });

            $(sharedModalCancel).on("click", function(){
                $(sharedModal).modal('hide');
                return false;
            });

        });

        //Make Homework button clicked
        $(makeHomework).unbind().bind("click", function(){
            const name = $(this).parent().attr("fileName");
            EditFileModal(name);

        });

        /*** Video Section ***///



        //Add video button clicked
        $(addVideoBtn).unbind().bind("click", function(){
            VideoModal();
        });


        /*** End of Video Section ***/


        /*** Set the day as the date automatic***/

        $(lectureDate).mouseleave(function(){
            let weekDay = new Date($(this).val());

            switch (weekDay.getDay()) {
                case 6:
                    $(lectureDay).get(0).selectedIndex = weekDay.getDay()-5;
                    break;
                default: $(lectureDay).get(0).selectedIndex = weekDay.getDay()+2;
            }
        });





        //Functions

        function OpenEditMode(){
            saveBtn.css("display", "inline-block");
            cancelBtn.css("display", "inline-block");

            titleContainer.css("display", "none");
            editTitleContainer.css("display", "block");

            lectureDescription.attr("readonly", false);
            lecturePreparation.attr("readonly", false);

        }

        function CloseEditMode(){
            saveBtn.css("display", "none");
            cancelBtn.css("display", "none");

            titleContainer.css("display", "block");
            editTitleContainer.css("display", "none");

            lectureDescription.attr("readonly", true);
            lecturePreparation.attr("readonly", true);
        }

        function AddDataToLectureObject(){
            LECTURE = {
                // number: parseInt(lectureContainer.attr("id").split(":")[1]),
                id: lectureId,
                title: lectureTitle.val(),
                description: lectureDescription.val(),
                preparation: lecturePreparation.val(),
                completed: lectureCompleted.prop("checked"),
                free: lectureFree.prop("checked"),
                from: lectureFrom.val(),
                to: lectureTo.val(),
                day: lectureDay.val(),
                date: lectureDate.val(),

            };
        }

        

        function UploadFile(file){
            
            $(waitModal).modal('show');
            const formData = new FormData;
            formData.append(file.name, file);

            $.ajax({
                url: "/Lecture/UploadFile?lectureId="+lectureId,
                type: "POST",
                contentType: false,
                processData: false,
                //ToDo :: Check why is not async and remove it
                async: false,
                data: formData,
                success: function(response){
                    setTimeout(function(){$(waitModal).modal('hide');}, 600);
                    fileName.css("color", "green");
                    fileName.text(JSLanguage(response));
                    $(uploadBtn).attr("disabled", "disabled");

                    //Append the new data to the file container
                    AppendNewFile(file.name);

                },
                error: function(error){
                    setTimeout(function(){$(waitModal).modal('hide');}, 600);
                    if(error.status === 400){
                        fileName.text(JSLanguage(error.responseText));
                    }else{
                        fileName.text(JSLanguage('errorRefresh'));
                    }
                    fileName.css("color", "red");
                    $(uploadBtn).attr("disabled", "disabled");

                }
            });
        }

        function AppendNewFile(name){
            $.ajax({
                type: "GET",
                url: "/Lecture/GetFile/",
                data: {lectureId: lectureId, name: name},
                success: function(response){
                    $(noFiles).css("display", "none");
                    $(filesContainer).append(response);
                }
            })
        }

        function DeleteFile(lectureId, name, parentDiv){

            $.ajax({
                type: "DELETE",
                url: "/Lecture/DeleteFile/",
                async: false,
                data: {lectureId: lectureId, name: name},
                success: function (data){
                    $(fileName).css("color", "red");
                    $(fileName).text("File Deleted: "+name);
                    $(parentDiv).parent().remove();

                }
            });
        }


        function VideoModal(){


            
            $.ajax({
                type: "GET",
                url: "/Lecture/GetVideos",
                data: {lectureId: lectureId},
                success: function(response){
                    //Set up the values in the modal
                    sharedModalTitle.text(JSLanguage('videosForLecture')+": "+ lectureNumber);
                    sharedModalContent.html(response);
                    sharedModalConfirm.text(JSLanguage('save'));
                    sharedModalCancel.text(JSLanguage('cancel'));

                    let removeVideo = $(".video-remove");
                    
                    //If a new video will be added
                    $("#new-video-btn").unbind().bind("click", function (){
                        const addVideoContainer = $(".add-video-container");
                        const videosCount = addVideoContainer.find("span").length+1;
                        addVideoContainer.append(
                            '<div class="add-video-inputs" style="display: block;">\n' +
                            '            <span>'+ videosCount+'- </span>\n' +
                            '            <input class="video-name form-control" placeholder="'+JSLanguage('newVideoName')+'" id="video-name-'+videosCount+'"/>\n' +
                            '            <input class="video-path form-control" placeholder="'+JSLanguage('newVideoLink')+'" id="video-path-'+videosCount+'"/>\n' +
                            '            <div class="video-remove">&#10060;</div>\n'+
                            '        </div>'
                        );
                        removeVideo = $(".video-remove");
                        $(removeVideo).unbind().bind("click", function(){
                            $(this).parent().find("input").each(function(index, element){$(element).val("");});
                        });
                    });

                    

                    //If remove video button clicked
                    $(removeVideo).unbind().bind("click", function(){
                        $(this).parent().find("input").each(function (index, element) {
                            $(element).val("");
                            $(this).parent().find(".video-name").attr("placeholder", JSLanguage('newVideoName'));
                            $(this).parent().find(".video-path").attr("placeholder", JSLanguage('newVideoLink'));
                        });
                    });

                    //If cancel button clicked
                    sharedModalCancel.click(function(){$("#shared-modal").modal("hide");});

                    //If save button clicked
                    sharedModalConfirm.unbind().bind("click", function(){
                        const addVideoContainer = $(".add-video-container");
                        const newVideos = addVideoContainer.find(".add-video-inputs");
                        let weCanEditVideos = true;

                        const readyVideos =[];

                        newVideos.each(function(index, element){
                            const videoName = $(element).find(".video-name");
                            let videoPath = $(element).find(".video-path");

                            if(videoName.val() ==="" && videoPath.val() ==="")
                                return;

                            if(videoName.val().length<5){
                                videoName.attr("style", "border: 2px solid red");
                                setTimeout(function(){videoName.removeAttr("style")}, 1000);
                                weCanEditVideos = false;
                                return false;
                            }
                            if(videoPath.val().length < 10){
                                videoPath.attr("style", "border: 2px solid red");
                                setTimeout(function(){videoPath.removeAttr("style")}, 1000);
                                weCanEditVideos = false;
                                return false;
                            }

                            // ToDo :: This should be empty if one up there not valid
                            readyVideos.push($(element));



                        });

                        //Check if there are some changes                    
                        if(readyVideos.length !==0 && weCanEditVideos){
                            const readyVideosToSend=[];

                            for(let i=0; i<readyVideos.length; i++){
                                
                                //ToDo :: Edit this, send to check vimeo only if path is vimeo, the same for youtube
                                let tempPath = CheckVimeo(readyVideos[i].find(".video-path").val());
                                tempPath = CheckYoutube(tempPath);
                                const tempObject={
                                    Url: tempPath,
                                    Name: $(readyVideos[i]).find(".video-name").val(),
                                    VideoNumber:i+1,
                                    lectureId: lectureId,
                                    LectureCourseId: courseId,
                                };
                                readyVideosToSend.push(tempObject);

                            }


                            $.post('/Lecture/AddVideos/', { videos: readyVideosToSend },
                                function (data) {
                                    videosContainer.html(data);
                                });
                            $(sharedModal).modal("hide");

                        }
                        else if(readyVideos.length === 0 && weCanEditVideos){
                            $.post('/Lecture/RemoveVideos/', {lectureId: lectureId },
                                function (data) {
                                    videosContainer.html(data);
                                });
                            $(sharedModal).modal("hide");
                        }
                    });

                    

                    $(sharedModal).modal("show");

                },
                
            });
            // $(sharedModal).modal("show");
        }


        function EditFileModal(name){

            $.ajax({
                type: "GET",
                url:"/Lecture/EditFile",
                data: {lectureId: lectureId, name: name},
                success: function(response){
                    
                    

                    //Set the title and content
                    sharedModalTitle.text(JSLanguage('homeworkForLecture')+": "+ lectureNumber);
                    $(sharedModalContent).html(response);
                    $("#edit-file-modal-title").text(JSLanguage('makeTheFileHomework'));
                    $("#is-homework").text(JSLanguage('isHomework'));
                    $("#notification").text(JSLanguage('sendNotification'));
                    $("#deadline").text(JSLanguage('deadline'));

                    //Define variables for the file current values
                    const isHomework = $(".is-homework");
                    const deadLine = $(".homework-deadline");
                    const homeworkContainer = $(".is-homework-container");
                    const notification = $(".notification");

                    //If file is homework by default, enable to change the date
                    if(isHomework.prop("checked")){
                        deadLine.attr("disabled", false);
                        homeworkContainer.attr("display", "none");
                    }else{
                        deadLine.attr("disabled", "disabled");
                        homeworkContainer.attr("display", "block");
                        
                    }

                    //Set the modal buttons
                    sharedModalConfirm.text(JSLanguage('save'));
                    sharedModalCancel.text(JSLanguage('cancel'));


                    //Listen to the isHomework checkbox, enable disable date
                    isHomework.unbind().bind("click", function(){
                        if($(isHomework).prop("checked")){
                            deadLine.attr("disabled", false);
                            $(homeworkContainer).fadeIn(500);
                        }else{
                            deadLine.attr("disabled", "disabled");
                            $(homeworkContainer).fadeOut(500);
                        }
                    });

                    //Cancel clicked
                    sharedModalCancel.unbind().bind("click", function(){
                        $(sharedModal).modal("hide");
                    });

                    //Confirm clicked
                    sharedModalConfirm.unbind().bind("click", function(){
                        $(waitModal).modal('show');
                        if(isHomework.prop("checked") && deadLine.val() ===""){

                            deadLine.attr("style", "border: 2px red solid");
                            setTimeout(function(){deadLine.removeAttr("style")}, 3000);
                        }else{
                            $.ajax({
                                type:"PUT",
                                url:"/Lecture/EditFile",
                                data:{lectureId:lectureId, name: name, isHomework: isHomework.prop("checked"), deadLine: deadLine.val(), notification: notification.prop("checked")},
                                success: function(){
                                    setTimeout(function(){$(waitModal).modal('hide')}, 600);
                                    $(sharedModal).modal("hide");
                                    setTimeout(function(){RevokeNotifications("Email"); }, 2000);
                                    $(fileName).css("color", "green");
                                    $(fileName).text("File Updated");

                                },
                                error: function(){
                                    setTimeout(function(){$(waitModal).modal('hide')}, 600);
                                }
                            })
                        }

                    });


                },
                error: function(error){
                    setTimeout(function(){$(waitModal).modal('hide')}, 600);
                    alert("error");
                }

            });




            $(sharedModal).modal("show");
        }

    });
    
    //Add New Lecture
    const addLecture = $("#add-lecture");
    const addIntroLecture = $("#add-intro-lecture");
    let intro = false;
    
    $(addLecture).add($(addIntroLecture)).unbind().bind("click", function(){
        if($(this).attr('id') === 'add-intro-lecture'){
            intro = true;
        }
        $(this).attr("disabled", true);
        $.ajax({
            type: "POST",
            url: "/Lecture/AddNewLecture",
            data: {courseId: courseId, intro: intro},
            success: function(){location.reload()},
            error: function(){alert("error")}
        });
    });
    
    
    
    //*** END OF LECTURE ACTION ***//
    
    
    
    
    
    
    
    
    
    //*** COURSE RATING ***//
    const sendFeedbackBtn = $("#send-feedback");
    const feedbackContainer = $("#feedback-container");
    const feedbackText = $("#feedback-input");
    
    
    let feedbackDeleteBtn = $(".feedback-delete");

    $(feedbackText).keypress(function(event){
        if(event.keyCode === 13)
            sendFeedbackBtn.trigger("click");
    });


    $(feedbackDeleteBtn).unbind().bind("click", function(){
        const thisElement = $(this);
        DeleteFeedback(thisElement);
    });

    $(sendFeedbackBtn).unbind().bind("click", function(e){
        if(feedbackText.val()===""){
            feedbackText.attr("style", "border: 1px red solid");
            setTimeout(function(){feedbackText.removeAttr("style")}, 1500);
            e.stopPropagation();
            return false;
        }
        $.ajax({
            type: "POST",
            url: "/Course/AddFeedback",
            data:{courseId: courseId, text: feedbackText.val()},
            success: function(response){
                const htmlData = '<div direction-paragraph feedback-text>' + response +'</div>';
                feedbackContainer.prepend(htmlData);
                adjustParagraphDirection();
                feedbackText.val("");
                $("#no-comment-yet").remove();
                feedbackDeleteBtn = $(".feedback-delete");
                $(feedbackDeleteBtn).click(function(){
                    const thisElement = $(this);
                    DeleteFeedback(thisElement);
                });
            },
            error: function(){
                // console.log(feedbackText);
            }
        })
    });

    adjustParagraphDirection();
    
    function adjustParagraphDirection(){
        const dirParagraph = $('.direction-paragraph');
        $(dirParagraph).each(function(i,e){
            const fullText = $(e).text();
            const allowedChar = ['0','1','2','3','4','5','6','7','8','9','-','!','~','@','#','$','%','^','&','*','(',')','_','+','=','?','؟',',','،', ' '];

            for(let i = 0; i< fullText.length; i++){
                if(!allowedChar.includes(fullText[i])){
                    if(/^[a-zA-Z]+$/.test(fullText[i])){
                        break;
                    }else{
                        $(e).addClass('text-right').css('direction', 'rtl');
                        break;
                    }
                }
            }
        });
    }
    

    function DeleteFeedback(element){
        const feedback = $(element).parent().parent().parent();
        const feedbackId = $(element).attr("feedback-id");
        const feedbackText = $(feedback).find('.feedback-text').text();
        
        $(sharedModalTitle).text(JSLanguage('confirm'));
        $(sharedModalContent).html('<div style="margin:1rem;">'+JSLanguage('confirmDeleteComment')+'</div><div style="margin:1rem;">'+feedbackText+'</div>');
        $(sharedModal).modal('show');
        
        $(sharedModalCancel).click(function(){
            $(sharedModal).modal('hide');
        });

        $(sharedModalConfirm).unbind().bind('click', function () {
            $.ajax({
                type: "POST",
                url: "/Course/DeleteFeedBack",
                data: {courseId: courseId, feedbackId : feedbackId},
                success: function(){
                    $(feedback).remove();
                    const feedBackContainer = $("#feedback-container");
                    if($(feedBackContainer).find(".feedback-div").length === 0){
                        $(feedBackContainer).append("<div class=\"text-center direction\" id=\"no-comment-yet\"style=\"margin: 1rem;\">"+JSLanguage('noCommentsYet')+"</div> ");
                    }
                    $(sharedModal).modal('hide');

                }
            });            
        });
        
    } 
    
    
    //*** END OF COURSE RATING ***//
    
    
    
    
    
    //*** HOMEWORK ***//

    //Variables
    const OpenDeliverModal = $(".open-deliver-modal");
    OpenDeliverModal.each(function(i,e){
        if($(this).children().hasClass('deadline-passed')){
            $(this).attr('disabled', true);
        }
    });
    
    
    $(OpenDeliverModal).unbind().bind("click",function(){

        const relatedHomeworkFileName = $(this).attr("related-homework-file");
        const isOldDeliveryExist = $(this).attr("old-delivery") === "False";
        const lectureId = $(this).attr("lecture-id");
        
        
        sharedModal.modal('show');



        //Modify modal buttons and title
        sharedModalConfirm.text(JSLanguage('upload')).attr("disabled", "disabled");
        sharedModalCancel.text(JSLanguage('cancel'));
        $(sharedModalTitle).text(JSLanguage("deliveryForHomework")+": "+ relatedHomeworkFileName);

        //Create the elements inside the modal
        let changeFileWarningElement = "";
        if(isOldDeliveryExist){
            changeFileWarningElement = '<div style="padding: 1rem; margin: 1rem;">'+JSLanguage('ifTeacherStartedToCorrect')+'</div>';
        }else{
            changeFileWarningElement = '<div class="mt-2 mb-4">'+JSLanguage('youCanChangeFile')+'</div>';
        }
        const hiddenInputElement = '<input hidden="hidden" class="hidden-homework-file" type="file"/>';
        const choseFileElement = '<button class="m-button m-button-primary choose-homework-file" >'+JSLanguage('chooseFile')+'</button>';
        const fileNameElement = '<br/><br/><div class="homework-file-name"></div>';

        //Append the elements to the modal
        sharedModalContent.html(changeFileWarningElement + hiddenInputElement + choseFileElement + fileNameElement);


        //Get the self elements
        const hiddenInput = $(".hidden-homework-file");
        const choseFileBtn = $(".choose-homework-file");
        const fileName = $(".homework-file-name");
        

        //Trigger the hidden input on choose file click
        $(choseFileBtn).click(function(){
            $(hiddenInput).trigger("click");
        });

        //Input change, show the file name on file chosen
        $(hiddenInput).unbind().bind("change", function(e){
            let homeworkDeliveryFile = e.target.files[0];

            //If no file chosen, else do the uploads if saved
            if(e.target.files.length === 0){
                fileName.text("");
                sharedModalConfirm.attr("disabled", "disabled");
            }else{
                homeworkDeliveryFile = e.target.files[0];
                fileName.text(homeworkDeliveryFile.name);
                sharedModalConfirm.removeAttr("disabled");

                //Save button clicked
                $(sharedModalConfirm).unbind().bind("click", function () {
                    
                    $(waitModal).modal('show');
                    
                    if(homeworkDeliveryFile.size > 25 * 1024* 1024){
                        $(fileName.text(JSLanguage('largeFileMax25')));
                        return false;
                    };
                    const formData = new FormData;
                    formData.append(homeworkDeliveryFile.name, homeworkDeliveryFile);


                    $.ajax({
                        type: "POST",
                        url: "/Lecture/AddHomework?courseId="+courseId+"&lectureId=" + lectureId + "&homeworkFileName=" + relatedHomeworkFileName + "&studentId=" + studentId,
                        data: formData,
                        contentType: false,
                        processData: false,
                        success: function () {
                            setTimeout(function(){$(waitModal).modal('hide');}, 600);
                            
                            sharedModal.modal("hide");
                            window.location.reload();
                        },
                        error: function (response) {
                            setTimeout(function(){$(waitModal).modal('hide');}, 600);
                            $(fileName).text(JSLanguage(response.responseText));
                            // console.log(response)

                        }
                    });



                });

            }


        });

        //Cancel button clicked
        $(sharedModalCancel).unbind().bind("click", function () {

            $(sharedModal).modal("hide");

        });

    });


    //Calculate and assign average
    const marks = $(".homework-mark");
    const average = $(".marks-average");
    const addComment = $(".homework-add-comment");
    const homeworkComment = $(".homework-comment");

    let markList=[];
    let averageValue = 0;

    marks.each(function(index, element){
        const aMark = parseInt($(element).text());
        if( aMark>= 1 && aMark<=6)
            markList.push(aMark);
    });
    for (let i = 0; i < markList.length; i++){
        averageValue += markList[i];
    }
    if (markList.length !==0){
        averageValue = averageValue/markList.length;
        average.text(averageValue);
    }else{
        average.text(0);
    }
    
    //*** END OF HOMEWORK ***//
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //*** HOMEWORK DELIVERY ***//

    $(marks).unbind().bind("change", function(){
        const currentMark = $(this);
        const parent = $(this).parent().parent();
        const lectureId = parent.attr("lecture-id");
        const relatedHomeworkName = parent.attr("related-homework-name");
        const mark = parseInt($(this).val());
        const studentId = parent.attr("student-id");

        // console.log(lectureNumber +" "+ relatedHomeworkName + " " + mark + " " +courseId + " " + studentId);


        $.ajax({
            type:"PUT",
            url:"/Lecture/AddMark",
            data: {lectureId: lectureId, relatedHomeworkFileName: relatedHomeworkName, studentId: studentId, mark: mark},
            success: function(){
                $(currentMark).css('border', '2px solid green');
                setTimeout(function(){$(currentMark).css('border', '')}, 1500);
                setTimeout(function(){RevokeNotifications("Email");}, 2000);
            },
            error: function(){
                $(currentMark).css('border', '2px solid red');
                setTimeout(function(){$(currentMark).css('border', '')}, 1500);
            }
        })
    });
    
    
    // ** COMMENT **//
    //Add
    $(addComment).unbind().bind('click', function(){
        
        const commentText = $(this).find('.homework-comment-text');
        const oldCommentText = $(commentText).val();

        const parent = $(this).parent();
        const lectureId = parent.attr("lecture-id");
        const relatedHomeworkName = parent.attr("related-homework-name");
        const studentId = parent.attr("student-id");
        
        $(sharedModalTitle).text(JSLanguage('notes'))
        $(sharedModalContent).html("<textarea id='new-comment-text' style='resize: none; height: 50%' rows='12' class='w-75 p-2 m-2'>"+oldCommentText+"</textarea>");
        $(sharedModalConfirm).text(JSLanguage('save'));
        $(sharedModalCancel).text(JSLanguage('cancel'));
        $(sharedModal).modal('show');
        
        
        
        $(sharedModalConfirm).unbind().bind('click', function(){

            const newCommentText = $("#new-comment-text").val();
            $(commentText).val(newCommentText);
            
            $.ajax({
                type:"PUT",
                url:"/Lecture/AddHomeworkComment",
                data: {lectureId: lectureId, relatedHomeworkFileName: relatedHomeworkName, studentId: studentId, comment: newCommentText},
            });
            
            $(sharedModal).modal('hide');
        });
        
        $(sharedModalCancel).unbind().bind('click', function(){
            $(sharedModal).modal('hide');
        })
        
    });
    
    
    //Show
    
    $(homeworkComment).unbind().bind('click', function(){
        const commentText = $(this).find('.homework-comment-text').val();
        
        if(commentText === '' || commentText === null || commentText === undefined)
            return false;
        

        $(sharedModalTitle).text(JSLanguage('notes'));
        $(sharedModalContent).html("<div class='text-center m-2 p-2'>"+commentText+"</div>");
        $(sharedModalConfirm).hide();
        $(sharedModalCancel).text(JSLanguage('close'));
        
        $(sharedModal).modal('show');
        
        $(sharedModal).on('hidden.bs.modal', function(){
            $(sharedModalConfirm).show();
        });
        
        $(sharedModalCancel).unbind().bind('click', function () {
            $(sharedModal).modal('hide');
        })
        
    });
    
    
    
    //*** END OF HOMEWORK DELIVERY ***//


    
    
    
    //*** VIDEO HANDLER ***//

    //Set height and positions
    const listContainer = $("#playlist-container");
    const courseDivContainer = $("#course-videos-container");
    
    // const clientHeight = window.innerHeight - $(courseDivContainer).offset().top - $("footer").height() - 100;
    
    //ToDo :: I had to comment this down and replace with 150 after the footer added
    // const clientHeight = window.innerHeight - $("footer").height() - 100;
    const clientHeight = window.innerHeight - 150;
    $(courseDivContainer).css('height', clientHeight + 'px');
    
    // $(listContainer).height(function() {
    //     return window.innerHeight - $(this).offset().top - parseInt( $(this).css("margin-bottom"));
    // });
    $(listContainer).height(courseDivContainer.height());
    
    $("#main-video-container").height(courseDivContainer.height());

    //Variables
    const videoInList = $(".video-in-list");
    const mainFrame = $("#main-video-container");
    const frame = $("#main-video-frame");
    const videoTitle = $("#video-mask");
    const openCloseVideoList = $(".open-close-video-list");
    // $(videoTitle).css('top', $(tabNav).positionY);
    // $(openCloseVideoList).css('top', $(videoTitle).positionY + $(videoTitle).css('top'));


    
    //Check if there is no video href in the url
    if (window.location.href.split("#").length ===2){
        
        //Check if the list not empty
        if(videoInList.length !== 0){

            //If list not empty, make the first video ready to play
            const defaultHref = $(videoInList[0]).attr("id");
            window.location.href+="#"+defaultHref;
            $(videoInList[0]).addClass("active-video");
            SetVideoToMainFrame(defaultHref);
        }else{

            //If the list empty stop everything
            videoTitle.text(JSLanguage('noVideoInCourse'));
            return false;
        }
    }else{
        
        
        const currentHref = window.location.href.split("#")[2];
        // const currentVideoId =  $(`#${currentHref}`);
        const currentVideoId =  $(".video-in-list#"+currentHref);
        currentVideoId.addClass("active-video");
        SetVideoToMainFrame(currentHref);
        $(listContainer).animate({
            // scrollTop: currentVideoId.offset().top - $(currentVideoId).height()
            scrollTop: currentVideoId.height()*5*-1*getScrollElementIndex($(currentVideoId)) + 'px'
        }, 1500);
    }
    
    function getScrollElementIndex(elm){
        const videos = $(".video-in-list");
        return $(videos).index(elm)
    }

    //One video clicked    
    videoInList.click(function(){
        //Add the class active-video
        videoInList.removeClass("active-video");
        $(this).addClass("active-video");

        //Set the new href
        const currentUrl = window.location.href.split("#");
        const clickedHref = $(this).attr("id");
        window.location.href = currentUrl[0] + "#"+ currentUrl[1] +"#"+clickedHref;
        SetVideoToMainFrame(clickedHref);

    });

    function SetVideoToMainFrame(id){
        $.ajax({
            type:"GET",
            url: "/Lecture/GetUrl",
            async: false,
            data: {videoId: id},
            // encrypt: Response,
            success: function(response){
                $(frame).attr("src", response.url);
                const lectureTitle = response.name === 'intro' ? JSLanguage('intro') : JSLanguage('lectureNoNumber')+": "+response.lectureNumber + " - " + response.name;
                // videoTitle.text(JSLanguage('lectureNoNumber')+": "+ response.lectureNumber + " - " + response.name);
                videoTitle.html("<span class='small un-select'>"+ lectureTitle+"</span>");
                videoTitle.append("<span id='video-problem' class='pointer code-color un-select' style='margin: auto 1rem; font-size: 0.6rem;'>| ("+JSLanguage('videoProblem')+")</span>");
                $("#video-problem").unbind().bind('click', function () {
                    VideoProblem();
                })
            },
            error: function(response){
                // console.log(response);
            }

        });

    }
    
    
    
    //Open close Video list
    $(openCloseVideoList).unbind().bind('click', function(){
        
        $(listContainer).toggle();
        $(".open-close-video-list").each(function(i,e){$(e).toggle()})
        
        $(mainFrame).removeClass('col-10').addClass('col-12');
        
    });




    //*** END OF VIDEO HANDLER ***//









    
    
    
    
    





});