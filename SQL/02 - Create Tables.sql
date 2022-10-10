USE [Financeiro]
GO

/****** Object:  Table [dbo].[Cliente]    Script Date: 10/10/2022 16:40:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO




USE [Financeiro]
GO

/****** Object:  Table [dbo].[TipoLancamento]    Script Date: 10/10/2022 16:40:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TipoLancamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](80) NOT NULL,
	[Tipo] [int] NOT NULL,
 CONSTRAINT [PK_TipoLancamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO





USE [Financeiro]
GO

/****** Object:  Table [dbo].[Lancamento]    Script Date: 10/10/2022 16:40:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Lancamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](80) NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[Valor] [float] NOT NULL,
	[TipoLancamentoId] [int] NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Lancamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_Cliente_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Cliente] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_Cliente_ClienteId]
GO

ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_TipoLancamento_TipoLancamentoId] FOREIGN KEY([TipoLancamentoId])
REFERENCES [dbo].[TipoLancamento] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_TipoLancamento_TipoLancamentoId]
GO


