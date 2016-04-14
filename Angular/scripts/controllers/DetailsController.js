(function () {

    var app = angular.module("school");

    app.controller("DetailsController", function ($scope, $rootScope, DataService) {

        var dataSet = "details";
        $scope.selDetail = "";
        $scope.sortOrder = '-date';
        getTeams();
        fetchData();
        getPeople();
        getDays();
        function getDays() {
            DataService.read("days", currentUser.id, function (data) {
                $scope.days= data;
            });
        };
        
        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };
        function getPeople() {
            DataService.read("people", currentUser.id, function (data) {
                $scope.people = data;
            });
        };
        function fetchData() {
            DataService.read(dataSet, currentUser.id, function (data) {
                $scope.details = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.detail = item;
        };
        $scope.reloadRoute = function () {
            $window.location.reload();
        }
       
        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                day: 0,
                date: new Date().Date,
                person: currentUser.id,
                personName: currentUser.personName,
                workTime: "",
                description: "",
                team: 0,
                teamName: ""
            }
        };
        $scope.deleteData = function()
        {
                DataService.delete(dataSet, $scope.detail.id, function (data) { fetchData()});   
           // fetchData();
            
        }

        $scope.saveData = function () {
            var promise;
            if ($scope.detail.id == 0) {
                DataService.create(dataSet, $scope.detail, function (data) {fetchData() });
            }
            else {
                DataService.update(dataSet, $scope.detail.id, $scope.detail, function (data) { fetchData()});
            }
            //fetchData();
        }
    });

}());
