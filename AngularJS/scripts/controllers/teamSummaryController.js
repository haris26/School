(function () {

    var app = angular.module("school");

    app.controller("TeamsSummaryCtrl", function ($scope, DataService) {

        $scope.message = "Loading data...";

        fetchTeams();

        function fetchTeams() {
            DataService.list("teamsummaries", function (data) {
                $scope.teams = data;
                $scope.message = "";
            })
        }
    });
}());