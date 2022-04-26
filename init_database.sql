
-- VeloMax Database

DROP DATABASE IF EXISTS velomax;
CREATE DATABASE IF NOT EXISTS velomax;
USE velomax;


-- Clients

DROP TABLE IF EXISTS clients;
CREATE TABLE IF NOT EXISTS clients(
    id INT NOT NULL AUTO_INCREMENTS,
    client_type ENUM("profesionnal", "individual"),
    company_name VARCHAR(255) NULL,
    last_name VARCHAR(255) NULL,
    first_name VARCHAR(255) NULL,
    street VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL,
    postal_code VARCHAR(255) NOT NULL,
    province VARCHAR(255) NOT NULL,
    phone VARCHAR(255) NOT NULL,
    mail VARCHAR(255) NOT NULL,
    fidelity_program INT DEFAULT 0,
    member BOOLEAN NOT NULL DEFAULT 0,
    order_count INT NULL DEFAULT 0,
    PRIMARY KEY(id);
);

-- Orders

DROP TABLE IF EXISTS orders;
CREATE TABLE IF NOT EXISTS orders(

);