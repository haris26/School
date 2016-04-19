(function () {

    var app = angular.module("school");

    app.controller("PeopleController", function ($scope, DataService) {

        $scope.modal = false;
        var dataSet = "people";
        $scope.selPerson = "";
        $scope.sortOrder = "lastName";
        fetchPeople();

        function fetchPeople() {
            DataService.list("people", function (data) {
                $scope.people = data;
            });
        };

        $scope.transfer = function (item) {
            $scope.modal = true;
            $scope.person = item;
        };

        $scope.newPerson = function () {
            $scope.person = {
                id: 0,
                firstName: "",
                lastName: "",
                email: "",
                phone: "",
                category: "Full",
                gender: "",
                address: {},
                birthDate: "",
                startDate: new Date(),
                status: "Active"
            }
        };


        $scope.saveData = function() {
            if ($scope.person.id == 0){
                DataService.create(dataSet, $scope.person, function(data){fetchPeople()});
            }
            else {
                DataService.update(dataSet, $scope.person.id, $scope.person, function (data) { fetchPeople() });
            }
            $scope.modal = false;
            //fetchPeople();
        }
    });
}());