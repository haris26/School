(function () {

    var app = angular.module("school");

    app.factory("DataService", function ($http) {

        var source = "http://localhost:50169/api/userreservations/";

        return {
            getDashboard: function () {
                return $http.get(source, {
                    headers: {
                        'Token': 'avYGA9YvZT7oy99tyOvSHNol6Gu57alW8xpP2ugePBg=',
                        'ApiKey': 'R2lnaVNjaG9vbA==',
                        'Content-Type': 'application/json;odata=verbose'
                    }
                });
            }
        };
    });
}());