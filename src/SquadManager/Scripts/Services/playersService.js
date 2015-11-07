(function () {
    'use strict';

    var playersService = angular.module('playersService', ['ngResource']);
    playersService.factory('Players', ['$resource',
        function ($resource) {
            return $resource('/api/v1/player', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }
    ]);
})();