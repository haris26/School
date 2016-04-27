(function () {

    var app = angular.module("school");

    app.directive("datePicker", function ($modal, schConfig) {
        return {
            restrict: "AE",
            replace:true,
            template:'<div>{{today}}</div>',
      
            link: function (scope, elem, attrs) {
                scope.today = new Date(1991, 2, 2);
                console.log(scope.today);
            }
            
        };
    });
}());
