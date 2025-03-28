// Conectar a la base de datos de MongoDB
use FinancialTransactionsDB;

// Crear la colección 'Transactions' si no existe (MongoDB crea colecciones automáticamente cuando insertas documentos)
db.createCollection("Transactions");

// Insertar documentos de ejemplo en la colección 'Transactions'
db.Transactions.insertMany([
    {
        "_id": UUID("8c937580-5db4-4d47-b6c0-b1b4b55c16d1"),
        "Amount": 100.50,
        "Currency": "USD",
        "Date": new ISODate("2025-03-28T10:00:00Z"),
        "Status": "Pending"
    },
    {
        "_id": UUID("b1a775f5-d9b1-4fd2-8c0e-c8b0735c9819"),
        "Amount": 250.75,
        "Currency": "EUR",
        "Date": new ISODate("2025-03-28T12:30:00Z"),
        "Status": "Completed"
    },
    {
        "_id": UUID("f3e6878f-e7b9-4a37-9010-e1a4e929c28a"),
        "Amount": 450.20,
        "Currency": "USD",
        "Date": new ISODate("2025-03-28T14:45:00Z"),
        "Status": "Failed"
    }
]);

// Verificar los documentos insertados
db.Transactions.find().pretty();
