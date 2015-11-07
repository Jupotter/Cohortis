(function () {
    'use strict';

    angular
        .module('squadApp')
        .controller('playersController', playersController);

    playersController.$inject = ['$scope', 'Players']; 

    function playersController($scope, Players) {
        var players = Players.query();
        $scope.Players = players;

        activate();

        function activate() { }
    }
})();
