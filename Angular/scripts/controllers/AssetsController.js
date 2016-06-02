(function () {

    var app = angular.module("school");

    app.controller("AssetsController", function ($scope, $rootScope, $location,toaster, DataService, $route) {

        $scope.modal = false;
        var dataSet = "assets";
        $scope.selString = "";
        $scope.sortOrder = "userName";
        $rootScope.model = {};
       
        fetchData();
        getPeople();
        getAssets();
      
        getDeviceAssets();
        getOfficeAssets();
        getAllDeviceAssets();
        getAllOfficeAssets();
        getFreeAssets();
        getFreeOfficeAssets();
        getOutOfStockAssets();

        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.assets = data.allAssets;
            });
        };
        
        function getOutOfStockAssets() {
            DataService.list("assets", function (data) {
                $scope.outofstockassets = data.outOfStockAssets;
            });
        };

      


        function getAllDeviceAssets() {
            DataService.list("assets", function (data) {
                $scope.alldeviceassets = data.allDeviceAssets;
            });
        };


        function getAllOfficeAssets() {
            DataService.list("assets", function (data) {
                $scope.allofficeassets = data.allOfficeAssets;
            });
        };

        function getFreeOfficeAssets() {
            DataService.list("assets", function (data) {
                $scope.freeofficeassets = data.officeFreeAssets;
               
            });
        };

        function getOfficeAssets() {
            DataService.list("assets", function (data) {
                $scope.officeassets = data.officeAssets;

            });
        };
        function getDeviceAssets() {
            DataService.list("assets", function (data) {
                $scope.deviceassets = data.deviceAssets;

            });
        };

      
        function getFreeAssets() {
            DataService.list("assets", function (data) {
                $scope.freeassets = data.freeAssets;
                console.log($scope.freeassets);
            });
        };

        function getPeople() {
            DataService.list("people", function (data) {
                $scope.users = data;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.assets = data.allAssets;
            });
        }

        $scope.permissions = {
            showAdminIT: currentUser.roles.indexOf("ITOfficer") > -1,
            showAdminOfficer: currentUser.roles.indexOf("OfficeManager") > -1

        }




        pop = function () {
            toaster.pop('success', "Success", " You assigned this asset!");
        };



        $scope.asset = {
            id: 0,
            name: "",
            user: 0,
            userName: "",
            model: "",
            serialNumber: "",
            vendor: "",
            price: "",
            dateOfTrade: new Date(),
            
            status: "",
            category: 0,
            categoryName: ""
        }


        $scope.assignDevice = function (item, selectedUser) {
            $scope.selectedUser = selectedUser;
            console.log($scope.selectedUser);
            $scope.asset = {
                id: item.id,
                name: item.name,
                user: selectedUser.id,
                userName: selectedUser.firstName + ' ' + selectedUser.lastName,
                model: item.model,
                serialNumber: item.serialNumber,
                vendor: item.vendor,
                price: item.price,
                dateOfTrade: item.dateOfTrade,
                dateOfAssign: item.dateOfAssign,
                status: 1,
                category: item.category,
                categoryName: item.categoryName
            }
            DataService.update("assets", $scope.asset.id, $scope.asset, function (data) { });
            console.log($scope.asset);
            $route.reload();
            pop();
            getAssets();
        }

        $scope.transfer = function(item) {
            $rootScope.model = item;
            $scope.asset = item;
            console.log($scope.asset);
        }


        $scope.transferasset = function(item) {
        
            $rootScope.asset = item;
           
        }
    });



    app.controller("EditAssetController", function ($scope, $rootScope, toaster, DataService, $route) {
     
        $scope.showcharacteristic = false;
        getCharacteristicNames();

        pop = function () {
            toaster.pop('success', "Success", " You edited asset!");
        };


        popchar = function () {
            toaster.pop('success', "Success", " You edited characteristic for this asset!");
        };

       
        $scope.showChars = function () {

            $scope.showcharacteristic = !$scope.showcharacteristic;
        }


        $scope.saveData = function (item) {
            
            console.log($scope.item);
            $scope.asset = {
                id: item.id,
                name: item.name,
                user:item.user,
                userName:item.userName,
                model: item.model,
                serialNumber: item.serialNumber,
                vendor: item.vendor,
                price: item.price,
                dateOfTrade: item.dateOfTrade,
                dateOfAssign: item.dateOfAssign,
                status: 1,
                category: item.category,
                categoryName: item.categoryName
            }

           
            DataService.update("assets", $scope.asset.id, $scope.asset, function (data) { });
            pop();
          
        }

        function getCharacteristicNames() {
            DataService.read("assetcategories", $scope.asset.id, function (data) {
              
           $scope.assetCharacteristics= data;
            });
        };
       


  

        $scope.saveNew = function (item) {

            $scope.char = {
                id: 0,
                name: item.name,
                value: item.value,
                asset: $scope.asset.id,
                assetName: ""
            }
            if ($scope.char.id == 0) {
                DataService.create("assetchars", $scope.char, function (data) { pop();});

            }
            else {
                DataService.update("assetchars", item.id, item, function (data) { popchar(); });
            
            }
           
        }

        
    });

}());



