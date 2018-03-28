"use strict";

define(['knockout', 'koValidation', 'surveyModel', 'setInterval', 'geolocation', 'toastr'],
    function (ko, koValidation, surveyModel, setInterval, geolocation, toastr) {

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

            geolocation.getCurrentPosition(
                function (position) {
                    $.getJSON("Location/Get?latitude=" + position.coords.latitude + "&longitude=" + position.coords.longitude)
                        .fail(function (d, textStatus, error) {
                            model.location(position.coords.latitude + ',' + position.coords.longitude);
                        }).done(function (response) {
                            model.location(response.result);
                    });
                }, function (error) {
                    switch (error.code) {
                        case error.PERMISSION_DENIED:
                            toastr.error("User denied the request for Geolocation.");
                            break;
                        case error.POSITION_UNAVAILABLE:
                            toastr.error("Location information is unavailable.");
                            break;
                        case error.TIMEOUT:
                            toastr.error("The request to get user location timed out.");
                            break;
                        case error.UNKNOWN_ERROR:
                            toastr.error("An unknown error occurred.");
                            break;
                    }
                }, {
                    enableHighAccuracy: true,
                    timeout: 5000,
                    maximumAge: 0
                });
        }
    });