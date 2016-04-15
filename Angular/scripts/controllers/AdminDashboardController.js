(function () {

    var app = angular.module("school");

    app.controller("AdminDashboardController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "admindashboard";
        var num="1";
        fetchData();

        function fetchData() {

            DataService.read(dataSet,num, function (data) {
                $scope.dashboard = data;
            });
        }

      
       
    });
}());
