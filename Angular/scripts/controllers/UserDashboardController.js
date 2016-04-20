(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "dashboard";
       
        fetchData();
       
        function fetchData() {

            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }



    });
}());
