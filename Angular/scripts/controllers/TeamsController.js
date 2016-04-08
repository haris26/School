(function(){

    var app = angular.module("school");

    app.controller("TeamsController", function($scope, $rootScope, DataService) {

        var dataSet = "teams";
        fetchTeams();

        function fetchTeams() {
            DataService.list(dataSet, function(data){
                $scope.teamd = data;
            })
        }

        $scope.transfer = function(item) {
            $scope.team = item;
        };

        $scope.newTeam = function() {
            $scope.team = {
                id: 0,
                name: "",
                type: "External",
                description: ""
            }
        };

        $scope.saveData = function() {
            if ($scope.team.id == 0){
                DataService.create(dataSet, $scope.team, function(data){});
            }
            else {
                DataService.update(dataSet, $scope.team.id, $scope.team, function(data){});
            }
            fetchPeople();
        }
    });

}());
