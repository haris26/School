(function () {

    var app = angular.module("school");

    app.controller("ServiceRequestsController", function ($scope, $rootScope, DataService) {

        var dataSet = "newReq";
        $scope.selString = "";
        //$scope.sortOrder = "";
        getRequests();

        fetchData();

        function getRequests() {
            DataService.list("servicerequests", function (data) {
                $scope.requests = data.allRequests;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.requests = data.allRequests;
            });
        }

        $scope.transfer = function (item) {
            $scope.requests = item;

        };




    });

}());