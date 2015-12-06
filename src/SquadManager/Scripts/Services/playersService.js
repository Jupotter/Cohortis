(function () {
    'use strict';

    var playersService = angular.module('playersService', ['ngResource']);
    playersService.factory('Players', ['$resource',
        function ($resource) {
            var res = $resource('/api/v1/player/:id', { id:'@Id' }, {
                query: { method: 'GET', isArray: true },
                save: { method: 'POST' },   
            });
            return res;
        }
    ]);
})();