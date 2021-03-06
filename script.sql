USE [TranslationDb]
GO
/****** Object:  Table [dbo].[T_ACCOUNTS]    Script Date: 24.04.2022 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ACCOUNTS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](max) NULL,
	[password] [varchar](max) NULL,
 CONSTRAINT [PK_T_ACCOUNTS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TRANSLATIONS_LOG]    Script Date: 24.04.2022 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TRANSLATIONS_LOG](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[total] [int] NULL,
	[translated] [varchar](max) NULL,
	[text] [varchar](max) NULL,
	[translation] [varchar](max) NULL,
	[create_time] [date] NOT NULL,
 CONSTRAINT [PK_T_TRANSLATIONS_LOG] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_TRANSLATIONS_LOG] ADD  DEFAULT (getdate()) FOR [create_time]
GO
/****** Object:  StoredProcedure [dbo].[checkAccount]    Script Date: 24.04.2022 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[checkAccount] @Username nvarchar(100),@Password nvarchar(100)
AS
SELECT TOP 1 1 "Verify" FROM T_ACCOUNTS WHERE username =  @Username and password = @Password
GO

INSERT INTO T_ACCOUNTS (username, password)
VALUES ('utkuunal', 'bestpwintheworld');