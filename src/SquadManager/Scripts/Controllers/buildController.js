(function () {
    'use strict';

    angular
        .module('squadApp')
        .controller('buildController', buildController);

    buildController.$inject = ['$scope', 'Builds', '$http'];

    function buildController($scope, Builds, $http) {
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

        $scope.saveBuild = function () {
            $scope.opened.Name = $scope.opened.newName;
            $scope.opened.$save();
            $scope.toggleEdit();
        }

        $scope.openBuild = function (item) {
            var builds = Builds.query(function () {
                var id = item.Id;
                $scope.open(builds[id], 'build');
            });
        };

        activate();

        function activate() { }
    }
})();
