(function () {

    var app = angular.module("school");

    app.controller("ExtendModalCtrl", function($scope, $modalInstance, DataService, schConfig, toaster) {

        $scope.saveData = function () {
            if ($scope.newRoomEvent != undefined) $scope.newEvent = $scope.newRoomEvent;
            if ($scope.newDeviceEvent != undefined) $scope.newEvent = $scope.newDeviceEvent;
            console.log("newEvent", $scope.newEvent,$scope.newDeviceEvent,$scope.newRoomEvent);
            DataService.create("eventextends", $scope.eventExtend, function (data) {
                DataService.update("events", $scope.newEvent.id, $scope.newEvent, function (data) { });
            });
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
            toaster.pop('success', "Confirmation", "Reservation successfully canceled!");
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

    app.controller("EditDeviceEventModalCtrl", function ($scope, $modalInstance, DataService, schConfig, $rootScope) {
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

    app.controller("EditDeviceModalCtrl", function ($scope, $modalInstance, DataService, $rootScope, $location, $route) {
        $scope.saveChanges = function () {
            DataService.update("resources", $scope.device.id, $scope.device, function (data) {
                DataService.update("characteristics", $scope.deviceTypeCharac.id, $scope.deviceTypeCharac, function (data) {
                    DataService.update("characteristics", $scope.osTypeCharac.id, $scope.osTypeCharac, function (data) {
                        DataService.update("characteristics", $scope.osVersionCharac.id, $scope.osVersionCharac, function (data){})
                    })
                })
                var result = true;
                $route.reload();
                $modalInstance.close(result);
            });
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }
    });

    app.controller("EditRoomModalCtrl", function ($scope, $modalInstance, DataService, $rootScope) {
        $scope.saveChanges = function () {
            DataService.update("resources", $scope.editR.id, $scope.editR, function (data) {
                DataService.update("characteristics", $scope.roomChairCharac.id, $scope.roomChairCharac, function (data) {
                    DataService.update("characteristics", $scope.roomSpeakerCharac.id, $scope.roomSpeakerCharac, function (data){
                        DataService.update("characteristics", $scope.roomTvCharac.id, $scope.roomTvCharac, function (data){
                            DataService.update("characteristics", $scope.roomBoardCharac.id, $scope.roomBoardCharac, function (data){})
                            })
                        })                    
                })
                var result = true;
                $modalInstance.close(result);
            });            
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }
    });
}());
