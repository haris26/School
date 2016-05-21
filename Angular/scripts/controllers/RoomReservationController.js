(function () {

    var app = angular.module("school");

    app.controller("RoomReservationController", function ($scope, $rootScope, DataService, $modal) {

        $scope.permission = {
            showAdmin: currentUser.roles.indexOf("Admin")> -1
        }
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
        };
        $scope.getReservations();

        $scope.editRoom = function (item) {
            $scope.editR = {
                id: item.id,
                name: item.roomName,
                resoureCategory: 2
            }
            $scope.roomChairCharac = {
                id: item.characteristics[0].id,
                name: item.characteristics[0].name,
                value: item.characteristics[0].value,
                resource: item.id
            }
            $scope.roomSpeakerCharac = {
                id: item.characteristics[1].id,
                name: item.characteristics[1].name,
                value: item.characteristics[1].value,
                resource: item.id
            }
            $scope.roomTvCharac = {
                id: item.characteristics[2].id,
                name: item.characteristics[2].name,
                value: item.characteristics[2].value,
                resource: item.id
            }
            $scope.roomBoardCharac = {
                id: item.characteristics[3].id,
                name: item.characteristics[3].name,
                value: item.characteristics[3].value,
                resource: item.id
            }
            var modalInstance = $modal.open({
                templateUrl: 'views/modals/editRoomModal.html',
                controller: 'EditRoomModalCtrl',
                windowClass: 'app-modal-window',
                backdrop: 'static',
                size: 'md',
                scope: $scope
            });
        }
        //$scope.getWeekReservations =function(){}
        $scope.getReservations();
        $scope.setAccordion = {
            modayOpen: false,
            tuesdayOpen: false,
            wednesdayOpen: false,
            thursdayOpen: false,
            fridayOpen: false,
            mondayDisabled:false,
            tuesdayDisabled:false,
            wednesdayDisabled:false,
            thursdayDisabled:false,
            fridayDisabled:false
        };
        $scope.disable = true;
        //TODO
        //$scope.getReservations=function(){}
        $rootScope.refreshWeek = function () {
            console.log("ref");
            $scope.getWeekReservations($rootScope.currentDay);
        }
        $scope.status = 0;
        $scope.getWeekReservations = function (item) {
           
            if (item.weekStart < item.today && $scope.status == 0) {
                
                $scope.setAccordion.mondayDisabled = true;
            }
            if (item.weekStart >= item.today || $scope.status != 0) {
                $scope.setAccordion.mondayDisabled = $scope.disable;
                if (item.weekStart == item.today  && $scope.status==0) {
                    $scope.setAccordion.modayOpen = true;
                }
                $scope.mondayParameters = {
                    fromDate: item.weekStart,
                    toDate: item.weekStart,
                    categoryName: "Room",
                    resourceName: "",
                    osType: ""
                };
                
                DataService.create("reservationoverview", $scope.mondayParameters, function (data) {
                    $scope.mondayReservations = data;
                });

            }

            if (item.tuesday < item.today && $scope.status == 0) {

                $scope.setAccordion.tuesdayDisabled = true;
            }
            if (item.tuesday >= item.today || $scope.status != 0) {
                $scope.setAccordion.tuesdayDisabled = $scope.disable;
                if (item.tuesday == item.today && $scope.status == 0) {
                    $scope.setAccordion.tuesdayOpen = true;
                }
                $scope.tuesdayParameters = {
                    fromDate: item.tuesday,
                    toDate: item.tuesday,
                    categoryName: "Room",
                    resourceName: "",
                    osType: ""
                };

                DataService.create("reservationoverview", $scope.tuesdayParameters, function (data) {
                    $scope.tuesdayReservations = data;
                });

            }
            
            if (item.wednesday < item.today && $scope.status == 0) {

                $scope.setAccordion.wednesdayDisabled = true;
            }
            if (item.wednesday >= item.today || $scope.status != 0) {
                $scope.setAccordion.wednesdayDisabled = false;
                if (item.wednesday == item.today && $scope.status == 0) {
                    $scope.setAccordion.wednesdayOpen = true;
                }
                $scope.wednesdayParameters = {
                    fromDate: item.wednesday,
                    toDate: item.wednesday,
                    categoryName: "Room",
                    resourceName: "",
                    osType: ""
                };
                DataService.create("reservationoverview", $scope.wednesdayParameters, function (data) {
                    $scope.wednesdayReservations = data;
                });

            }

            if (item.thursday < item.today && $scope.status == 0) {

                $scope.setAccordion.thursdayDisabled = true;
            }
            if (item.thursday >= item.today || $scope.status != 0) {
                $scope.setAccordion.thursdayDisabled = false;
                if (item.thursday == item.today && $scope.status == 0) {
                    $scope.setAccordion.thurdayOpen = true;
                }
                $scope.thursdayParameters = {
                    fromDate: item.thursday,
                    toDate: item.thursday,
                    categoryName: "Room",
                    resourceName: "",
                    osType: ""
                };
                DataService.create("reservationoverview", $scope.thursdayParameters, function (data) {
                    $scope.thursdayReservations = data;
                });

            }

            if (item.weekEnd < item.today && $scope.status == 0) {

                $scope.setAccordion.fridayDisabled = true;
            }
            if (item.weekEnd >= item.today || $scope.status != 0) {
                $scope.setAccordion.fridayDisabled = false;
                if (item.weekEnd == item.today && $scope.status == 0) {
                    $scope.setAccordion.fridayOpen = true;
                }
                $scope.fridayParameters = {
                    fromDate: item.weekEnd,
                    toDate: item.weekEnd,
                    categoryName: "Room",
                    resourceName: "",
                    osType: ""
                };
                DataService.create("reservationoverview", $scope.fridayParameters, function (data) {
                    $scope.fridayReservations = data;
                });

            }
        }
    });
}());

