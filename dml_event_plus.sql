--DML(DataBase Manipulation language)

USE [Event+_Manha];

--Inserir dados nas tabelas
INSERT INTO TiposDeUsuario (TituloTipoDeUsuario)
VALUES ('Administrador'), ('Comum')

INSERT INTO TiposDeEvento (TituloTipoDeEvento)
VALUES ('Sql Server')

INSERT INTO Instituicao (NomeFantasia, CNPJ, Endereco)
VALUES ('Dev School', '12345678910114', 'Rua Niteroi, 180')

INSERT INTO Usuario (IdTipoDeUsuario, Nome, Email, Senha)
VALUES (1, 'Marqz', 'adm@gmail.com', 'admin1234')

INSERT INTO Eventos (IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HorarioEvento)
VALUES (1, 1, 'Introdução ao Banco de Dados Sql Server', 'Aprenda os conceitos basicos do Sql Server', '2023-08-10', '10:00:00')

INSERT INTO PresencasEvento (IdUsusario, IdEvento)
VALUES (1, 1)

INSERT INTO ComentarioEvento (IdUsusario, IdEvento, Descricao, Exibe)
VALUES (1, 1, 'Excelente evento, professores top!', 1)

SELECT * FROM TiposDeUsuario
SELECT * FROM TiposDeEvento 
SELECT * FROM Instituicao
SELECT * FROM Usuario
SELECT * FROM Eventos
SELECT * FROM PresencasEvento
SELECT * FROM ComentarioEvento