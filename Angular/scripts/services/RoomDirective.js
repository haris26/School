(function () {

    var app = angular.module("school");

    app.directive("roomRes", function ($modal, schConfig) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {
                var eventDate = new Date(scope.timeSlot.eventStart);
                var todayDate = new Date();

                if (eventDate <= todayDate) {
                    elem.css('background-color', '#F2F2F2');
                    scope.timeSlot.isPast = true;
                }
               
                if (scope.timeSlot.$id == 10 || scope.timeSlot.$id == 14
                || scope.timeSlot.$id == 18 || scope.timeSlot.$id == 22 || scope.timeSlot.$id == 26
                || scope.timeSlot.$id == 30 || scope.timeSlot.$id == 34 || scope.timeSlot.$id == 48) {
                    elem.css('border-right-color', '#2E2E2E ')
                }           
                             
                if (scope.timeSlot.isReserved == true) {elem.css('background-color', '#B01E5F ')
                    if (scope.timeSlot.personName == currentUser.name) {
                        elem.css('background-color', '#01AB8E ');
                    }
                }
                //console.log('room scope', scope);

                elem.bind('click', function () {
                   
                    if (scope.timeSlot.isReserved == false && scope.timeSlot.isPast == false) {
                        scope.newEvent = {
                            id: 0,
                            eventTitle: "",
                            startDate: scope.timeSlot.eventStart,
                            endDate: scope.timeSlot.eventEnd,
                            resource: scope.$parent.room.room.id,
                            resourceName: scope.$parent.room.room.roomName,
                            category: 2,
                            categoryName: "Room",
                   
                        };
                        console.log(scope.newEvent);
                        var modalInstance = $modal.open({
                            templateUrl: 'views/modals/createRoomEventModal.html',
                            controller: 'createRoomEventCtrl',
                            windowClass: 'app-modal-window',
                            backdrop: 'static',
                            size: 'md',
                            scope: scope

                        }).result.then(function (result) {
                            scope.timeSlot.isReserved = result;
                            if (scope.timeSlot.isReserved == true) {
                                elem.css('background-color', '#01AB8E');
                            }
                        });
                    }
                })
            }
        }
    });
}());
