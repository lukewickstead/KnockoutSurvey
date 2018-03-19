"use strict";

define(['jquery', 'jquery-ui'],
    function ($, jqueryUi) {
        return function () {

            var now = new Date();
            var minDate = new Date(now.getFullYear() - 125, now.getMonth(), now.getDay());
            var maxDate = new Date();

            $('#dateOfBirth').datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'yy-mm-dd',
                minDate: minDate,
                maxDate: maxDate
            });
        }
    });
