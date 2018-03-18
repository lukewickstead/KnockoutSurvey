/* global describe, it, expect */
"use strict";

define(["knockout", "surveyModel", "surveyModelBuilder", "stringBuilder"],
    function (ko, surveyModel, surveyModelBuilder, stringBuilder) {

        beforeEach(function () {
            this.model = surveyModelBuilder.defaultValid();
        });

        describe("When validating surveyModel", function () {

            describe("and all fields are valid", function () {

                it("then the model is reported as valid", function () {
                    expect(this.model.isValid()).toEqual(true);
                });

                it("then a minimum length name is reported as valid", function () {
                    this.model.name(stringBuilder.stringWithLength(3));
                    expect(this.model.isValid()).toEqual(true);
                });

                it("then a maximum length age is reported as valid", function () {
                    this.model.name(stringBuilder.stringWithLength(50));
                    expect(this.model.isValid()).toEqual(true);
                });

                it("then a maximum length location is reported as valid", function () {
                    this.model.location(stringBuilder.stringWithLength(100));
                    expect(this.model.isValid()).toEqual(true);
                });

                it("then a maximum length location is reported as valid", function () {
                    this.model.location(stringBuilder.stringWithLength(100));
                    expect(this.model.isValid()).toEqual(true);
                });

                it("then a minimum length feed back is reported as valid", function () {
                    this.model.feedBack(stringBuilder.stringWithLength(25));
                    expect(this.model.isValid()).toEqual(true);
                });

                it("then a maximum length feed back is reported as valid", function () {
                    this.model.feedBack(stringBuilder.stringWithLength(500));
                    expect(this.model.isValid()).toEqual(true);
                });
            });

            describe("and the title field is not provided", function () {

                beforeEach(function () {
                    this.model.title('');
                    this.titleErrors = ko.validation.group(this.model.title);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.titleErrors().length).toEqual(1);
                    expect(this.titleErrors()[0]).toEqual("Please select your title");
                });

                it("then the model reports in page one errors", function () {
                    expect(this.model.pageOneErrors().length).toEqual(1);
                });

                it("then the model reports page one is invalid", function () {
                    expect(this.model.isPageOneValid()).toEqual(false);
                });
            });

            describe("and the name field is not provided", function () {

                beforeEach(function () {
                    this.model.name('');
                    this.nameErrors = ko.validation.group(this.model.name);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.nameErrors().length).toEqual(1);
                    expect(this.nameErrors()[0]).toEqual("Please enter your name.");
                });
            });

            describe("and the name field is too short", function () {

                beforeEach(function () {
                    this.model.name(stringBuilder.stringWithLength(2));
                    this.nameErrors = ko.validation.group(this.model.name);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is too short", function () {
                    expect(this.nameErrors().length).toEqual(1);
                    expect(this.nameErrors()[0]).toEqual("Your name must be more than 3 characters");
                });
            });


            describe("and the name field is too long", function () {

                beforeEach(function () {
                    this.model.name(stringBuilder.stringWithLength(51));
                    this.nameErrors = ko.validation.group(this.model.name);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is too long", function () {
                    expect(this.nameErrors().length).toEqual(1);
                    expect(this.nameErrors()[0]).toEqual('Your name must not be more than 50 characters');
                });
            });

            describe("and the date of birth field is not provided", function () {

                beforeEach(function () {
                    this.model.dateOfBirth('');
                    this.dateOfBirthErrors = ko.validation.group(this.model.dateOfBirth);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.dateOfBirthErrors().length).toEqual(1);
                    expect(this.dateOfBirthErrors()[0]).toEqual("Please enter your date of birth");
                });

                it("then the model reports in page one errors", function () {
                    expect(this.model.pageOneErrors().length).toEqual(1);
                });

                it("then the model reports page on is invalid", function () {
                    expect(this.model.isPageOneValid()).toEqual(false);
                });
            });

            describe("and the location field is not provided", function () {

                beforeEach(function () {
                    this.model.location('');
                    this.locationErrors = ko.validation.group(this.model.location);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.locationErrors().length).toEqual(1);
                    expect(this.locationErrors()[0]).toEqual("Please enter your location");
                });

                it("then the model reports in page two errors", function () {
                    expect(this.model.pageTwoErrors().length).toEqual(1);
                });

                it("then the model reports page two is invalid", function () {
                    expect(this.model.isPageTwoValid()).toEqual(false);
                });
            });

            describe("and the location field is too long", function () {

                beforeEach(function () {
                    this.model.location(stringBuilder.stringWithLength(101));
                    this.locationErrors = ko.validation.group(this.model.location);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.locationErrors().length).toEqual(1);
                    expect(this.locationErrors()[0]).toEqual("Your location must not be more than 100 characters");
                });
            });

            describe("and the now field is not provided", function () {

                beforeEach(function () {
                    this.model.now('');
                    this.nowErrors = ko.validation.group(this.model.now);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.nowErrors().length).toEqual(1);
                    expect(this.nowErrors()[0]).toEqual("Please enter your current date time");
                });

                it("then the model reports in page two errors", function () {
                    expect(this.model.pageTwoErrors().length).toEqual(1);
                });

                it("then the model reports page two is invalid", function () {
                    expect(this.model.isPageTwoValid()).toEqual(false);
                });

            });

            describe("and the feed back field is not provided", function () {

                beforeEach(function () {
                    this.model.feedBack('');
                    this.feedBackErrors = ko.validation.group(this.model.feedBack);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.feedBackErrors().length).toEqual(1);
                    expect(this.feedBackErrors()[0]).toEqual("Please enter some feedback");
                });

                it("then the model reports in page two errors", function () {
                    expect(this.model.pageTwoErrors().length).toEqual(1);
                });

                it("then the model reports page two is invalid", function () {
                    expect(this.model.isPageTwoValid()).toEqual(false);
                });
            });

            describe("and the feed back field is too short", function () {

                beforeEach(function () {
                    this.model.feedBack(stringBuilder.stringWithLength(24));
                    this.feedBackErrors = ko.validation.group(this.model.feedBack);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.feedBackErrors().length).toEqual(1);
                    expect(this.feedBackErrors()[0]).toEqual("Your feed back must be more than 25 characters");
                });
            });

            describe("and the feed back field is too long", function () {

                beforeEach(function () {
                    this.model.feedBack(stringBuilder.stringWithLength(501));
                    this.feedBackErrors = ko.validation.group(this.model.feedBack);
                });

                it("then the model is reported as invalid", function () {
                    expect(this.model.isValid()).toEqual(false);
                });

                it("then the model reports the field is required", function () {
                    expect(this.feedBackErrors().length).toEqual(1);
                    expect(this.feedBackErrors()[0]).toEqual("Your feed back must not be more than 500 characters");
                });
            });
        });

        describe("When toggling pages", function () {

            it("then calling page one goes to page one", function () {
                this.model.gotoPageOne();
                expect(this.model.page()).toEqual(1);
            });

            it("then calling page two goes to page two", function () {
                this.model.gotoPageTwo();
                expect(this.model.page()).toEqual(2);
            });
        });
    });