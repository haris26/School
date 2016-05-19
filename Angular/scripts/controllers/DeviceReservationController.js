(function () {

    var app = angular.module("school");

    app.controller("DeviceReservationController", function ($scope, $rootScope, DataService, $modal, DeviceService, toaster) {

        $scope.permission = {
            showAdmin: currentUser.roles.indexOf("Admin") > -1
        }

        var dataSet = "characteristics";
        DeviceService.getOsType();

        $scope.Type = "";
        $scope.showBtn = false;
      
        $rootScope.refreshPage = function () {
            DeviceService.getOsType();
        }

        $scope.getDevices = function () {
            DataService.read(dataSet, "?type=" + $scope.Type, function (data) {
                $scope.devices = data;
                $scope.deviceCharacteristics = false;
            });
        }

        $scope.resourceName = "";
        $rootScope.getParameters = function () {
            $scope.showBtn = true;
            $scope.searchParameters = {
                fromDate: new Date(),
                toDate: new Date(),
                categoryName: "Device",
                resourceName: $scope.resourceName,
                osType: $scope.Type
            };
        };
        $scope.searchParameters = {
            fromDate: new Date(),
            toDate: new Date(),
            categoryName: "Device",
            resourceName: $scope.resourceName,
            osType: $scope.Type
        };
       
        $scope.getReservations = function ()
        {
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                $scope.reservations = data;
                console.log($scope.reservations);
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
       $scope.editDevice = function (item) {
           DeviceService.getDeviceType();

           $scope.device = {
               id: item.id,
               name: item.name,
               recourceCategory: 1
           }
           $scope.deviceTypeCharac = {
               id: item.characteristics[0].id,
               name: item.characteristics[0].name,
               value: item.characteristics[0].value,
               resource: item.id
           }
           $scope.osTypeCharac = {
               id: item.characteristics[1].id,
               name: item.characteristics[1].name,
               value: item.characteristics[1].value,
               resource: item.id
           }
           $scope.osVersionCharac = {
               id: item.characteristics[2].id,
               name: item.characteristics[2].name,
               value: item.characteristics[2].value,
               resource: item.id
           }
           var modalInstance = $modal.open({
               templateUrl: 'views/modals/editDeviceModal.html',
               controller: 'EditDeviceModalCtrl',
               windowClass: 'app-modal-window',
               backdrop: 'static',
               size: 'md',
               scope: $scope
           });
           
       };
      
    });
}());

