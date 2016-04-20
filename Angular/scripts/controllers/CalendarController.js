(function () {

    var app = angular.module("school");
    app.controller("CalendarController", function ($scope, $modal) {
    $scope.day = moment();

    $scope.openModal = function (selectedDay) {
        var modalInstance = $modal.open({
            templateUrl: 'views/daymodal.html',
            controller: 'DayModalController',
            resolve: {
                day: function () {
                    return selectedDay;
                }
            }
        });
    }
   
});
}());