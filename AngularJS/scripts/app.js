(function () {

    var app = angular.module("school", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:55013/api/",
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/skills", { templateUrl: "views/skills.html", controller: "SkillsCtrl" })
            .when("/editCategory", { templateUrl: "views/editCategory.html", controller: "SkillsCtrl" })
            .otherwise({ redirectTo: "/skills" });
    });

}());