(function () {

    var app = angular.module("school");

    app.controller("RoomReservationController", function ($scope, $rootScope, DataService, $modal) {

        $scope.permission = {
            showAdmin: currentUser.roles.indexOf("Admin")> -1
        }
        $scope.searchParameters = {
            fromDate: new Date(),
            toDate: new Date(),
            categoryName: "Room",
            resourceName: "",
            osType: ""
        };

        $scope.getReservations = function () {
            DataService.create("reservationoverview", $scope.searchParameters, function (data) {
                $scope.reservations = data;
                console.log($scope.reservations);
            });
        };
        $scope.getReservations();

        $scope.editRoom = function (item) {
            $scope.editR = {
                id: item.id,
                name: item.roomName,
                resoureCategory: 2
            }
            $scope.roomChairCharac = {
                id: item.characteristics[0].id,
                name: item.characteristics[0].name,
                value: item.characteristics[0].value,
                resource: item.id
            }
            $scope.roomSpeakerCharac = {
                id: item.characteristics[1].id,
                name: item.characteristics[1].name,
                value: item.characteristics[1].value,
                resource: item.id
            }
            $scope.roomTvCharac = {
                id: item.characteristics[2].id,
                name: item.characteristics[2].name,
                value: item.characteristics[2].value,
                resource: item.id
            }
            $scope.roomBoardCharac = {
                id: item.characteristics[3].id,
                name: item.characteristics[3].name,
                value: item.characteristics[3].value,
                resource: item.id
            }
            var modalInstance = $modal.open({
                templateUrl: 'views/modals/editRoomModal.html',
                controller: 'EditRoomModalCtrl',
                windowClass: 'app-modal-window',
                backdrop: 'static',
                size: 'md',
                scope: $scope
            });
        }
    });
}());

