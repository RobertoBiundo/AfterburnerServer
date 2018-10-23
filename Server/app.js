var app = require("express")();
var http = require("http").Server(app);
var io = require("socket.io")(http);
var middleware = require("socketio-wildcard")();

io.use(middleware);

io.on("connection", function (socket) {
    socket.on("*",function(message) {
        console.log(message);
        socket.broadcast.emit(message.data[0], message.data[1]);
    });
});

http.listen(3000, function () {
    console.log("Socket Server Started");
});