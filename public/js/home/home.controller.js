'use strict';

angular.module('home')
    .controller('homeController', function ($scope, $http, API_CONSTANTS) {

        $scope.toggleLed=function(){
            $http.get(API_CONSTANTS.TesselIP + API_CONSTANTS.Leds + '0')
                .success(function(response){
                    console.log("La respuesta fue: ", response)
                }).error(function(e){
                console.log("ocurrio un error",e);
            });
        }

        $scope.readLight=function(){
            $http.get(API_CONSTANTS.TesselIP + API_CONSTANTS.Analog)
                .success(function(response){
                    console.log("La respuesta fue: ", response)
                }).error(function(e){
                console.log("ocurrio un error",e);
            });
        }

        $scope.readAccelerometer=function(){
            $http.get(API_CONSTANTS.TesselIP + API_CONSTANTS.Accel)
                .success(function(response){
                    console.log("La respuesta fue: ", response)
                }).error(function(e){
                console.log("ocurrio un error",e);
            });
        }

        function makeGetHttpRequest(parameters){

        }

    });
