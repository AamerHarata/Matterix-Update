$(document).ready(function() {
    $(function() {
        $('.clockpicker').clockpicker({
            'default': 'now',
            vibrate: true,
            placement: "bottom",
            align: "left",
            autoclose: true,
            twelvehour: false
        });
        $('.clockpicker2').clockpicker({
            'default': 'now',
            vibrate: true,
            placement: "top",
            align: "left",
            autoclose: true,
            twelvehour: false
        });

    });


});