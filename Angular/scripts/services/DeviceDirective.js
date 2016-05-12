(function () {

    var app = angular.module("school");

    app.directive("deviceRes", function ($modal) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {
                var eventDate = new Date(scope.day.date);
                var todayDate = new Date();
                var today = new Date(todayDate.getFullYear(), todayDate.getMonth(), todayDate.getDate());
                

                if (eventDate < today || (eventDate <= today && scope.hour.hour <= todayDate.getHours())) {
                    elem.css('background-color', '#F2F2F2');
                    scope.hour.isPast = true;
                }
               

                if (scope.hour.isReserved == true) {
                    elem.css('background-color', '#B01E5F')
                    if (scope.hour.personName == currentUser.name) {
                        elem.css('background-color', '#01AB8E');
                    }
                }
                elem.bind('click', function () {
                    console.log(scope, "daj skop");
                    
                    if (scope.hour.isReserved == false && scope.hour.isPast != true) {
                        scope.newEvent = {
                            id: 0,
                            eventTitle: "",
                            startDate: scope.$parent.day.date,
                            endDate: scope.$parent.day.date,
                            resource: scope.$parent.reservations.id,
                            resourceName: scope.$parent.reservations.resourceName,
                            category: 1,
                            categoryName: "Device",
                            startTime: scope.hour.hour,
                            endTime: scope.hour.hour + 1,
                            endTimes: []
                        };

                        for (var i = 0; i < scope.$parent.day.hours.length; i++) {
                            if (scope.$parent.day.hours[i].isReserved == false && scope.hour.hour <= scope.$parent.day.hours[i].hour) {
                                scope.newEvent.endTimes.push(scope.$parent.day.hours[i].hour+1);

                            }
                            if (scope.$parent.day.hours[i].isReserved == true && scope.hour.hour <= scope.$parent.day.hours[i].hour) {
                                break;
                            }
                            
                        }
                        
                        
                        var modalInstance = $modal.open({
                            templateUrl: 'views/modals/createEventModal.html',
                            controller: 'createEventCtrl',
                            windowClass: 'app-modal-window',
                            backdrop: 'static',
                            size: 'md',
                            scope: scope

                        }).result.then(function(result) {
                            scope.hour.isReserved = result;
                            if (scope.hour.isReserved == true)
                            {
                                scope.$parent.$parent.getDevices();
                                elem.css('background-color', '#01AB8E');
                            }
                        });                         
                    }
                })             
            }           
        };
    });
}());
