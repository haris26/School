(function () {

    var app = angular.module("school");

    app.controller("AdminDashboardController", function ($scope, $rootScope, DataService, schConfig, $route) {
        var dataSet = "admindashboard";
        var num="1";
        fetchData();
        $scope.selString = "";
        $scope.sortOrder = "userName";
        $rootScope.model = {};
       

        function fetchData() {

            DataService.read(dataSet,num, function (data) {
                $scope.dashboard = data;
            });
        }

        function getRequests() {
            DataService.list(dataSet, function (data) {
                $scope.requests = data.allRequests;
            });
        };
        
        $scope.permissions = {
            showAdminIT: currentUser.roles.indexOf("ITOfficer") > -1,
            showAdminOfficer: currentUser.roles.indexOf("OfficeManager") > -1
      
        }

        $scope.changeStatus = function (item) {
            $scope.request = {
                id: item.id,
                requestMessage: item.message,
                requestDescription: item.description,
                requestType: item.type,
                requestDate: Date.now(),
                quantity: item.quantity,
                assetType: item.assetType,
                category: item.category,
                person: item.user,
                status: item.status
            }
            DataService.update("admindashboard", $scope.request.id, $scope.request, function (data) { });
            //$location.path("/servicerequests");
            console.log($scope.request);
         
            $route.reload();
        }

        $scope.transfer = function (item) {
            $scope.requests = item;
        };
       
    });
}());
