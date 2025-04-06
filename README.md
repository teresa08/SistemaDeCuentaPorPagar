# SistemasDeCuentaPorPagar

CREATE DATABASE Cuentas_por_pagar;
USE Cuentas_por_pagar

-- Tabla de Proveedores
CREATE TABLE Supplier (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Rnc_cedula VARCHAR(50) UNIQUE NOT NULL,
    Phone VARCHAR(20),
    Email VARCHAR(100),
    Address VARCHAR(500),
);

-- Tabla de Facturas
CREATE TABLE Invoice (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Supplier_id INT NOT NULL,
    Invoice_number VARCHAR(50) UNIQUE NOT NULL,
    Issue_date DATE NOT NULL,
    Expiration_date DATE NOT NULL,
    Total_amount DECIMAL(10,2) NOT NULL,
    State VARCHAR(50),
);

-- Tabla de Pagos
CREATE TABLE Payment (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Invoice_id INT NOT NULL,
    Payment_date DATE NOT NULL,
    Paid_amount DECIMAL(10,2) NOT NULL,
    Payment_method VARCHAR(50) NOT NULL,
);
