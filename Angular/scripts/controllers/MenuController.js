(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope,$scope) {

        buildMenu();
        $scope.showelement = true;
        console.log(adminPermission);

       
        function buildMenu() {
            $rootScope.menuItems = [];
            $rootScope.menuItems.push({ text: "Requests" });

         if (currentUser.roles.indexOf("ITOfficer") > -1) {
             $rootScope.menuItems.push({ link: "requests", text: "Requests for new asset" });
             $rootScope.menuItems.push({ link: "servicerequests", text: "Requests for service" });
             $rootScope.menuItems.push({ text: "Inventory" });
             $rootScope.menuItems.push({ link: "addasset", text: "Add new equipment" });
             $rootScope.menuItems.push({ link: "assets", text: "Assigned equipment" });
             $rootScope.menuItems.push({ link: "admindashboard" });
             $rootScope.menuItems.push({ link: "free", text: "Reports" });
             $rootScope.menuItems.push({ link: "free", text: "Free equipment" });
             $rootScope.menuItems.push({ link: "deviceassets", text: "All assets" });
             $rootScope.menuItems.push({ link: "completeddevicerequests", text: "Completed requests" });
             $rootScope.menuItems.push({ link: "reports", text: "Request reports" })
             $rootScope.menuItems.push({ link: "assetReports", text: "Asset reports" })
            };



         if (currentUser.roles.indexOf("OfficeManager") > -1) {
             $rootScope.menuItems.push({ link: "officerequests", text: "Requests for new asset" });
             $rootScope.menuItems.push({ link: "officeservicerequests", text: "Requests for service" });
            $rootScope.menuItems.push({ text: "Inventory" });
            $rootScope.menuItems.push({ link: "addofficeasset", text: "Add new equipment" });
            $rootScope.menuItems.push({ link: "officeassets", text: "Assigned equipment" });
             $rootScope.menuItems.push({ link: "officer" });
             $rootScope.menuItems.push({ link: "free", text: "Reports" });
             $rootScope.menuItems.push({ link: "freeoffice", text: "Free equipment" });
             $rootScope.menuItems.push({ link: "allofficeassets", text: "All assets" });
             $rootScope.menuItems.push({ link: "completedofficerequests", text: "Completed requests" });
             $rootScope.menuItems.push({ link: "reports", text: "Request reports" })
             $rootScope.menuItems.push({ link: "assetReports", text: "Asset reports" })
         };

        if (currentUser.roles.indexOf("User") > -1) {
            $rootScope.menuItems.push({ link: "makenewrequest", text: "New asset" });
            $rootScope.menuItems.push({ link: "servicemyassets", text: "Service" });
            $rootScope.menuItems.push({ text: "My Requests" });
            $rootScope.menuItems.push({ link: "usernewrequests", text: " New requests(new equipment)" });
            $rootScope.menuItems.push({ link: "userservicerequests", text: "New requests(service)" });
            $rootScope.menuItems.push({ link: "userdashboard" });
            $rootScope.menuItems.push({ text: "My assets" });
            $rootScope.menuItems.push({ link: "completedrequests", text: "Completed requests" });
            $rootScope.menuItems.push({ link: "changedrequests", text: "Pending requests" });
            $rootScope.menuItems.push({ link: "completedrequests", text: "Completed requests" });
            $rootScope.menuItems.push({ link: "myassets", text: "My Assets" });
         
           
        };
    
     
       
        };

        $scope.showElement = function () {
            if ((currentUser.roles.indexOf("ITOfficer") > -1) || (currentUser.roles.indexOf("OfficeManager") > -1)) {
                $scope.showelements = $scope.showelement;
            }
            else
                $scope.showelements = !$scope.showelement;

        }

        $rootScope.$on('userLoggedIn', function () {
            console.log("User logged in");
            buildMenu();
        });

    });
}());