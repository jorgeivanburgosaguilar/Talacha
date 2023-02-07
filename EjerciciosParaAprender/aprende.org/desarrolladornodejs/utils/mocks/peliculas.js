const { faker } = require("@faker-js/faker");

// Preferi usar faker en lugar de crear un objeto manualmente
function generarPeliculas() {
    let peliculas = [];
    for (let i = 0; i < 10; i++) {
        peliculas.push({
            id: faker.datatype.uuid(),
            titulo: faker.lorem.words(),
        });
    }
    return peliculas;
}

const peliculasMock = generarPeliculas();

module.exports = { peliculasMock };
