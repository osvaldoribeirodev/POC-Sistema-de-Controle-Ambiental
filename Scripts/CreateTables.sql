USE [SCA]
GO
/****** Object:  User [sca]    Script Date: 09/04/2020 22:57:23 ******/
CREATE USER [sca] FOR LOGIN [sca] WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [sca]
GO
/****** Object:  Table [db_owner].[__EFMigrationsHistory]    Script Date: 09/04/2020 22:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [db_owner].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [db_owner].[Ativo]    Script Date: 09/04/2020 22:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [db_owner].[Ativo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](200) NOT NULL,
	[Fabricante] [varchar](200) NOT NULL,
	[NumeroSerie] [varchar](20) NOT NULL,
	[ManutencaoAgendada] [bit] NOT NULL,
	[DataManutencao] [datetime2](7) NULL,
	[TipoManutencao] [varchar](15) NULL,
	[Situacao] [varchar](10) NOT NULL,
	[DataCriacao] [datetime2](7) NOT NULL,
	[DataUltimaAtualizacao] [datetime2](7) NOT NULL,
	[ClasseId] [int] NOT NULL,
 CONSTRAINT [PK_Ativo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [db_owner].[Classe]    Script Date: 09/04/2020 22:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [db_owner].[Classe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](180) NOT NULL,
 CONSTRAINT [PK_Classe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [db_owner].[Perfil]    Script Date: 09/04/2020 22:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [db_owner].[Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Perfil] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [db_owner].[Usuario]    Script Date: 09/04/2020 22:57:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [db_owner].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](180) NOT NULL,
	[Login] [varchar](30) NOT NULL,
	[Senha] [varchar](180) NOT NULL,
	[Situacao] [varchar](10) NOT NULL,
	[PerfilId] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO
ALTER TABLE [db_owner].[Ativo]  WITH CHECK ADD  CONSTRAINT [FK_Ativo_Classe_ClasseId] FOREIGN KEY([ClasseId])
REFERENCES [db_owner].[Classe] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [db_owner].[Ativo] CHECK CONSTRAINT [FK_Ativo_Classe_ClasseId]
GO
ALTER TABLE [db_owner].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Perfil_PerfilId] FOREIGN KEY([PerfilId])
REFERENCES [db_owner].[Perfil] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [db_owner].[Usuario] CHECK CONSTRAINT [FK_Usuario_Perfil_PerfilId]
GO
/****** Object: Table [db_owner].[Estoque] Script Date: 24/04/2020 07:45:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [db_owner].[Estoque] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (180) NOT NULL,
    [DataCriacao] DATETIME2 (7) NOT NULL
);