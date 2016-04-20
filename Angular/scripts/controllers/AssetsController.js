﻿(function () {

    var app = angular.module("school");

    app.controller("AssetsController", function ($scope, $rootScope, DataService) {

        $scope.modal = false;
        var dataSet = "assets";
        $scope.selString = "";
        $scope.sortOrder = "userName";
        $rootScope.model = {};
        fetchData();
        getAssets();
       

        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.assets = data.allAssets;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.assets = data.allAssets;
            });
        }

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }
    });
}());