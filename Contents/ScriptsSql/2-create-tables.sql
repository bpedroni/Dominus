USE dominus
GO

-- Comandos para deletar as tabelas, caso elas existam:
DROP TABLE IF EXISTS Chamado;
DROP TABLE IF EXISTS Relatorio;
DROP TABLE IF EXISTS TipoRelatorio;
DROP TABLE IF EXISTS Transacao;
DROP TABLE IF EXISTS Planejamento;
DROP TABLE IF EXISTS Categoria;
DROP TABLE IF EXISTS Usuario;
GO

-- Criação da tabela Usuario.
CREATE TABLE Usuario (
	IdUsuario uniqueidentifier CONSTRAINT DF_Usuario_IdUsuario DEFAULT newid() CONSTRAINT PK_Usuario PRIMARY KEY,
	Nome varchar(100) NOT NULL,
	Login varchar(25) NOT NULL CONSTRAINT AK_Usuario_Login UNIQUE,
	Email varchar(100) NOT NULL CONSTRAINT AK_Usuario_Email UNIQUE,
	Senha varchar(255) NOT NULL,
	PerfilAdministrador int NOT NULL CONSTRAINT DF_Usuario_PerfilAdministrador DEFAULT 0,
	DataCriacao datetime NOT NULL CONSTRAINT DF_Usuario_DataCriacao DEFAULT dateadd(HOUR, -3, getutcdate()),
	DataExclusao datetime NULL,
	Ativo int NOT NULL CONSTRAINT DF_Usuario_Ativo DEFAULT 1
);
CREATE INDEX IX_Usuario_IdUsuario ON Usuario (IdUsuario);
GO

-- Criação da tabela Categoria.
CREATE TABLE Categoria (
	IdCategoria uniqueidentifier CONSTRAINT DF_Categoria_IdCategoria DEFAULT newid() CONSTRAINT PK_Categoria PRIMARY KEY,
	Nome varchar(50) NOT NULL,
	Descricao varchar(255) NOT NULL,
	TipoFluxo varchar(10) NOT NULL CONSTRAINT CK_Categoria_TipoFluxo CHECK (TipoFluxo IN ('Receita', 'Despesa')),
	Icone varchar(100) NOT NULL,
	DataCriacao datetime NOT NULL CONSTRAINT DF_Categoria_DataCriacao DEFAULT dateadd(HOUR, -3, getutcdate()),
	DataExclusao datetime NULL,
	Ativo int NOT NULL CONSTRAINT DF_Categoria_Ativo DEFAULT 1,
	CONSTRAINT AK_Categoria_Nome_TipoFluxo UNIQUE (Nome, TipoFluxo)
);
CREATE INDEX IX_Categoria_IdCategoria ON Categoria (IdCategoria);
GO

-- Criação da tabela Transacao.
CREATE TABLE Transacao (
	IdTransacao uniqueidentifier CONSTRAINT DF_Transacao_IdTransacao DEFAULT newid() CONSTRAINT PK_Transacao PRIMARY KEY,
	IdUsuario uniqueidentifier NOT NULL CONSTRAINT FK_Transacao_IdUsuario FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdCategoria uniqueidentifier NOT NULL CONSTRAINT FK_Transacao_IdCategoria FOREIGN KEY REFERENCES Categoria (IdCategoria),
	Identificacao varchar(25) NULL,
	Descricao varchar(100) NOT NULL,
	TipoFluxo varchar(10) NOT NULL CONSTRAINT CK_Transacao_TipoFluxo CHECK (TipoFluxo IN ('Receita', 'Despesa')),
	Valor dec(11,2) NULL,
	Data date NULL,
	Comentario varchar(255) NULL,
	Provisionado int NOT NULL CONSTRAINT DF_Transacao_Provisionado DEFAULT 0,
	ValorProvisao dec(11,2) NULL,
	DataProvisao date NULL
);
CREATE INDEX IX_Transacao_IdTransacao ON Transacao (IdTransacao);
CREATE INDEX IX_Transacao_IdUsuario ON Transacao (IdUsuario);
CREATE INDEX IX_Transacao_IdCategoria ON Transacao (IdCategoria);
GO

