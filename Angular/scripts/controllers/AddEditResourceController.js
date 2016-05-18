(function () {

    var app = angular.module("school");

    app.controller("AddEditResourceController", function ($scope, $rootScope, DataService) {
        
        var dataSet = "resourcecategories";
        getResourceCategories();

        $scope.resCategory = "";

        $scope.devType = "";
        $scope.oType = "";
        $scope.osVersion = "";
        
        $scope.chairNum = "";
        $scope.speaker = "";
        $scope.tv = "";
        $scope.whiteBoard = "";

        $scope.device = false;
        $scope.room = false;

        function getResourceCategories() {
            DataService.list(dataSet, function (data) {
                $scope.categories = data;
                console.log($scope.categories);
            });
        };
        function getOsType() {
            DataService.read("characteristics", "?type=OsType", function (data) {
                $scope.osType = data;
            });
        }
        function getDeviceType() {
            DataService.read("characteristics", "?type=DeviceType", function (data) {
                $scope.deviceType = data;
            });
        }
        $scope.getForm = function () {
            if ($scope.resCategory == "Device") {
                $scope.device = true;
                $scope.room = false;
                getOsType();
                getDeviceType();
            };
            if ($scope.resCategory == "Room") {
                $scope.room = true;
                $scope.device = false;
            };
        };
        
        $scope.addDevice = function () {
            $scope.newDevice = {
                id: 0,
                name: $scope.deviceName,
                resourceCategory: 1,
                resourceCategoryName: $scope.resCategory
            };
            DataService.create("resources", $scope.newDevice, function (data) {
                $scope.deviceId = data;
                $scope.deviceTypeCharac = {
                    id: 0,
                    name: "DeviceType",
                    value: $scope.devType,
                    resource: $scope.deviceId
                };
                $scope.osTypeCharac = {
                    id: 0,
                    name: "OsType",
                    value: $scope.oType,
                    resource: $scope.deviceId
                };
                $scope.osVersionCharac = {
                    id: 0,
                    name: "OsVersion",
                    value: $scope.osVersion,
                    resource: $scope.deviceId
                };
                DataService.create("characteristics", $scope.deviceTypeCharac, function (data) {
                    DataService.create("characteristics", $scope.osTypeCharac, function (data) {
                        DataService.create("characteristics", $scope.osVersionCharac, function (data) { });
                    });
                });
            });            
        }
        $scope.addRoom = function () {
            $scope.newRoom = {
                id: 0,
                name: $scope.roomName,
                resourceCategory: 2,
                resourceCategoryName: $scope.resCategory
            };
            DataService.create("resources", $scope.newRoom, function (data) {
                $scope.roomId = data;
                $scope.numOfChairsCharac = {
                    id: 0,
                    name: "NumberOfChairs",
                    value: $scope.chairNum,
                    resource: $scope.roomId
                };
                $scope.speakerCharac = {
                    id: 0,
                    name: "Speaker",
                    value: $scope.speaker,
                    resource: $scope.roomId
                };
                $scope.tvCharac = {
                    id: 0,
                    name: "TV",
                    value: $scope.tv,
                    resource: $scope.roomId
                };
                $scope.whiteBoardCharac = {
                    id: 0,
                    name: "WhiteBoard",
                    value: $scope.whiteBoard,
                    resource: $scope.roomId
                };
                DataService.create("characteristics", $scope.numOfChairsCharac, function (data) {
                    DataService.create("characteristics", $scope.speakerCharac, function (data) {
                        DataService.create("characteristics", $scope.tvCharac, function (data) {
                            DataService.create("characteristics", $scope.whiteBoardCharac, function (data) { })
                        });
                    });
                });
            });
        }
    });

}());