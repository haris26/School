(function () {

    var app = angular.module("school");

    app.controller("RecurringReservationsController", function ($scope, $rootScope, DataService, $modal, schConfig) {

        var dataSet = "extendedoverview";
        fetchData();
        $scope.repeatingTypes = schConfig.repeatingType;

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.extendedEvents = data;
            });
        }
        $rootScope.refreshRecc = function () {
            fetchData();
        }
        $scope.cancelRecurring = function (item) {
            var index = $scope.extendedEvents.indexOf(item);
            $scope.extEventId = item.id;
            getExtEvent($scope.extEventId);

            $scope.confirmed = {
                isConfirmed: false
            }

            var modalInstance = $modal.open({
                templateUrl: 'views/modals/cancelExtendedModal.html',
                controller: 'CancelExtendedCtrl',
                windowClass: 'app-modal-window',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    confirmed: function () {
                        return $scope.confirmed;
                    }
                }
            }).result.then(function (result) {
                $scope.isConfirmed = result;
                if ($scope.extEvent != undefined && $scope.isConfirmed) {
                    DataService.remove("eventextends", $scope.extEvent.id, function (data) { });
                    $scope.extendedEvents.splice(index, 1);
                }
            });
        };
        $scope.editExtended = function (item) {
            $scope.event = {
                id: item.id,
                parentEvent: item.parentEvent,
                repeatUntil: new Date().Date,
                repeatingType: item.repeatingType,
                frequency: item.frequency,
                endTime: item.endTime
            }
            var modalInstance = $modal.open({
                templateUrl: 'views/modals/editExtendedModal.html',
                controller: 'EditExtendedCtrl',
                windowClass: 'app-modal-window',
                backdrop: 'static',
                size: 'md',
                scope: $scope
            });
        };
        function getExtEvent(id) {
            DataService.read("eventextends", id, function (data) {
                $scope.extEvent = data;
            });
        };

    });
}());
