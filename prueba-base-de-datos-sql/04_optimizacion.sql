-- 4. Optimización y administración (20 pts)
USE EmpresaDB;
GO

-- Crear un índice no cluster en la columna Apellido de la tabla Empleados para optimizar búsquedas.
CREATE NONCLUSTERED INDEX IX_Empleados_Apellido ON Empleados(Apellido);
GO

-- Explicar en máximo 5 líneas cómo implementarías un backup y restore de la base de datos en SQL Server.
/*
Para realizar un backup de la base de datos EmpresaDB, ejecutaría el comando:
BACKUP DATABASE EmpresaDB TO DISK = 'C:\Backup\EmpresaDB.bak' WITH FORMAT;

Para restaurar la base de datos a partir de ese backup, primero me aseguraría 
que no hayan conexiones activas y luego ejecutaría:
RESTORE DATABASE EmpresaDB FROM DISK = 'C:\Backup\EmpresaDB.bak' WITH REPLACE;
*/
GO
