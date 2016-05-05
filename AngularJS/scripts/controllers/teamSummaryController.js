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
                for (i = 0; i < $scope.teams[i].skills.length; i++) {
                    for (var j = 0; j < $scope.teams[i].skills[j]; j++){
                        $scope.collapsed[$scope.teams[i].skills[j].categoryName] = true;
                        
                    }
                }
            })
        }
    });
}());