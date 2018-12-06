CREATE TABLE [dbo].[tblChamado] (
    [IdChamado]             BIGINT        NOT NULL IDENTITY,
    [Titulo]                VARCHAR (100) NOT NULL,
    [DataAbertura]          DATETIME      NOT NULL,
    [DataConclusaoPrevista] DATETIME      NULL,
    [DataFechamento]        DATETIME      NULL,
    [IdStatus]              INT           NOT NULL,
    [IdSolicitacao]       INT           NOT NULL,
    [IdUsuarioAbertura]     BIGINT        NOT NULL,
    [IdTecnico]             BIGINT        NULL,
    CONSTRAINT [PK_tblChamado] PRIMARY KEY CLUSTERED ([IdChamado] ASC),
    CONSTRAINT [FK_tblChamado_tblStatus] FOREIGN KEY ([IdStatus]) REFERENCES [dbo].[tblStatus] ([IdStatus]),
    CONSTRAINT [FK_tblChamado_tblUsuarioAbertura] FOREIGN KEY ([IdUsuarioAbertura]) REFERENCES [dbo].[tblUsuario] ([IdUsuario]),
    CONSTRAINT [FK_tblChamado_tblUsuarioTecnico] FOREIGN KEY ([IdTecnico]) REFERENCES [dbo].[tblUsuario] ([IdUsuario]) 
);

