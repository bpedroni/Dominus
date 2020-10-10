USE dominus
GO

-- Comandos para deletar as tabelas, caso elas existam:
IF EXISTS(SELECT * from sys.tables WHERE name='Chamado')
BEGIN
    DROP TABLE Chamado;
END
IF EXISTS(SELECT * from sys.tables WHERE name='Relatorio')
BEGIN
    DROP TABLE Relatorio;
END
IF EXISTS(SELECT * from sys.tables WHERE name='TipoRelatorio')
BEGIN
    DROP TABLE TipoRelatorio;
END
IF EXISTS(SELECT * from sys.tables WHERE name='Transacao')
BEGIN
    DROP TABLE Transacao;
END
IF EXISTS(SELECT * from sys.tables WHERE name='Planejamento')
BEGIN
    DROP TABLE Planejamento;
END
IF EXISTS(SELECT * from sys.tables WHERE name='Categoria')
BEGIN
    DROP TABLE Categoria;
END
IF EXISTS(SELECT * from sys.tables WHERE name='Usuario')
BEGIN
    DROP TABLE Usuario;
END
GO

-- Criação da tabela Usuario.
CREATE TABLE Usuario (
	IdUsuario uniqueidentifier CONSTRAINT DF_Usuario_IdUsuario DEFAULT newid() CONSTRAINT PK_Usuario PRIMARY KEY,
	Nome varchar(100) NOT NULL,
	Login varchar(25) NOT NULL CONSTRAINT AK_Usuario_Login UNIQUE,
	Email varchar(100) NOT NULL CONSTRAINT AK_Usuario_Email UNIQUE,
	Senha varchar(255) NOT NULL,
	PerfilAdministrador int NOT NULL CONSTRAINT DF_Usuario_PerfilAdministrador DEFAULT 0,
	DataCriacao datetime NOT NULL CONSTRAINT DF_Usuario_DataCriacao DEFAULT getdate(),
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
	DataCriacao datetime NOT NULL CONSTRAINT DF_Categoria_DataCriacao DEFAULT getdate(),
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
	DataAtualizacao datetime NOT NULL CONSTRAINT DF_Planejamento_DataAtualizacao DEFAULT getdate(),
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
	DataCriacao datetime NOT NULL CONSTRAINT DF_Chamado_DataCriacao DEFAULT getdate(),
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
