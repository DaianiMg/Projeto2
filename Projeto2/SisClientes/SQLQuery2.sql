﻿CREATE TABLE usuario(
Id_cliente INT,
Login VARCHAR(50) NOT NULL,
Senha VARCHAR(15) NOT NULL,
CONSTRAINT FK_CLIENTE FOREIGN KEY (Id_cliente) REFERENCES cliente (Id)
);

CREATE TABLE produto(
Id INT,
Nome VARCHAR(50) NOT NULL,
Descrecao VARCHAR(100),
Preco FLOAT NOT NULL,
Palavra_Chave VARCHAR(50) NOT NULL,
Categoria VARCHAR (35) NOT NULL,
Produto_Cidade INT,
CONSTRAINT PK_PRODUTO PRIMARY KEY (Id),
CONSTRAINT FK_PRODUTO FOREIGN KEY (Produto_Cidade) REFERENCES Cidade (Id)
);