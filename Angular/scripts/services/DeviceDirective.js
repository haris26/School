(function () {

    var app = angular.module("school");

    app.directive("deviceRes", function ($modal) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {
                elem.bind('click', function () {
                    console.log(scope.$parent.day.day);
                    console.log("nesto");
                    console.log(scope.hour);
                   
                    if (scope.hour.isReserved == false) {
                        var dayDate = scope.$parent.day.date;
                        var eventDate = new Date(dayDate);
                        //var time = scope.$parent.day.hours.
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
                    if (scope.hour.isReserved == false) {
                        elem.css('background-color', '#B01E5F');
                    }
                })
            }
        };
    });

}());
