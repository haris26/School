(function(){

    var app = angular.module("school", []);

    app.controller("MainCtrl", function($scope, $http) {

        var onComplete = function(response) {
            $scope.people = response.data;
            $scope.message = "";
        };

        var onError = function(reason) {
            $scope.message = "No data for that request";
        };

        $scope.selPerson = "";
        $scope.sortOrder = "lastName";
        var promise = $http.get("http://localhost:50169/api/people");
        $scope.message = "Wait...";
        promise.then(onComplete, onError);
    });

    app.directive("schOsoba", function() {
        return {
            restrict: "E",
            scope: true,
            replace: false,
            transclude: true,
            template: "<div>Employee: {{ person.FirstName }} {{ person.LastName }}<br>E-mail: {{ person.email }}, Phone: {{ person.phone }}<hr></div>"
        };
    });

}());

