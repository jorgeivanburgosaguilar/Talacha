function servicio(usuario, peticion) {
    // En la version original del video tutorial usaban $() en lugar de ${} que es incorrecta
    // se deja el codigo original como anotacion por si alguien mas se da cuenta.
    //const respuesta = `Gracias, $(usuario), en un momento atenderemos su peticion: $(peticion)`;

    const respuesta = `Gracias, ${usuario}, en un momento atenderemos su peticion: ${peticion}`;
    return respuesta;
}

console.log(servicio("Usuario Maria", "Necesitio un chocolate, por favor"));
console.log(servicio("Usuario Octavio", "Necesitio un helado, por favor"));
console.log(servicio("Usuario Ana", "Necesitio un capuccino, por favor"));

function agente(nombre, recado, responsable) {
    return responsable(nombre, recado);
}

const persona1 = agente(
    "Usuario Maria",
    "Necesitio un chocolate, por favor",
    servicio
);

const persona2 = agente(
    "Usuario Octavio",
    "Necesitio un helado, por favor",
    servicio
);

const persona3 = agente(
    "Usuario Ana",
    "Necesitio un capuccino, por favor",
    servicio
);

console.log(persona1);
console.log(persona2);
console.log(persona3);
