(function () {

    var app = angular.module("school");

    app.controller("NewServiceRequestController", function ($scope, $rootScope, DataService) {

        var dataSet = "newservicerequests";
        $scope.requestMessage = "";
        $scope.requestDescription = "";
       
        function fetchNewServiceRequests() {
           DataService.list(dataSet, function (data) {
                $scope.newservicerequests = data;
            });
        };
        $scope.save = function save()
        {
            var model = $rootScope.model;
            $scope.request = {
                id:0,
                requestMessage: $scope.requestMessage,
                requestDescription: $scope.requestDescription,
                requestType: 2,
                requestDate: Date.now(),
                quantity: 1,
                asset: model.id,
                assetType: 1,
                category: model.category,
                person: model.user
            };               
            DataService.create("requests", $scope.request, function (response) { });
        }
    });
}());