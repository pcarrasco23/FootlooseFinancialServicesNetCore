 // login.js
var module = angular.module('login', ['ngRoute']);

module.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when("/", {
            controller: "loginController",
            templateUrl: "/templates/login.html"
        })
        .otherwise({ redirectTo: "/" });

    $locationProvider.html5Mode(true);
}]);

module.controller('loginController', ['$scope', '$http', 'dataService', function ($scope, $http, dataService) {
    $scope.isBusy = false;
    $scope.isError = false;   

    $scope.username = "";
    $scope.password = "";

    $scope.submit = function () {
        $scope.isBusy = true;

        dataService.Login($scope.username, $scope.password)
            .then(function (data) {
                // success

                dataService.GetDashboard()
                    .then(function (data) {                       
                        sessionStorage.setItem("firstName", data.FirstName);
                        sessionStorage.setItem("lastName", data.LastName);

                        // Login and dashboard calls were successfull
                        // Redirect to the main application page
                        location.href = "/";
                    },
                    function (errorMessage) {
                        // error
                        alert(errorMessage);
                    })
                    .then(function () {
                        $scope.isBusy = false;
                    });
            },
            function (errorMessage) {
                // error
                $scope.isBusy = false;
                $scope.isError = true;
            })
            .then(function () {
                $scope.isBusy = false;
            });
    }    
}]);