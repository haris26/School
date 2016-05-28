(function () {

    var app = angular.module("school");

    app.controller("NewRequestsController", function ($scope, $rootScope, toaster, DataService, $location,$route) {


        var dataSet = "requests";
        getCategories();       
        fetchData();
               
        function getCategories() {
            DataService.list("assetcategories", function (data) {
                $scope.categories = data.allCategories;
            });
        };
            
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.requests= data.allRequests;
            });
        }
      
        pop = function () {
            toaster.pop('success', "Success", " Your request is sent!");
        };

        errorPop = function () {
            toaster.pop('error', "Error", " All fields are required!");
        };

        $scope.newRequest = function () {
            $scope.request = {
                id: 0,
                person: currentUser.id,
                personName:"",
                category: 0,
                categoryName:"",
                asset:0,
                requestMessage:"",
                requestDescription:"",
                requestDate: new Date(),
                status:1,
                requestType: "New",
                assetType: "",
                serviceType:0,
            }
        };
       
        console.log($scope.newRequest);
        $scope.saveData = function () {
            var promise;
            if($scope.request.requestDescription == "" || $scope.request.requestMessage == "" || $scope.request.quantity == null)
            {
                errorPop();
                return
            } else
            {
                
                    DataService.create(dataSet, $scope.request, function (data) { });
                    pop();
                    console.log($scope.request);
                    $route.reload();             
                    $location.path("/usernewrequests")
                
                
            }
        }
       

        $scope.setCategory = function () {
            $scope.request.category = $scope.selectedCategory.id
            $scope.request.categoryName = $scope.selectedCategory.categoryName

            $scope.request.assetType = $scope.selectedCategory.type

        }
    });

}());