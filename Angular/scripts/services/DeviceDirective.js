(function () {

    var app = angular.module("school");

    app.directive("deviceRes", function ($modal,  schConfig) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {
                if (scope.hour.isReserved == true) {
                    elem.css('background-color', '#B01E5F')
                    if (scope.hour.personName == currentUser.name) {
                        elem.css('background-color', '#01AB8E');
                    }
                }
                elem.bind('click', function () {                            		
                    var sTime = scope.hour.hour;
                    var Day = scope.day.day;
                    if (scope.hour.isReserved == false) {
                        console.log(eventDate);
                        scope.newEvent = {
                            id: 0,
                            eventTitle: "",
                            startDate: scope.$parent.day.date,
                            endDate: scope.$parent.day.date,
                            resource: scope.$parent.reservations.id,
                            resourceName: scope.$parent.reservations.resourceName,
                            category: 1,
                            categoryName: "Device",
                            startTime: sTime,
                            endTime: sTime+1
                        };
                        console.log(scope.newEvent);
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
                                elem.css('background-color', '#01AB8E');
                            }
                        });                         
                    }
                })             
            }           
        };
    });
}());
