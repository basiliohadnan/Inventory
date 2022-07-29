
CREATE TABLE tb_endereco (
                endereco_id INT IDENTITY NOT NULL,
                logradouro VARCHAR(30) NOT NULL,
                numero INT NOT NULL,
                complemento VARCHAR(20),
                bairro VARCHAR(25) NOT NULL,
                cidade VARCHAR(40) NOT NULL,
                uf VARCHAR(2) NOT NULL,
                cep VARCHAR(9) NOT NULL,
                CONSTRAINT tb_endereco_pk PRIMARY KEY (endereco_id)
)

CREATE TABLE tb_Pessoa (
                pessoa_id INT IDENTITY NOT NULL,
                nome VARCHAR(50) NOT NULL,
                telefone1 VARCHAR(14) NOT NULL,
                telefone2 VARCHAR(14),
                email VARCHAR(50),
                endereco_id INT NOT NULL,
                CONSTRAINT tb_Pessoa_pk PRIMARY KEY (pessoa_id)
)

CREATE TABLE tb_fornecedor (
                fornecedor_id INT NOT NULL,
                cnpj VARCHAR(14) NOT NULL,
                pessoa_id INT NOT NULL,
                CONSTRAINT tb_fornecedor_pk PRIMARY KEY (fornecedor_id)
)

CREATE TABLE tb_cliente (
                cliente_id INT IDENTITY NOT NULL,
                cpf VARCHAR(11) NOT NULL,
                fidelizado BOOLEAN NOT NULL,
                pessoa_id INT NOT NULL,
                CONSTRAINT tb_cliente_pk PRIMARY KEY (cliente_id)
)

CREATE TABLE tb_vendedor (
                vendedor_id INT IDENTITY NOT NULL,
                pis VARCHAR(11) NOT NULL,
                pessoa_id INT NOT NULL,
                CONSTRAINT tb_vendedor_pk PRIMARY KEY (vendedor_id)
)

CREATE TABLE tb_marca (
                marca_id INT IDENTITY NOT NULL,
                nome VARCHAR(30) NOT NULL,
                site VARCHAR,
                CONSTRAINT tb_marca_pk PRIMARY KEY (marca_id)
)

CREATE TABLE tb_fornecedorMarca (
                fornecedor_marca_id INT IDENTITY NOT NULL,
                fornecedor_id INT NOT NULL,
                marca_id INT NOT NULL,
                CONSTRAINT tb_fornecedorMarca_pk PRIMARY KEY (fornecedor_marca_id)
)

CREATE TABLE tb_pedido (
                pedido_id INT NOT NULL,
                data DATETIME NOT NULL,
                valor_total DECIMAL NOT NULL,
                cliente_id INT NOT NULL,
                vendedor_id INT NOT NULL,
                CONSTRAINT tb_pedido_pk PRIMARY KEY (pedido_id)
)

CREATE TABLE tb_produtoTipo (
                produto_tipo_id INT IDENTITY NOT NULL,
                tipo VARCHAR(30) NOT NULL,
                CONSTRAINT tb_produtoTipo_pk PRIMARY KEY (produto_tipo_id)
)

CREATE TABLE tb_produto (
                produto_id INT IDENTITY NOT NULL,
                descricao VARCHAR(50) NOT NULL,
                preco DECIMAL NOT NULL,
                produto_tipo_id INT NOT NULL,
                marca_id INT NOT NULL,
                CONSTRAINT tb_produto_pk PRIMARY KEY (produto_id)
)

CREATE TABLE tb_Item_Pedido (
                item_pedido_id INT IDENTITY NOT NULL,
                quantidade INT NOT NULL,
                produto_id INT NOT NULL,
                pedido_id INT NOT NULL,
                CONSTRAINT tb_Item_Pedido_pk PRIMARY KEY (item_pedido_id)
)

CREATE TABLE tb_ESTOQUE (
                estoque_id INT IDENTITY NOT NULL,
                quantidade INT NOT NULL,
                data_entrada DATETIME NOT NULL,
                produto_id INT NOT NULL,
                CONSTRAINT tb_ESTOQUE_pk PRIMARY KEY (estoque_id)
)

ALTER TABLE tb_Pessoa ADD CONSTRAINT tb_endereco_tb_Pessoa_fk
FOREIGN KEY (endereco_id)
REFERENCES tb_endereco (endereco_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_fornecedor ADD CONSTRAINT tb_Pessoa_tb_fornecedor_fk
FOREIGN KEY (pessoa_id)
REFERENCES tb_Pessoa (pessoa_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_cliente ADD CONSTRAINT tb_Pessoa_tb_cliente_fk
FOREIGN KEY (pessoa_id)
REFERENCES tb_Pessoa (pessoa_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_vendedor ADD CONSTRAINT tb_Pessoa_tb_vendedor_fk
FOREIGN KEY (pessoa_id)
REFERENCES tb_Pessoa (pessoa_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_fornecedorMarca ADD CONSTRAINT tb_fornecedor_tb_fornecedorMarca_fk
FOREIGN KEY (fornecedor_id)
REFERENCES tb_fornecedor (fornecedor_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_pedido ADD CONSTRAINT tb_cliente_tb_pedido_fk
FOREIGN KEY (cliente_id)
REFERENCES tb_cliente (cliente_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_pedido ADD CONSTRAINT tb_vendedor_tb_pedido_fk
FOREIGN KEY (vendedor_id)
REFERENCES tb_vendedor (vendedor_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_produto ADD CONSTRAINT tb_marca_tb_produto_fk
FOREIGN KEY (marca_id)
REFERENCES tb_marca (marca_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_fornecedorMarca ADD CONSTRAINT tb_marca_tb_fornecedorMarca_fk
FOREIGN KEY (marca_id)
REFERENCES tb_marca (marca_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_Item_Pedido ADD CONSTRAINT tb_pedido_tb_Item_Pedido_fk
FOREIGN KEY (pedido_id)
REFERENCES tb_pedido (pedido_id)
ON DELETE NO ACTION\
ON UPDATE NO ACTION

ALTER TABLE tb_produto ADD CONSTRAINT tb_produtoTipo_tb_produto_fk
FOREIGN KEY (produto_tipo_id)
REFERENCES tb_produtoTipo (produto_tipo_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_Item_Pedido ADD CONSTRAINT tb_produto_tb_Item_Pedido_fk
FOREIGN KEY (produto_id)
REFERENCES tb_produto (produto_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION

ALTER TABLE tb_ESTOQUE ADD CONSTRAINT tb_produto_tb_ESTOQUE_fk
FOREIGN KEY (produto_id)
REFERENCES tb_produto (produto_id)
ON DELETE NO ACTION
ON UPDATE NO ACTION