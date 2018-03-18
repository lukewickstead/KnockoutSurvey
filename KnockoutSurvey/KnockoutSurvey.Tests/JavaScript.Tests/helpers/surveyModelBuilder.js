"use strict";

define(["surveyModel"], function (surveyModel) {

    function defaultValid() {
        var model = new surveyModel();
        model.title('Mr');
        model.name('Luke');
        model.dateOfBirth('25/10/1978');
        model.location('This house, Bristol');
        model.now(new Date());
        model.feedBack('This is some feedback which is longer than 25 chars');

        return model;
    }

    return {defaultValid: defaultValid}
});