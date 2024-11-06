CREATE DATABASE TesteDb;

USE [TesteDb]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 06/11/2024 15:50:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[Cpf] [nvarchar](15) NOT NULL,
	[DataNascimento] [datetime] NOT NULL,
	[UfNascimento] [nvarchar](2) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [TesteDb]
GO

/****** Object:  Table [dbo].[Endereco]    Script Date: 06/11/2024 15:50:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClienteId] [int] NOT NULL,
	[Logradouro] [nvarchar](500) NOT NULL,
	[Bairro] [nvarchar](500) NOT NULL,
	[Cidade] [nvarchar](500) NOT NULL,
	[Uf] [nvarchar](2) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
GO



