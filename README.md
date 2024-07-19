##Use Below query to default user

USE [RafatDB]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [FullName], [UserName], [Password], [Role], [IsSecondaryUser], [UserId], [Phone], [Email], [Address], [CreatedDate], [EditedDate]) VALUES (1, N'الشعبة الادارية', N'admin', N'12345', N'User', 0, N'7e3c6ce6-a05b-4cbe-b0fc-c6057cd30541', N'', N'', N'', CAST(N'2024-06-14T00:00:00.0000000' AS DateTime2), CAST(N'2024-07-17T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (18, N'checkBoxAdd', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (19, N'checkBoxDelete', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (20, N'checkBoxEdit', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (21, N'checkBoxExport', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (22, N'checkBoxPrint', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (23, N'checkBoxSearch', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (24, N'checkBoxHomeSearch', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (25, N'checkBoxHome', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (26, N'checkBoxSalary', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (27, N'checkBoxEmployees', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (28, N'checkBoxUsers', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (29, N'checkBoxReport', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (30, N'checkBoxSettings', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (31, N'checkBoxAbout', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (32, N'checkBoxHelp', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (33, N'checkBoxRetirmnet', 1, 1)
GO
INSERT [dbo].[Roles] ([Id], [Key], [Value], [UsersId]) VALUES (34, N'checkBoxSystemRecords', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
