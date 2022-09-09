/***** CREACION DE BASE DE DATOS *****/
IF NOT EXISTS (
	SELECT name FROM sys.databases WHERE name = 'SanDiegoDB'
)
	CREATE DATABASE SanDiegoDB
GO

/***** CREACION DE TABLA *****/
IF OBJECT_ID('dbo.LecturaContador', 'U') IS NULL
BEGIN

	CREATE TABLE dbo.LecturaContador(
		IdLectura INT,
		NumContador VARCHAR(50) NOT NULL,
		Fecha DATETIME NOT NULL,
		Valor DECIMAL(20, 8) NOT NULL,
		Observaciones VARCHAR(999),
		Estado VARCHAR(1) DEFAULT ('A') NOT NULL CONSTRAINT CHK_LecturaContador__Estado CHECK (Estado IN ('A', 'I')),
		CONSTRAINT LecturaContador_PK PRIMARY KEY (IdLectura)
	) 
	PRINT 'Tabla LecturaContador Creada'
END

GO

/***** CREACION DE PROCEDIMIENTOS *****/
CREATE OR ALTER PROCEDURE dbo.SPLecturaContador_Crear
    @NumContador varchar(25),
	@Fecha datetime,
	@Valor decimal(20, 8),
	@Observaciones varchar(999)
AS
BEGIN

	DECLARE @Index INT = (SELECT ISNULL(MAX(IdLectura),0) + 1 FROM LecturaContador WITH (NOLOCK))

	INSERT INTO LecturaContador ( 
			IdLectura, 
			NumContador,
			Fecha,
			Valor,
			Observaciones
			)
	VALUES (
			@Index, 
			@NumContador,
			@Fecha,
			@Valor,
			@Observaciones
			)
	
	SELECT @Index
	
END

GO

CREATE OR ALTER PROCEDURE dbo.SPLecturaContador_Actualizar
	@IdLectura int = null,
    @NumContador varchar(25),
	@Fecha datetime,
	@Valor decimal(20, 8),
	@Observaciones varchar(999)
AS
BEGIN

	UPDATE dbo.LecturaContador
	SET	NumContador = @NumContador,
		Fecha = @Fecha,
		Valor = @Valor,
		Observaciones = @Observaciones
	WHERE IdLectura = @IdLectura
	
END

GO

CREATE OR ALTER PROCEDURE dbo.SPLecturaContador_Eliminar
	@IdLectura int = null
AS
BEGIN

	UPDATE dbo.LecturaContador
	SET
		Estado = 'I'
	WHERE IdLectura = @IdLectura
		    
END

GO

CREATE OR ALTER PROCEDURE dbo.SPLecturaContador_Listar
	@IdLectura int = NULL
AS
BEGIN

	SELECT
		IdLectura,
		NumContador,
		Fecha,
		Valor,
		Observaciones,
		Estado
	FROM dbo.LecturaContador WITH (NOLOCK)
	WHERE Estado = 'A'
		  AND IdLectura = ISNULL(@IdLectura, IdLectura)
END

GO


