(function () {

    var app = angular.module("school", []);

    app.controller("MainCtrl", function ($scope, DataService) {

        $scope.selDetail = "";
        $scope.sortOrder = "date";
        fetchDetails();

        function fetchDetails() {
            $scope.message = "Wait...";
            DataService.list().then(
                function (response) {
                    $scope.details = response.data;
                    $scope.message = "";
                },
                function (reason) {
                    $scope.message = "No data for that request";
                }
            );
        }

        $scope.transfer = function (item) {
            $scope.detail = item;
        };

        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                day: "",
                date: new Date(),
                person: 8,
                personName: "Lejla",
                workTime: "",
                description: "",
                team: "5",
                teamName: "Delta"
            }
        };

        $scope.saveData = function () {
            var promise;
            if ($scope.detail.id == 0) {
                promise = DataService.create($scope.detail);
            }
            else {
                promise = DataService.update($scope.detail.id, $scope.detail);
            }
            promise.then(
                function (response) { window.alert("data saved!"); },
                function (reason) { window.alert("something went wrong!"); });
        }
    });

}());
