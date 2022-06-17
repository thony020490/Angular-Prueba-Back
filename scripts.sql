 IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'PruebaIndraBD')
  BEGIN
    CREATE DATABASE [PruebaIndraBD]
  END
 GO


 USE [PruebaIndraBD]
 GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Tutorial')
BEGIN
    CREATE TABLE Tutorial (
        Id INT PRIMARY KEY IDENTITY,
        Titulo VARCHAR(100),
		Descripcion VARCHAR(250),
		Publicado bit
    )
END


/*
insert into Tutorial values('Titulo Prueba 1','Descripcion Prueba 1',1)
insert into Tutorial values('Titulo Prueba 2','Descripcion Prueba 2',1)
insert into Tutorial values('Titulo Prueba 3','Descripcion Prueba 3',1)
*/