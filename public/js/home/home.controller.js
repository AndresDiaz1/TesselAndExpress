'use strict';

angular.module('home')
    .controller('homeController', function ($scope, $http, API_CONSTANTS) {

        $scope.toggleLed=function(){
            $http.get(API_CONSTANTS.TesselIP + API_CONSTANTS.Leds + '0')
                .success(function(response){

                }).error(function(e){
                console.log("ocurrio un error",e);
            });
        }

        $scope.readLight=function(){
            console.log("leer luz");
        }

        $scope.readAccelerometer=function(){
            console.log("Leer acelerómetro");
        }

    });