-- Criação da tabela Planejamento.
CREATE TABLE Planejamento (
	IdPlanejamento uniqueidentifier CONSTRAINT DF_Planejamento_IdPlanejamento DEFAULT newid() CONSTRAINT PK_Planejamento PRIMARY KEY,
	IdUsuario uniqueidentifier NOT NULL CONSTRAINT FK_Planejamento_IdUsuario FOREIGN KEY REFERENCES Usuario (IdUsuario),
	IdCategoria uniqueidentifier NOT NULL CONSTRAINT FK_Planejamento_IdCategoria FOREIGN KEY REFERENCES Categoria (IdCategoria),
	Mes int NOT NULL CONSTRAINT CK_Planejamento_Mes CHECK (Mes in (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)),
	Ano int NOT NULL,
	Valor decimal(11,2) NOT NULL,
	DataAtualizacao datetime NOT NULL CONSTRAINT DF_Planejamento_DataAtualizacao DEFAULT dateadd(HOUR, -3, getutcdate()),
	CONSTRAINT AK_Planejamento_CategUsuMesAno UNIQUE (IdUsuario, IdCategoria, Mes, Ano)
);
CREATE INDEX IX_Planejamento_IdPlanejamento ON Planejamento (IdPlanejamento);
CREATE INDEX IX_Planejamento_IdUsuario ON Transacao (IdUsuario);
CREATE INDEX IX_Planejamento_IdCategoria ON Transacao (IdCategoria);
GO

-- Criação da tabela Categoria.
CREATE TABLE TipoRelatorio (
	IdTipoRelatorio uniqueidentifier CONSTRAINT DF_TipoRelatorio_IdTipoRelatorio DEFAULT newid() CONSTRAINT PK_TipoRelatorio PRIMARY KEY,
	Tipo varchar(25) NOT NULL CONSTRAINT AK_TipoRelatorio_Tipo UNIQUE,
	Descricao varchar(100) NOT NULL
);
CREATE INDEX IX_TipoRelatorio_IdTipoRelatorio ON TipoRelatorio (IdTipoRelatorio);
GO

-- Criação da tabela Transacao.
CREATE TABLE Relatorio (
	IdRelatorio uniqueidentifier CONSTRAINT DF_Relatorio_IdRelatorio DEFAULT newid() CONSTRAINT PK_Relatorio PRIMARY KEY,
	IdTipoRelatorio uniqueidentifier NOT NULL CONSTRAINT FK_Relatorio_IdTipoRelatorio FOREIGN KEY REFERENCES TipoRelatorio (IdTipoRelatorio),
	IdUsuario uniqueidentifier NOT NULL CONSTRAINT FK_Relatorio_IdUsuario FOREIGN KEY REFERENCES Usuario (IdUsuario),
	Nome varchar(100) NOT NULL,
	InfoLinha varchar(100) NOT NULL,
	InfoColuna varchar(100) NULL
);
CREATE INDEX IX_Relatorio_IdRelatorio ON Relatorio (IdRelatorio);
GO

-- Criação da tabela Chamado.
CREATE TABLE Chamado (
	IdChamado uniqueidentifier CONSTRAINT DF_Chamado_IdChamado DEFAULT newid() CONSTRAINT PK_Chamado PRIMARY KEY,
	IdUsuario uniqueidentifier NOT NULL CONSTRAINT FK_Chamado_IdUsuario FOREIGN KEY REFERENCES Usuario (IdUsuario),
	Titulo varchar(50) NOT NULL,
	Mensagem varchar(1000) NOT NULL,
	DataCriacao datetime NOT NULL CONSTRAINT DF_Chamado_DataCriacao DEFAULT dateadd(HOUR, -3, getutcdate()),
	IdUsuarioSuporte uniqueidentifier NULL CONSTRAINT FK_Chamado_IdUsuarioSuporte FOREIGN KEY REFERENCES Usuario (IdUsuario),
	MensagemResposta varchar(1000) NULL,
	DataResposta datetime NULL,
	Validado int NOT NULL CONSTRAINT DF_Chamado_Validado DEFAULT 0,
	IdChamadoAssociado uniqueidentifier NULL CONSTRAINT FK_Chamado_IdChamadoAssociado FOREIGN KEY REFERENCES Chamado (IdChamado)
);
CREATE INDEX IX_Chamado_IdChamado ON Chamado (IdChamado);
CREATE INDEX IX_Chamado_IdUsuario ON Chamado (IdUsuario);
CREATE INDEX IX_Chamado_IdUsuarioSuporte ON Chamado (IdUsuarioSuporte);
CREATE INDEX IX_Chamado_IdChamadoAssociado ON Chamado (IdChamadoAssociado);
GO

