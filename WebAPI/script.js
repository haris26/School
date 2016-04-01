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
        var promise = $http.get("http://localhost:61310/api/people/");
        $scope.message = "Wait...";
        promise.then(onComplete, onError);
    });

    app.directive("schOsoba", function() {
        return {
            restrict: "E",
            scope: true,
            replace: false,
            transclude: true,
            template: "<div>Employee: {{ person.firstName }} {{ person.lastName }}<br>E-mail: {{ person.email }}, Phone: {{ person.phone }}<hr></div>"
        };
    });



app.directive("schoolPerson", function() {
    return {
        restrict: "AE",
        scope: true,
        transclude: true,
        templateUrl: "view10.html",
        link: function(scope, elem, attrs) {
            elem.bind('click', function(){ elem.css('font-size', '30px')});
            elem.bind('mouseover', function(){ elem.css('color', 'red'); });
            elem.bind('mouseout', function () { elem.css('color', 'green'); });
            elem.bind('mouseout', function () { elem.css('font-size', '16px'); });
        }
    };
});

}());
