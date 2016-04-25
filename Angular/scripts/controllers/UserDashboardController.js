(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "dashboard";
       // $scope.modal = false;
        //$rootScope.model = {};
        $rootScope.model = {};
        fetchData();
       
       
      
       
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }

        //function getAssets() {
        //    DataService.list("assets", function (data) {
        //        $scope.assets = data.allAssets;
        //    });
        //};

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }


    });
}());
