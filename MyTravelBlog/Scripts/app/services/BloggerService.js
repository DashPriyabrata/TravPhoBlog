
app.factory('bloggerService', [
        'bloggerApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                getBlogger: function () {
                    var def = $q.defer();

                    $http.get(apiRoot + 'GetBlogger')
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },

                getTestData: function () {
                    var def = $q.defer();

                    $http.get(apiRoot + 'GetTestData')
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);
