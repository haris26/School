(function () {

    var app = angular.module("school");

    app.controller("DeviceReservationController", function ($scope, $rootScope, DataService) {

        var dataSet = "characteristics";
        getOsType();

        $scope.Type = "";
        $scope.showBtn = false;
      
        function getOsType() {
            DataService.read(dataSet, "?type=OsType", function (data) {
                $scope.osType = data;
            });
        }

        $scope.getDevices = function () {
            DataService.read(dataSet, "?type=" + $scope.Type, function (data) {
                $scope.devices = data;
                $scope.deviceCharacteristics = false;
            });
        }

        $scope.resourceName = "";
        $scope.getParameters = function () {
            $scope.showBtn = true;
            $scope.searchParameters = {
                fromDate: new Date(),
                toDate: new Date(),
                categoryName: "Device",
                resourceName: $scope.resourceName,
                osType: $scope.Type
            };
        };

        $scope.getReservations = function ()
        {
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                $scope.reservations = data;
                    $scope.mobile = false;
                    $scope.tablet = false;
                    if ($scope.reservations.characteristics[0].name == "DeviceType") {
                        if ($scope.reservations.characteristics[0].value == "MobilePhone") {
                            $scope.mobile = true;
                        }
                        else if ($scope.reservations.characteristics[0].value == "Tablet") {
                            $scope.tablet = true;
                        }
                    }                
            });
            setCharacteristics();
            $scope.deviceCharacteristics = true;
        }
        $rootScope.refreshTable = function() {
            $scope.getReservations();
        }
       $scope.images = {
           iOS: "images/iosYes.png",
           Android: "images/androidYes.png",
           Windows: "images/windowsYes.png",
           OsVersion: "images/versionYes.png",
           Quantity: "images/quantityYes.png",
           Mobile: "images/mobile.png",
           Tablet: "images/tablet.png"
       }

       function setCharacteristics () {
           $scope.ios = false;
           $scope.android = false;
           $scope.windows = false;

            if ($scope.Type == "iOS") {
                $scope.ios = true;
            }
            else if ($scope.Type == "Android") {
                $scope.android = true;
            }
            else if ($scope.Type == "Windows") {
                $scope.windows = true;
            }                     
       }

    });
}());

