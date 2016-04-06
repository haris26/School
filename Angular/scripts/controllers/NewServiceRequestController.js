(function () {

    var app = angular.module("school");

    app.controller("NewServiceRequestController", function ($scope, DataService) {

        var dataSet = "servicerequests";
        //$scope.selPerson = "";
        //$scope.sortOrder = "lastName";
        fetchPeople();
        

        function fetchPeople() {
            DataService.list("servicerequests", function (data) {
                $scope.servicerequest = data;
            });
        };

        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.assets = data;
            });
        };

        $scope.transfer = function (item) {
            $scope.servicerequest = item;
        };

        $scope.newServiceRequest = function () {
            $scope.servicerequest = {
                id: 0,
                requestType: 2,
                requestDescription: "",
                requestMessage: "",
                phone: "",
                category: "Full",
                gender: "",
                address: {},
                birthDate: "",
                startDate: new Date(),
                status: "Active"
            }
        };

        $scope.saveData = function () {
            if ($scope.person.id == 0) {
                DataService.create(dataSet, $scope.person, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.person.id, $scope.person, function (data) { });
            }
            fetchPeople();
        }
    });
}());