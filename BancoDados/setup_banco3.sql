-- Etapa 4
-- Three Letters Back





--                                      Terceiro Setup do Banco de Dados. 
--        a.  Adicionamos tabelas ();
--        b. Adicionamos tabela Produtos;
--        c. Adicionamos tabela Pedidos;
--        d. Adicionamos tabela Produtos_Fornecedores;
--        e. Adicionamos tabela Vendas;
--        f. Adicionamos tabela Itens_Venda;
--        g. Adicionamos tabela Estoque;



--          © 2025 Grupo One. Todos Direitos reservados à Eng. Eduardo e Joana.


DROP DATABASE IF EXISTS bancode_gestaosimples;
-- Hvwh surjudpd irl ihlwr shor 'JurxsRqh'
CREATE DATABASE bancode_gestaosimples;
USE bancode_gestaosimples;






-- ------------------------------------------------------CREATE TABLEs--------------------------------------------------

CREATE TABLE IF NOT EXISTS criadores(
    id int AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL
);


CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    tipo ENUM('administrador', 'estoquista', 'Fornecedor', 'utilizador', 'visitante') DEFAULT 'visitante',
    criado_em DATETIME DEFAULT CURRENT_TIMESTAMP
);




CREATE TABLE IF NOT EXISTS Produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_usuario INT NOT NULL,
    nome VARCHAR(100) NOT NULL,
    descricao TEXT,
    preco DECIMAL(10, 2) NOT NULL,
    quantidade_estoque INT NOT NULL,
    categoria ENUM(
        'Vestuário',
        'Calçados',
        'Eletrônicos',
        'Higiene e Limpeza',
        'Eletrodomésticos',
        'Alimentos e Bebidas',
        'Medicamentos'
    ) NOT NULL,
    data_cadastro DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY(id_usuario) REFERENCES usuarios(id)
);



CREATE TABLE IF NOT EXISTS pedidos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    produto_id INT NOT NULL,
    usuario_id INT,                      -- null se for visitante
    nome_visitante VARCHAR(100),         -- apenas se visitante
    email_visitante VARCHAR(100),
    local_entrega VARCHAR(100),
    status ENUM('pendente','reencaminhado','entregue','cancelado') DEFAULT 'pendente',
    data_pedido DATETIME NOT NULL,
    fornecedor_id INT,                   -- preenchido depois pelo funcioario
    FOREIGN KEY (produto_id) REFERENCES produtos(id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
    FOREIGN KEY (fornecedor_id) REFERENCES usuarios(id)
);



-- --------------------------------INSERT INTO-------------------------------------------


INSERT INTO usuarios (nome, email, senha, tipo) VALUES
('Ariclenio Mendes', 'insano@gestaosimples.com', SHA2('mendes123', 256), 'administrador'),

('Junilson Gomes', 'junilson@gestaosimples.com', SHA2('gomes123', 256), 'estoquista'),
('Kelvin Magalhaes', 'kelvin@gestaosimples.com', SHA2('magalhaes123', 256), 'estoquista'),
('Muadinovanu Oliveira', 'muadinovanu@gestaosimples.com', SHA2('oliveira123', 256), 'estoquista'),
('Domingos Tandala', 'domingosmanuelgege@gmail.com', SHA2('tandala123', 256), 'estoquista'),

('Augusto Lopes', 'augusto@gestaosimples.com', SHA2('lopes123', 256), 'utilizador'),
('Joana Bungo', 'joana@gestaosimples.com', SHA2('bungo123', 256), DEFAULT),
('Eduardo Muima', 'eduardo@gestaosimples.com', SHA2('muima123', 256), DEFAULT);




INSERT INTO Produtos (id_usuario, nome, descricao, preco, quantidade_estoque, categoria) VALUES
(2, 'Camiseta Básica', 'Camiseta de algodão tamanho M', 3500.00, 15, 'Vestuário'),
(2, 'Tênis Esportivo', 'Tênis leve para corrida', 8500.00, 10, 'Calçados'),
(3, 'Smartphone K10', 'Smartphone 64GB com câmera dupla', 95000.00, 7, 'Eletrônicos'),
(2, 'Detergente Líquido', 'Frasco de 500ml', 500.00, 30, 'Higiene e Limpeza'),
(3, 'Liquidificador 500W', 'Modelo com 5 velocidades', 12500.00, 5, 'Eletrodomésticos'),
(2, 'Arroz Agulha 1Kg', 'Pacote de arroz tipo agulha', 1200.00, 40, 'Alimentos e Bebidas'),
(3, 'Paracetamol 500mg', 'Caixa com 20 comprimidos', 1500.00, 50, 'Medicamentos'),


