(function () {

    var app = angular.module("school");

    app.factory("DeviceService", function ($rootScope, DataService) {
        return {
            getDeviceType: function() {
                DataService.read("characteristics", "?type=DeviceType", function (data) {
                    $rootScope.deviceType = data;
                });
            },
            getOsType: function() {
            DataService.read("characteristics", "?type=OsType", function (data) {
                $rootScope.osType = data;
            });
        }
        }
    });

}());