-- 5. Bonus (opcional – 10 pts) – Consumo de API
USE EmpresaDB;
GO

-- Habilitar sp_OA
/*
EXEC sp_configure 'show advanced options', 1;
RECONFIGURE;
EXEC sp_configure 'Ole Automation Procedures', 1;
RECONFIGURE;
*/

-- Consumir la API y guardar en tabla temporal
DECLARE @Object AS INT;
DECLARE @ResponseText AS VARCHAR(8000);

EXEC sp_OACreate 'MSXML2.XMLHTTP', @Object OUT;
EXEC sp_OAMethod @Object, 'open', NULL, 'get', 'https://jsonplaceholder.typicode.com/users', 'false';
EXEC sp_OAMethod @Object, 'send';
EXEC sp_OAMethod @Object, 'responseText', @ResponseText OUTPUT;
EXEC sp_OADestroy @Object;

IF OBJECT_ID('tempdb..#UsuariosAPI') IS NOT NULL
    DROP TABLE #UsuariosAPI;

CREATE TABLE #UsuariosAPI (
    id INT,
    name VARCHAR(255),
    username VARCHAR(255),
    email VARCHAR(255)
);

INSERT INTO #UsuariosAPI (id, name, username, email)
SELECT 
    id,
    name,
    username,
    email
FROM OPENJSON(@ResponseText)
WITH (
    id INT '$.id',
    name VARCHAR(255) '$.name',
    username VARCHAR(255) '$.username',
    email VARCHAR(255) '$.email'
);

-- Mostrar un listado comparando los correos de la API con los correos de la tabla Empleados para identificar cuáles coinciden.
-- Nota: Para este ejemplo, no hay correos en la tabla Empleados, por lo que no habrá coincidencias.
-- Se agregaría una columna de email a la tabla Empleados para una comparación real.
SELECT 
    u.email AS EmailAPI,
    e.Nombre,
    e.Apellido
FROM 
    #UsuariosAPI u
JOIN 
    Empleados e ON u.email = e.Email; -- Suponiendo que Empleados tiene una columna Email

-- Limpieza
DROP TABLE #UsuariosAPI;
GO
