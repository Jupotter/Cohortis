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

        $scope.open = function (item) {
            $scope.opened = item;
        };

        $scope.anyOpened = function () {
            return $scope.opened !== undefined;
        };

        activate();

        function activate() { }
    }
})();
