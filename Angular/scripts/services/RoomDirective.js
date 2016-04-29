(function () {

    var app = angular.module("school");

    app.directive("roomRes", function ($modal, schConfig) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {

                console.log('room scope', scope);
            }
        }
    });
}());
