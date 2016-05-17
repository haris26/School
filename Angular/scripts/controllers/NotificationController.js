(function () {
    var app = angular.module("school");
  
    app.controller("NotificationController", function ($scope, toaster, $window, $timeout) {
       
        //$scope.$watch('$viewContentLoaded', function () {
        //    $timeout(function () {
        //        var nDay = new Date();
        //        var day = nDay.getDate();
                
        //        if (day <= 28 && day > 23) {
        //            $scope.dayL = 30 - day;
        //            $scope.pop($scope.dayL);
        //            console.log($scope.dayL);
        //        }
        //        else if(day = 30)
        //        {
        //            $scope.pop();
        //        }
               
        //    }, 0);
        //});
        $scope.pop = function () {
            toaster.pop('info', "Please complete your time log", "myTemplate.html", null, 'template');
        };

        $scope.info = function () {
            toaster.pop('info', "Success!", "myTemplate.html", null, 'template')
        }
        $scope.goToLink = function (toaster) {
            var match = toaster.body.match(/http[s]?:\/\/[^\s]+/);
            if (match) $window.open(match[0]);
            return true;
        };
       

    });
}());