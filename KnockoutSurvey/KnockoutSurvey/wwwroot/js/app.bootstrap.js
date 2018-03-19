//"use strict";
requirejs.config({
    paths: {
        // libs
        'jquery': '../lib/jquery/dist/jquery.min',
        'jquery-ui': '../lib/jquery-ui/jquery-ui.min',
        'knockout': '../lib/knockout/dist/knockout',
        'koValidation': '../lib/knockout-validation/dist/knockout.validation',
        'moment': '../lib/moment/moment',
        'toastr': '../lib/toastr/toastr',
       
        // window exposure
        'setInterval': 'window.setInterval',
        'console': 'window.console',

        // apps
        'bootstrap.ko': 'app.bootstrap.ko',
        'surveyModel': 'models.surveyModel'
    }
});

require(['bootstrap.ko', 'console', 'toastr', 'jquery', 'jquery-ui'],
    function (bootstrapKo, console, toastr, $, jqueryUi) {

        console.log("Bottstrapping: KO");
        bootstrapKo();
        
        // TODO: refactor

        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        var now = new Date();
        var minDate = new Date(now.getFullYear() - 125, now.getMonth(), now.getDay());       
        
        $('#dateOfBirth').datepicker({
            changeMonth: true,
            changeYear: true,
            dateFormat: 'dd/mm/yy',
            minDate:  minDate
        });
    });