(function () {

    var app = angular.module("school");

    app.controller("CompletedRequestsController", function ($scope, $rootScope, DataService, $route, $location) {


        var dataSet = "allrequests";
        $scope.selRequest = "";
        $scope.sortOrder = "requestType";
        getOfficerequests();
        getDevicerequests();


       
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