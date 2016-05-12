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
        $scope.speakerY = false;
        $scope.speakerN = false;
        $scope.tvY = false;
        $scope.tvN = false;
        $scope.boardY = false;
        $scope.boardN = false;
       $scope.getReservations = function () {
           DataService.create("reservationoverview", $scope.searchParameters, function (data) {
               $scope.reservations = data;
               console.log($scope.reservations);
               //if ($scope.reservations.room.characteristics[1].value = "Yes") {
               //    $scope.speakerY = true;
               //}
               //else
               //    $scope.speakerN = true;
               //if ($scope.reservations.room.characteristics[2].value = "Yes") {
               //    $scope.tvY = true;
               //}
               //else
               //    $scope.tvN = true;
               //if ($scope.reservations.room.characteristics[3].value = "Yes") {
               //    $scope.boardY = true;
               //}
               //else
               //    $scope.boardN = true;
           });
       }

       $scope.roomPopover = {
           content: '<img src="{{images.tvYes}}"/>'
       };
       $scope.images = {
           tvYes: "images/tvYes.png",
           tvNo: "images/tvNo.png",
           boardYes: "images/whiteboardYes.png",
           boardNo: "images/whiteboardNo.png",
           chairs: "images/chairYes.png",
           speakerYes: "images/speakerYes.png",
           speakerNo: "images/speakerNo.png"
       };

       $scope.getReservations();
       
       // $rootScope.refreshTable = function () {
       //     $scope.getReservations();
       // }
        

    });
}());

