CREATE DATABASE agenzia_viaggi;

CREATE TABLE indirizzo (
    indirizzo_id INT AUTO_INCREMENT PRIMARY KEY,
    via VARCHAR(255),
    città VARCHAR(100),
    cap VARCHAR(10),
    provincia VARCHAR(100),
    nazione VARCHAR(100)
);

CREATE TABLE citta (
    citta_id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    provincia VARCHAR(100),
    nazione VARCHAR(100)
);

CREATE TABLE utenti (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    telefono VARCHAR(15) UNIQUE,
    ruolo CHAR(1) NOT NULL DEFAULT 'U',
    indirizzo_id INT,
    FOREIGN KEY (indirizzo_id) REFERENCES indirizzo(indirizzo_id),
    CONSTRAINT chk_password_length CHECK (LENGTH(password) >= 8)
);

CREATE TABLE luoghi (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descrizione TEXT,
    citta_id INT,
    FOREIGN KEY (citta_id) REFERENCES citta(citta_id)
);

CREATE TABLE attrazioni (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descrizione TEXT,
    luogo_id INT,
    FOREIGN KEY (luogo_id) REFERENCES luoghi(id)
);

CREATE TABLE prenotazioni (
    id INT AUTO_INCREMENT PRIMARY KEY,
    utente_id INT,
    attrazione_id INT,
    data_prenotazione DATE,
    FOREIGN KEY (utente_id) REFERENCES utenti(id),
    FOREIGN KEY (attrazione_id) REFERENCES attrazioni(id)
);
CREATE TABLE carrello (
    id INT AUTO_INCREMENT PRIMARY KEY,
    utente_id INT NOT NULL,
    attrazione_id INT NOT NULL,
    quantita INT DEFAULT 1 CHECK (quantita > 0),
    stato VARCHAR(20) DEFAULT 'in_corso', 
    FOREIGN KEY (utente_id) REFERENCES utenti(id),
    FOREIGN KEY (attrazione_id) REFERENCES attrazioni(id)
);