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
                        var modalInstance = $modal.open({
                            templateUrl: 'views/modals/extendModal.html',
                            controller: 'ExtendModalCtrl',
                            windowClass: 'app-modal-window',
                            backdrop: 'static',
                            size: 'md',
                            scope: scope
                        });
                    }


                })
                //elem.bind('mouseover', function () { elem.css('color', 'red'); })
                //elem.bind('mouseout', function () { elem.css('color', 'green'); })
            }
        };
    });

}());
