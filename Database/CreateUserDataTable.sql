
CREATE TABLE [dbo].[UserData](
	[RecordId] [int] NULL,
	[UserId] [int] NULL,
	[UserName] [nvarchar](255) NULL,
	[UserEmail] [nvarchar](255) NULL,
	[DataValue] [nvarchar](max) NULL,
	[NotificationFlag] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL
)
GO


