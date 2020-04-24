USE SCA
GO

--SELECT * FROM db_owner.Classe
INSERT INTO db_owner.Classe(Nome) VALUES('Equipamentos de perfuração')
INSERT INTO db_owner.Classe(Nome) VALUES('Equipamentos de carregamento')
INSERT INTO db_owner.Classe(Nome) VALUES('Equipamentos de desmonte mecânico')
INSERT INTO db_owner.Classe(Nome) VALUES('Equipamentos de transporte')

--SELECT * FROM db_owner.Perfil
INSERT INTO db_owner.Perfil(Nome) VALUES('Administrador')
INSERT INTO db_owner.Perfil(Nome) VALUES('Engenheiro')
INSERT INTO db_owner.Perfil(Nome) VALUES('Manutenção')
INSERT INTO db_owner.Perfil(Nome) VALUES('Auditoria')
INSERT INTO db_owner.Perfil(Nome) VALUES('Consultor')
INSERT INTO db_owner.Perfil(Nome) VALUES('Gestor')

--SELECT * FROM db_owner.Usuario
INSERT INTO db_owner.Usuario(Nome, Login, Senha, PerfilId, Situacao) VALUES('Administrador do Sistema','admin','admin',1,'ATIVO')
