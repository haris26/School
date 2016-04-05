(function () {

    var app = angular.module("school", []);

    app.controller("MainCtrl", function ($scope, $http) {

        var onComplete = function(response) {
            $scope.events = response.data;
            $scope.message = "";
        };
        var onError = function (reason) {

            $scope.message = "No data for that request";
        };

        $scope.selEvn = "";
        $scope.sortOrder = "eventTitle";
        var promise = $http.get("http://localhost:50169/api/events/");
        $scope.message = "Wait...";
        promise.then(onComplete, onError);

        $scope.transfer = function(item) {
            $scope.ev = item;
        };

        $scope.newEvent = function() {
            $scope.ev = {
                id: 0,
                eventTitle: "",
                startDate: new Date(),
                endDate: new Date(),
                resourceName: "",
                personName: ""
            }
        };

        $scope.saveData = function () {
            var promise;
            if ($scope.ev.id == 0){
                promise = $http({
                    method: "post",
                    url: "http://localhost:50169/api/events/",
                    data: $scope.ev
                })
            }
            else {
                promise = $http({
                    method: "put",
                    url: "http://localhost:50169/api/events/" + $scope.ev.id,
                    data: $scope.ev
                })
            }
            promise.then(
                function (response) { window.alert("data saved!"); },
                function (reason) { window.alert("something went wrong!"); });
        }
    });

}());

