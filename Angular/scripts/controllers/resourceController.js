(function () {

    var app = angular.module("school");

    app.controller("ResourceController", function ($scope, $rootScope, DataService) {

        var dataSet = "resources";
        $scope.showme = false;
        fetchData();
        getCharacteristics();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.resources = data;
            });
        }

        function getCharacteristics() {
            DataService.list("characteristics", function (data) {
                $scope.characteristics = data;
            });
        };

        $scope.createEvent = function ()
        {
            DataService.create("events", $scope.eventReservation, function (data) { });
            $scope.showme = false;
        }

        $scope.transfer = function (item) {
            $scope.resource = item;
            $scope.showme = true;
            $scope.eventReservation = {
                id: 0,
                eventTitle: "",
                startDate: new Date(),
                endDate: new Date(),
                resource: item.id,
                resourceName:item.name,
                category:item.category,
                categoryName:item.categoryName
            };
        };
        
        $scope.newResource = function () {
            $scope.resource = {
                id: 0,
                name: "",
                status: "",
                category: "",
                categoryName:""
            }
        };
        
        $scope.saveData = function () {
            var promise;
            if ($scope.resource.id == 0) {
                DataService.create(dataSet, $scope.resource, function (data) { });
            }
            else {
                DataService.update(dataSet, $scope.resource.id, $scope.resource, function (data) { });
            }
            fetchData();
        }

    });

}());
