(function () {
    'use strict';

    var buildsService = angular.module('buildsService', ['ngResource']);
    buildsService.factory('builds', ['$resource',
        function ($resource) {
            var res = $resource('/api/v1/build', {}, {
                query: { method: 'GET', params: {}, isArray: true },
            });
            return res;
        }
    ]);
})();