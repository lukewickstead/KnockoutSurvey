"use strict";

define(['knockout', 'koValidation', 'surveyModel', 'setInterval', 'geolocation'],
    function (ko, koValidation, surveyModel, setInterval, geolocation) {

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
        
        geolocation.getCurrentPosition(function getLocationFromLatLong(position) {
            var url = "Location/Get?latitude=" + position.coords.latitude + "&longitude=" + position.coords.longitude;
            
            $.getJSON("Location/Get?latitude=" + position.coords.latitude + "&longitude=" + position.coords.longitude )
                .fail(function (d, textStatus, error) {                   
                    model.location(position.coords.latitude + ',' + position.coords.longitude);
                }).done(function (response) {
                    model.location(response.result);
            });            
        });        
    }
});