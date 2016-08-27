var tessel = require('tessel');
var express = require('express');
var path = require('path');
var app = express();

var analogReadPin = tessel.port.B.pin[7];


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
    var light = 0;
    analogReadPin.analogRead(function (error, value) {
        console.log('Luz actual', value);
        res.send("La cantidad de luz actual es de: "+ value);
    });
});

app.listen(8080, function () {
    console.log("El servidor express está corriendo");
});

// Blink!
setInterval(function () {
    tessel.led[2].toggle();
    tessel.led[3].toggle();
}, 100);

