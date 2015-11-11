(function () {
    'use strict';

    angular
        .module('squadApp')
        .controller('playersController', playersController);

    playersController.$inject = ['$scope', 'Players', '$http']; 

    function playersController($scope, Players, $http) {
        var players = Players.query();
        $scope.Players = players;
        $scope.newPlayer = {};
        $scope.newPlayer.Name = "";
        $scope.typeOpen = 'none'

        $scope.newPlayer.Submit = function(item, event)
        {
            var data = {
                Name: $scope.newPlayer.Name,
                Id: 0,
                Build: [],
            };

            var res = $http.post("/api/v1/player/", data, {});

            $scope.Players = Players.query
        }

        $scope.openBuild = function (item) {
            $scope.opened = item;
            $scope.typeOpen = 'build'
        };

        $scope.openPlayer = function (item) {
            $scope.opened = item;
            $scope.typeOpen = 'player'
        };

        activate();

        function activate() { }
    }
})();
