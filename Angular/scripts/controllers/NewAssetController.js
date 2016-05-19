(function () {

    var app = angular.module("school");

    app.controller("NewAssetController", function ($scope, $rootScope, toaster, DataService, $location, $route) {


        var dataSet = "assets";
        getCategories();
        fetchData();
        $scope.asset = {};
        $scope.chars = {};
      
        function getCategories() {
            DataService.list("assetcategories", function (data) {
                $scope.devicecategories = data.deviceCategories;
            });
        };


        


        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.assets = data.allAssets;
            });
        }

        pop = function () {
            toaster.pop('success', "Success", " You added a new asset!");
        };

        errorPop = function () {
            toaster.pop('error', "Error", " All fields are required!");
        };

       

       
            $scope.asset = {
                id: 0,
                name: "",
                user: 0,
                userName:"",
                model: "",
                serialNumber:"",
                vendor:"",
                price: "",
                dateOfTrade: new Date(),
                status: 2,
                category: 0,
                categoryName:""
            }

            $scope.chars = {
                id: 0,
                name: "",
                value: "",
                asset: $scope.asset.id,
                assetName:""
            }


            $scope.transfer = function transfer(item) {
                $rootScope.model = item;
            }


        $scope.saveData = function () {
            if ($scope.asset.serialNumber == "") {
                errorPop();
                return
            } else {
                DataService.create(dataSet, $scope.asset, function (data) { });

              
 
                pop();     
                }    
        }


        $scope.addChars = function () {
            //if ($scope.asset.serialNumber == "") {
            //    errorPop();
            //    return
            //} else {
            DataService.create("assetchars", $scope.chars, function (data) { });
            console.log($scope.chars);
            console.log($scope.asset);
              

                pop();
            //}
        }



        $scope.setCategory = function () {
            $scope.asset.category = $scope.selectedCategory.id
            $scope.asset.categoryName = $scope.selectedCategory.categoryName

        }
        });

    }());