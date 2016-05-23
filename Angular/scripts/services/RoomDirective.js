(function () {

    var app = angular.module("school");

    app.directive("roomRes", function ($modal, $rootScope) {
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

                if (scope.timeSlot.isReserved == true) {
                    elem.css('background-color', '#B01E5F');
                    if (scope.timeSlot.personName == currentUser.name) {
                        elem.css('background-color', '#01AB8E');
                    }
                }
               

                
                if (scope.timeSlot.endTime == "10:00" || scope.timeSlot.endTime == "11:00" ||
                        scope.timeSlot.endTime == "12:00" || scope.timeSlot.endTime == "13:00" ||
                        scope.timeSlot.endTime == "14:00" || scope.timeSlot.endTime == "15:00" ||
                        scope.timeSlot.endTime == "16:00" || scope.timeSlot.endTime == "17:00") {
                   
                        elem.css('border-right-color', '#2E2E2E')
                }

                elem.bind('click', function() {
                
                    if (scope.timeSlot.isReserved == false && scope.timeSlot.isPast == false) {
                        console.log("slot", scope.timeSlot);
                        scope.newEvent = {
                            id: 0,
                            eventTitle: "",
                            startDate: scope.timeSlot.eventStart,
                            endDate: scope.timeSlot.eventEnd,
                            resource: scope.$parent.room.room.id,
                            resourceName: scope.$parent.room.room.roomName,
                            category: 2,
                            categoryName: "Room",
                            startTime: scope.timeSlot.startTime,
                            endTime: scope.timeSlot.endTime,
                            endTimes: []
                            
                        };

                        for (var i = 0; i < scope.$parent.room.room.timeSlots.length; i++) {
                            if (scope.$parent.room.room.timeSlots[i].isReserved == false && scope.timeSlot.startTime <= scope.$parent.room.room.timeSlots[i].startTime) {
                                scope.newEvent.endTimes.push(scope.$parent.room.room.timeSlots[i].endTime);              
                            }
                            if (scope.$parent.room.room.timeSlots[i].isReserved == true && scope.timeSlot.startTime <= scope.$parent.room.room.timeSlots[i].startTime) {
                                break;
                            }  
                        }                        
                        var modalInstance = $modal.open({
                            templateUrl: 'views/modals/createRoomEventModal.html',
                            controller: 'createRoomEventCtrl',
                            windowClass: 'app-modal-window',
                            backdrop: 'static',
                            size: 'md',
                            scope: scope
                        }).result.then(function(result) {
                            scope.timeSlot.isReserved = result;
                            console.log("scoppe ovdje", scope);
                            if (scope.timeSlot.isReserved == true) {
                                scope.getReservations();
                                $rootScope.refreshWeek();
                                elem.css('background-color', '#01AB8E');
                            }
                        });
                    }
                });
            }
        }
    });
}());
