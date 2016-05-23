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
                scope.count = 0;
                getDay = function () {                   
                   DataService.create("datepicker", scope.day, function (data) {
                       scope.newDay = data;
                       $rootScope.currentDay = scope.newDay;
                       if (attrs.view == "weekly") {                   
                           scope.searchWeekParameters.fromDate = scope.newDay.weekStart;
                           scope.searchWeekParameters.toDate = scope.newDay.weekEnd;
                           scope.getWeekReservations();
                       }                      
                   });
               }
                   getDay();                  
                   scope.goNext = function () {
                       var skip = 1;
                       if (attrs.type == "daily") {
                           var dayOftheWeek = new Date($rootScope.currentDay.today).toDateString().substring(0, 3);                          
                           if (dayOftheWeek == "Fri") skip = 3;
                           if (dayOftheWeek == "Sat") skip = 2;
                       }                                          
                   scope.day = {
                       today: "",
                       type: scope.day.type,
                       step: scope.day.step+skip                     
                   }
                   
                  
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
                           
                           scope.searchWeekParameters.fromDate = scope.newDay.weekStart;
                           scope.searchWeekParameters.toDate = scope.newDay.weekEnd;
                           scope.getWeekReservations();
                       } 
                       
                       else scope.getReservations();
                           
                   });
                   scope.count++;
               }
               scope.goPrevious = function () {     
                   if (scope.count != 0) {
                       var skip = 1;
                       if (attrs.type == "daily") {
                           var dayOftheWeek = new Date($rootScope.currentDay.today).toDateString().substring(0, 3);
                           if (dayOftheWeek == "Mon" && scope.day.step >2) skip = 3;
                           
                       }
                       scope.day = {
                           today: "",
                           type: scope.day.type,
                           step: scope.day.step - skip
                       }
                       
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
                              
                               scope.searchWeekParameters.fromDate = scope.newDay.weekStart;
                               scope.searchWeekParameters.toDate = scope.newDay.weekEnd;
                               scope.getWeekReservations();
                           }
                           else scope.getReservations();
                           
                       });
                       scope.count--;
                   }
                } 
            }
        }
    });
}());
