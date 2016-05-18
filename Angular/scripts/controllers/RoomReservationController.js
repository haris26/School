(function () {

    var app = angular.module("school");

    app.controller("RoomReservationController", function ($scope, $rootScope, DataService, $sce) {

        $scope.searchParameters = {
            fromDate: new Date(),
            toDate: new Date(),
            categoryName: "Room",
            resourceName: "",
            osType: ""
        };

        $scope.getReservations = function () {
           DataService.create("reservationoverview", $scope.searchParameters, function (data) {
               $scope.reservations = data;   
           });
       }
       
       $scope.getReservations();
       
      
     
        

    });
}());

