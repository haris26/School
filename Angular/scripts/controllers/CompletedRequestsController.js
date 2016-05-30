(function () {

    var app = angular.module("school");

    app.controller("CompletedRequestsController", function ($scope, $rootScope, DataService, $route, $location) {


        var dataSet = "requests";
      
        getOfficerequests();
        getDevicerequests();
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.requests = data.allRequests;
            });
        }
        function getOfficerequests() {
            DataService.list(dataSet, function (data) {
                $scope.completedOfficerequests= data.completedOfficeRequests;
            });
        };

        function getDevicerequests() {
          
                DataService.list(dataSet, function (data) {
                    $scope.completedrequests = data.completedDeviceRequests;
                
               
            });
        };

       

      

       

        
       
    });

}());