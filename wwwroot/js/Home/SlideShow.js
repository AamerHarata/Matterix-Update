$(document).ready(function () {


    let order = 1;
    let slideElements = $(".slide-element");


    setInterval(changeElement, 2500);

    function changeElement(){
        const current = order;
        const next = current === 13? 1 : current+1;

        $(`.slide-element[order='${current}']`).fadeToggle(0).removeAttr('in');
        $(`.slide-element[order='${next}']`).fadeIn(700).attr('in', 'true');

        order++;
        if(order > 13){
            order = 1
        }
    }


});