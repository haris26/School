(function () {

    var app = angular.module("school");

    app.controller("AllRequestsController", function ($scope, $rootScope, toaster, DataService, $route, $location) {


        var dataSet = "requests";
        $scope.selString = "";
        $scope.sortOrder = "";

        $scope.currentPage = 1;
        $scope.pageSize = 10;

        getRequests();

        fetchData();
        getDeviceRequests();
        getOfficeRequests();
        getCompleted();

        function getRequests() {
            DataService.list(dataSet, function (data) {
                $scope.requests = data.allRequests;
               
            });
        };

        function getOfficeRequests() {
            DataService.list(dataSet, function (data) {
                $scope.officerequests = data.officeRequests;
            });
        };

       

        function getDeviceRequests() {
            DataService.list(dataSet, function (data) {
                $scope.devicerequests = data.deviceRequests;
            });
        };



        pop = function () {
            toaster.pop('success', "Success", " You have changed status of request!");

        };

        $scope.changeStatus = function (item) {
            $scope.request = {
                id: item.id,
                requestMessage: item.requestMessage,
                requestDescription: item.requestDescription,
                requestType: 1,
                requestDate: Date.now(),
                quantity: item.quantity,              
                assetType: item.assetType,
                category: item.category,
                categoryName: item.categoryName,
                person: item.person,
                personName:item.personName,
                status: item.status,
                email: item.email,
                serviceType: item.serviceType

            }
            DataService.update("requests", $scope.request.id, $scope.request, function (data) { });
            pop();
            //$location.path("/servicerequests");

            $route.reload();
            getRequests();
            $location.path("/requests")
        }

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.requests= data.allRequests;
            });
        }

      

        $scope.transfer = function (item) {
            $scope.requests = item;
            
        };      
    });
}());