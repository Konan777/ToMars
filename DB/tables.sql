-- для проверки Entity Framework Extensions

/****** Object:  Table [dbo].[AAA_300]    Script Date: 23.02.2019 12:54:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AAA_300](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DT01] [date] NOT NULL,
	[TXT01] [varchar](50) NOT NULL,
	[TXT02] [varchar](50) NOT NULL,
	[TXT03] [varchar](50) NOT NULL,
	[TIME01] [varchar](50) NOT NULL,
	[TIME02] [varchar](50) NULL,
	[COST] [float] NULL,
 CONSTRAINT [PK_AAA_300] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

-- для проверки Bulk & XML

/****** Object:  Table [dbo].[AAA_100]    Script Date: 23.02.2019 12:54:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[AAA_100](
	[DT01] [date] NOT NULL,
	[TXT01] [varchar](50) NOT NULL,
	[TXT02] [varchar](50) NOT NULL,
	[TXT03] [varchar](50) NOT NULL,
	[TIME01] [varchar](50) NOT NULL,
	[TIME02] [varchar](50) NULL,
	[COST] [float] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO




-- PrimaryKey with Identity
CREATE TABLE [dbo].[TestApp01](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AtomId] [int] NULL,
	[Version] [int] NULL,
	[BindingRuleId] [int] NULL,
	[AccountId] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ClientId] [nvarchar](max) NULL,
	[DataSource] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
	[Medium] [nvarchar](max) NULL,
	[Campaign] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Term] [nvarchar](max) NULL,
	[FullUrl] [nvarchar](max) NULL,
	[DateStatus] [datetime] NULL,
	[Label] [nvarchar](300) NULL,
	[GaFound] [bit] NULL,
	[GaSource] [nvarchar](max) NULL,
	[GaMedium] [nvarchar](max) NULL,
	[GaCampaign] [nvarchar](max) NULL,
	[GaPapId] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestApp01] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


-- PrimaryKey without Identity
CREATE TABLE [dbo].[TestApp02](
	[Id] [bigint] NOT NULL,
	[AtomId] [int] NULL,
	[Version] [int] NULL,
	[BindingRuleId] [int] NULL,
	[AccountId] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ClientId] [nvarchar](max) NULL,
	[DataSource] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
	[Medium] [nvarchar](max) NULL,
	[Campaign] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Term] [nvarchar](max) NULL,
	[FullUrl] [nvarchar](max) NULL,
	[DateStatus] [datetime] NULL,
	[Label] [nvarchar](300) NULL,
	[GaFound] [bit] NULL,
	[GaSource] [nvarchar](max) NULL,
	[GaMedium] [nvarchar](max) NULL,
	[GaCampaign] [nvarchar](max) NULL,
	[GaPapId] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestApp02] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


-- Composite PrimaryKey
CREATE TABLE [dbo].[TestApp03](
	[Id] [bigint] NOT NULL,
	[AtomId] [int] NOT NULL,
	[Version] [int] NULL,
	[BindingRuleId] [int] NULL,
	[AccountId] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[ClientId] [nvarchar](max) NULL,
	[DataSource] [nvarchar](max) NULL,
	[Source] [nvarchar](max) NULL,
	[Medium] [nvarchar](max) NULL,
	[Campaign] [nvarchar](max) NULL,
	[Content] [nvarchar](max) NULL,
	[Term] [nvarchar](max) NULL,
	[FullUrl] [nvarchar](max) NULL,
	[DateStatus] [datetime] NULL,
	[Label] [nvarchar](300) NULL,
	[GaFound] [bit] NULL,
	[GaSource] [nvarchar](max) NULL,
	[GaMedium] [nvarchar](max) NULL,
	[GaCampaign] [nvarchar](max) NULL,
	[GaPapId] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestApp03] PRIMARY KEY ([Id] , [AtomId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

