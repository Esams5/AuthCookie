CREATE DATABASE IF NOT EXISTS AuthCookieDb;

USE AuthCookieDb;


CREATE TABLE IF NOT EXISTS Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(255) NOT NULL
);

-- Insere um usuário de exemplo (senha em texto plano, apenas para teste)
INSERT INTO Users (Username, Password) VALUES ('user', 'password');