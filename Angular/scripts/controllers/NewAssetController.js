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

          
            $scope.transfer = function transfer(item) {
                $rootScope.model = item;
                $scope.asset= item;
            }


        $scope.saveData = function () {
            if ($scope.asset.serialNumber == "") {
                errorPop();
                return
            } else {
                DataService.create(dataSet, $scope.asset, function (data) {
                    $scope.savedasset = data;
                    console.log($scope.savedasset);
                    $scope.chars = {
                        id: 0,
                        name: $scope.name,
                        value: $scope.value,
                        asset: $scope.savedasset,
                        assetName:$scope.savedasset.name
                    }

                });                
                $scope.transfer($scope.asset); 
                pop();
                $location.path("/free");
                }    
        }
        console.log($scope.savedasset);

       
        $scope.addChars = function () {
            //if ($scope.asset.serialNumber == "") {
            //    errorPop();
            //    return
            //} else {
        
            DataService.create("assetchars", $scope.chars, function (data) { });
            console.log($scope.chars);
                pop();
            //}
        }



        $scope.setCategory = function () {
            $scope.asset.category = $scope.selectedCategory.id
            $scope.asset.categoryName = $scope.selectedCategory.categoryName

        }
        });

    }());