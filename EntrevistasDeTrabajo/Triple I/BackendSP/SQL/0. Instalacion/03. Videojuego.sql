USE [ExamenVDG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videojuego](
    [IdVideojuego] [int] IDENTITY(1,1) NOT NULL,
    [IdTipoConsola] [tinyint] NOT NULL,
    [IdTipoGenero] [tinyint] NOT NULL,
    [Titulo] [nvarchar](256) NOT NULL,
    [Descripcion] [nvarchar](max) NOT NULL,
    [Anio] [smallint] NOT NULL,
    [Calificacion] [tinyint] NOT NULL,
    [Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_Videojuego] PRIMARY KEY CLUSTERED 
(
    [IdVideojuego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Videojuego] ADD  CONSTRAINT [DF_Videojuego_Calificacion]  DEFAULT ((1)) FOR [Calificacion]
GO
ALTER TABLE [dbo].[Videojuego] ADD  CONSTRAINT [DF_Videojuego_Cantidad]  DEFAULT ((1)) FOR [Cantidad]
GO
ALTER TABLE [dbo].[Videojuego]  WITH CHECK ADD  CONSTRAINT [FK_Videojuego_TipoConsola] FOREIGN KEY([IdTipoConsola])
REFERENCES [dbo].[TipoConsola] ([IdTipoConsola])
GO
ALTER TABLE [dbo].[Videojuego] CHECK CONSTRAINT [FK_Videojuego_TipoConsola]
GO
ALTER TABLE [dbo].[Videojuego]  WITH CHECK ADD  CONSTRAINT [FK_Videojuego_TipoGenero] FOREIGN KEY([IdTipoGenero])
REFERENCES [dbo].[TipoGenero] ([IdTipoGenero])
GO
ALTER TABLE [dbo].[Videojuego] CHECK CONSTRAINT [FK_Videojuego_TipoGenero]
GO