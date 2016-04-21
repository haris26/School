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

        $scope.images = {
            iOS: "images/iosBlue.png",
            Android: "images/androidBlue.png",
            Windows: "images/windowsBlue.png",
            OsVersion : "images/versionBlue.png",
            Quantity : "images/quantityBlue.png"
        }

        $scope.setCharacteristics = function (item) {
            $scope.typeValue = "";
            $scope.verValue = "";
            $scope.quantValue = "";

            if (item.name == "OsType") {
                if (item.value == "iOS") {
                    $scope.ios = true;
                    $scope.typeValue = item.value;
                }
                else if (item.value == "Android") {
                    $scope.android = true;
                    $scope.typeValue = item.value;
                }
                else if (item.value == "Windows") {
                    $scope.win = true;
                    $scope.typeValue = item.value;
                }
            }
            if (item.name == "OsVersion") {
                $scope.version = true;
                $scope.verValue = item.value;
            }
            if (item.name == "Quantity") {
                $scope.quantity = true;
                $scope.quantValue = item.value;
                console.log($scope.quantity);
            }
            
        }

        $scope.getReservations = function () {
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                $scope.reservations = data;
                console.log(data);
            });
            $scope.deviceCharacteristics = true;
        }
    });
}());

