(function () {

    var app = angular.module("school");

    app.controller("WeeklyRoomReservationController", function ($scope, $rootScope, DataService) {

        $scope.searchParameters = {
            fromDate: new Date(),
            toDate: new Date(),
            categoryName: "Room",
            resourceName: "",
            osType: ""
        };
  
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
        $scope.getWeekReservations = function (item) {
           
            if (item.weekStart < item.today && $scope.disable) {
                
                $scope.setAccordion.mondayDisabled = true;
            }
            if (item.weekStart >= item.today || !$scope.disable) {
                $scope.setAccordion.mondayDisabled = $scope.disable;
                if (item.weekStart == item.today && $scope.disable) {
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

            if (item.tuesday < item.today && $scope.disable) {

                $scope.setAccordion.tuesdayDisabled = true;
            }
            if (item.tuesday >= item.today || !$scope.disable) {
                $scope.setAccordion.tuesdayDisabled = $scope.disable;
                if (item.tuesday == item.today && $scope.disable) {
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
            
            if (item.wednesday < item.today && $scope.disable) {

                $scope.setAccordion.wednesdayDisabled = true;
            }
            if (item.wednesday >= item.today || !$scope.disable) {
                $scope.setAccordion.wednesdayDisabled = false;
                if (item.wednesday == item.today) {
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

            if (item.thursday < item.today && $scope.disable) {

                $scope.setAccordion.thursdayDisabled = true;
            }
            if (item.thursday >= item.today || !$scope.disable) {
                $scope.setAccordion.thursdayDisabled = false;
                if (item.thursday == item.today) {
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

            if (item.weekEnd < item.today && $scope.disable) {

                $scope.setAccordion.fridayDisabled = true;
            }
            if (item.weekEnd >= item.today || !$scope.disable) {
                $scope.setAccordion.fridayDisabled = false;
                if (item.weekEnd == item.today) {
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

