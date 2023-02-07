const express = require("express");
const color = require("colors");

const server = express();
const peliculasAPI = require("./routes/peliculas.js");
peliculasAPI(server);

server.listen(3000, () => {
    console.log("Servidor Iniciado".green);
});

server.get("/", (req, res) => {
    res.send("<h1>Hola " + new Date().getFullYear() + "</h1>");
    res.end();
});
