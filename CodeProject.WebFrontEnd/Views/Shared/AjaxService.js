﻿
console.log("ajax service");

angular.module('codeProject').service('ajaxService',['$http', 'blockUI', function ($http, blockUI) {

    "use strict";

    this.ajaxPost = function (data, route, successFunction, errorFunction) {

        blockUI.start();

        $http.post(route, 

            JSON.stringify(data),
                            {
                                    headers:  {
                                            'Content-Type':  'application/json'
                                    }
                            } 

        ).success(function (response, status, headers, config) {
            blockUI.stop();
            successFunction(response, status);
        }).error(function (response) {
            blockUI.stop();
            errorFunction(response);
        });

    }

}]);