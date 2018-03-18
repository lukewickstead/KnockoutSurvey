"use strict";
define(['knockout', 'moment', 'koValidation'],
    function (ko, moment) {
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
        };
    });