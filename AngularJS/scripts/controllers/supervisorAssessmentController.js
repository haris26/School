(function () {

    var app = angular.module("school");

    app.controller("SupervisorAssessmentCtrl", function ($scope,$rootScope, $routeParams, $log, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.assessed = {};
        $scope.leftToAssess = {};

        $scope.assessmentClass = {
            true: "btn btn-success btn-sm",
            false: "btn btn-primary btn-sm"
        }
        $scope.permissions = {
            showAdmin: currentUser.roles.indexOf("Admin") > -1,
            showUser: currentUser.id == $scope.employeeId
        }
        getEmployee($scope.employeeId);
        console.log("prije dodavanja", $scope.assessedEmployees);

        function getEmployee(id) {
            DataService.read("supervisorassessments", id, function (data) {
                $scope.assessments = data;
                for(var i=0; i<$scope.assessments.skills.length; i++){
                    for (var j = 0; j < $scope.assessments.skills[i].skills.length; j++) {
                        $scope.assessed[$scope.assessments.skills[i].skills[j].skillId] = false;
                }
                }
                $scope.message = "";
                $scope.data = [];
            })
        }

        $scope.updateEmployeeSkill = function (skill, dateOfSelfAssessment ) {
            var employeeSkill = {
                id: skill.employeeSkillId,
                employee: $scope.employeeId,
                tool: skill.skillId,
                level: skill.level,
                experience: skill.experience,
                skill:skill.skill,
                dateOfSelfAssessment: dateOfSelfAssessment,
                dateOfSupervisorAssessment: new Date(),
                assessedBy: 1,
            }

            DataService.update("employeeskills", skill.employeeSkillId, employeeSkill, function (data) {
                if (data != false) {
                    toaster.pop('note', skill.skill + " assessed");
                    $scope.assessed[skill.skillId] = true;

                    DataService.read("employeenotifications", $scope.employeeId, function (data) {
                        $scope.notification = data;
                        $scope.newNotificationItem = {
                            id: $scope.notification.id,
                            employeeId: $scope.notification.employeeId,
                            assessedBySupervisor: true
                        }
                        console.log($scope.notification.id);
                        if ($scope.notification.assessedBySupervisor!=true) {
                            console.log("pozvao update");
                            DataService.update("employeenotifications", $scope.notification.id, $scope.newNotificationItem, function (data) {
                            })
                        }
                    });
                }
                else {
                    toaster.pop('error', skill.skill + " could not be assessed!");
                }
            });
        }
      
            $scope.goToAssessment = function () {
                $location.path('/employeeAssessments/' + $scope.employeeId);
                $('#finishAssessmentModal').modal('hide');
                $('.modal-backdrop').remove();
                $('body').removeClass('modal-open');
            }
    });
}());