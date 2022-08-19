let promesa = new Promise(function (resolve, reject) {
    setTimeout(() => {
        // El ejemplo en el video tenia reject pero creo que hiba resolve
        resolve("Hecho"); // Simula la accion de 'cumplido'
    }, 3000);
});

promesa.then((result) => {
    console.log("Exito", result);
});

let promesaRechazada = new Promise(function (resolve, reject) {
    setTimeout(() => {
        reject("ERROR!!!"); // Simula la accion de 'falla'
    }, 3000);
});

promesaRechazada.catch((error) => {
    console.log("FALLA!!", error);
});
