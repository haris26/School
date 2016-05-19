(function () {

    var app = angular.module("school");

    app.directive("datePicker", function ($modal, schConfig, DataService,$rootScope) {
        return {
            restrict: "AE",
            replace: true,
            templateUrl:"views/datePicker.html",
            link: function (scope, elem, attrs) {
                scope.show = true;
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
                       $rootScope.currentDay = scope.newDay;
                       if (attrs.view == "weekly") {
                           $rootScope.currentDay = scope.newDay;
                           scope.getWeekReservations(scope.newDay);
                       }                      
                   });
               }
                   getDay();
                   
               scope.goNext = function () {
                   scope.day = {
                       today: "",
                       type: scope.day.type,
                       step: scope.day.step+1                      
                   }
                   scope.status = 1;
                   DataService.create("datepicker", scope.day, function (data) {
                       scope.newDay = data;
                       $rootScope.currentDay = scope.newDay;
                       scope.searchParameters.fromDate = scope.newDay.weekStart;
                       scope.searchParameters.toDate = scope.newDay.weekEnd;
                       if (attrs.type == "daily") {
                           scope.searchParameters.fromDate = scope.newDay.today;
                           scope.searchParameters.toDate = scope.newDay.today;
                       }
                       if (attrs.view == "weekly") {
                           if (count == 0) {
                               scope.disable = true;
                           }
                           scope.disable = false;
                          
                           scope.getWeekReservations(scope.newDay);
                       }
                       else scope.getReservations();
                           
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
                       scope.status = 1;
                       DataService.create("datepicker", scope.day, function (data) {
                           scope.newDay = data;
                           $rootScope.currentDay = scope.newDay;
                           scope.searchParameters.fromDate = scope.newDay.weekStart;
                           scope.searchParameters.toDate = scope.newDay.weekEnd;
                           if (attrs.type == "daily") {
                               scope.searchParameters.fromDate = scope.newDay.today;
                               scope.searchParameters.toDate = scope.newDay.today;
                           }
                           if (attrs.view == "weekly") {
                              
                               scope.disable = false;
                               scope.getWeekReservations(scope.newDay);
                           }
                           else scope.getReservations();
                           
                       });
                       count--;
                       if (count == 0) {
                           scope.status = 0;
                       }
                   }
                } 
            }
        }
    });
}());
