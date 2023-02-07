const os = require("os");
const fs = require("fs");
const file = process.argv[2];

if (!file) {
    throw new Error("No hay archivo");
}

console.log("Informacion del CPU", os.cpus());
console.log(os.networkInterfaces());
console.log(os.type());
