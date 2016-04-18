(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService, schConfig ) {
        var dataSet = "userreservations";
        $scope.repeatingTypes = schConfig.repeatingType;
        fetchData();
      
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }

        function onClick(item) {
            console.log("ulazak");
            var index = $scope.dashboard.activeReservations.indexOf(item);
            $scope.eventId = item.id;
            getEvent($scope.eventId);
            if ($scope.reservationEvent != undefined) {
                DataService.remove("events", $scope.reservationEvent.id, function (data) { });
                $scope.dashboard.activeReservations.splice(index, 1);
            }
        }

        $scope.cancelReservation = function(item) {
            onClick(item);
        }

        $scope.extendReservation = function (item) {
            $scope.eventExtend = {
                id: 0,
                parentEvent: item.id,
                repeatUntil: new Date().Date,
                repeatingType: $scope.repeatingTypes.indexOf(0),
                frequency: 0
            }
            $scope.modalShow = true;
        };

        $scope.saveData = function () {
            DataService.create("eventextends", $scope.eventExtend, function (data) { });
            $scope.modalShow = false;
        };

        $scope.cancel = function() {
            $scope.modalShow = false;
        };

        function getEvent(id) {
            DataService.read("events", id , function (data) {
                $scope.reservationEvent = data;
            });
        };
    });
}());