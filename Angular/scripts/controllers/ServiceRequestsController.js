(function () {

    var app = angular.module("school");

    app.controller("ServiceRequestsController", function ($scope, $rootScope, DataService, $location, $route) {

        $scope.modal = false;
        var dataSet = "servicerequests";
        $scope.selString = "";
        $scope.sortOrder = "date";
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
                asset: item.asset,
                assetType: item.assetType,
                category: item.category,
                person: item.person,
                personName: item.personName,
                categoryName:item.categoryName,
                status: item.status,
                email: item.email,
                serviceType:item.serviceType
            }
          
            DataService.update("servicerequests", $scope.request.id, $scope.request, function (data) { });
            //$location.path("/servicerequests");
            console.log($scope.request)
            $scope.modal = false;

            getRequests();
            $route.reload();
        }

        $scope.transfer = function (item) {
            $scope.requests = item;
        };
    });
}());