USE [ExamenVDG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoConsola](
    [IdTipoConsola] [tinyint] IDENTITY(1,1) NOT NULL,
    [Nombre] [varchar](256) NOT NULL
 CONSTRAINT [PK_TipoConsola] PRIMARY KEY CLUSTERED 
(
    [IdTipoConsola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TipoConsola] ON 
INSERT [dbo].[TipoConsola] ([IdTipoConsola], [Nombre]) VALUES (1, N'Microsft Xbox Series X')
INSERT [dbo].[TipoConsola] ([IdTipoConsola], [Nombre]) VALUES (2, N'Sony PlayStation 5')
INSERT [dbo].[TipoConsola] ([IdTipoConsola], [Nombre]) VALUES (3, N'Nintendo Switch')
SET IDENTITY_INSERT [dbo].[TipoConsola] OFF
GO