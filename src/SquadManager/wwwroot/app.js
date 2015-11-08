!function() {
    "use strict";
    angular.module("squadApp", [ "playersService" ]);
}(), function() {
    "use strict";
    function a(a, b, c) {
        function d() {}
        var e = b.query();
        a.Players = e, a.newPlayer = {}, a.newPlayer.Name = "", a.newPlayer.Submit = function(d, e) {
            var f = {
                Name: a.newPlayer.Name,
                Id: 0,
                Build: []
            };
            c.post("/api/v1/player/", f, {});
            a.Players = b.query;
        }, d();
    }
    angular.module("squadApp").controller("playersController", a), a.$inject = [ "$scope", "Players", "$http" ];
}(), function() {
    "use strict";
    var a = angular.module("playersService", [ "ngResource" ]);
    a.factory("Players", [ "$resource", function(a) {
        var b = a("/api/v1/player", {}, {
            query: {
                method: "GET",
                params: {},
                isArray: !0
            }
        });
        return b;
    } ]);
}();