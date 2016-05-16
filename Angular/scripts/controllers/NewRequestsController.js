(function () {

    var app = angular.module("school");

    app.controller("NewRequestsController", function ($scope, $rootScope, toaster, DataService, $location,$route) {


        var dataSet = "requests";
        getCategories();       
        fetchData();
               
        function getCategories() {
            DataService.list("assetcategories", function (data) {
                $scope.categories = data;
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
       
        $scope.saveData = function () {
            var promise;
            if($scope.request.requestDescription == "" || $scope.request.requestMessage == "" || $scope.request.quantity == null)
            {
                errorPop();
                return
            }else{
                //if ($scope.request.id == 0) {
                    DataService.create(dataSet, $scope.request, function (data) { });
                    pop();
                    console.log($scope.request);
                    $route.reload();             
                    $location.path("/usernewrequests")
                //}else {
                //    DataService.update(dataSet, $scope.request.id, $scope.request, function (data) { });
                //    pop();
                //    console.log($scope.request);
                //    $route.reload();
                //    fetchData();
                //    $location.path("/usernewrequests")
                //}
                
            }
        }
       

        $scope.setCategory = function () {
            $scope.request.category = $scope.selectedCategory.id
            $scope.request.categoryName = $scope.selectedCategory.categoryName

            $scope.request.assetType = $scope.selectedCategory.type

        }
    });

}());