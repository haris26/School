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
            toaster.pop('success', "Confirmation", "Reservation successfully extended!");
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

    app.controller("createEventCtrl", function ($scope, $modalInstance, DataService, schConfig, $rootScope) {
        $scope.createReservation = function () {
            console.log($scope.newEvent,"daj event");
            DataService.create("events", $scope.newEvent, function(data) {
                var result = true;
                $modalInstance.close(result);
            });
        };
        
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("createRoomEventCtrl", function ($scope, $modalInstance, DataService, $rootScope) {
       
        $scope.createReservation = function () {
            $scope.newEvent.endDate = $scope.newEvent.endDate.substring(0, 10) +" "+ $scope.newEvent.endTime + ":00";
            DataService.create("events", $scope.newEvent, function (data) {
                var result = true;
                $modalInstance.close(result);
            });
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("CancelExtendedCtrl", function ($scope, $modalInstance, DataService, schConfig, confirmed) {

        $scope.confirmed = confirmed;
        $scope.yes = function () {
            $scope.isConfirmed = true;
            $modalInstance.close($scope.isConfirmed);
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("EditExtendedCtrl", function ($scope, $modalInstance, DataService, schConfig, $rootScope) {
        $scope.saveData = function () {
            DataService.update("eventextends", $scope.event.id, $scope.event, function (data) {
                var result = true;
                $rootScope.refreshRecc();
                $modalInstance.close(result);
            });

        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("EditDeviceModalCtrl", function ($scope, $modalInstance, DataService, schConfig, $rootScope) {
        $scope.saveReservation = function () {
            DataService.update("events", $scope.editEvent.id, $scope.editEvent, function (data) {
                var result = true;
                $rootScope.refreshActive();
                $modalInstance.close(result);
                console.log($scope.editEvent);
            });
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });
}());
