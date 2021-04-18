$(document).ready(function(){







    //Coloring the different devices
    const colors = ["lightblue", "darkseagreen", "antiquewhite",  "lightpink", "darkcyan","coral", "olive", "darkcyan",   "navajowhite", "palevioletred", "peru"];

    const allDevices = $(".activity-device");


    while (colors.length < allDevices.length)
        colors.push("rgba(" + parseInt(Math.random() * 255).toString() + "," + parseInt(Math.random() * 255).toString() + "," + parseInt(Math.random() * 255).toString() + ",0.5)");


    for(let i =0; i<allDevices.length; i++ ){

        const groupNumber = $(allDevices[i]).attr("group-number");
        
        $(allDevices[i]).add(($(allDevices[i])).parent().find(".activity-number")).css("background-color", colors[groupNumber]);
    }
    
    
    
    
    
    
});