
														--LUNES 2020 JUNIO 15 10:10AM--
USE master
GO
											--GESTOR DE BASE DATOS = SQL SERVER 2014 MANAGEMENT STUDIO--

CREATE DATABASE FRESHDENT /*SE CREA LA BASE DE DATOS APLICANDO NOMBRE A ELLA*/
GO

USE FRESHDENT /*SE MANDA A LLAMAR EL NOMBRE DE LA BASE DE DATOS PARA GUARDAR LA CODIFICACI�N QUE TENDR� PARA QUE M�S ADELANTE UTILIZARLA PARA GUARDAR INFORMACI�N POR OTROS MEDIOS PROGRAMATIVOS, EN ESTE CASO EL SISTEMA
				QUE EST� CREADO EN VISUAL STUDIO RELACIONADO A ODONTOLOGIA*/
GO

CREATE TABLE Expediente (																--Creaci�n de la tabla Expediente.
IdExpediente INT PRIMARY KEY IDENTITY (1,1),											--Almacena el c�digo de expediente.
Cedula VARCHAR (100),																	--Almacena la c�dula de la persona en el expediente.
Nombres VARCHAR (80),																	--Almacena los nombres de la persona en el expediente.
Apellidos VARCHAR (80),																	--Almacena los apellidos de la persona en el expediente.
Fecha_Nacimiento varchar (30),															--Almacena la fecha de nacimiento de la persona en el expediente.
Telefono_Celular INT,																	--Almacena el tel�fono-celular de la persona en el expediente.
Municipio VARCHAR (50),																	--Almacena el municipio donde vive la persona en el expediente. 
Departamento VARCHAR (50),																--Almacena el departamento que forma parte el municipio donde vive la persona en el expediente.
CONSTRAINT Expediente_Paciente UNIQUE (Cedula, Fecha_Nacimiento, Telefono_Celular)
);

CREATE TABLE Receta (																	--Creaci�n de la tabla Receta.
IdReceta INT PRIMARY KEY IDENTITY (1,1),												--Almacena c�digo de receta m�dica.
Nombre VARCHAR (50),																	--Almacena el nombre de lo medicamento.
Presentacion VARCHAR (100),																--Almacena la informaci�n del medicamento.
Cantidad INT,																			--Almacena cantidad de medicamentos.
Descripcion VARCHAR (150),																--Almacena la indicaci�n de la toma del medicamento.
CONSTRAINT Receta_Info UNIQUE (Nombre, Cantidad)
);


CREATE TABLE Medico (																	--Creaci�n de la tabla M�dico
IdMedico INT PRIMARY KEY IDENTITY (1,1),												--Almacena el c�digo del m�dico.
NombreMedico VARCHAR (30),																--Almacena el nombre del m�dico.
Telefono_Celular INT,																	--Almacena el n�mero telef�nico personal del m�dico.
CONSTRAINT Medico_Nombre UNIQUE (Telefono_Celular)
);

CREATE TABLE Consulta (																	--Creaci�n de la tabla Consulta.
IdConsulta INT PRIMARY KEY IDENTITY (1,1),												--Almacena c�digo de consulta.
Fecha DATE,																				--Almacena la fecha que se est� realizando la consulta.
Hora TIME,																				--Almacena la hora que se est� realizando la consulta.
Sintoma VARCHAR (250),																	--Almacena los s�ntomas mencionada por la persona que est� en consulta.
Diagnostico VARCHAR (200),																--Almacena el diagn�stico que determina el medico.
IdExpediente INT																		/*Almacena el c�digo del expediente.*/
FOREIGN KEY (IdExpediente) REFERENCES Expediente (IdExpediente),
IdMedico INT																			/*Almacena el c�digo del m�dico.*/
FOREIGN KEY (IdMedico) REFERENCES Medico (IdMedico),
);

 ----------------------------------------------------------------PROCEDIMIENTO ALMACENADO------------------------------------------------------------------------------------

 --Se crea el procedimiento almacenado para la tabla Expediente

 CREATE PROCEDURE InsertExpediente  --Guarda la informaci�n insertada.
	@Cedula VARCHAR (100),
	@Nombres VARCHAR (80),
	@Apellidos VARCHAR (80),
	@Fecha_Nacimiento varchar (20),
	@Telefono_Celular INT, 
	@Municipio VARCHAR (50), 
	@Departamento VARCHAR (50)
