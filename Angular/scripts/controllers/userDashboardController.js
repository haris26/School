(function () {

    var app = angular.module("school", []);

    app.controller("UserDashboardController", function ($scope, DataService) {

      fetchResources();

        function fetchResources() {
            $scope.message = "Wait...";
            DataService.getDashboard().then(
                function (response) {
                    $scope.dashboard = response.data;
                    $scope.message = "";
                },
                function (reason) {
                    $scope.message = "No data for that request";
                }
            );
        }
      });

}());