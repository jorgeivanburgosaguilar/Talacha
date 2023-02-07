const express = require("express");
const { peliculasMock } = require("../utils/mocks/peliculas.js");

function peliculasAPI(app) {
    const router = express.Router();
    // En la version original del video usan app.user que esta incorrecto es app.use
    app.use("/api/peliculas", router);

    router.get("/", async function (req, res, next) {
        try {
            const peliculas = await Promise.resolve(peliculasMock);
            res.status(200).json({
                data: peliculas,
                message: "peliculas listadas",
            });
        } catch (err) {
            next(err);
        }
    });
}

module.exports = peliculasAPI;
