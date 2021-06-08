USE [lab7db]
GO

/****** Object: Table [dbo].[Table] Script Date: 08.06.2021 23:19:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Coin] (
    [CoinId]   INT           IDENTITY (1, 1) NOT NULL,
    [Title]    NVARCHAR (50) NOT NULL,
    [Amount]   FLOAT (53)    NOT NULL,
    [CrtPrice] FLOAT (53)    NOT NULL,
    [CrtCost]  FLOAT (53)    NOT NULL
);



