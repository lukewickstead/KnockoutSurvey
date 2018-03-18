"use strict";
requirejs.config({
    paths: {
        // libs
        'jquery': '../lib/jquery/dist/jquery.min',
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

require(['bootstrap.ko', 'console', 'toastr'],
    function (bootstrapKo, console, toastr) {

        console.log("Bottstrapping: KO");
        bootstrapKo();

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
        
        
        
    });