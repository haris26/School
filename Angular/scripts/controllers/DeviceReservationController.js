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

    });
}());