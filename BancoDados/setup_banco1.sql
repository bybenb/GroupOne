
CREATE DATABASE IF NOT EXISTS bancode_gestaosimples;
USE bancode_gestaosimples;


CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    tipo ENUM('administrador', 'estoquista', 'utilizador') DEFAULT 'utilizador',
    criado_em DATETIME DEFAULT CURRENT_TIMESTAMP
);


INSERT INTO usuarios (nome, email, senha, tipo) VALUES
('Joana Bungo', 'joana@gestaosimples.com', SHA2('bungo123', 256), 'administrador'),
('Ariclenio Mendes', 'insano@gestaosimples.com', SHA2('mendes123', 256), 'administrador'),
('Junilson Gomes', 'junilson@gestaosimples.com', SHA2('gomes123', 256), 'estoquista'),
('Kelvin Magalhaes', 'kelvin@gestaosimples.com', SHA2('magalhaes123', 256), 'estoquista'),
('Muadinovanu Oliveira', 'muadinovanu@gestaosimples.com', SHA2('oliveira123', 256), 'estoquista'),
('Domingos Tandala', 'domingosmanuelgege@gmail.com', SHA2('tandala123', 256), 'estoquista'),
('Augusto Lopes', 'augusto@gestaosimples.com', SHA2('lopes123', 256), 'utilizador');


--      Primeiro Setup do Banco de Dados. colocamos inicialmente no banco uma tabela..


--          © 2025 Grupo One. Todos Direitos reservados à Eng. Eduardo e Joana.

