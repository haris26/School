(function () {

    var app = angular.module("school");

    app.directive("datePicker", function ($modal, schConfig) {
        return {
            restrict: "AE",
            replace:true,
            templateUrl:'views/datePicker.html',
            scope: {
                today: '=',
                week: '=',
            },
            link: function (scope, elem, attrs) {
                
                var setToday = new Date();
                scope.today = setToday.setUTCHours(-2);
              

                scope.week = {
                    start: new Date(setToday.getFullYear(),setToday.getMonth(),(setToday.getDate()-setToday.getDay()+2)),
                    end: new Date(setToday.getFullYear(),setToday.getMonth(),(setToday.getDate()-setToday.getDay()+6))
                };
                

            scope.next=function () {
                     scope.week = {
                         start: new Date(scope.week.start.getFullYear(), scope.week.start.getMonth(), scope.week.start.getDate() +6),
                         end: new Date(scope.week.end.getFullYear(), scope.week.end.getMonth(), scope.week.end.getDate() +6),
                     };
                     
                     scope.$parent.getWeek(scope.week);
                     
                }
          
      
               scope.previous = function () {
                   scope.week = {
                       start: new Date(scope.week.start.getFullYear(), scope.week.start.getMonth(), scope.week.start.getDate() - 7),
                       end: new Date(scope.week.end.getFullYear(), scope.week.end.getMonth(), scope.week.end.getDate() - 7),
                       
                   };
                   scope.$parent.getWeek(scope.week);
               }
            }
            
        };
    });
}());
