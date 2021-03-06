USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 3/3/2017 2:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 3/3/2017 2:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 3/3/2017 2:44:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[bands] ON 

INSERT [dbo].[bands] ([id], [name]) VALUES (1, N'Dave Matthews Band')
INSERT [dbo].[bands] ([id], [name]) VALUES (2, N'Beyonce')
INSERT [dbo].[bands] ([id], [name]) VALUES (9, N'Britney Spears')
INSERT [dbo].[bands] ([id], [name]) VALUES (10, N'John Mayer')
INSERT [dbo].[bands] ([id], [name]) VALUES (11, N'Adele')
INSERT [dbo].[bands] ([id], [name]) VALUES (12, N'Keith Ubran')
INSERT [dbo].[bands] ([id], [name]) VALUES (8, N'Jack Johnson')
SET IDENTITY_INSERT [dbo].[bands] OFF
SET IDENTITY_INSERT [dbo].[bands_venues] ON 

INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (5, 8, 2)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (2, 1, 2)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (8, 10, 5)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (6, 1, 5)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (7, 9, 5)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (9, 1, 6)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (10, 10, 7)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (11, 11, 7)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (12, 9, 8)
INSERT [dbo].[bands_venues] ([id], [band_id], [venue_id]) VALUES (13, 12, 6)
SET IDENTITY_INSERT [dbo].[bands_venues] OFF
SET IDENTITY_INSERT [dbo].[venues] ON 

INSERT [dbo].[venues] ([id], [name]) VALUES (5, N'Key Arena')
INSERT [dbo].[venues] ([id], [name]) VALUES (2, N'The Gorge')
INSERT [dbo].[venues] ([id], [name]) VALUES (6, N'Puyallup Fairgrounds')
INSERT [dbo].[venues] ([id], [name]) VALUES (7, N'The Showbox')
INSERT [dbo].[venues] ([id], [name]) VALUES (8, N'Neumos')
SET IDENTITY_INSERT [dbo].[venues] OFF
