/// <reference path="DataService.js" />
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

            readD: function (dataSet, id, m, y, d, callback) {
                $http.get(source + dataSet + "/" + id + "/" + m + "/" + y + "/" + d)
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     })
            },
            readDd: function (dataSet, id, m, y, callback) {
                $http.get(source + dataSet + "/" + id + "/" + y + "/" + m)
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     })
            },
            read1: function (dataSet, id, m, callback) {
                $http.get(source + dataSet + "/" + id + "/" + m )
                     .success(function (data) {
                         return callback(data);
                     })
                     .error(function (error) {
                         $rootScope.message = error.message;
                         callback(false);
                     })
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

            create: function (dataSet, data, callback) {
                $http({ method: "post", url: source + dataSet, data: data })
                    .success(function (data) {
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
                        $rootScope.message = "Error deleting data!";
                        callback(false);
                    })
            },

            getDetail: function (page, pageSize) {
                var resourceUrl = "";
               resourceUrl = source + "details/?page=" + page + "&pagesize=" + pageSize
               

                return $http({
                    method: 'GET',
                    url: resourceUrl
                });
            },

        };
    });
}());
