(function () {

    var app = angular.module("school");

    app.controller("NewAssetController", function ($scope, $rootScope, toaster, DataService, $location, $route) {

        $scope.modal = false;
        var dataSet = "assets";
        getdeviceCategories();
        getofficeCategories();
        getAssets();

        $rootScope.model = {};
      
        function getdeviceCategories() {
            DataService.list("assetcategories", function (data) {
                $scope.deviceCategories = data.deviceCategories;
            });
        };

        function getofficeCategories() {
            DataService.list("assetcategories", function (data) {
                $scope.officeCategories = data.officeCategories;
            });
        };

        function getAssets() {
            DataService.list("assets", function (data) {
                $scope.assets = data.allAssets;
            });
        };

      



        errorPop = function () {
            toaster.pop('error', "Error", " All fields are required!");
        };
       
        pop = function () {
            toaster.pop('success', "Success", " You assigned this asset!");
        };

      

        $scope.addAsset = function (item) {
            $scope.asset = {
                id: 0,
                name: "",

                model: "",
                serialNumber: "",
                vendor: "",
                price: "",
                dateOfTrade: new Date(),
                status: 2,
                category: $scope.selectedCategory.id,
                categoryName: $scope.selectedCategory.categoryName
            }

           
        };

        $scope.saveData = function () {
            
     
            console.log($scope.asset);
            if ($scope.asset.serialNumber == "" || $scope.asset.vendor == "" ) {
                errorPop();
                return
            } else {
            
                DataService.create(dataSet, $scope.asset, function (data) { });

                pop();
              
               
               
            }
        }


         
     

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }



      
    });
}());