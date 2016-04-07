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

        $scope.cancelReservation = function (item) {
            var promise;
            $scope.eventId = item.id;
            getEvent($scope.eventId);
            if ($scope.reservationEvent != undefined) {
                DataService.remove("events", $scope.reservationEvent.id, function (data) { });
            }
        };

        //$scope.transfer = function (item) {
        //    $scope.reservationEvent = item;
        //};

        function getEvent(id) {
            DataService.read("events", id , function (data) {
                $scope.reservationEvent = data;
            });
        };
    });
}());