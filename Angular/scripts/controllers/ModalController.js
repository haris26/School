(function () {

    var app = angular.module("school");

    app.controller("ExtendModalCtrl", function($scope, $modalInstance, DataService, schConfig, toaster) {

        $scope.saveData = function () {
            DataService.create("eventextends", $scope.eventExtend, function (data) { });
            $modalInstance.close();
            pop();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
        pop = function () {
            toaster.pop('note', "Confirmation", "Reservation successfully extended!");
        };
    });

    app.controller("CancelResCtrl", function ($scope, $modalInstance, DataService, schConfig, confirmed, toaster ) {
   
        $scope.confirmed = confirmed;

        $scope.yes = function () {
            $scope.isConfirmed = true;
            $modalInstance.close($scope.isConfirmed);
            pop();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
         pop = function () {
            toaster.pop('note', "Confirmation", "Reservation successfully canceled!");
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
