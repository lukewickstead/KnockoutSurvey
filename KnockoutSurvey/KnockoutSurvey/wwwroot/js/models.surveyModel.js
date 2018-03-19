"use strict";
define(['knockout', 'moment', 'jquery', 'toastr', 'koValidation'],
    function (ko, moment, $, toastr) {
        return function surveyModel() {

            var self = this;

            // TITLE    
            self.availableTitles = ko.observableArray(['Miss', 'Mr', 'Mrs', 'Other']);
            self.title = ko.observable().extend({
                required: {message: 'Please select your title'}
            });

            // NAME
            self.name = ko.observable('').extend({
                required: {message: 'Please enter your name.'},
                minLength: {params: 3, message: 'Your name must be more than 3 characters'},
                maxLength: {params: 50, message: 'Your name must not be more than 50 characters'}

            });

            // DATE OF BIRTH
            self.dateOfBirth = ko.observable().extend({
                required: {message: 'Please enter your date of birth'}
            });

            // LOCATION
            self.location = ko.observable().extend({
                required: {message: 'Please enter your location'},
                minLength: {params: 3, message: 'Your location must be more than 3 characters'},
                maxLength: {params: 100, message: 'Your location must not be more than 100 characters'}
            });

            // NOW
            self.now = ko.observable(new Date()).extend({
                required: {message: 'Please enter your current date time'}
            });

            self.nowDisplay = function () {
                return moment(self.now()).format('MMMM Do YYYY, h:mm:ss a');
            };

            // FEED BACK
            self.feedBack = ko.observable().extend({
                required: {message: 'Please enter some feedback'},
                minLength: {params: 25, message: 'Your feed back must be more than 25 characters'},
                maxLength: {params: 500, message: 'Your feed back must not be more than 500 characters'}
            });

            // PAGE
            self.page = ko.observable(1);

            self.gotoPageOne = function () {
                self.page(1);
            };

            self.gotoPageTwo = function () {
                self.page(2);
            };

            // VALIDATION

            self.titleBlurEvent = function () {
                ko.validation.group([self.title]).showAllMessages()
            };

            self.nameBlurEvent = function () {
                ko.validation.group([self.name]).showAllMessages()
            };

            self.dateOfBirthBlurEvent = function () {
                ko.validation.group([self.dateOfBirth]).showAllMessages()
            };

            self.feedbackBlurEvent = function () {
                ko.validation.group([self.feedBack]).showAllMessages()
            };

            self.pageOneErrors = ko.validation.group([self.title, self.name, self.dateOfBirth]);
            self.pageTwoErrors = ko.validation.group([self.location, self.now, self.feedBack]);
            
            self.isPageOneValid = function () {
                return self.pageOneErrors().length === 0;
            };

            self.isPageTwoValid = function () {
                return self.pageTwoErrors().length === 0;
            };

            self.isValid = function () {
                return self.isPageOneValid() && self.isPageTwoValid();
            };
                      
            // TODO Put under test    
            self.isSubmitted = ko.observable(false)

            // TODO: LW - This needs to be refactoed and put under test
           
            self.submit = function() {
                var theModel = {
                    Title : self.title(),
                    Name : self.name(),
                    DateOfBirth : self.dateOfBirth(),
                    Location : self.location(),
                    Now : self.now(),
                    Feedback : self.feedBack()
                };

                $.ajax('Survey/Submit', {
                    data : JSON.stringify(theModel),
                    contentType : 'application/json; charset=utf-8',
                    type : 'POST',
                    dataType: 'json',
                    success: function(result) {
                        self.isSubmitted(true)
                        console.log('Survey Submitted: ' + result);
                        toastr.success("Thank you, your survey has been submitted.");
                    },
                    error: function (xhr, ajaxOptions, thrownError) {                       
                        toastr.error("An error was returned, please try again.");
                        console.log('Survey Submitted Error: '+  thrownError, ', ' + xhr.responseText);
                    }
                });                
            };            
        };
    });