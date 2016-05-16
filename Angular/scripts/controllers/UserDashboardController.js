(function () {

    var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope,$log, $rootScope,toaster, DataService, schConfig, $modal, $route) {
        var dataSet = "dashboard";
 
        $scope.buttonView = false;
        $scope.selString = "";
        $scope.sortOrder = "";
        $rootScope.model = {};
       
     
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }
        fetchData();

        $scope.transfer = function transfer(item) {
            $rootScope.model = item;
        }

        pop = function () {
            toaster.pop('success', "Success", " Your request is canceled!");

        };

        $scope.getRequest = function (item) {
            $scope.requestId = item.id;
            $scope.confirmed = {
                isConfirmed: false
            }

            var modalInstance = $modal.open({
                templateUrl: 'views/cancelRequestModal.html',
                controller: 'CancelReqCtrl',
                size: 'sm',
                
                resolve: {
                    confirmed: function () {
                        return $scope.confirmed;
                    }
                }
            }).result.then(function (result) {
                $scope.isConfirmed = result;
                DataService.delete("requests", $scope.requestId, function (data) { });
                pop();
                fetchData();
                $route.reload();
            })
            
        }
    });
}());
