function realizaAlgo(asyncCallback) {
    setTimeout(asyncCallback, Math.random() + 1000);
}

realizaAlgo(() => {
    console.log("Esto se ejecuta de forma asincrona");
});

console.log("Respuesta adelantada");
