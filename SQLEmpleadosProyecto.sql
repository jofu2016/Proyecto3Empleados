CREATE DATABASE DbSegurosPacifico;
GO

USE DbSegurosPacifico;
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    HorasNormales INT,
    HorasExtras INT,
    SalarioBruto DECIMAL(18, 2),
    Deducciones DECIMAL(18, 2),
    SalarioNeto DECIMAL(18, 2)
);
GO

CREATE TABLE [dbo].[Login] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Usuario] NVARCHAR(255) NOT NULL,
    [Contrasena] NVARCHAR(255) NOT NULL
);