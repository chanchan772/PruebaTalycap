-- 1. Modelado y creación de tablas (20 pts)

-- Crear una base de datos llamada EmpresaDB
CREATE DATABASE EmpresaDB;
GO

USE EmpresaDB;
GO

-- Crear la tabla Departamentos
CREATE TABLE Departamentos (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL
);

-- Crear la tabla Proyectos
CREATE TABLE Proyectos (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Presupuesto DECIMAL(18, 2) NOT NULL
);

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    DepartamentoID INT,
    FOREIGN KEY (DepartamentoID) REFERENCES Departamentos(ID)
);

-- Crear la tabla intermedia EmpleadoProyecto
CREATE TABLE EmpleadoProyecto (
    EmpleadoID INT,
    ProyectoID INT,
    PRIMARY KEY (EmpleadoID, ProyectoID),
    FOREIGN KEY (EmpleadoID) REFERENCES Empleados(ID),
    FOREIGN KEY (ProyectoID) REFERENCES Proyectos(ID)
);
GO

-- Insertar al menos 5 registros en cada tabla para pruebas
INSERT INTO Departamentos (Nombre) VALUES
('Recursos Humanos'),
('Tecnología'),
('Ventas'),
('Marketing'),
('Finanzas');

INSERT INTO Proyectos (Nombre, Presupuesto) VALUES
('Migración a la Nube', 50000.00),
('Desarrollo de App Móvil', 75000.00),
('Campaña Publicitaria Q3', 25000.00),
('Implementación de ERP', 120000.00),
('Auditoría Interna', 30000.00);

INSERT INTO Empleados (Nombre, Apellido, FechaNacimiento, DepartamentoID) VALUES
('Juan', 'Pérez', '1990-05-15', 2),
('María', 'González', '1988-09-20', 1),
('Carlos', 'López', '1995-02-10', 2),
('Ana', 'Martínez', '1992-11-30', 3),
('Pedro', 'Sánchez', '1985-07-25', 4),
('Laura', 'Díaz', '1998-01-18', 2);

INSERT INTO EmpleadoProyecto (EmpleadoID, ProyectoID) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 1),
(3, 4),
(4, 3),
(5, 5),
(6, 2),
(6, 4);
GO
