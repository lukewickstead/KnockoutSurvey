"use strict";

define(['knockout', 'koValidation', 'surveyModel', 'setInterval'],
    function (ko, koValidation, surveyModel, setInterval) {

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

        var model = new surveyModel();
        ko.applyBindings(model);

        setInterval(function () {
            model.now(new Date());
        }, 1000);
        
        // Debug
        model.title("Mr");
        model.name("Luke");
        model.dateOfBirth("1978-10-25");
        model.location("Right here, right now!");
        model.feedBack("Comments comment comment comment comment comment comment comment comment comment");

    }
});