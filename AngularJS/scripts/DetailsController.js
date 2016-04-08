
(function () {

    var app = angular.module("school", []);

    app.controller("MainCtrl", function ($scope, $http) {

        var onComplete = function (response) {
            $scope.details = response.data;
            $scope.message = "";
        };

        var onError = function (reason) {
            $scope.message = "No data for that request";
        };

        $scope.selDetail = "";
        $scope.sortOrder = "lastName";
        var promise = $http.get("http://localhost:52571/api/details");
        $scope.message = "Wait...";
        promise.then(onComplete, onError);

        $scope.transfer = function (item) {
            $scope.detail = item;
        };

        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                Day: 0,
                Date: "",
                Person: 0,
                PersonName: "",
                WorkTime: "",
                Description: "",
                Team: 0,
                TeamName: "",
            }
        };

        $scope.saveData = function () {
            var promise;
            if ($scope.detail.id == 0) {
                promise = $http({
                    method: "post",
                    url: "http://localhost:52571/api/details",
                    data: $scope.detail
                })
            }
            else {
                promise = $http({
                    method: "put",
                    url: "http://localhost:52571/api/details/" + $scope.detail.id,
                    data: $scope.detail
                })
            }
            promise.then(
                function (response) { window.alert("data saved!"); },
                function (reason) { window.alert("something went wrong!"); });
        }
    });

}());