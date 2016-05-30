(function () {

    var app = angular.module("school");


    app.controller("AssetReportsController", function ($scope, $rootScope, DataService) {
        var dataSet = "assetReports";
        //var m = $scope.selectedMonth;
        //var y = $scope.selectedYear;

        $scope.fetchData = function () {
            var m = $scope.selectedMonth;
            var y = $scope.selectedYear;
            DataService.read1(dataSet, m, y, function (data) {
                $scope.assetReports = data;
            });
        }
    });
}());