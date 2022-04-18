
var testApp = angular.module("personaModule", []);

testApp.controller("personaController", function ($scope, $http) {
    $http.get('/api/Personas').then(function (response) {
        $scope.personitas = response.data;
    });
});