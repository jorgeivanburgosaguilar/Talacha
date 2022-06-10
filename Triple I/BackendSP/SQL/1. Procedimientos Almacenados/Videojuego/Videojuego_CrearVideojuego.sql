USE [ExamenVDG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Burgos
-- Create date: 23/05/2022
-- Description:	Crea un nuevo videojuego
-- =============================================
CREATE PROCEDURE [dbo].[Videojuego_CrearVideojuego]
     @IdTipoConsola tinyint
    ,@IdTipoGenero tinyint
    ,@Titulo nvarchar(256)
    ,@Descripcion nvarchar(max)
    ,@Anio smallint
    ,@Calificacion tinyint
    ,@Cantidad int
    ,@IdVideojuego int=NULL OUTPUT
AS
BEGIN
    IF (NOT EXISTS(SELECT IdTipoConsola FROM TipoConsola WHERE IdTipoConsola = @IdTipoConsola))
        RETURN(2)

    IF (NOT EXISTS(SELECT IdTipoGenero FROM TipoGenero WHERE IdTipoGenero = @IdTipoGenero))
        RETURN(2)

    IF (@Calificacion > 10)
        SET @Calificacion = 10

    IF (@Calificacion = 0)
        SET @Calificacion = 1

    IF (@Cantidad < 1)
        SET @Cantidad = 0

    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO [dbo].[Videojuego]
                   ([IdTipoConsola]
                   ,[IdTipoGenero]
                   ,[Titulo]
                   ,[Descripcion]
                   ,[Anio]
                   ,[Calificacion]
                   ,[Cantidad])
             VALUES
                   (@IdTipoConsola
                   ,@IdTipoGenero
                   ,@Titulo
                   ,@Descripcion
                   ,@Anio
                   ,@Calificacion
                   ,@Cantidad)
        
        SET @IdVideojuego = SCOPE_IDENTITY()
        COMMIT TRANSACTION
        RETURN(0)
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT>0
            ROLLBACK TRANSACTION

        RETURN(3)
    END CATCH
END
GO