-- Criação de trigger para inserção na tabela Usuario.
CREATE OR ALTER TRIGGER trgInserirUsuario
ON Usuario
INSTEAD OF INSERT
AS BEGIN
	-- Criação das variáveis:
	DECLARE
	@IdUsuario uniqueidentifier,
	@Nome varchar(100),
	@Login varchar(25),
	@Email varchar(100),
	@Senha varchar(255),
	@Usuario int
	-- Criação de um cursor para percorrer cada registro inserido:
	DECLARE cursorUsuario CURSOR FOR SELECT IdUsuario, Nome, Login, Email, Senha FROM Inserted
	OPEN cursorUsuario
	FETCH NEXT FROM cursorUsuario INTO @IdUsuario, @Nome, @Login, @Email, @Senha
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Define o uuid, caso este seja nulo ou existente no sistema:
		SELECT @Usuario = COUNT(IdUsuario) FROM Usuario WHERE IdUsuario = @IdUsuario
		IF (@IdUsuario IS NULL OR @Usuario <> 0)
		BEGIN
			SELECT @IdUsuario = newid()
		END
		-- Verifica se as informações são válidas:
		IF (@Nome IS NULL OR @Nome = '')
		BEGIN
			PRINT 'O nome deve ser informado.'
		END
		ELSE
		BEGIN
			IF (@Login IS NULL OR @Login = '')
			BEGIN
				PRINT 'Um login deve ser informado.'
			END
			ELSE
			BEGIN
				IF (@Email IS NULL OR @Email = '')
				BEGIN
					PRINT 'Um e-mail deve ser informado.'
				END
				ELSE
				BEGIN
					IF (@Senha IS NULL OR @Senha = '')
					BEGIN
						PRINT 'A senha deve ser informada.'
					END
					ELSE
					BEGIN
						-- Verifica se não existe nenhum usuário com o login fornecido:
						SELECT @Usuario = COUNT(IdUsuario) FROM Usuario WHERE Login LIKE @Login
						IF (@Usuario <> 0)
						BEGIN
							PRINT CONCAT('O login ', @Login, ' já existe. Escolha um outro login.')
						END
						ELSE
						BEGIN
							-- Verifica se não existe nenhum usuário com o e-mail fornecido:
							SELECT @Usuario = COUNT(IdUsuario) FROM Usuario WHERE Email LIKE @Email
							IF (@Usuario <> 0)
							BEGIN
								PRINT CONCAT('O e-mail ', @Email, ' já possui cadastro no sistema. Utilize um outro e-mail ou recupere sua senha.')
							END
							ELSE
							BEGIN
								BEGIN TRY
									-- Insere o novo registro após as validações com os valores padrões para os outros campos:
									INSERT INTO Usuario (IdUsuario,Nome,Login,Email,Senha,PerfilAdministrador,DataCriacao)
										VALUES (@IdUsuario, @Nome, @Login, @Email, @Senha, 0, dateadd(HOUR, -3, getutcdate()))
								END TRY
								BEGIN CATCH
									PRINT 'Ocorreu algum erro inesperado ao tentar inserir o registro. Verifique os dados ou contate o administrador do sistema'
								END CATCH
							END
						END
					END
				END
			END
		END
		-- Atualiza o cursor:
		FETCH NEXT FROM cursorUsuario INTO @IdUsuario, @Nome, @Login, @Email, @Senha
	END
	CLOSE cursorUsuario
	DEALLOCATE cursorUsuario
END
GO

