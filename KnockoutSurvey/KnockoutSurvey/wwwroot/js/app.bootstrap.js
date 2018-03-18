"use strict";
requirejs.config({
    paths: {        
        // libs
        'jquery': '../lib/jquery/dist/jquery.min',
        'knockout': '../lib/knockout/dist/knockout',
        'koValidation': "../lib/knockout-validation/dist/knockout.validation",
        'moment': "../lib/moment/moment",
       
        // apps
        'bootstrap.ko': 'app.bootstrap.ko',
        'surveyModel': 'models.surveyModel'
    }
});

require(['bootstrap.ko' ],
    function (bootstrapKo) {
        bootstrapKo();
    });