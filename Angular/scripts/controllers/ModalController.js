(function () {

    var app = angular.module("school");

    app.controller("ModalController", function ($scope, $rootScope, DataService) {
        $scope.modalShow = false;
        $scope.toggleModal = function () {
            console.log("show modal");
            $scope.modalShow = !$scope.modalShow;
        };
    });

    app.directive('modalDialog', function () {
        return {
            restrict: 'E',
            scope: { show: '=' },
            replace: true,
            transclude: true,
            link: function (scope, element, attrs) {
                scope.dialogStyle = {};
                if (attrs.width) scope.dialogStyle.width = attrs.width;
                if (attrs.height) scope.dialogStyle.height = attrs.height;
                scope.hideModal = function () {
                    scope.show = false;
                };
            },
            template: "<div class='modal' ng-show='show'><div class='modal-overlay' ng-click='hideModal()'></div><div class='modal-dialog' ng-style='dialogStyle'><div class='modal-close' ng-click='hideModal()'>X</div><div class='modal-dialog-content' ng-transclude></div></div></div>"

        };
    });
}());