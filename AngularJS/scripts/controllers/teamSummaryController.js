(function () {

    var app = angular.module("school");

    app.controller("TeamsSummaryCtrl", function ($scope, DataService) {

        $scope.message = "Loading data...";

        $scope.collapsed = {};

        $scope.icon = {
            true: "glyphicon glyphicon-chevron-down",
            false: "glyphicon glyphicon-chevron-up"
        }

        fetchTeams();

        function fetchTeams() {
            DataService.list("teamsummaries", function (data) {
                $scope.teams = data;
                $scope.message = "";
            })
        }
    });
}());