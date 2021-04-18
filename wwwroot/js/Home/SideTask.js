$(document).ready(function(){

    //Hide other tasks when one is opened
    const taskContainer = $('#tasks-container');
    taskContainer.on('show.bs.collapse','.collapse', function() {
        if($(this).hasClass('modal-collapse'))
            return false;
        taskContainer.find('.collapse.show').collapse('hide');
    });
    
    
    //ToDo :: Get all lectures, if any live? append the circle and open the div (lecture will have priority)
    
    // OPEN DIV ACCORDING TO PRIORITY //
    let timeout = 1;
    
    //Tasks
    const liveLectures = $(".join-lecture-btn[isLive='True']");
    const invoices = $(".invoice-btn[dueOrLate='True']");
    const tasks = $(".task-card[todo]");
    const importantTask = $(".task-card[important-todo]");
    const otherLectures = $(".join-lecture-btn[isLive='False']");
    
    //Priority #1
    //If any lecture is live -> append the circle 
    const anyLive = liveLectures.length > 0;
    if(anyLive)
        $("#live-circle").html("<i style=\"color: red; margin: 0 4px;\" class=\"fa fa-dot-circle-o\"></i>").click();


    //Priority #2 //ToDo :: To be implemented later
    const anyImportantTask = importantTask.length > 0;
    if(anyImportantTask && !anyLive)
        setTimeout(function(){$("#todo-tasks-title").trigger('click');}, timeout);
    
    
    //Priority #3
    const anyInvoice = invoices.length > 0;
    if(anyInvoice && !anyLive && !anyImportantTask)
        setTimeout(function(){$("#upcoming-invoices-title").trigger('click');}, timeout);

    //Priority #5 //ToDo :: Edit this to be 5 (could be 6 after adding new features)
    const anyOtherLectures = otherLectures.length > 0;
    if(anyOtherLectures && !anyLive && !anyImportantTask && !anyInvoice){
        setTimeout(function(){$("#upcoming-lectures-title").trigger('click');}, timeout);
    }
    
    //Priority #4
    const anyTask = tasks.length > 0;
    if(anyTask && !anyOtherLectures && !anyLive && !anyImportantTask && !anyInvoice)
        setTimeout(function(){$("#todo-tasks-title").trigger('click');}, timeout);
    
    //Priority #6
    if(!anyTask && !anyOtherLectures && !anyLive && !anyImportantTask && !anyInvoice){
        setTimeout(function(){$("#short-videos-title").trigger('click');}, timeout);
    }

        
    
    
    
    
    // END OF OPEN DIV ACCORDING TO PRIORITY //
    
    
    
});