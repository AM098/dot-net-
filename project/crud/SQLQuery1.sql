use crud_operation
USE  crud_operation
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON

GO

 

CREATE TABLE [dbo].[Employee1](

            [id] [int] NOT NULL,

            [name] [varchar](50) NOT NULL,

            [salary] [int] NOT NULL,

            [address] [varchar](50) NOT NULL,

 CONSTRAINT [PK_Employee1] PRIMARY KEY CLUSTERED 

(

            [id] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

 

GO

 

SET ANSI_PADDING OFF

GO