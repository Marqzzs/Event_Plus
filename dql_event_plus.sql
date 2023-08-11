--DQL

--Nome do usuario
--data do evento
--local do evento
--Titulo do evento
--Nome do evento
--Descricao
--situacao
--comentario
USE Event_Manha;

SELECT
Usuario.Nome AS Nome,
TiposDeUsuario.TituloTipoDeUsuario AS TiposDeUsuario,
Eventos.DataEvento AS [Data],
Instituicao.Endereco AS Endereco,
Eventos.Nome AS Titulo,
Eventos.Descricao AS Descricao,
PresencasEvento.Situacao AS Situacao,
ComentarioEvento.Descricao AS Comentario
FROM Eventos
LEFT JOIN Usuario ON Usuario.IdUsuario = Usuario.IdUsuario
LEFT JOIN TiposDeUsuario ON Usuario.IdTipoDeUsuario = TiposDeUsuario.IdTipoDeUsuario
LEFT JOIN Instituicao ON Eventos.IdInstituicao = Instituicao.IdInstituicao
LEFT JOIN PresencasEvento ON Eventos.IdEvento = PresencasEvento.IdEvento
LEFT JOIN ComentarioEvento ON Eventos.IdEvento = ComentarioEvento.IdEvento

SELECT
    Usuario.Nome AS Nome,
    TiposDeUsuario.TituloTipoDeUsuario AS TipoUsuario,
    Eventos.DataEvento AS Data,
    CONCAT (Instituicao.Endereco, ' - ',  Instituicao.NomeFantasia) AS Endereco,
    Eventos.Nome AS Titulo,
    Eventos.Descricao AS Descricao,
    PresencasEvento.Situacao AS Situacao,
    ComentarioEvento.Descricao AS Comentario,
    CASE 
        WHEN PresencasEvento.Situacao = 1 THEN 'Presente'
        WHEN PresencasEvento.Situacao = 0 THEN 'Ausente'
        ELSE 'Não Registrado'
    END AS StatusPresenca
FROM Eventos
LEFT JOIN Usuario ON Usuario.IdUsuario = Usuario.IdUsuario
LEFT JOIN TiposDeUsuario ON Usuario.IdTipoDeUsuario = TiposDeUsuario.IdTipoDeUsuario
LEFT JOIN Instituicao ON Eventos.IdInstituicao = Instituicao.IdInstituicao
LEFT JOIN PresencasEvento ON Eventos.IdEvento = PresencasEvento.IdEvento
LEFT JOIN ComentarioEvento ON Eventos.IdEvento = ComentarioEvento.IdEvento;
