CREATE TABLE [dbo].[tblOcorrencia] (
    [IdOcorrencia]       BIGINT        NOT NULL IDENTITY,
    [IdChamado]          BIGINT        NOT NULL,
    [DataAlteracao]      DATETIME      NOT NULL,
    [IdUsuarioAlteracao] BIGINT        NOT NULL,
    [Descricao]          VARCHAR (400) NOT NULL,
    CONSTRAINT [PK_tblOcorrencia] PRIMARY KEY CLUSTERED ([IdOcorrencia] ASC),
    CONSTRAINT [FK_tblOcorrencia_tblChamado] FOREIGN KEY ([IdChamado]) REFERENCES [dbo].[tblChamado] ([IdChamado]),
    CONSTRAINT [FK_tblOcorrencia_tblUsuario] FOREIGN KEY ([IdUsuarioAlteracao]) REFERENCES [dbo].[tblUsuario] ([IdUsuario])
);

