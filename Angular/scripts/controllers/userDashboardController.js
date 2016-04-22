(function () {

   var app = angular.module("school");

    app.controller("UserDashboardController", function ($scope, $rootScope, DataService, schConfig, $modal, toaster) {
        var dataSet = "userreservations";
        $scope.repeatingTypes = schConfig.repeatingType;
        fetchData();
       
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.dashboard = data;
            });
        }

        $scope.cancelReservation = function (item){
           var index = $scope.dashboard.activeReservations.indexOf(item);
           $scope.eventId = item.id;
           getEvent($scope.eventId);
           $scope.confirmed = {
               isConfirmed:false
           }


           var modalInstance = $modal.open({
               templateUrl: 'views/modals/cancelResModal.html',
               controller: 'CancelResCtrl',
               windowClass: 'app-modal-window',
               backdrop: 'static',
               size: 'sm',
               resolve : {
                   confirmed : function() {
                       return $scope.confirmed;
                   }
               }
           }).result.then(function(result) {
               $scope.isConfirmed = result;
               if ($scope.reservationEvent != undefined && $scope.isConfirmed) {
                   DataService.remove("events", $scope.reservationEvent.id, function (data) { });
                   $scope.dashboard.activeReservations.splice(index, 1);
               }
           });
        
       };
       $scope.extendReservation = function (item) {
           $scope.eventExtend = {
               id: 0,
               parentEvent: item.id,
               repeatUntil: new Date().Date,
               repeatingType: $scope.repeatingTypes.indexOf(0),
               frequency: 0
           }
           var modalInstance = $modal.open({
               templateUrl: 'views/modals/extendModal.html',
               controller:'ExtendModalCtrl',
               windowClass: 'app-modal-window',
               backdrop: 'static',
               size: 'md',
               scope: $scope
           });
       };
 
    
   function getEvent(id) {
       DataService.read("events", id, function (data) {
           $scope.reservationEvent = data;
       });
   };
   $scope.pop = function () {
       toaster.pop('note', "Confirmation", "Successfully canceled reservation!");
   };

   });

  
}());
