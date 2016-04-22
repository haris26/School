(function () {

    var app = angular.module("school");

    app.directive("deviceRes", function ($modal) {
        return {
            restrict: "AE",
            replace: true,
            link: function (scope, elem, attrs) {
                elem.bind('click', function () {                            
					if (scope.hour.isReserved == true) {
						elem.css('background-color', '#B01E5F')
						if (scope.hour.personName == $rootScope.currentUser.name)
						{
							elem.css('background-color', '#01AB8E');
						}
					
					}
                    var dayDate = scope.$parent.day.date;
                    var split = dayDate.split(".");
                    //console.log(scope.hour.hour);
                    var eventDate = new Date(split[2], split[1]-1, split[0], scope.hour.hour+1, 0, 0, 0);
                    var endDate = new Date(split[2], split[1]-1, split[0], scope.hour.hour+2, 0, 0, 0);
                
                    if (scope.hour.isReserved == false) {
                        scope.newEvent = {
                            id: 0,
                            eventTitle: "",
                            startDate: eventDate,
                            endDate: endDate,
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
                })
               
            }
           
        };
    });

}());
