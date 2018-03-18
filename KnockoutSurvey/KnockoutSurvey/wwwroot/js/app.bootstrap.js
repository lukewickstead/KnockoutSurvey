"use strict";
requirejs.config({
    paths: {
        // libs
        'jquery': '../lib/jquery/dist/jquery.min',
        'knockout': '../lib/knockout/dist/knockout',
        'koValidation': '../lib/knockout-validation/dist/knockout.validation',
        'moment': '../lib/moment/moment',

        // window exposure
        'setInterval': 'window.setInterval',
        'console': 'window.console',

        // apps
        'bootstrap.ko': 'app.bootstrap.ko',
        'surveyModel': 'models.surveyModel'
    }
});

require(['bootstrap.ko', 'console'],
    function (bootstrapKo, console) {

        console.log("Bottstrapping: KO");
        bootstrapKo();
    });