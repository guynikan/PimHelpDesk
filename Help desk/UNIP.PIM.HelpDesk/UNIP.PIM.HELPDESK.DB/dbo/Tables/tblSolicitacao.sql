CREATE TABLE [dbo].[tblSolicitacao] (
    [IdSolicitacao] INT            NOT NULL IDENTITY,
    [Codigo]          VARCHAR (50)   NOT NULL,
    [Descricao]       VARCHAR (100)  NOT NULL,
    [IdGrupo]         INT            NOT NULL,
    [Sla]             DECIMAL (8, 2) NOT NULL,
    [Ativo] BIT NOT NULL, 
    CONSTRAINT [PK_tblSolicitacao] PRIMARY KEY CLUSTERED ([IdSolicitacao] ASC),
    CONSTRAINT [FK_tblSolicitacao_tblGrupo] FOREIGN KEY ([IdGrupo]) REFERENCES [dbo].[tblGrupo] ([IdGrupo])
);

