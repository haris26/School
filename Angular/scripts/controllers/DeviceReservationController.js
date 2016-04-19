(function () {

    var app = angular.module("school");

    app.controller("DeviceReservationController", function ($scope, $rootScope, DataService) {

        var dataSet = "characteristics";
        getOsType();

        $scope.Type = "";
      
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
        $scope.searchParameters = {
            fromDate: Date.now,
            toDate: Date.now,
            categoryName: "Device",
            resourceName: $scope.resourceName,
            osType: $scope.Type
        }

        $scope.getReservations = function () {
            console.log($scope.Type);
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                console.log(data);
                $scope.reservations = data;
                
            });
        }
    });
}());