-- Criação de trigger para edição na tabela Usuario.
CREATE OR ALTER TRIGGER trgEditarUsuario
ON Usuario
INSTEAD OF UPDATE
AS BEGIN
	-- Criação das variáveis:
	DECLARE
	@IdUsuario uniqueidentifier,
	@Nome varchar(100),
	@Login varchar(25),
	@Senha varchar(255),
	@PerfilAdministrador int,
	@Ativo int,
	@Usuario int
	-- Criação de um cursor para percorrer cada registro inserido:
	DECLARE cursorUsuario CURSOR FOR SELECT IdUsuario, Nome, Login, Senha, PerfilAdministrador, Ativo FROM Inserted
	OPEN cursorUsuario
	FETCH NEXT FROM cursorUsuario INTO @IdUsuario, @Nome, @Login, @Senha, @PerfilAdministrador, @Ativo
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Verifica se as informações são válidas:
		IF (@PerfilAdministrador IS NULL OR @PerfilAdministrador <> 1)
		BEGIN
			SELECT @PerfilAdministrador = 0
		END
		IF (@Ativo IS NULL OR @Ativo <> 0)
		BEGIN
			SELECT @Ativo = 1
		END
		IF (@IdUsuario IS NULL)
		BEGIN
			PRINT 'O usuário não foi encontrado no sistema.'
		END
		ELSE
		BEGIN
			IF (@Nome IS NULL OR @Nome = '')
			BEGIN
				PRINT 'O nome deve ser informado.'
			END
			ELSE
			BEGIN
				IF (@Login IS NULL OR @Login = '')
				BEGIN
					PRINT 'Um login deve ser informado.'
				END
				ELSE
				BEGIN
					IF (@Senha IS NULL OR @Senha = '')
					BEGIN
						PRINT 'A senha deve ser informada.'
					END
					ELSE
					BEGIN
						-- Verifica se não existe nenhum usuário com o login fornecido:
						SELECT @Usuario = COUNT(IdUsuario) FROM Usuario WHERE IdUsuario <> @IdUsuario AND Login LIKE @Login
						IF (@Usuario <> 0)
						BEGIN
							PRINT CONCAT('O login ', @Login, ' já existe. Escolha um outro login.')
						END
						ELSE
						BEGIN
							BEGIN TRY
								-- Edita o registro após as validações com os valores padrões para os outros campos:
								UPDATE Usuario SET Nome = @Nome, Login = @Login, Senha = @Senha, PerfilAdministrador = @PerfilAdministrador, Ativo = @Ativo
									WHERE IdUsuario = @IdUsuario
							END TRY
							BEGIN CATCH
								PRINT 'Ocorreu algum erro inesperado ao tentar inserir o registro. Verifique os dados ou contate o administrador do sistema'
							END CATCH
						END
					END
				END
			END
		END
		-- Atualiza o cursor:
		FETCH NEXT FROM cursorUsuario INTO @IdUsuario, @Nome, @Login, @Senha, @PerfilAdministrador, @Ativo
	END
	CLOSE cursorUsuario
	DEALLOCATE cursorUsuario
END
GO

-- Criação de trigger para remoção na tabela Usuario.
CREATE OR ALTER TRIGGER trgDesativarUsuario
ON Usuario
INSTEAD OF DELETE
AS BEGIN
	-- Criação das variáveis:
	DECLARE
	@IdUsuario uniqueidentifier
	-- Criação de um cursor para percorrer cada registro removido:
	DECLARE cursorUsuario CURSOR FOR SELECT IdUsuario FROM Deleted
	OPEN cursorUsuario
	FETCH NEXT FROM cursorUsuario INTO @IdUsuario
	WHILE @@FETCH_STATUS = 0
	BEGIN
		BEGIN TRY
			-- Altera o status do usuário para inativo no sistema:
			UPDATE Usuario SET Ativo = 0, DataExclusao = dateadd(HOUR, -3, getutcdate()) WHERE IdUsuario = @IdUsuario
		END TRY
		BEGIN CATCH
			PRINT 'Ocorreu algum erro inesperado ao tentar remover o registro. Contate o administrador do sistema'
		END CATCH
		-- Atualiza o cursor:
		FETCH NEXT FROM cursorUsuario INTO @IdUsuario
	END
	CLOSE cursorUsuario
	DEALLOCATE cursorUsuario
