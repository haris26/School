(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "dashboard";
        $scope.modal = false;
       $rootScope.model = {};
        fetchData();
        getAssets();
       
      
       
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }


        function getAssets() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data.assets;
            });
        }

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }


    });
}());
