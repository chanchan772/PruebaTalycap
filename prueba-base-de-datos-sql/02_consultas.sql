-- 2. Consultas SQL (30 pts)
USE EmpresaDB;
GO

-- Listar todos los empleados con el nombre de su departamento
SELECT 
    e.Nombre,
    e.Apellido,
    d.Nombre AS Departamento
FROM 
    Empleados e
JOIN 
    Departamentos d ON e.DepartamentoID = d.ID;

-- Mostrar los proyectos con su presupuesto y la cantidad de empleados asignados
SELECT 
    p.Nombre AS Proyecto,
    p.Presupuesto,
    COUNT(ep.EmpleadoID) AS CantidadEmpleados
FROM 
    Proyectos p
LEFT JOIN 
    EmpleadoProyecto ep ON p.ID = ep.ProyectoID
GROUP BY 
    p.Nombre, p.Presupuesto
ORDER BY 
    CantidadEmpleados DESC;

-- Obtener el top 3 de empleados con más proyectos asignados
SELECT TOP 3
    e.Nombre,
    e.Apellido,
    COUNT(ep.ProyectoID) AS CantidadProyectos
FROM 
    Empleados e
JOIN 
    EmpleadoProyecto ep ON e.ID = ep.EmpleadoID
GROUP BY 
    e.Nombre, e.Apellido
ORDER BY 
    CantidadProyectos DESC;

-- Listar los departamentos que no tienen empleados
SELECT 
    d.Nombre AS Departamento
FROM 
    Departamentos d
LEFT JOIN 
    Empleados e ON d.ID = e.DepartamentoID
WHERE 
    e.ID IS NULL;

-- Consultar todos los empleados que participan en más de un proyecto
SELECT
    e.Nombre,
    e.Apellido,
    COUNT(ep.ProyectoID) AS CantidadProyectos
FROM
    Empleados e
JOIN
    EmpleadoProyecto ep ON e.ID = ep.EmpleadoID
GROUP BY
    e.Nombre, e.Apellido
HAVING
    COUNT(ep.ProyectoID) > 1;
GO
