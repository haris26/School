(function () {

    var app = angular.module("school");

    app.controller("AssetsController", function ($scope, $rootScope, DataService) {

        var dataSet = "assets";
        $scope.selString = "";
        //$scope.sortOrder = "";
        getAssets();

        fetchData();

        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.requests = data.allAssets;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.assets = data.allAssets;
            });
        }

        $scope.transfer = function (item) {
            $scope.assets = item.allAssets;

        };




    });

}());