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
    app.directive("schoolPerson", function () {
        return {
            restrict: "AE",
            scope: true,
            transclude: true,
            templateUrl: "view10.html",
            link: function (scope, elem, attrs) {
                elem.bind('click', function () { elem.css('background-color', 'yellow'); });
                elem.bind('mouseover', function () { elem.css('color', 'red'); });
                elem.bind('mouseout', function () { elem.css('color', 'green'); });
            }
        };
    });

}());

