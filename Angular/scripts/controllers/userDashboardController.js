(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService) {
        var dataSet = "userreservations";
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }

        $scope.saveData = function () {
            var promise;
            if ($scope.engagement.id == 0) {
                DataService.create(dataSet, $scope.engagement, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.engagement.id, $scope.engagement, function (data) { });
            }
            fetchData();
        }
        function getEvent(id) {
            DataService.read("events", id , function (data) {
                $scope.event = data;
            });
        };

        $scope.cancelReservation = function(item) {
            var promise;
            getEvent(item.id);
            if ($scope.event != null) {
                DataService.remove(dataSet, $scope.event.id , function (data) {});
            }         
        };
    });
}());