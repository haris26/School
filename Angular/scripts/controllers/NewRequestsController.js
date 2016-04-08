(function () {

    var app = angular.module("school");

    app.controller("NewRequestsController", function ($scope, $rootScope, DataService) {

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

       

        $scope.newRequest = function () {
            $scope.request = {
                id: 0,
                person: 6,
                personName:"",
                category: 0,
                categoryName:"",
                asset:0,
                requestMessage:"",
                requestDescription:"",
                requestDate: new Date().Date,
                status:"In process",
                requestType: "Equipment",
                assetType: "",
             
               
            }
        };
       

        $scope.saveData = function () {
            var promise;
            if ($scope.request.id == 0) {
                DataService.create(dataSet, $scope.request, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.request.id, $scope.request, function (data) { });
            }
            fetchData();
        }

        $scope.setCategory = function () {
            $scope.request.category = $scope.selectedCategory.id
            $scope.request.assetType=$scope.selectedCategory.type
           
          
        }
    });

}());