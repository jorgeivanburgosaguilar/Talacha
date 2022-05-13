const express = require("express");
const color = require("colors");
const server = express();
server.listen(3000, () => {
    console.log("Server".green);
})

server.get("/", (req, res) => {
    res.send("<h1>Adios Mundo</h1>");
    res.end();
});