(function () {

    var app = angular.module("school");

    app.directive("deviceRes", function ($modal) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {
                elem.bind('click', function () {
                    //console.log(scope.$parent.day.day);
                    //console.log("nesto");
                    //console.log(scope.hour.hour);
                    
                    var dayDate = scope.$parent.day.date;
                    var eventDate = new Date(dayDate);
                    eventDate.setHours(scope.hour.hour);
                    console.log(eventDate);
                    if (scope.hour.isReserved == false) {
                        scope.newEvent = {
                            id: 0,
                            eventTitle: "",
                            startDate: eventDate,
                            endDate: eventDate,
                            resource: scope.$parent.reservations.id,
                            resourceName: scope.$parent.reservations.resourceName,
                            category: 1,
                            categoryName: "Device"
                        };
                        var modalInstance = $modal.open({
                            templateUrl: 'views/modals/createEventModal.html',
                            controller: 'createEventCtrl',
                            windowClass: 'app-modal-window',
                            backdrop: 'static',
                            size: 'md',
                            scope: scope
                        });                        
                    }
                })
                //elem.bind('mouseover', function () { elem.css('color', 'red'); })
                elem.bind('mouseout', function () {
                    if (scope.hour.isReserved == true) {
                        elem.css('background-color', '#B01E5F');
                    }
                })
            }
        };
    });

}());
