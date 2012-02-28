USE [StofferIT_Intranet_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SP_Address_Delete]    Script Date: 02/29/2012 00:22:30 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Address_Delete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Address_Delete]
GO


USE [StofferIT_Intranet_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SP_Address_ReadByKey]    Script Date: 02/29/2012 00:22:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Address_ReadByKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Address_ReadByKey]
GO


USE [StofferIT_Intranet_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SP_Address_Create]    Script Date: 02/29/2012 00:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Address_Create]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Address_Create]
GO

USE [StofferIT_Intranet_Dev]
GO

/****** Object:  StoredProcedure [dbo].[SP_Address_Create]    Script Date: 02/29/2012 00:22:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_Address_ReadByKey]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[SP_Address_ReadByKey]
GO


USE [StofferIT_Intranet_Dev]
GO

/****** Object:  Table [dbo].[Address]    Script Date: 02/29/2012 00:22:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
DROP TABLE [dbo].[Address]
GO