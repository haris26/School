(function () {

    var app = angular.module("school");

    app.controller("DetailsController", function ($scope, $rootScope, DataService) {

        var dataSet = "month";
        getMonth()
        getTeams();
        fetchData();
        getPeople();
        getDays();
        function getDays() {
            DataService.list("days", function (data) {
                $scope.days = data;
            });
        };

        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };
        function getPeople() {
            DataService.list("people", function (data) {
                $scope.people = data;
            });
        };
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.month = data;
            });
        }
    });
}());
