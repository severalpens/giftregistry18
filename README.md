USE [master]
GO
/****** Object:  Table [GR].[Gift]    Script Date: 20/10/2019 7:29:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GR].[Gift](
	[GiftID] [int] IDENTITY(1,1) NOT NULL,
	[GiftRegistryID] [int] NOT NULL,
	[GiftName] [varchar](500) NULL,
	[GiftDescription] [varchar](4000) NULL,
	[Email] [varchar](500) NULL,
 CONSTRAINT [PK_GR.Gift] PRIMARY KEY CLUSTERED 
(
	[GiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GR].[GiftRegistry]    Script Date: 20/10/2019 7:29:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GR].[GiftRegistry](
	[GiftRegistryID] [int] IDENTITY(1,1) NOT NULL,
	[GiftRegistryName] [varchar](500) NULL,
 CONSTRAINT [PK_GR.GiftRegistry] PRIMARY KEY CLUSTERED 
(
	[GiftRegistryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GR].[GiftRegistryInvite]    Script Date: 20/10/2019 7:29:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GR].[GiftRegistryInvite](
	[GiftRegistryInviteID] [int] IDENTITY(1,1) NOT NULL,
	[GiftRegistryID] [int] NOT NULL,
	[InviteeName] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
 CONSTRAINT [PK_GR.GiftRegistryInvite] PRIMARY KEY CLUSTERED 
(
	[GiftRegistryInviteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [GR].[GiftRegistryMember]    Script Date: 20/10/2019 7:29:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GR].[GiftRegistryMember](
	[GiftRegistryMemberID] [int] IDENTITY(1,1) NOT NULL,
	[GiftRegistryID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_GR.GiftRegistryMember] PRIMARY KEY CLUSTERED 
(
	[GiftRegistryMemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [GR].[Member]    Script Date: 20/10/2019 7:29:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GR].[Member](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[MemberName] [varchar](500) NULL,
	[MemberEmail] [varchar](500) NULL,
	[HasEmail] [bit] NOT NULL,
	[AccountID] [nvarchar](max) NULL,
 CONSTRAINT [PK_GR.Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [GR].[MemberGift]    Script Date: 20/10/2019 7:29:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [GR].[MemberGift](
	[MemberGiftID] [int] IDENTITY(1,1) NOT NULL,
	[GiftID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[Recipient] [bit] NOT NULL,
	[Suggestor] [bit] NOT NULL,
	[Contributor] [bit] NOT NULL,
 CONSTRAINT [PK_GR.MemberGift] PRIMARY KEY CLUSTERED 
(
	[MemberGiftID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
