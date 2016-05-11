(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "dashboard";
       // $scope.modal = false;

        //$rootScope.model = {};
        $scope.selString = "";
        $scope.sortOrder = "";
        $rootScope.model = {};
        fetchData();
       

      
       
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }



      

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }


    });
}());
