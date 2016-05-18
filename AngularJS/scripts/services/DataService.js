(function () {

    var app = angular.module("school");

    app.factory("DataService", function ($http, $rootScope, schConfig) {

        var source = schConfig.source;
        $http.defaults.headers.common['Token'] = currentUser.token;
        $http.defaults.headers.common['ApiKey'] = schConfig.apiKey;

        return {

           list : function (dataSet, callback) {
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
                     });
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

           remove: function (dataSet, id, callback) {
                $http({ method: "delete", url: source + dataSet + "/" + id })
                    .success(function () {
                        callback(true);
                    })
                    .error(function (error) {
                        $rootScope.message = error.message;
                        callback(false);
                    })
           },

           nameCheck: function (dataSet, name, callback) {
               $http.get(source + dataSet + "/" + name)
                   .success(function (data) {
                       return callback(data);
                   })
               .error(function (error) {
                   $rootScope.message = error.message;
                   callback(false);
               });
           },

           getPeople: function (searchedString, page, pageSize) {
               var resourceUrl = "";
               if (searchedString != "") {
                   resourceUrl = source + "people/?searchedString=" + searchedString + "&page=" + page + "&pagesize=" + pageSize
               }
               else {
                   resourceUrl = source + "people/?page=" + page + "&pagesize=" + pageSize
               }

               return $http({
                   method: 'GET',
                   url: resourceUrl
               });
           },

           getPendingAssessments: function (page, pageSize, callback) {
                   resourceUrl = source + "people/?page=" + page + "&pagesize=" + pageSize

               return $http({
                   method: 'GET',
                   url: resourceUrl
               });
           },

           getAssessmentHistory: function (searchOptions, callback) {
               $http({ method: "post", url: source + "skillassessmenthistories", data: searchOptions })
                   .success(function (data) {
                       callback(data);
                   })
                   .error(function (error) {
                       $rootScope.message = error.message;
                       callback(false);
                   })
           },

           findPeople: function (searchModel, callback) {
               $http({ method: "post", url: source + "findpeople", data: searchModel })
                   .success(function (data) {
                       callback(data);
                   })
                   .error(function (error) {
                       $rootScope.message = error.message;
                       callback(false);
                   })
           }

        };
    });
}());