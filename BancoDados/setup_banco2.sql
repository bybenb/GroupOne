-- Etapa 2

DROP DATABASE IF EXISTS bancode_gestaosimples;

CREATE DATABASE bancode_gestaosimples;
USE bancode_gestaosimples;


CREATE TABLE criadores(
    id int AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL
);

INSERT INTO criadores (nome) VALUES
('Beny B. Reis'), ('Lord Sapiência'), ('Neidy Scobar'), ('Steam Blood'), ('Marcos Mpelo'),
('Ariclenio Mendes'), ('Augusto Lopes'), ('Kelvin Magalhães'), ('Junilson Gomes'), ('Domingos Tandala');


CREATE TABLE  usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    tipo ENUM('administrador', 'estoquista', 'Fornecedor', 'utilizador', 'visitante') DEFAULT 'visitante',
    criado_em DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO usuarios (nome, email, senha, tipo) VALUES
('Ariclenio Mendes', 'insano@gestaosimples.com', SHA2('mendes123', 256), 'administrador'),

('Junilson Gomes', 'junilson@gestaosimples.com', SHA2('gomes123', 256), 'estoquista'),
('Kelvin Magalhaes', 'kelvin@gestaosimples.com', SHA2('magalhaes123', 256), 'estoquista'),
('Muadinovanu Oliveira', 'muadinovanu@gestaosimples.com', SHA2('oliveira123', 256), 'estoquista'),
('Domingos Tandala', 'domingosmanuelgege@gmail.com', SHA2('tandala123', 256), 'estoquista'),

('Augusto Lopes', 'augusto@gestaosimples.com', SHA2('lopes123', 256), 'utilizador'),
('Joana Bungo', 'joana@gestaosimples.com', SHA2('bungo123', 256), DEFAULT),
('Eduardo Muima', 'eduardo@gestaosimples.com', SHA2('muima123', 256), DEFAULT);


--                                      Segundo Setup do Banco de Dados. 
--        a.  Adicionamos tabelas ();
--        b.  modificamos coluna 'tipo' (usuario) de nivel de acesso...


--          © 2025 Grupo One. Todos Direitos reservados à Eng. Eduardo e Joana.
