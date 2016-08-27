'use strict';
angular.module('home',[])
    .config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'js/home/home.html',
                controller: 'homeController'
            });
    });