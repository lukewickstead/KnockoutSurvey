requirejs.config({
    paths: {
        // src.app
        'surveyModel': '../../KnockoutSurvey/wwwroot/js/models.surveyModel',

        // src.libs
        'jquery': '../../KnockoutSurvey/wwwroot/lib/jquery/dist/jquery',
        'knockout': '../../KnockoutSurvey/wwwroot/lib/knockout/dist/knockout',
        'koValidation': '../../KnockoutSurvey/wwwroot/lib/knockout-validation/dist/knockout.validation',
        'moment': '../../KnockoutSurvey/wwwroot/lib/moment/moment',
        'toastr': '../../KnockoutSurvey/wwwroot/lib/toastr/toastr',

        
        // tests.jasmine
        'jasmine': 'lib/jasmine-2.4.1/jasmine',
        'jasmine-html': 'lib/jasmine-2.4.1/jasmine-html',
        'jasmine-boot': 'lib/jasmine-2.4.1/boot',
        
        // tests.specs
        'models.surveyModel.specs': 'specs/models.surveyModel.specs',

        // tests.helpers
        'surveyModelBuilder': 'helpers/surveyModelBuilder',
        'stringBuilder': 'helpers/stringBuilder'
    },

    shim: {
        'jasmine-html': {
            deps : ['jasmine']
        },
        'jasmine-boot': {
            deps : ['jasmine', 'jasmine-html']
        }
    }
});

require(['jasmine-boot'], function () {
    require(['models.surveyModel.specs'], function(){
        //triggers Jasmine
        window.onload();
    })
});