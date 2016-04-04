
(function () {

    var app = angular.module("school", []);

    app.controller("MainCtrl", function ($scope, $http) {

        var onComplete = function (response) {
            $scope.people = response.data;
            $scope.message = "";
        };

        var onError = function (reason) {
            $scope.message = "No data for that request";
        };

        $scope.selPerson = "";
        $scope.sortOrder = "lastName";
        var promise = $http.get("http://localhost:50169/api/people");
        $scope.message = "Wait...";
        promise.then(onComplete, onError);

        $scope.transfer = function (item) {
            $scope.person = item;
        };

        $scope.newPerson = function () {
            $scope.person = {
                id: 0,
                firstName: "",
                lastName: "",
                email: "",
                phone: "",
                category: "Full",
                gender: "",
                address: {},
                birthDate: "",
                startDate: new Date(),
                status: "Active"
            }
        };

        $scope.saveData = function () {
            var promise;
            if ($scope.person.id == 0) {
                promise = $http({
                    method: "post",
                    url: "http://localhost:50169/api/people",
                    data: $scope.person
                })
            }
            else {
                promise = $http({
                    method: "put",
                    url: "http://localhost:50169/api/people/" + $scope.person.id,
                    data: $scope.person
                })
            }
            promise.then(
                function (response) { window.alert("data saved!"); },
                function (reason) { window.alert("something went wrong!"); });
        }
    });

}());