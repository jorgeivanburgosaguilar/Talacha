function tripleDespues1Segundo(numero) {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve(numero * 3);
        }, 1000);
    });
}

const ResultadoFinal = async function (numero) {
    try {
        let triple = await tripleDespues1Segundo(numero).then((result) => {
            console.log(result);
        });
        return triple;
    } catch (error) {
        console.log("ERROR =>", error);
    }
};

ResultadoFinal(20);
