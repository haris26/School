(function () {

    var app = angular.module("school");

    app.controller("AdminDashboardController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "admindashboard";
        var num="1";
        fetchData();
        $scope.selString = "";
        $scope.sortOrder = "";
       

        function fetchData() {

            DataService.read(dataSet,num, function (data) {
                $scope.dashboard = data;
            });
        }

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
                person: item.personName,
                status: item.status
            }
            DataService.update("requests", $scope.request.id, $scope.request, function (data) { });
            //$location.path("/servicerequests");
            console.log($scope.request);
            getRequests();
            $route.reload();
        }

        $scope.transfer = function (item) {
            $scope.requests = item;
        };
       
    });
}());
