USE BDSistema_Tutoria
GO

INSERT INTO TEscuela_Profesional VALUES('INIS','INGENIER�A INFORM�TICA Y DE SISTEMAS');
INSERT INTO TEscuela_Profesional VALUES('INEO','INGENIER�A ELECTR�NICA');
INSERT INTO TEscuela_Profesional VALUES('INCV','INGENIER�A CIVIL');
INSERT INTO TEscuela_Profesional VALUES('CONT','CONTABILIDAD');
INSERT INTO TEscuela_Profesional VALUES('PSIC','PSICOLOG�A');
INSERT INTO TEscuela_Profesional VALUES('INQM','INGENIER�A QU�MICA');
GO

INSERT INTO TUsuario (Usuario, Contrase�a, Acceso, Datos, Perfil) 
SELECT 'ADMIN', 'ADMIN1234', 'Director de Escuela', 'ADMINISTRADOR', BulkColumn 
	FROM Openrowset(Bulk 'C:\Users\Jeremylazm\Desktop\Documentos\Copia de Proyecto de DS I\Proyecto Final\AppSistemaTutoria\CapaPresentaciones\Iconos\Perfil.png', Single_Blob) as PerfilAdmin
GO

SELECT * FROM TEscuela_Profesional
SELECT * FROM TEstudiante
SELECT * FROM TDocente
SELECT * FROM TUsuario
SELECT * FROM TTutoria
SELECT * FROM Historial
GO
