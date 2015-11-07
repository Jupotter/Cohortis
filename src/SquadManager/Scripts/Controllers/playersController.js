(function () {
    'use strict';

    angular
        .module('squadApp')
        .controller('playersController', playersController);

    playersController.$inject = ['$scope', 'Players']; 

    function playersController($scope, Players) {
        $scope.Players = Players.query();

        activate();

        function activate() { }
    }
})();
