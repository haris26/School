(function () {

    var app = angular.module("school", []);

    app.controller("MainCtrl", function ($scope, DataService) {

        $scope.selRequests = "";
        $scope.sortOrder = "Model";
        fetchRequests();

        function fetchRequests() {
            $scope.message = "Wait...";
            DataService.list().then(
                function (response) {
                    $scope.items= response.data.allRequests;
                    $scope.message = "";
                    console.log($scope.items);
                },
                function (reason) {
                    $scope.message = "No data for that request";
                }
            );
        }
        
        $scope.transfer = function (item) {
            $scope.request = item;
        };

       
       

        $scope.saveData = function () {
            var promise;
            if ($scope.person.id == 0) {
                promise = DataService.create("requests",$scope.requests);
            }
            else {
                promise = DataService.update($scope.person.id, $scope.requests);
            }
            promise.then(
                function (response) { window.alert("data saved!"); },
                function (reason) { window.alert("something went wrong!"); });
        }
    });

}());
