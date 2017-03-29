
app.factory('categoryService', [
        'categoryApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                getCategory: function (categoryId) {
                    var def = $q.defer();

                    $http.get(apiRoot + 'GetCategory/' + categoryId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },

                getAll: function () {
                    var def = $q.defer();

                    $http.get(apiRoot + 'All')
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);