'use strict';

angular.module('home')
    .controller('homeController', function ($scope, $http) {

        $scope.toggleLed=function(){

        }

        $scope.readLight=function(){
            console.log("leer luz");
        }

        $scope.readAccelerometer=function(){
            console.log("Leer acelerómetro");
        }

    });
