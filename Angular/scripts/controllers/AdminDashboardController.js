(function () {

    var app = angular.module("school");

    app.controller("AdminDashboardController", function ($scope, $rootScope, DataService) {

        var dataSet = "Files";
        $scope.selString = "";
        //$scope.sortOrder = "";
        getFiles();

        fetchData();

        function getFiles() {
            DataService.list("admindashboard/1", function (data) {
                $scope.Files= data;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.Files = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.Files = item;

        };




    });

}());