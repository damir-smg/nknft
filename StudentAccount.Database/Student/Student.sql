USE [Students]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 05.04.2023 23:11:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students]
(
    [id]          [int] IDENTITY (1,1) NOT NULL,
    [first_name]  [nvarchar](100)      NOT NULL,
    [second_name] [nvarchar](100)      NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED
        (
         [id] ASC
            ) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO