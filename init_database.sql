
-- VeloMax Database

DROP DATABASE IF EXISTS velomax;
CREATE DATABASE IF NOT EXISTS velomax;
USE velomax;


-- Clients
DROP TABLE IF EXISTS clients;
CREATE TABLE IF NOT EXISTS clients(
    id INT NOT NULL AUTO_INCREMENTS,
    type ENUM("profesionnal", "individual"),
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
    PRIMARY KEY(id),
);

-- Orders
DROP TABLE IF EXISTS orders;
CREATE TABLE IF NOT EXISTS orders(
    id INT NOT NULL AUTO_INCREMENTS,
    order_date DATE NOT NULL,
    shipping_address VARCHAR(255) NOT NULL,
    shipping_date DATE NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY(id),
);

-- Bikes
DROP TABLE IF EXISTS bikes;
CREATE TABLE IF NOT EXISTS bikes(
    id INT NOT NULL AUTO_INCREMENTS,
    name VARCHAR(255) NOT NULL,
    target VARCHAR(255) NOT NULL,
    unit_price FLOAT NOT NULL,
    type VARCHAR(255) NOT NULL,
    introduction_date DATE NOT NULL,
    discontinuation_date DATE NOT NULL,
    PRIMARY KEY(id),
);

-- Parts
DROP TABLE IF EXISTS parts;
CREATE TABLE IF NOT EXISTS parts(
    id INT NOT NULL AUTO_INCREMENTS,
    supplier_name VARCHAR(255) NOT NULL,
    description VARCHAR(255) NOT NULL,
    unit_price FLOAT NOT NULL,
    introduction_date DATE NOT NULL,
    discontinuation_date DATE NOT NULL,
    procurement_delay INT NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY(id),
);

-- Suppliers
DROP TABLE IF EXISTS suppliers;
CREATE TABLE IF NOT EXISTS suppliers(
    id INT NOT NULL AUTO_INCREMENTS,
    siret VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    contact VARCHAR(255) NOT NULL,
    location VARCHAR(255) NOT NULL,
    label ENUM(1,2,3,4), -- 1 very good, 2 good, 3 average, 4 bad
    PRIMARY KEY(id),
);

-- Fidelity programs
DROP TABLE IF EXISTS fidelity_programs;
CREATE TABLE IF NOT EXISTS fidelity_programs(
    id INT NOT NULL AUTO_INCREMENTS,
    label VARCHAR(255) NOT NULL,
    cost INT NOT NULL,
    duration INT NOT NULL,
    discount INT NOT NULL CHECK(discount < 100), -- percentage
);

-- Ordered bikes
DROP TABLE IF EXISTS ordered_bikes;
CREATE TABLE IF NOT EXISTS oredered_bikes(
    id INT NOT NULL AUTO_INCREMENTS,
    orders_id INT NOT NULL,
    bikes_id INT NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(orders_id) REFERENCES orders(id),
    FOREIGN KEY(bikes_id) REFERENCES bikes(id),
);

-- Ordered parts
DROP TABLE IF EXISTS ordered_parts;
CREATE TABLE IF NOT EXISTS oredered_parts(
    id INT NOT NULL AUTO_INCREMENTS,
    orders_id INT NOT NULL,
    parts_id INT NOT NULL,
    quantity INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(orders_id) REFERENCES orders(id),
    FOREIGN KEY(parts_id) REFERENCES parts(id),
);

-- Bike parts
DROP TABLE IF EXISTS bike_parts;
CREATE TABLE IF NOT EXISTS bike_parts(
    id INT NOT NULL AUTO_INCREMENTS,
    parts_id NOT NULL,
    bikes_id NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(parts_id) REFERENCES parts(id),
    FOREIGN KEY(bikes_id) REFERENCES bikes(id),
);

-- procurement
DROP TABLE IF EXISTS procurement;
CREATE TABLE IF NOT EXISTS procurement(
    id INT NOT NULL AUTO_INCREMENTS,
    parts_id INT NOT NULL,
    suppliers_id INT NOT NULL,
    PRIMARY KEY(id),
    FOREIGN KEY(parts_id) REFERENCES parts(id),
    FOREIGN KEY(suppliers_id) REFERENCES suppliers(id),
);

-- EOF