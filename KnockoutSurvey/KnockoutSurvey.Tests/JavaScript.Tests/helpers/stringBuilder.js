"use strict";

define(
    function () {
        function stringWithLength(length) {
            return Array(length + 1).join('.')
        }

        return {stringWithLength: stringWithLength}
    });