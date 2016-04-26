﻿(function (define) {
    var app = angular.module("school");

    app.controller("NotificationController", function ($scope, $flash) {
        $scope.msgTitle = 'Alert';
        $scope.msgBody = 'You have 5 days left';
        $scope.msgType = 'warning';

        $scope.flash = flash;
    });

        app.factory("flash", function ($rootScope) {
            var queue = [], currentMessage = '';

            $rootScope.$on('$routeChangeSuccess', function () {
                if (queue.length > 0)
                    currentMessage = queue.shift();
                else
                    currentMessage = '';
            });

            return {
                    set: function(message) {
                        var msg = message;
                        queue.push(msg);

                    },
                    get: function(message) {
                        return currentMessage;
                    },
                    pop: function(message) {
                        switch(message.type) {
                            case 'success':
                                toastr.success(message.body, message.title);
                                break;
                            case 'info':
                                toastr.info(message.body, message.title);
                                break;
                            case 'warning':
                                toastr.warning(message.body, message.title);
                                break;
                            case 'error':
                                toastr.error(message.body, message.title);
                                break;
                        }
                    }
            }   
        });
       
    
}());