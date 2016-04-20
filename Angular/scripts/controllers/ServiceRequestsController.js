(function () {

    var app = angular.module("school");

    app.controller("ServiceRequestsController", function ($scope, $rootScope, DataService, $location, $route) {

        var dataSet = "servicerequests";
        $scope.selString = "";
        //$scope.sortOrder = "";
        getRequests();
        fetchData();

        function getRequests() {
            DataService.list(dataSet, function (data) {
                $scope.serviceRequests = data.allRequests;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.requests = data.allRequests;             
            });
        }

        $scope.changeStatus = function (item) {
            $scope.request = {
                id: item.id,
                requestMessage: item.requestMessage,
                requestDescription: item.requestDescription,
                requestType: 2,
                requestDate: Date.now(),
                quantity: 1,
                asset: item.assetId,
                assetType: item.assetType,
                category: item.category,
                person: item.user,
                status: item.status
            }
            DataService.update("servicerequests", $scope.request.id, $scope.request, function (data) { });
            //$location.path("/servicerequests");
            console.log($scope.request)
            getRequests();
            $route.reload();
        }

        $scope.transfer = function (item) {
            $scope.requests = item;
        };
    });
}());