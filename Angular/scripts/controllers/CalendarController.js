(function () {

    var app = angular.module("school");
app.controller("CalendarController", function ($scope) {
    $scope.day = moment();
});
}());