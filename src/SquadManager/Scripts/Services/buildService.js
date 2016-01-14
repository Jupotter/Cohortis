(function () {
    'use strict';

    var buildsService = angular.module('buildsService', ['ngResource']);
    buildsService.factory('Builds', ['$resource',
        function ($resource) {
            var res = $resource('/api/v1/build/:id', { id: '@Id' }, {
                query: { method: 'GET', params: {}, isArray: true },
                save: { method: 'POST' },
            });
            return res;
        }
    ]);
})();