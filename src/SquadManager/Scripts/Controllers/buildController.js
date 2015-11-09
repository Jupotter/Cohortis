(function () {
    'use strict';

    angular
        .module('squadApp')
        .controller('buildsController', buildsController);

    buildsController.$inject = ['$scope', 'Builds', '$http'];

    function buildsController($scope, Builds, $http) {
        var builds = Builds.query();
        $scope.Builds = builds;


        activate();

        function activate() { }
    }
})();
