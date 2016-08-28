var tessel = require('tessel');
var express = require('express');
var path = require('path');
var app = express();

var accel = require('accel-mma84').use(tessel.port['A']);
var analogReadPin = tessel.port.B.pin[7];


accel.on('ready', function () {
    console.log("acelerometro listo");
    accel.setOutputRate(1.56, function rateSet() {})

});

accel.on('error', function(err){
    console.log('Error:', err);
});


app.use(express.static(path.join(__dirname, 'public')));


app.get('/', function (req, res) {
    res.sendfile('./public/index.html')
});

app.get('/leds/:led', function (req, res) {
    console.log('¿Cuál led modificó?', req.params.led);
    var index = req.params.led;
    tessel.led[index].toggle();
    res.send("Toggle led: " + index);
});

app.get("/analog", function (req, res) {
    analogReadPin.analogRead(function (error, value) {
        console.log('Luz actual', value);
        res.send("La cantidad de luz actual es de: "+ value);
    });
});

app.get("/accel", function (req, res) {
    accel.getAcceleration(function(err,xyz){
        console.log("lo que saco el acelerometro", xyz);
        if(xyz[0]>0){
            res.send('u');
            console.log('u')
        }else{
            res.send('d');
            console.log('d')

        }
        //res.send(xyz);
    });
});

app.listen(8080, function () {
    console.log("El servidor express está corriendo");
});

setInterval(function () {
    accel.getAcceleration(function(err,xyz){
        console.log("lo que saco el acelerometro",  xyz);
    });
}, 1000);