END
GO

-- Criação de trigger para inserção na tabela Categoria.
CREATE OR ALTER TRIGGER trgInserirCategoria
ON Categoria
INSTEAD OF INSERT
AS BEGIN
	-- Criação das variáveis:
	DECLARE
	@IdCategoria uniqueidentifier,
	@Nome varchar(50),
	@Descricao varchar(255),
	@TipoFluxo varchar(10),
	@Icone varchar(100),
	@Categoria int
	-- Criação de um cursor para percorrer cada registro inserido:
	DECLARE cursorCategoria CURSOR FOR SELECT IdCategoria, Nome, Descricao, TipoFluxo, Icone FROM Inserted
	OPEN cursorCategoria
	FETCH NEXT FROM cursorCategoria INTO @IdCategoria, @Nome, @Descricao, @TipoFluxo, @Icone
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Define o uuid, caso este seja nulo ou existente no sistema:
		SELECT @Categoria = COUNT(IdCategoria) FROM Categoria WHERE IdCategoria = @IdCategoria
		IF (@IdCategoria IS NULL OR @Categoria <> 0)
		BEGIN
			SELECT @IdCategoria = newid()
		END
		-- Verifica se as informações são válidas:
		IF (@Nome IS NULL OR @Nome = '')
		BEGIN
			PRINT 'O nome deve ser informado.'
		END
		ELSE
			BEGIN
			IF (@Descricao IS NULL OR @Descricao = '')
			BEGIN
				PRINT 'A descrição deve ser informada.'
			END
			ELSE
			BEGIN
				IF (@TipoFluxo NOT IN ('Receita', 'Despesa'))
				BEGIN
					PRINT 'O tipo do fluxo admite apenas os valores "Receita" e "Despesa".'
				END
				ELSE
				BEGIN
					IF (@Icone IS NULL OR @Icone = '')
					BEGIN
						PRINT 'O caminho do ícone deve ser informado.'
					END
					ELSE
					BEGIN
						-- Verifica se não existe nenhuma categoria com o nome e o tipo do fluxo fornecidos:
						SELECT @Categoria = COUNT(IdCategoria) FROM Categoria WHERE Nome LIKE @Nome AND TipoFluxo LIKE @TipoFluxo
						IF (@Categoria <> 0)
						BEGIN
							PRINT CONCAT('A categoria ', @Nome, ' com o tipo ', @TipoFluxo, ' já existe. Escolha um outro nome.')
						END
						ELSE
						BEGIN
							BEGIN TRY
								-- Insere o novo registro após as validações com os valores padrões para os outros campos:
								INSERT INTO Categoria(IdCategoria,Nome,Descricao,TipoFluxo,Icone,DataCriacao)
									VALUES (@IdCategoria, @Nome, @Descricao, @TipoFluxo, @Icone, dateadd(HOUR, -3, getutcdate()))
							END TRY
							BEGIN CATCH
								PRINT 'Ocorreu algum erro inesperado ao tentar inserir o registro. Verifique os dados ou contate o administrador do sistema'
							END CATCH
						END
					END
				END
			END
		END
		-- Atualiza o cursor:
		FETCH NEXT FROM cursorCategoria INTO @IdCategoria, @Nome, @Descricao, @TipoFluxo, @Icone
	END
	CLOSE cursorCategoria
	DEALLOCATE cursorCategoria
END
GO

