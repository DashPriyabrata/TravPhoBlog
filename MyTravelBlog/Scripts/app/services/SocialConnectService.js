
app.factory('socialConnectService', [
    'socialConnectApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
        'use strict';
        return {
            apiRoot: apiRoot,
            getInstagramRecentMedia: function () {
                var def = $q.defer();

                $http.get(apiRoot + 'Instagram/RecentMedia')
                    .then(function (response) {
                        def.resolve(response.data);
                    }, def.reject);

                return def.promise;
            }
        };
    }
])