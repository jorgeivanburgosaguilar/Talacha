var fs = require("fs");

fs.writeFile("mensaje.txt", "Esto es un mensaje", function () {
    console.log("Guardado");
});
console.log("Escribiendo en archivo...");

fs.readFile("mensaje.txt", function (err, datos) {
    console.log(datos);
});

fs.readFile("mensaje.txt", { encoding: "utf-8" }, function (err, datos) {
    console.log(datos);
});
