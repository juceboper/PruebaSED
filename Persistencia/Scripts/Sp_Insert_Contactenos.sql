-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Julio Bolaño
-- Create Date:  11/02/2019
-- Description: Inserta la información de contactenos
-- =============================================
CREATE PROCEDURE Sp_Insert_Contactenos(@IdTipoDocumento int, @Nombres varchar(50), @Apellidos varchar(50), @Email varchar(50), @Telefono varchar(20), @Asunto varchar(50), @Mensaje varchar(1000))
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Insert statements for procedure here

INSERT INTO [dbo].[TBCONTACTENOS]
           ([IdTipoDocumento]
           ,[Nombres]
           ,[Apellidos]
           ,[Email]
           ,[Telefono]
           ,[Asunto]
           ,[Mensaje])
     VALUES
           (@IdTipoDocumento
           ,@Nombres
           ,@Apellidos
           ,@Email
           ,@Telefono
           ,@Asunto
           ,@Mensaje)

END
GO
