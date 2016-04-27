(function () {

    var app = angular.module("school");

    app.controller("NewServiceRequestController", function ($scope, $rootScope, $log, DataService, $location) {

        var dataSet = "newservicerequests";
        $scope.requestMessage = "";
        $scope.requestDescription = "";
     
        function fetchNewServiceRequests() {
            DataService.list(dataSet, function (data) {
                $scope.newservicerequests = data;
            });
        };
        $scope.save = function save() {
            var model = $rootScope.model;
            $log.info($rootScope.model);
            $scope.request = {
                id: 0,
                requestMessage: $scope.requestMessage,
                requestDescription: $scope.requestDescription,
                requestType: 2,
                requestDate: Date.now(),
                quantity: 1,
                asset: model.asset,
                assetType: 1,
                category: model.category,
                categoryName:model.categoryName,
                person: model.user,
                status: 1,
                serviceType:$scope.serviceType

            };
           
           
            DataService.create("requests", $scope.request, function (response) { });
            console.log($scope.request)
            $location.path("/userservicerequests")

        }
    });
}());