AS
	BEGIN

		SET NOCOUNT ON;

		INSERT INTO Expediente (
		Cedula,																
		Nombres,																
		Apellidos,															
		Fecha_Nacimiento,														
		Telefono_Celular,																	
		Municipio,															
		Departamento
		) VALUES (
		@Cedula,
		@Nombres,
		@Apellidos,
		@Fecha_Nacimiento,
		@Telefono_Celular, 
		@Municipio, 
		@Departamento
		
		)
	END
GO

CREATE PROCEDURE SelectExpediente --Muestra toda la informaci�n guardada.
	@Cedula VARCHAR (100),
	@Nombres VARCHAR (80),
	@Apellidos VARCHAR (80),
	@Fecha_Nacimiento varchar (20),
	@Telefono_Celular INT, 
	@Municipio VARCHAR (50), 
	@Departamento VARCHAR (50)
AS
	BEGIN

		SET NOCOUNT ON;

		SELECT * FROM Expediente
	END
GO
CREATE PROCEDURE UpdateExpediente -- actualiza los dato de expediente
	@Cedula VARCHAR (100),
	@Nombres VARCHAR (80),
	@Apellidos VARCHAR (80),
	@Fecha_Nacimiento varchar (20),
	@Telefono_Celular INT, 
	@Municipio VARCHAR (50), 
	@Departamento VARCHAR (50)
AS
	BEGIN

		SET NOCOUNT ON;

		UPDATE Expediente SET Cedula=@Cedula, Nombres=@Nombres, Apellidos=@Apellidos, 
		Fecha_Nacimiento=@Fecha_Nacimiento, Telefono_Celular=@Telefono_Celular, Municipio=@Municipio,Departamento=@Departamento
	END
GO

CREATE PROCEDURE DeleteExpediente-- elimina campos de la base de dato
	@Cedula VARCHAR (100),
	@Nombres VARCHAR (80),
	@Apellidos VARCHAR (80),
	@Fecha_Nacimiento varchar (20),
	@Telefono_Celular INT, 
	@Municipio VARCHAR (50), 
	@Departamento VARCHAR (50)
AS

	BEGIN

		SET NOCOUNT ON;

		DELETE Expediente WHERE Cedula = @Cedula

	END
GO

--Se crea el procedimiento almacenado para la tabla M�dico

CREATE PROCEDURE InsertMedico  --Guarda la informaci�n insertada.
	@NombreMedico VARCHAR (30),
	@Telefono_Celular INT
AS
	BEGIN

	SET NOCOUNT ON;

 INSERT INTO Medico(
		NombreMedico,
		Telefono_Celular
		) VALUES (
		@NombreMedico,
		@Telefono_Celular
		
		)
	END
GO

CREATE PROCEDURE SelectMedico --Muestra toda la informaci�n guardada.
	@NombreMedico VARCHAR (30),
	@Telefono_Celular INT
AS
	BEGIN

		SET NOCOUNT ON;

		SELECT * FROM Medico
	END
GO
CREATE PROCEDURE UpdateMedico -- actualiza los dato
	@NombreMedico VARCHAR (30),
	@Telefono_Celular INT
AS
	BEGIN

		SET NOCOUNT ON;

		UPDATE Medico SET NombreMedico = @NombreMedico, Telefono_Celular = @Telefono_Celular
	END
GO

CREATE PROCEDURE DeleteMedico-- elimina campos de la base de dato
	@NombreMedico VARCHAR (30),
	@Telefono_Celular INT
AS

	BEGIN

		SET NOCOUNT ON;

		DELETE Medico WHERE NombreMedico = @NombreMedico

	END
GO

--Se crea el procedimiento almacenado para la tabla Consulta

CREATE PROCEDURE InsertConsulta  --Guarda la informaci�n insertada.
	@Fecha DATE, 
	@Hora TIME, 
	@Sintoma VARCHAR (250), 
	@Diagnostico VARCHAR (200), 
	@IdExpediente INT, 
	@IdMedico INT
	
	AS
	BEGIN

	SET NOCOUNT ON;

	INSERT INTO Consulta(
		Fecha, 
		Hora, 
		Sintoma, 
		Diagnostico, 
		IdExpediente, 
		IdMedico
	) VALUES (
		@Fecha, 
		@Hora, 
		@Sintoma, 
		@Diagnostico, 
		@IdExpediente, 
		@IdMedico
		
		)
	END
GO

CREATE PROCEDURE SelectConsulta --Muestra toda la informaci�n guardada.
	@Fecha DATE, 
	@Hora TIME, 
	@Sintoma VARCHAR (250), 
	@Diagnostico VARCHAR (200), 
	@IdExpediente INT, 
	@IdMedico INT
	
