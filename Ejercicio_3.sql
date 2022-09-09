-- =============================================
-- Author:		Arnoldo Escobar Ponce
-- Create date: 07-09-2022
-- Description:	Ejercicio 3
-- =============================================

IF OBJECT_ID('dbo.Ciudadano', 'U') IS NULL
BEGIN

	CREATE TABLE dbo.Ciudadano (
		DPI VARCHAR(100) PRIMARY KEY,
		Nombres VARCHAR(500),
		Apellidos VARCHAR(500),
		Fecha_Nacimiento DATE
	)

	PRINT 'Tabla <dbo.Ciudadano> Creada'
END

GO

CREATE OR ALTER PROCEDURE dbo.SPCiudadano_CrearActualizar
	@DPI VARCHAR(100),
	@Nombres VARCHAR(500),
	@Apellidos VARCHAR(500),
	@Fecha_Nacimiento DATE
AS
BEGIN

	IF NOT EXISTS(SELECT * FROM dbo.Ciudadano WHERE DPI = @DPI)
	BEGIN 
		INSERT INTO dbo.Ciudadano ( 
					DPI,
					Nombres ,
					Apellidos,
					Fecha_Nacimiento
				)
		VALUES (
					@DPI,
					@Nombres ,
					@Apellidos,
					@Fecha_Nacimiento
				)
		PRINT 'Registro Insertado'
	END
	ELSE
	BEGIN
		UPDATE dbo.Ciudadano
		SET
			Nombres = @Nombres ,
			Apellidos = @Apellidos,
			Fecha_Nacimiento = @Fecha_Nacimiento
		WHERE DPI = @DPI
		PRINT 'Registro Actualizado'
	END
	
END

GO

EXEC dbo.SPCiudadano_CrearActualizar @DPI = '1231123123', @Nombres = 'Arnoldo', @Apellidos = 'Escobar Ponce', @Fecha_Nacimiento = '1986-11-07'

EXEC dbo.SPCiudadano_CrearActualizar @DPI = '9832333123', @Nombres = 'Paola', @Apellidos = 'Escobar de Mata', @Fecha_Nacimiento = '1983-08-27'

SELECT * FROM dbo.Ciudadano