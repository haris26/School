(function () {

    var app = angular.module("school");

    app.controller("NewServiceRequestController", function ($scope, $rootScope, $log,toaster, DataService, $location) {

        var dataSet = "newservicerequests";
        $scope.requestMessage = "";
        $scope.requestDescription = "";
     
        function fetchNewServiceRequests() {
            DataService.list(dataSet, function (data) {
                $scope.newservicerequests = data;
            });
        };

        pop = function () {
            toaster.pop('success', "Success", " You have sent your request!");
        };

        errorPop = function () {
            toaster.pop('error', "Error", "All fields are required");
        }

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
                assetType:model.assetType,
                category: model.category,
                categoryName:model.categoryName,
                person: model.user,
                status: 1,
                serviceType:$scope.serviceType
            };
            if ($scope.request.requestDescription == "" || $scope.request.requestMessage == "" || $scope.request.requestType == "") {
                errorPop();
                return                
            } else {
                DataService.create("requests", $scope.request, function (response) { });
                pop();
                console.log($scope.request)
                $location.path("/userservicerequests")
            }
        }
    });
}());