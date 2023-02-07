USE [ExamenVDG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwVideojuego]
AS
    SELECT       V.IdVideojuego
                ,TC.IdTipoConsola
                ,TC.Nombre AS Consola
                ,TG.IdTipoGenero
                ,TG.Nombre AS Genero
                ,V.Titulo
                ,V.Descripcion
                ,V.Anio
                ,V.Calificacion
                ,V.Cantidad
    FROM        Videojuego AS V
    INNER JOIN  TipoConsola AS TC ON TC.IdTipoConsola = V.IdTipoConsola
    INNER JOIN  TipoGenero AS TG ON TG.IdTipoGenero = V.IdTipoGenero
GO