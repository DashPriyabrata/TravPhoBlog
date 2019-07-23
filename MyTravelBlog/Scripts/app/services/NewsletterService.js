app.factory('newsletterService', [
        'newsLetterApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                addSubscriber: function (subscriberData) {
                    var def = $q.defer();

                    $http.post(apiRoot + "AddSub", subscriberData)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);