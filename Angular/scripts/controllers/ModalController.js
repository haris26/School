(function () {

    var app = angular.module("school");

    app.controller("ExtendModalCtrl", function($scope, $modalInstance, DataService, schConfig) {

        $scope.saveData = function () {
            DataService.create("eventextends", $scope.eventExtend, function (data) { });
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("CancelResCtrl", function ($scope, $modalInstance, DataService, schConfig, confirmed ) {
   
        $scope.confirmed = confirmed;

        $scope.yes = function () {
            $scope.isConfirmed = true;
            $modalInstance.close($scope.isConfirmed);
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("createEventCtrl", function ($scope, $modalInstance, DataService, schConfig) {

        $scope.createReservation = function () {
            DataService.create("events", $scope.newEvent, function (data) { });
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

 
}());
