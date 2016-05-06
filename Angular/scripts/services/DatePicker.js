(function () {

    var app = angular.module("school");

    app.directive("datePicker", function ($modal, schConfig, DataService) {
        return {
            restrict: "AE",
            replace: true,
            templateUrl:"views/datePicker.html",
            link: function (scope, elem, attrs) {
                scope.show = true;
                //console.log(scope);
                if (attrs.type == "daily") {
                    scope.show = false;
                }
                scope.day = {
                    today: "",
                    type: attrs.type,
                    step: 0
                };
                var count = 0;
                   getDay= function (){
                   DataService.create("datepicker", scope.day, function (data) {
                       scope.newDay = data;
                   });
               }
               getDay();

               scope.goNext = function () {
                   scope.day = {
                       today: "",
                       type: scope.day.type,
                       step: scope.day.step+1                      
                   }
                   //console.log("param", scope.searchParameters);
                   DataService.create("datepicker", scope.day, function (data) {
                       scope.newDay = data;
                       scope.searchParameters.fromDate = scope.newDay.weekStart;
                       scope.searchParameters.toDate = scope.newDay.weekEnd;
                       if (attrs.type == "daily") {
                           scope.searchParameters.fromDate = scope.newDay.today;
                           scope.searchParameters.toDate = scope.newDay.today;
                       }
                       scope.getReservations();                    
                   });
                   count++;
               }
               scope.goPrevious = function () {     
                   if (count != 0) {
                       scope.day = {
                           today: "",
                           type: scope.day.type,
                           step: scope.day.step - 1
                       }
                       DataService.create("datepicker", scope.day, function (data) {
                           scope.newDay = data;
                           scope.searchParameters.fromDate = scope.newDay.weekStart;
                           scope.searchParameters.toDate = scope.newDay.weekEnd;
                           scope.getReservations();
                       });
                       count--;
                   }
                } 
            }
        }
    });
}());
