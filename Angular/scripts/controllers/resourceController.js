(function () {

    var app = angular.module("school", []);

    app.controller("ResourceController", function ($scope, DataService) {

        $scope.selResource = "";
        $scope.sortOrder = "";
        fetchResources();

        function fetchResources() {
            $scope.message = "Wait...";
            DataService.resourceList().then(
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

    app.controller("CharacteristicController", function ($scope, $http) {
        var onComplete = function (response) {
            $scope.characteristics = response.data;
        };
        var onError = function (reason) {
            $scope.message = "No data for characteristics request";
        };
        var promise = $http.get("http://localhost:50169/api/characteristics");
        promise.then(onComplete, onError);

    });

}());