"use strict";

define(['knockout', 'koValidation', 'surveyModel'],
    function (ko, koValidation, surveyModel) {

    return function init() {

        ko.validation.init({
            registerExtenders: true,
            messagesOnModified: true,
            insertMessages: false,
            parseInputAttributes: true,
            messageTemplate: null,
            decorateElement: true,
            errorElementClass: 'has-error',
            errorMessageClass: 'alert alert-danger'
        }, true);

        ko.applyBindings(new surveyModel());
    }
});