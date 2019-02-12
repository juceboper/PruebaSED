-- =======================================================
-- Create Stored Procedure Template for Azure SQL Database
-- =======================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:      Julio Bolaño
-- Create Date: 11/02/2019
-- Description: Obtiene los Tipos de Documentos
-- =============================================
CREATE PROCEDURE Sp_Get_TipoDocumentos
AS
BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

	SELECT [IdTipoDocumento]
		  ,[TipoDocumento]
	  FROM [dbo].[TBTIPODOCUMENTO]

END
GO
