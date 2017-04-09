app.factory('userService', [
        'userApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                addUser: function (userData) {
                    var def = $q.defer();

                    $http.post(apiRoot + "Add", userData)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);