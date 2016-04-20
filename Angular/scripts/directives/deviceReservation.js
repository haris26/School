(function () {

    var app = angular.module("school");

    app.directive("deviceReservation", function () {
        return {
            restrict: "AE",
            transclude: true,
            link: function (scope, elem, attrs) {
                elem.bind('click', function () { elem.css('background-color', 'yellow') });
                elem.bind('mouseover', function () { elem.css('background-color', 'blue'); })
                elem.bind('mouseout', function () { elem.css('background-color', 'red'); })
            }
        };

    });

}());
