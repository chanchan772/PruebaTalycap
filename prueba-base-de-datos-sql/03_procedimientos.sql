-- 3. Procedimientos y funciones (20 pts)
USE EmpresaDB;
GO

-- Crear un procedimiento almacenado sp_buscar_empleado
CREATE PROCEDURE sp_buscar_empleado
    @NombreEmpleado VARCHAR(50)
AS
BEGIN
    SELECT 
        e.ID,
        e.Nombre,
        e.Apellido,
        e.FechaNacimiento,
        d.Nombre AS Departamento
    FROM 
        Empleados e
    JOIN 
        Departamentos d ON e.DepartamentoID = d.ID
    WHERE 
        e.Nombre LIKE '%' + @NombreEmpleado + '%';
END;
GO

-- Crear una función escalar fn_total_proyectos
CREATE FUNCTION fn_total_proyectos (@IdEmpleado INT)
RETURNS INT
AS
BEGIN
    DECLARE @TotalProyectos INT;
    
    SELECT 
        @TotalProyectos = COUNT(ProyectoID)
    FROM 
        EmpleadoProyecto
    WHERE 
        EmpleadoID = @IdEmpleado;
        
    RETURN @TotalProyectos;
END;
GO

-- Ejemplo de uso del procedimiento almacenado
EXEC sp_buscar_empleado @NombreEmpleado = 'Juan';

-- Ejemplo de uso de la función
SELECT 
    Nombre,
    Apellido,
    dbo.fn_total_proyectos(ID) AS TotalProyectos
FROM 
    Empleados;
GO
