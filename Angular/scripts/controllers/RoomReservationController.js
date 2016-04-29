(function () {

    var app = angular.module("school");

    app.controller("RoomReservationController", function ($scope, $rootScope, DataService) {

        $scope.searchParameters = {
            fromDate: new Date(),
            toDate: new Date(),
            categoryName: "Room",
            resourceName: "",
            osType: ""
        };
        
       function getReservation() {
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                $scope.reservations = data;
                console.log($scope.reservations);
            });

       }
       getReservation();

        $rootScope.refreshTable = function () {
            $scope.getReservations();
        }
        
    });
}());

