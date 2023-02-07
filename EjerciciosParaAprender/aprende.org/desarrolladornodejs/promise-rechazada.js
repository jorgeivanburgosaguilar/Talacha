let promesa = new Promise(function (resolve, reject) {
    setTimeout(() => {
        resolve("Hecho"); // Cambia el estado a 'cumplido'
    }, 3000);
});

console.log("Promesa antes de ser resuelta", promesa); // imprimme la promesa para ver el estado
setTimeout(() => {
    console.log("Promesa antes de ser resuelta", promesa);
}, 3000);
// ejecuta la misma funcion de tiempo para el mensaje en la consola para ver claramente el resultado

let promesaRechazada = new Promise(function (resolve, reject) {
    setTimeout(() => {
        reject("ERROR!!!"); // Cambia el estado a 'cumplido'
    }, 3000);
});

console.log("Promesa antes de ser rechazada", promesaRechazada); // imprimme la promesa para ver el estado
setTimeout(() => {
    console.log("Promesa antes de ser rechazada", promesaRechazada);
}, 3000);
// ejecuta la misma funcion de tiempo para el mensaje en la consola para ver claramente el resultado
