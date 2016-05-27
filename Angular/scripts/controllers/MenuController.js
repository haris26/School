(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope) {

        buildMenu();

        function buildMenu() {
            $rootScope.menuItems = [];
            $rootScope.menuItems.push({ text: "Requests" });

         if (currentUser.roles.indexOf("ITOfficer") > -1) {
             $rootScope.menuItems.push({ link: "requests", text: "New Asset" });
             $rootScope.menuItems.push({ link: "servicerequests", text: "Service Asset" });
             $rootScope.menuItems.push({ text: "Inventory" });
             $rootScope.menuItems.push({ link: "addasset", text: "Add new equipment" });
             $rootScope.menuItems.push({ link: "assets", text: "Assigned equipment" });
             $rootScope.menuItems.push({ link: "admindashboard" });
             $rootScope.menuItems.push({ link: "free", text: "Reports" });
             $rootScope.menuItems.push({ link: "free", text: "Free equipment" });
             $rootScope.menuItems.push({ link: "deviceassets", text: "All assets" });
            };



         if (currentUser.roles.indexOf("OfficeManager") > -1) {
             $rootScope.menuItems.push({ link: "officerequests", text: "New Asset" });
             $rootScope.menuItems.push({ link: "officeservicerequests", text: "Service Asset" });
            $rootScope.menuItems.push({ text: "Inventory" });
            $rootScope.menuItems.push({ link: "addasset", text: "Add new equipment" });
            $rootScope.menuItems.push({ link: "officeassets", text: "Assigned equipment" });
             $rootScope.menuItems.push({ link: "officer" });
             $rootScope.menuItems.push({ link: "free", text: "Reports" });
             $rootScope.menuItems.push({ link: "freeoffice", text: "Free equipment" });
             $rootScope.menuItems.push({ link: "officeassets", text: "All assets" });
         };

        if (currentUser.roles.indexOf("User") > -1) {
            $rootScope.menuItems.push({ link: "makenewrequest", text: "New asset" });
            $rootScope.menuItems.push({ link: "servicemyassets", text: "Service" });
            $rootScope.menuItems.push({ text: "My Requests" });
            $rootScope.menuItems.push({ link: "usernewrequests", text: "Requests(new equipment)" });
            $rootScope.menuItems.push({ link: "userservicerequests", text: "Requests(service)" });
            $rootScope.menuItems.push({ link: "userdashboard" });
            $rootScope.menuItems.push({ link: "myassets", text: "My Assets" });
            $rootScope.menuItems.push({ link: "completedrequests", text: "Completed requests" });
        };
    
     
       
        };

        $rootScope.$on('userLoggedIn', function () {
            console.log("User logged in");
            buildMenu();
        });

    });
}());