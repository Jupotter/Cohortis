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

        $scope.classes = {
            Guardian: { display: 'Gardien', order: 0 },
            Warrior: { display: 'Guerrier', order: 1 },
            Revenant: { display: 'Revenant', order: 2 },
            Engineer: { display: 'Ingénieur', order: 3 },
            Ranger: { display: 'Rôdeur', order: 4 },
            Thief: { display: 'Voleur', order: 5 },
            Elementalist: { display: 'Élementaliste', order: 6 },
            Necromancer: { display: 'Nécromancien', order: 7 },
            Mesmer: { display: 'Envouteur', order: 8 },
        };

        $scope.newPlayer.Submit = function (item, event) {
            var data = {
                Name: $scope.newPlayer.Name,
                Id: 0,
                Build: [],
            };

            var res = $http.post("/api/v1/player/", data, {});

            $scope.Players = Players.query();
        };

        $scope.savePlayer = function () {
            var id = $scope.opened.Id;
            var res = $http.post("/api/v1/player/" + id, $scope.opened, {});
            console.log(res);

            $scope.Players = Players.query();
            $scope.toggleEdit();
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
        }

        activate();

        function activate() { }
    }
})();
