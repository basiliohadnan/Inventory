

INSERT INTO endereco
SELECT 'Rua Toranja', 10, 'casa 1', 'Mandaqui', 'São Paulo', 'SP', '02407-999'
UNION ALL SELECT 'Rua Toranja', 11, 'casa 2', 'Mandaqui', 'São Paulo', 'SP', '02407-999'
UNION ALL SELECT 'Rua Toranja', 12, 'casa 3', 'Mandaqui', 'São Paulo', 'SP', '02407-999'
UNION ALL SELECT 'Rua Toranja', 13, 'casa 4', 'Mandaqui', 'São Paulo', 'SP', '02407-999'
UNION ALL SELECT 'Rua Toranja', 14, 'casa 5', 'Mandaqui', 'São Paulo', 'SP', '02407-999'

SELECT 
	* 
FROM endereco
--------------------------------------------------------------------------------------------


INSERT INTO pessoa
SELECT 'Hadnan', '11951011010', NULL, 'hadnan@gmail.com', 1
UNION ALL SELECT 'Satoshi', '71951011011', '71955011011', 'satoshi@gmail.com', 2
UNION ALL SELECT 'Basilio', '31951011012', NULL, 'basilio@gmail.com', 3
UNION ALL SELECT 'Douglas', '21951011013', '21441011013', 'douglas@gmail.com', 4
UNION ALL SELECT 'César', '44951011014', NULL, 'cesar@gmail.com', 5

SELECT
	*
FROM pessoa
--------------------------------------------------------------------------------------------

	
INSERT INTO cliente
SELECT '319.000.999-10', 1, 1
UNION ALL SELECT '569.000.999-10', 0, 2
UNION ALL SELECT '449.000.999-10', 0, 3

SELECT * FROM cliente c
join pessoa p on p.id = c.pessoaId
join endereco e on e.id = p.enderecoId
--------------------------------------------------------------------------------------------


INSERT INTO vendedor
SELECT '10.222.333/5050-00', 5

SELECT * FROM vendedor v
join pessoa p on p.id = v.pessoaId

--------------------------------------------------------------------------------------------


INSERT INTO produtoTipo
SELECT 'Tablet'
UNION ALL SELECT 'Celular'
UNION ALL SELECT 'Acessório'

SELECT * FROM produtoTipo
--------------------------------------------------------------------------------------------


INSERT INTO marca
SELECT 'Apple', 'apple.com'
UNION ALL SELECT 'Motorola', 'motorola.com.br'
UNION ALL SELECT 'Samsung', 'shop.samsung.com'

SELECT * FROM marca
--------------------------------------------------------------------------------------------


INSERT INTO produto
SELECT 'iPad', 5000, 1, 1
UNION ALL SELECT 'iPad 2', 6000, 1, 1
UNION ALL SELECT 'Moto G', 2500, 2, 2
UNION ALL SELECT 'Galaxy Whatever', 3000, 2, 3
UNION ALL SELECT 'Carregador tipo C', 100, 3, 2


SELECT * FROM produto P
JOIN marca M ON M.id = P.marcaId
JOIN produtoTipo PT ON PT.id = P.produtoTipoId
--------------------------------------------------------------------------------------------

INSERT INTO estoque
SELECT 100, GETDATE(), 1
UNION ALL SELECT 10, GETDATE(), 2
UNION ALL SELECT 3, GETDATE(), 3
UNION ALL SELECT 500, GETDATE(), 4
UNION ALL SELECT 10, GETDATE(), 5

SELECT * FROM estoque E 
JOIN produto P ON P.id = E.produtoId
--------------------------------------------------------------------------------------------

INSERT INTO fornecedor
SELECT '10.000.333/0001-12', 4

SELECT * FROM fornecedor F
JOIN pessoa P ON P.id = F.pessoaId
--------------------------------------------------------------------------------------------


INSERT INTO fornecedorMarca
SELECT 1, 1
UNION ALL SELECT 1, 2
UNION ALL SELECT 1, 3

SELECT * FROM fornecedorMarca FM
JOIN marca M ON M.id = FM.marcaId
JOIN fornecedor F ON FM.fornecedorId = F.id
JOIN pessoa P ON P.id = F.pessoaId
--------------------------------------------------------------------------------------------

INSERT INTO pedido
SELECT GETDATE(), 100, 1, 1
UNION ALL SELECT GETDATE(), 900, 2, 1
UNION ALL SELECT GETDATE(), 2500, 3, 1
UNION ALL SELECT GETDATE(), 14300, 1, 1
UNION ALL SELECT GETDATE(), 10000, 2, 1

SELECT P.*, pes1.NOME cliente, pes2.nome vendedor
FROM pedido P
JOIN cliente C ON C.id = P.clienteId
JOIN pessoa pes1 ON pes1.id = C.pessoaId
JOIN vendedor v on v.id = p.vendedorId
JOIN pessoa pes2 on pes2.id = v.pessoaId
--------------------------------------------------------------------------------------------

INSERT INTO itemPedido
SELECT 1, 5, 1
UNION ALL SELECT 9, 5, 5
UNION ALL SELECT 1, 3, 6

SELECT * FROM itemPedido IP
JOIN produto P ON P.ID = IP.produtoId
JOIN pedido PED ON PED.id = IP.pedidoId