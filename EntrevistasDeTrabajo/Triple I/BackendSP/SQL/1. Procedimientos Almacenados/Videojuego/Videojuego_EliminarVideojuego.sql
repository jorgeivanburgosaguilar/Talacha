USE [ExamenVDG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Burgos
-- Create date: 23/05/2022
-- Description:	Elimina un videojuego
-- =============================================
CREATE PROCEDURE [dbo].[Videojuego_EliminarVideojuego]
    @IdVideojuego int
AS
BEGIN
    IF (NOT EXISTS(SELECT IdVideojuego FROM Videojuego WHERE IdVideojuego = @IdVideojuego))
        RETURN(2)

    BEGIN TRANSACTION
    BEGIN TRY
        DELETE FROM [dbo].[Videojuego]
              WHERE [IdVideojuego] = @IdVideojuego

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
