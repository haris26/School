(function () {

    var app = angular.module("school", []);

    app.controller("ResourceController", function ($scope, DataService) {

        $scope.selResource = "";
        $scope.sortOrder = "name";
        fetchResources();

        function fetchResources() {
            $scope.message = "Wait...";
            DataService.list().then(
                function (response) {
                    $scope.resources = response.data;
                    $scope.message = "";
                },
                function (reason) {
                    $scope.message = "No data for that request";
                }
            );
        }

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
                promise = DataService.create($scope.resource);
            }
            else {
                promise = DataService.update($scope.resource.id, $scope.resource);
            }
            promise.then(
                function (response) { window.alert("data saved!"); },
                function (reason) { window.alert("something went wrong!"); });
        }
    });

}());