-- Criação de trigger para edição na tabela Categoria.
CREATE OR ALTER TRIGGER trgEditarCategoria
ON Categoria
INSTEAD OF UPDATE
AS BEGIN
	-- Criação das variáveis:
	DECLARE
	@IdCategoria uniqueidentifier,
	@Nome varchar(50),
	@Descricao varchar(255),
	@TipoFluxo varchar(10),
	@Icone varchar(100),
	@Ativo int,
	@Categoria int
	-- Criação de um cursor para percorrer cada registro inserido:
	DECLARE cursorCategoria CURSOR FOR SELECT IdCategoria, Nome, Descricao, TipoFluxo, Icone, Ativo FROM Inserted
	OPEN cursorCategoria
	FETCH NEXT FROM cursorCategoria INTO @IdCategoria, @Nome, @Descricao, @TipoFluxo, @Icone, @Ativo
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- Verifica se as informações são válidas:
		IF (@Ativo IS NULL OR @Ativo <> 0)
		BEGIN
			SELECT @Ativo = 1
		END
		IF (@IdCategoria IS NULL)
		BEGIN
			PRINT 'A categoria não foi encontrada no sistema.'
		END
		ELSE
		BEGIN
			IF (@Nome IS NULL OR @Nome = '')
			BEGIN
				PRINT 'O nome deve ser informado.'
			END
			ELSE
				BEGIN
				IF (@Descricao IS NULL OR @Descricao = '')
				BEGIN
					PRINT 'A descrição deve ser informada.'
				END
				ELSE
				BEGIN
					IF (@TipoFluxo NOT IN ('Receita', 'Despesa'))
					BEGIN
						PRINT 'O tipo do fluxo admite apenas os valores "Receita" e "Despesa".'
					END
					ELSE
					BEGIN
						IF (@Icone IS NULL OR @Icone = '')
						BEGIN
							PRINT 'O caminho do ícone deve ser informado.'
						END
						ELSE
						BEGIN
							-- Verifica se não existe nenhuma categoria com o nome e o tipo do fluxo fornecidos:
							SELECT @Categoria = COUNT(IdCategoria) FROM Categoria WHERE IdCategoria <> @IdCategoria AND Nome LIKE @Nome AND TipoFluxo LIKE @TipoFluxo
							IF (@Categoria <> 0)
							BEGIN
								PRINT CONCAT('A categoria ', @Nome, ' com o tipo ', @TipoFluxo, ' já existe. Escolha um outro nome.')
							END
							ELSE
							BEGIN
								BEGIN TRY
									-- Edita o registro após as validações com os valores padrões para os outros campos:
									UPDATE Categoria SET Nome = @Nome, Descricao = @Descricao, TipoFluxo = @TipoFluxo, Icone = @Icone, Ativo = @Ativo
										WHERE IdCategoria = @IdCategoria
								END TRY
								BEGIN CATCH
									PRINT 'Ocorreu algum erro inesperado ao tentar inserir o registro. Verifique os dados ou contate o administrador do sistema'
								END CATCH
							END
						END
					END
				END
			END
		END
		-- Atualiza o cursor:
		FETCH NEXT FROM cursorCategoria INTO @IdCategoria, @Nome, @Descricao, @TipoFluxo, @Icone, @Ativo
	END
	CLOSE cursorCategoria
	DEALLOCATE cursorCategoria
END
GO

-- Criação de trigger para remoção na tabela Categoria.
CREATE OR ALTER TRIGGER trgDesativarCategoria
ON Categoria
INSTEAD OF DELETE
AS BEGIN
	-- Criação das variáveis:
	DECLARE
	@IdCategoria uniqueidentifier
	-- Criação de um cursor para percorrer cada registro removido:
	DECLARE cursorCategoria CURSOR FOR SELECT IdCategoria FROM Deleted
	OPEN cursorCategoria
	FETCH NEXT FROM cursorCategoria INTO @IdCategoria
	WHILE @@FETCH_STATUS = 0
	BEGIN
		BEGIN TRY
			-- Altera o status da categoria para inativo no sistema:
			UPDATE Categoria SET Ativo = 0, DataExclusao = dateadd(HOUR, -3, getutcdate()) WHERE IdCategoria = @IdCategoria
		END TRY
		BEGIN CATCH
			PRINT 'Ocorreu algum erro inesperado ao tentar remover o registro. Contate o administrador do sistema'
		END CATCH
		-- Atualiza o cursor:
		FETCH NEXT FROM cursorCategoria INTO @IdCategoria
	END
	CLOSE cursorCategoria
	DEALLOCATE cursorCategoria
END
GO
