"use strict";

define(['jquery', 'jquery-ui'],
    function ($, jqueryUi) {
        return function () {

            var now = new Date();
            var minDate = new Date(now.getFullYear() - 125, now.getMonth(), now.getDay());

            $('#dateOfBirth').datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy',
                minDate: minDate
            });
        }
    });
