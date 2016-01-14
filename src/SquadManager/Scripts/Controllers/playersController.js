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
        $scope.editMode = false;

        $scope.weekdays = [
            { name: 'Monday', },
            { name: 'Tuesday', },
            { name: 'Wednesday' },
            { name: 'Thursday' },
            { name: 'Friday' },
            { name: 'Saturday' },
            { name: 'Sunday' },
        ];

        $scope.newPlayer.Submit = function (item, event) {
            var data = {
                Name: $scope.newPlayer.Name,
                Id: 0,
                Build: [],
            };

            var res = $http.post("/api/v1/player/", data, {});

            $scope.Players = Players.query();
        };

        $scope.createPlayer = function () {
            $scope.opened = {
                Name: "Nouveau joueur",
                $save: function () {
                    Players.save(this);
            }};
            $scope.typeOpen = 'player';
            $scope.editMode = true;
        }

        $scope.savePlayer = function () {
            $scope.opened.Name = $scope.opened.newName;
            $scope.opened.$save();
            $scope.toggleEdit();
        }

        $scope.open = function (item, type) {
            $scope.opened = item;
            $scope.typeOpen = type
        }

        $scope.openBuild = function (item) {
            $scope.opened = item;
            $scope.typeOpen = 'build'
        };

        $scope.openPlayer = function (item) {
            $scope.opened = item;
            $scope.typeOpen = 'player'
        };

        $scope.toggleEdit = function () {
            $scope.editMode = !$scope.editMode;
            $scope.Players = Players.query();
        }

        activate();

        function activate() { }
    }
})();
