(function(){

    var app = angular.module("school", []);

    app.controller("MainCtrl", function($scope, DataService) {

        $scope.selPerson = "";
        $scope.sortOrder = "lastName";
        fetchPeople();

        function fetchPeople() {
            $scope.message = "Wait...";
            DataService.list().then(
                function(response) {
                    $scope.people = response.data;
                    $scope.message = "";
                },
                function(reason) {
                    $scope.message = "No data for that request";
                }
            );
        }

        $scope.transfer = function(item) {
            $scope.person = item;
        };

        $scope.newPerson = function() {
            $scope.person = {
                id: 0,
                firstName: "",
                lastName: "",
                email: "",
                phone: "",
                category: "Full",
                gender: "",
                address: "",
                birthDate: "",
                startDate: new Date(),
                status: "Active"
            }
        };

        $scope.saveData = function() {
            var promise;
            if ($scope.person.id == 0){
                promise = DataService.create($scope.person);
            }
            else {
                promise = DataService.update($scope.person.id, $scope.person);
            }
            promise.then(
                function(response){ window.alert("data saved!");},
                function(reason){ window.alert("something went wrong!");});
        }
    });

}());
