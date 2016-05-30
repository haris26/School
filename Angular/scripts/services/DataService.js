(function () {

    var app = angular.module("school");

    app.factory("DataService", function ($http, $rootScope, schConfig) {

        var source = schConfig.source;
        $http.defaults.headers.common['Token'] = currentUser.token;
        $http.defaults.headers.common['ApiKey'] = schConfig.apiKey;
        
        return {
            list: function (dataSet, callback) {
                $http.get(source + dataSet)
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     });
            },

            read: function (dataSet, id, callback) {
                $http.get(source + dataSet + "/" + id)
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     })
            },
            read1: function (dataSet, m, y, callback) {
                $http.get(source + dataSet + "/" + m + "/" + y)
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     })
            },
            completedService: function (dataSet, type, status, callback) {
                $http.get(source + dataSet + "/" + type + "/" + status)
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     })
            },
            create: function (dataSet, data, callback) {
                $http({ method: "post", url: source + dataSet, data: data })
                    .success(function (data) {
                        $rootScope.message = "You have submited your request!";
                        callback(data);
                    })
                    .error(function (error) {
                        $rootScope.message = error.message;
                        callback(false);
                    })
            },

            update: function (dataSet, id, data, callback) {
                $http({ method: "put", url: source + dataSet + "/" + id, data: data })
                    .success(function (data) {
                        callback(data);
                    })
                    .error(function (error) {
                        $rootScope.message = error.message;
                        callback(false);
                    })
            },

            delete: function (dataSet, id, callback) {
                $http({ method: "delete", url: source + dataSet + "/" + id })
                    .success(function () {
                        callback(true);
                    })
                    .error(function (error) {
                        $rootScope.message = error.message;
                        callback(false);
                    })
            }

        };
    });
}());