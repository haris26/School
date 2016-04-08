(function () {

    var app = angular.module("school");

    app.controller("AllRequestsController", function ($scope, $rootScope, DataService) {

        var dataSet = "requests";
        $scope.selString = "";
        $scope.sortOrder = "";
        getRequests();

        fetchData();

        function getRequests() {
            DataService.list("requests", function (data) {
                $scope.requests = data.allRequests;

            });
        };

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