(function () {

    var app = angular.module("school");

    app.controller("DetailsController", function ($scope, $rootScope, DataService) {

        var dataSet = "details";
        $scope.selString = "";
        $scope.sortOrder = "teamName";
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.details = data;
            });
        }

        $scope.transfer = function (item) {
            $scope.detail = item;
        };

        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                day: "",
                date: new Date(),
                person: 10,
                personName: "Elma",
                workTime: "",
                description: "",
                team: "5",
                teamName: "Delta"
            }
        };

        $scope.saveData = function () {
            var promise;
            if ($scope.detail.id == 0) {
                DataService.create(dataSet, $scope.detail, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.detail.id, $scope.detail, function (data) { });
            }
            fetchData();
        }
    });

}());
