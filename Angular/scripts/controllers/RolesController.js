(function(){

    var app = angular.module("school");

    app.controller("RolesCtrl", function($scope, $rootScope, DataService) {

        var dataSet = "roles";
        fetchRoles();

        function fetchRoles() {
            DataService.list(dataSet, function(data){
                $scope.roles = data;
            })
        }

        $scope.transfer = function(item) {
            $scope.role = item;
        };

        $scope.newRole = function() {
            $scope.role = {
                id: 0,
                name: "",
                system: "false",
                team: "false"
            }
        };

        $scope.saveData = function() {
            var promise;
            if ($scope.role.id == 0){
                promise = DataService.create(dataSet, $scope.role);
            }
            else {
                promise = DataService.update(dataSet, $scope.role.id, $scope.role);
            }
            promise.then(
                function(response){ window.alert("data saved!");},
                function(reason){ window.alert("something went wrong!");});
        };

        $scope.saveData = function() {
            if ($scope.role.id == 0){
                DataService.create(dataSet, $scope.role, function(data){});
            }
            else {
                DataService.update(dataSet, $scope.role.id, $scope.role, function(data){});
            }
            fetchRoles();
        }
    });
}());
