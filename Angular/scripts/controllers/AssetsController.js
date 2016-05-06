(function () {

    var app = angular.module("school");

    app.controller("AssetsController", function ($scope, $rootScope, DataService, $route) {

        $scope.modal = false;
        var dataSet = "assets";
        $scope.selString = "";
        $scope.sortOrder = "userName";
        $rootScope.model = {};
        fetchData();
        getPeople();
        getAssets();
        getFreeAssets();
        
        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.assets = data.allAssets;
            });
        };

        function getFreeAssets() {
            DataService.list("assets", function (data) {
                $scope.freeassets = data.freeAssets;
            });
        };

        function getPeople() {
            DataService.list("people", function (data) {
                $scope.users = data;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.assets = data.allAssets;
            });
        }
        

        $scope.assignDevice = function (item, selectedUser) {
            $scope.selectedUser = selectedUser;
            console.log($scope.selectedUser);
            $scope.asset = {
                id: item.id,
                name: item.name,
                user: selectedUser.id,
                userName: selectedUser.firstName + ' ' + selectedUser.lastName,
                model: item.model,
                serialNumber: item.serialNumber,
                vendor: item.vendor,
                price: item.price,
                dateOfTrade: new Date(),
                status: 1,
                category: item.category,
                categoryName: item.categoryName
            }
            DataService.update("assets", $scope.asset.id, $scope.asset, function (data) { });
            console.log($scope.asset);
            $route.reload();
            getAssets();
        }

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }
    });
}());