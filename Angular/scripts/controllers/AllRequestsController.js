(function () {

    var app = angular.module("school");

    app.controller("AllRequestsController", function ($scope, $rootScope, DataService, $route) {

        var dataSet = "requests";
        $scope.selString = "";
        $scope.sortOrder = "";
        getRequests();
        fetchData();

        function getRequests() {
            DataService.list(dataSet, function (data) {
                $scope.requests = data.allRequests;
            });
        };

        $scope.changeStatus = function (item) {
            $scope.request = {
                id: item.id,
                requestMessage: item.requestMessage,
                requestDescription: item.requestDescription,
                requestType: 1,
                requestDate: Date.now(),
                quantity: item.quantity,              
                assetType: item.assetType,
                category: item.category,
                categoryName: item.categoryName,
                person: item.person,
                personName:item.personName,
                status: item.status,
                email: item.email,
                serviceType: item.serviceType
            }
            DataService.update("requests", $scope.request.id, $scope.request, function (data) { });
            //$location.path("/servicerequests");
            console.log($scope.request);
            getRequests();
            $route.reload();
        }

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.requests= data.allRequests;
            });
        }

        $scope.transfer = function (item) {
            $scope.requests = item;    
        };      
    });
}());