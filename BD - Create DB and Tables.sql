CREATE DATABASE ElectronicStore

USE ElectronicStore
CREATE TABLE endereco (
                id INT IDENTITY NOT NULL,
                logradouro VARCHAR(30) NOT NULL,
                numero INT NOT NULL,
                complemento VARCHAR(20),
                bairro VARCHAR(25) NOT NULL,
                cidade VARCHAR(40) NOT NULL,
                uf VARCHAR(2) NOT NULL,
                cep VARCHAR(9) NOT NULL,
                CONSTRAINT endereco_pk PRIMARY KEY (id)
)

CREATE TABLE pessoa (
                id INT IDENTITY NOT NULL,
                nome VARCHAR(50) NOT NULL,
                telefone1 VARCHAR(14) NOT NULL,
                telefone2 VARCHAR(14),
                email VARCHAR(50),
                enderecoId INT NOT NULL,
                CONSTRAINT pessoa_pk PRIMARY KEY (id)
)

CREATE TABLE fornecedor (
                id INT IDENTITY NOT NULL,
                cnpj VARCHAR(18) NOT NULL,
                pessoaId INT NOT NULL,
                CONSTRAINT fornecedor_pk PRIMARY KEY (id)
)

CREATE TABLE cliente (
                id INT IDENTITY NOT NULL,
                cpf VARCHAR(14) NOT NULL,
                fidelizado BIT NOT NULL,
                pessoaId INT NOT NULL,
                CONSTRAINT cliente_pk PRIMARY KEY (id)
)

CREATE TABLE vendedor (
                id INT IDENTITY NOT NULL,
                pis VARCHAR(18) NOT NULL,
                pessoaId INT NOT NULL,
                CONSTRAINT vendedor_pk PRIMARY KEY (id)
)

CREATE TABLE marca (
                id INT IDENTITY NOT NULL,
                nome VARCHAR(30) NOT NULL,
                site VARCHAR(50),
                CONSTRAINT marca_pk PRIMARY KEY (id)
)

CREATE TABLE fornecedorMarca (
                id INT IDENTITY NOT NULL,
                fornecedorId INT NOT NULL,
                marcaId INT NOT NULL,
                CONSTRAINT fornecedorMarca_pk PRIMARY KEY (id)
)

CREATE TABLE pedido (
                id INT IDENTITY NOT NULL,
                data DATETIME NOT NULL,
                valorTotal DECIMAL NOT NULL,
                clienteId INT NOT NULL,
                vendedorId INT NOT NULL,
                CONSTRAINT pedido_pk PRIMARY KEY (id)
)

CREATE TABLE produtoTipo (
                id INT IDENTITY NOT NULL,
                tipo VARCHAR(30) NOT NULL,
                CONSTRAINT produtoTipo_pk PRIMARY KEY (id)
)

CREATE TABLE produto (
                id INT IDENTITY NOT NULL,
                descricao VARCHAR(50) NOT NULL,
                preco DECIMAL NOT NULL,
                produtoTipoId INT NOT NULL,
                marcaId INT NOT NULL,
                CONSTRAINT produto_pk PRIMARY KEY (id)
)

CREATE TABLE itemPedido (
                id INT IDENTITY NOT NULL,
                quantidade INT NOT NULL,
                produtoId INT NOT NULL,
                pedidoId INT NOT NULL,
                CONSTRAINT itemPedido_pk PRIMARY KEY (id)
)

CREATE TABLE estoque (
                id INT IDENTITY NOT NULL,
                quantidade INT NOT NULL,
                dataEntrada DATETIME NOT NULL,
                produtoId INT NOT NULL,
                CONSTRAINT estoque_pk PRIMARY KEY (id)
)

ALTER TABLE pessoa ADD CONSTRAINT endereco_pessoa_fk
FOREIGN KEY (enderecoId)
REFERENCES endereco (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE fornecedor ADD CONSTRAINT pessoa_fornecedor_fk
FOREIGN KEY (pessoaId)
REFERENCES pessoa (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE cliente ADD CONSTRAINT pessoa_cliente_fk
FOREIGN KEY (pessoaId)
REFERENCES pessoa (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE vendedor ADD CONSTRAINT pessoa_vendedor_fk
FOREIGN KEY (pessoaId)
REFERENCES pessoa (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE fornecedorMarca ADD CONSTRAINT fornecedor_fornecedorMarca_fk
FOREIGN KEY (fornecedorId)
REFERENCES fornecedor (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE pedido ADD CONSTRAINT cliente_pedido_fk
FOREIGN KEY (clienteId)
REFERENCES cliente (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE pedido ADD CONSTRAINT vendedor_pedido_fk
FOREIGN KEY (vendedorId)
REFERENCES vendedor (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE produto ADD CONSTRAINT marca_produto_fk
FOREIGN KEY (marcaId)
REFERENCES marca (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE fornecedorMarca ADD CONSTRAINT marca_fornecedorMarca_fk
FOREIGN KEY (marcaId)
REFERENCES marca (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE itemPedido ADD CONSTRAINT pedido_itemPedido_fk
FOREIGN KEY (pedidoId)
REFERENCES pedido (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE produto ADD CONSTRAINT produtoTipo_produto_fk
FOREIGN KEY (produtoTipoId)
REFERENCES produtoTipo (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE itemPedido ADD CONSTRAINT produto_itemPedido_fk
FOREIGN KEY (produtoId)
REFERENCES produto (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE estoque ADD CONSTRAINT produto_estoque_fk
FOREIGN KEY (produtoId)
REFERENCES produto (id)
ON DELETE NO ACTION
ON UPDATE NO ACTION