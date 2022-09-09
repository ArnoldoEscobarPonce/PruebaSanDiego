-- =============================================
-- Author:		Arnoldo Escobar Ponce
-- Create date: 07-09-2022
-- Description:	Ejercicio 1
-- =============================================

--DROP TYPE dbo.Persona_TableType

-- Declarar un Tipo de Dato TABLA
IF type_id('dbo.Persona_TableType') IS NULL
	CREATE TYPE dbo.Persona_TableType AS TABLE(
		Nombre varchar(100),
		FechaNacimiento DATE
	)

	PRINT 'TYPE <dbo.Persona_TableType> Creada'
GO

-- Crea una funcion que recibe una tabla y devuelve la misma con el campo calculado Edad
CREATE OR ALTER FUNCTION dbo.Obtener_Fecha_Nacimiento
(
	@TmpTable Persona_TableType READONLY
)
RETURNS TABLE
AS
RETURN 
	SELECT Nombre, FechaNacimiento, DATEDIFF(YEAR, FechaNacimiento, GETDATE()) AS Edad 
	FROM @TmpTable

GO

-- Declaramos una tabla del tipo personalizado
DECLARE @Empleados dbo.Persona_TableType

-- Insertamos datos
INSERT INTO @Empleados VALUES('Arnoldo','1986-11-07')
INSERT INTO @Empleados VALUES('Paola','1983-08-27')
INSERT INTO @Empleados VALUES('Jose','2012-10-1')
INSERT INTO @Empleados VALUES('Ricardo','2015-09-22')

-- Prueba final de Funcion
SELECT * FROM dbo.Obtener_Fecha_Nacimiento(@Empleados)