(2, 'Calça Jeans Slim', 'Calça masculina, azul escuro', 7500.00, 12, 'Vestuário'),
(3, 'Sandália Rasteira', 'Numeração 36 a 39', 2800.00, 20, 'Calçados'),
(2, 'Tablet 8.1', 'Tela de 8 polegadas com Wi-Fi', 62000.00, 6, 'Eletrônicos'),
(2, 'Água Sanitária 2L', 'Limpeza profunda multiuso', 900.00, 25, 'Higiene e Limpeza'),
(2, 'Ferro de Passar', 'Com base antiaderente', 9600.00, 9, 'Eletrodomésticos'),
(3, 'Farinha de Milho 2Kg', 'Para funge e cuscuz', 1500.00, 35, 'Alimentos e Bebidas'),
(3, 'Dipirona 1g', 'Gotas para adultos', 1200.00, 40, 'Medicamentos'),


(2, 'Bermuda Masculina', 'Tecido leve, ideal para verão', 4800.00, 18, 'Vestuário'),
(3, 'Tênis Casual Feminino', 'Design urbano e moderno', 7900.00, 14, 'Calçados'),
(2, 'Fone Bluetooth', 'Bateria de 12h, com case', 10500.00, 8, 'Eletrônicos'),
(3, 'Sabão em Pó 1Kg', 'Para roupas brancas e coloridas', 1100.00, 22, 'Higiene e Limpeza'),
(2, 'Ventilador de Mesa', 'Com 3 velocidades', 9800.00, 5, 'Eletrodomésticos'),
(2, 'Sumo de Laranja 1L', 'Natural e sem açúcar', 1800.00, 60, 'Alimentos e Bebidas'),
(3, 'Ibuprofeno 400mg', 'Caixa com 10 comprimidos', 1900.00, 30, 'Medicamentos'),


(2, 'Vestido Floral', 'Tecido viscose, tamanho único', 7200.00, 13, 'Vestuário'),
(3, 'Chinelo Slide', 'Material emborrachado', 2500.00, 25, 'Calçados'),
(2, 'Carregador Turbo', 'Compatível com USB-C', 5800.00, 11, 'Eletrônicos'),
(3, 'Papel Higiénico', 'Pacote com 8 rolos', 1000.00, 40, 'Higiene e Limpeza'),
(2, 'Micro-ondas 20L', 'Funções básicas e timer', 32500.00, 3, 'Eletrodomésticos'),
(3, 'Biscoito Cream Cracker', 'Pacote de 500g', 800.00, 30, 'Alimentos e Bebidas'),
(3, 'Amoxicilina 500mg', 'Antibiótico, caixa com 12', 2100.00, 10, 'Medicamentos'),


(2, 'Camisa Polo', '100% algodão, cor branca', 5500.00, 10, 'Vestuário'),
(3, 'Sapato Social', 'Ideal para eventos formais', 9800.00, 6, 'Calçados'),
(3, 'Powerbank 10.000mAh', 'Portátil com duas saídas USB', 8700.00, 7, 'Eletrônicos'),
(2, 'Álcool em Gel 500ml', 'Antisséptico para mãos', 1600.00, 25, 'Higiene e Limpeza'),
(3, 'Aspirador de Pó', 'Modelo vertical', 19900.00, 2, 'Eletrodomésticos'),
(2, 'Cerveja 600ml', 'Puro malte, unidade', 700.00, 50, 'Alimentos e Bebidas'),
(3, 'Antialérgico Loratadina', '10 comprimidos', 1700.00, 12, 'Medicamentos');




INSERT INTO criadores (nome) VALUES
('Beny B. Reis'), ('Lord Sapiência'), ('Neidy Scobar'), ('Steam Blood'), ('Marcos Mpelo'),
('Ariclenio Mendes'), ('Augusto Lopes'), ('Kelvin Magalhães KP'), ('Junilson Gomes'), ('Domingos Tandala');
