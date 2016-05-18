(function () {

    var app = angular.module("school");

    app.controller("NewAssetController", function ($scope, $rootScope, toaster, DataService, $location, $route) {

        $scope.modal = false;
        var dataSet = "assets";
        getdeviceCategories();
        getofficeCategories();
        getCharacteristics()
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

        function getCharacteristics() {
            DataService.list("assetcharacteristicnames", function (data) {
                $scope.assetNames = data;

            });
        };

      



        errorPop = function () {
            toaster.pop('error', "Error", " All fields are required!");
        };
       
        pop = function () {
            toaster.pop('success', "Success", " You added asset!");
        };

        //$scope.asset = {
        //    id: 0,
        //    name: "",
        //    model: "",
        //    serialNumber: "",
        //    vendor: "",
        //    price: "",
        //    dateOfTrade: new Date(),
        //    status: 2,
        //    category: 0,
        //    categoryName: ""
        //}

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
                category: 0,
                categoryName:""
            }
         
        };


        $scope.saveData = function (item) {
            $scope.asset = {


                serialNumber: item.serialNumber,
                vendor: item.vendor,
                price: item.price,
                dateOfTrade: new Date(),
                status: 2,
                category:$scope.item.selectedCategory.id,
                categoryName: $scope.item.selectedCategory.categoryName
            }
     
            
      
            if ($scope.item.serialNumber == "" || $scope.item.vendor == "" ) {
                errorPop();
                return
            } else {

               
                console.log("kakav je ovdje", $scope.selectedCategory);
                console.log("nikakav", $scope.asset.category);
                DataService.create(dataSet, $scope.asset, function (data) {
                    console.log($scope.asset);
                });
                pop();
            }
        }



        $scope.setCategory = function () {
            console.log($scope.selectedCategory);
            $scope.category = $scope.selectedCategory.id;
            $scope.categoryName = $scope.selectedCategory.categoryName

         
        }
     

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }

        

      
    });
}());