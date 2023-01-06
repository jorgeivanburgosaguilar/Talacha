USE [ExamenVDG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoGenero](
    [IdTipoGenero] [tinyint] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](256) NOT NULL
 CONSTRAINT [PK_TipoGenero] PRIMARY KEY CLUSTERED 
(
    [IdTipoGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TipoGenero] ON 
INSERT [dbo].[TipoGenero] ([IdTipoGenero], [Nombre]) VALUES (1, N'Acción')
INSERT [dbo].[TipoGenero] ([IdTipoGenero], [Nombre]) VALUES (2, N'Deportes')
INSERT [dbo].[TipoGenero] ([IdTipoGenero], [Nombre]) VALUES (3, N'Estrategia')
SET IDENTITY_INSERT [dbo].[TipoGenero] OFF
GO