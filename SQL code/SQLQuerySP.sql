CREATE PROCEDURE sp_GetEmpleados
AS
BEGIN
    SELECT Id, Nombre, Salario
    FROM Empleado
    ORDER BY Nombre ASC;
END;
GO

CREATE PROCEDURE sp_InsertEmpleado
    @Nombre VARCHAR(128),
    @Salario MONEY
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Empleado WHERE Nombre = @Nombre)
    BEGIN
        RAISERROR('Nombre de Empleado ya existe.', 16, 1);
        RETURN;
    END

    INSERT INTO Empleado (Nombre, Salario) VALUES (@Nombre, @Salario);
END;
GO
