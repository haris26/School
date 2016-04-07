(function () {

    var app = angular.module("school");

    app.controller("NewServiceRequestController", function ($scope, DataService) {

        var dataSet = "newservicerequests";
        //$scope.selPerson = "";
        //$scope.sortOrder = "lastName";
        fetchNewServiceRequests();
        

        function fetchNewServiceRequests() {
           DataService.list("newservicerequests", function (data) {
                $scope.newservicerequests = data;
            });
        };

        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.assets = data;
            });
        };

        $scope.transfer = function (item) {
            $scope.assets = item;
        };

        $scope.newServiceRequest = function () {
            $scope.newservicerequests = {
                id: 0,
                requestType: 2,
                requestDescription:"aloo" ,
                requestMessage: "haloo",
                requestDate: new Date(),
                status: 1,
                assetId: assets.assetId,
                userId: assets.userId,
                quantity:1,
                assetType: assets.assetType,
                assetCategory:assets.assetCategory
            }
        };

        $scope.saveData = function () {
            if ($scope.newservicerequests.id == 0) {
                DataService.create(dataSet, $scope.newservicerequests, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.newservicerequests.id, $scope.newservicerequests, function (data) { });
            }
            fetchNewServiceRequests();
        }
    });
}());