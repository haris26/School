(function () {

    var app = angular.module("school");


    app.controller("ReportsController", function ($scope, $rootScope, DataService) {
        var dataSet = "reports";
        var n = 5;
        var y = 2016;
    
        $scope.fetchData = function () {
            DataService.read1(dataSet, user, type, status, function (data) {
                $scope.reports = data;
            });


        }

      
    });
}());