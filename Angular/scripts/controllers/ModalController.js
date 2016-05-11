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

    app.controller("createEventCtrl", function ($scope, $modalInstance, DataService, schConfig, $rootScope) {
        $scope.createReservation = function () {
            DataService.create("events", $scope.newEvent, function(data) {
                var result = true;
                $rootScope.refreshTable();
                $modalInstance.close(result);
            });
        };
        //console.log($scope.newEvent);
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };
    });

    app.controller("createRoomEventCtrl", function ($scope, $modalInstance, DataService, $rootScope) {
        var todayDate = new Date();
        var today = new Date(todayDate.getFullYear(), todayDate.getMonth(), todayDate.getDate(), 17, 00,00).toJSON();
        $scope.todayDate = today;
        $scope.createReservation = function () {
            DataService.create("events", $scope.newEvent, function (data) {
                var result = true;
                //$rootScope.refreshTable();
                $modalInstance.close(result);
            });
        };
        //console.log($scope.newEvent);
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
        //console.log($scope.extendedEvent);
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
