(function () {

    var app = angular.module("school");

    app.controller("DetailsController", function ($scope, $rootScope, DataService) {

        var dataSet = "details";
        $scope.selDetail = "";
        $scope.sortOrder = "teamName";
        getTeams();
        fetchData();
        getPeople();
        getDays();
        function getDays() {
            DataService.list("days", function (data) {
                $scope.days= data;
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
                $scope.details = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.detail = item;
        };

        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                day: 0,
                date: "",//$filter('date')(new Date(), 'yyyy-MM-ddT00:00:00'),
                person: 0,
                personName: "",
                workTime: "",
                description: "",
                team: 0,
                teamName: ""
            }
        };
        $scope.deleteData = function()
        {

                DataService.delete(dataSet, $scope.detail.id, function (data) { });   
            fetchData();
            
        }

        $scope.saveData = function () {
            var promise;
            if ($scope.detail.id == 0) {
                DataService.create(dataSet, $scope.detail, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.detail.id, $scope.detail, function (data) { });
            }
            fetchData();
        }
    });

}());
