SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl]) VALUES (1, N'Top Gun: Maverick', N'Joseph Kosinski', 2022, CAST(67.00 AS Decimal(18, 2)), NULL)
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl]) VALUES (2, N'Talk to Me', N' Danny Philippou, Michael Philippou ', 2022, CAST(89.00 AS Decimal(18, 2)), NULL)
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl]) VALUES (3, N'Don''t Worry Darling ', N'Olivia Wilde', 2022, CAST(149.00 AS Decimal(18, 2)), NULL)
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl]) VALUES (4, N' The Batman', N' Matt Reeves', 2022, CAST(39.00 AS Decimal(18, 2)), NULL)
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl]) VALUES (5, N'The Shawshank Redemption', N' Frank Darabont', 1994, CAST(199.00 AS Decimal(18, 2)), NULL)
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl]) VALUES (6, N'The Godfather', N' Francis Ford Coppola', 1972, CAST(149.00 AS Decimal(18, 2)), NULL)
INSERT INTO [dbo].[Movies] ([Id], [Title], [Director], [ReleaseYear], [Price], [ImgUrl], [Description]) VALUES (7, N'The Dark Knight', N'Christopher Nolan', 2008, CAST(79.00 AS Decimal(18, 2)), NULL, 'something')
SET IDENTITY_INSERT [dbo].[Movies] OFF
