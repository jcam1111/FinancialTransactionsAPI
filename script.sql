CREATE TABLE TransactionLogs (
    Id UNIQUEIDENTIFIER NOT NULL,
    TransactionId NVARCHAR(100) NOT NULL, 
Action NVARCHAR(100) NOT NULL, 
    Date DATETIME NOT NULL DEFAULT GETDATE(),  -- Fecha del sistema
    Observaciones NVARCHAR(800) NULL,           -- Detalles de la transaccion Id (GUID) Amount (decimal),Currency (string),Date (DateTime),Status (string)

Amount NVARCHAR(100) NULL,                      -- Monto de la transacción en el momento del log
    Currency NVARCHAR(3) NULL,                       -- Moneda de la transacción
    Status NVARCHAR(50) NULL,     

    Usuario NVARCHAR(100) NOT NULL,             -- Nombre del usuario

    IPAddress NVARCHAR(50),  -- IP desde la que se ejecutó la acción

);