AS
	BEGIN

		SET NOCOUNT ON;
		SELECT c.IdConsulta,c.Fecha,c.Hora,c.Sintoma,c.Diagnostico,m.IdMedico,M.NombreMedico,X.IdExpediente,X.Nombres
				FROM Medico AS M INNER JOIN Consulta AS c
				ON M.IdMedico =c.IdMedico  inner join Expediente as X on X.IdExpediente=C.IdExpediente 
		
	END
GO

CREATE PROCEDURE DeleteConsulta-- elimina campos de la base de dato
	@Fecha DATE, 
	@Hora TIME, 
	@Sintoma VARCHAR (250), 
	@Diagnostico VARCHAR (200), 
	@IdExpediente INT, 
	@IdMedico INT
	
AS

	BEGIN

		SET NOCOUNT ON;

		DELETE Consulta WHERE Fecha = @Fecha

	END
GO

--Se crea el procedimiento almacenado para la tabla Receta

CREATE PROCEDURE InsertReceta  --Guarda la informaci�n insertada.
	 @Nombre VARCHAR (50), 
	 @Presentacion VARCHAR (100), 
	 @Cantidad INT, 
	 @Descripcion VARCHAR (150)
	AS
		BEGIN
			SET NOCOUNT ON;

	INSERT INTO Receta(
	 Nombre, 
	 Presentacion, 
	 Cantidad, 
	 Descripcion
	) VALUES (
	 @Nombre, 
	 @Presentacion, 
	 @Cantidad, 
	 @Descripcion
		)
	END
GO

CREATE PROCEDURE SelectReceta--Muestra toda la informaci�n guardada.
	 @Nombre VARCHAR (50), 
	 @Presentacion VARCHAR (100), 
	 @Cantidad INT, 
	 @Descripcion VARCHAR (150)
	
AS
	BEGIN

		SET NOCOUNT ON;
		SELECT * from Receta
		
	END
GO

CREATE PROCEDURE DeleteReceta-- elimina campos de la base de dato
	 @Nombre VARCHAR (50), 
	 @Presentacion VARCHAR (100), 
	 @Cantidad INT, 
	 @Descripcion VARCHAR (150)
	
	
AS

	BEGIN

		SET NOCOUNT ON;

		DELETE Receta WHERE Nombre = @Nombre

	END
GO


--Se crea el procedimiento almacenado para el Respaldo
CREATE PROCEDURE RespaldoBD_GER
	AS
		BEGIN
			SET NOCOUNT ON;

			BACKUP DATABASE FRESHDENT
			TO DISK = N'C:\Users\Elkin Maltez\Documents\Ingenieria en Sistema\2020\I Semestre\Programaci�n de Base de Datos\Proyecto' ---Directorio donde se guardar� el respaldo de la base de datos
			WITH CHECKSUM;
		END
	GO

	
CREATE TABLE Users(																		--Creaci�n de la tabla Usuarios.
UserID INT IDENTITY (1,1) PRIMARY KEY,													--Almacena c�digo de usuario.
LoginName NVARCHAR (100) UNIQUE NOT NULL,												--Almacena nombre de usuario.
Password NVARCHAR (100) NOT NULL														--Almacena contrase�a de usuario.
);

------------Inserci�n de datos------------------
insert into Users values ('doctor','0987654321')										--Datos ingresado que no tendr� cambio                                 
insert into Users values ('admin','1234567890')											--Datos ingresado que no tendr� cambio
--Procedimiento almacenado para la tabla users
CREATE PROCEDURE Us
	@b INT, @UserID int ,@LoginName nvarchar (100), @Password nvarchar (100)
	-----------Atributo que tiene el procedimiento almacenado---------------
	AS
		BEGIN
			SET NOCOUNT ON;
			
			IF @b=1
				INSERT INTO Users VALUES (@LoginName,@Password); --Guarda la informaci�n insertada.
			IF @b=2
				SELECT * FROM Users--Muestra toda la informaci�n guardada.
			IF @b=3
				UPDATE Users SET LoginName=@LoginName, Password=@Password WHERE UserID = @UserID; --Actualiza la informaci�n seleccionada por el n�mero de registro asignado.
			IF @b=4
				SELECT * FROM Users WHERE LoginName = @LoginName and [Password] = @Password --Inicia sesi�n el usuario
		END
	GO