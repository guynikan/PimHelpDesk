CREATE TABLE [dbo].[tblPerfil] (
    [IdPerfil]  INT           NOT NULL IDENTITY,
    [Codigo]    VARCHAR (50)  NOT NULL,
    [Descricao] VARCHAR (100) NOT NULL,
    [Ativo]     BIT           NOT NULL,
    CONSTRAINT [PK_tblPerfil] PRIMARY KEY CLUSTERED ([IdPerfil] ASC)
);

