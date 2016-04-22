(function () {

    var app = angular.module("school");

    app.controller("DeviceReservationController", function ($scope, $rootScope, DataService, toaster) {

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

       $scope.getReservations = function () {
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                $scope.reservations = data;
                console.log(data);
                console.log($scope.reservations.characteristics[0].name);
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
       $scope.images = {
           iOS: "images/iosBlue.png",
           Android: "images/androidBlue.png",
           Windows: "images/windowsBlue.png",
           OsVersion: "images/versionBlue.png",
           Quantity: "images/quantityBlue.png",
           Mobile: "images/mobile2.png",
           Tablet: "images/tablet2.png"
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
       $scope.pop = function () {
           toaster.pop('note', "Haris", "bravo majstore");
       }
    });
}());

