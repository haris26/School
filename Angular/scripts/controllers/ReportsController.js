(function () {

    var app = angular.module("school");


    app.controller("ReportsController", function ($scope, $rootScope, DataService) {
        var dataSet = "reports";       
        getUsers();


        $scope.fetchData = function () {
            var user = $scope.selectedUser.id;
            var type = $scope.requestType;
            var status = $scope.requestStatus;
            console.log(user);
            DataService.read2(dataSet, user, status, type, function (data) {
                $scope.reports = data;
            });
        }

        function getUsers() {
            DataService.list("people", function (data) {
                $scope.users = data;
            })
        }
      
    });
}());