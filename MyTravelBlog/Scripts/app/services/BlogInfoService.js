
app.factory('blogInfoService', [
        'blogInfoApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                getBlogInfo: function () {
                    var def = $q.defer();

                    $http.get(apiRoot)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);
