(function () {

    var app = angular.module("school");

    app.controller("ResourceController", function ($scope, $rootScope, DataService) {

        $rootScope.selResource = "";
        var dataSet = "resources";
        fetchData();
        getCharacteristics();


        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.resources = data;
            });
        }
        function getCharacteristics() {
            DataService.list("characteristics", function (data) {
                $scope.characteristics = data;
            });
        };

        $scope.transfer = function (item) {
            $scope.resource = item;
        };

        $scope.newResource = function () {
            $scope.resource = {
                id: 0,
                name: "",
                status: "",
                category: "",
                categoryName:""
            }
        };

        $scope.saveData = function () {
            var promise;
            if ($scope.resource.id == 0) {
                DataService.create(dataSet, $scope.resource, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.resource.id, $scope.resource, function (data) { });
            }
            fetchData();
        }
    });

}());
