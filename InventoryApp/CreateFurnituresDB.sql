USE [Furnitures]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 1/29/2017 11:54:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Furniture](
	[FurnitureId] [int] IDENTITY(1,1) NOT NULL,
	[FurnitureDescription] [nvarchar](50) NOT NULL,
	[FurniturePrice] [float] NULL,
	[FurnitureQuantity] [int] NULL,
	[FurnitureCost] [float] NULL,
	[FurnitureValue] [float] NOT NULL,
 CONSTRAINT [PK_Furniture] PRIMARY KEY CLUSTERED 
(
	[FurnitureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, 
IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO