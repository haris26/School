(function(){

    var app = angular.module("school");

    app.controller("EngagementsController", function($scope, $rootScope, DataService) {

        var dataSet = "engagements";
        $scope.selString = "";
        $scope.sortOrder = "teamName";
        getTeams();
        getRoles();
        getPeople();
        fetchData();

        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };

        function getRoles() {
            DataService.list("roles", function (data) {
                $scope.roles = data;
            });
        };

        function getPeople() {
            DataService.list("people", function (data) {
                $scope.people = data;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function(data) {
                $scope.engagements= data;
            });
        }

        $scope.transfer = function(item) {
            $scope.engagement = item;
        };

        $scope.newEngagement = function() {
            $scope.engagement = {
                id: 0,
                person: 0,
                personName: "",
                team: 0,
                teamName: "",
                role: 0,
                roleName: "",
                time: 40,
                startDate: new Date()
            }
        };

        $scope.saveData = function() {
            var promise;
            if ($scope.engagement.id == 0){
                DataService.create(dataSet, $scope.engagement, function(data){});
            }
            else {
                DataService.update(dataSet, $scope.engagement.id, $scope.engagement, function(data){});
            }
            fetchData();
        }
    });

}());
