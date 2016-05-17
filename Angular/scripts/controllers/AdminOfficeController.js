(function () {

    var app = angular.module("school");

    app.controller("AdminOfficeController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "admindashboard";
        var num = "2";
        fetchData();

        function fetchData() {

            DataService.read(dataSet, num, function (data) {
                $scope.dashboard = data;
            });
        }


        $scope.permissions = {
            showAdminIT: currentUser.roles.indexOf("ITOfficer") > -1,
            showAdminOfficer: currentUser.roles.indexOf("OfficeManager") > -1

        }


    

    });
}());
