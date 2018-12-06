CREATE TABLE [dbo].[tblFeriado] (
    [IdFeriado]    INT           NOT NULL IDENTITY,
    [Dia]          INT           NOT NULL,
    [Mes]          INT           NOT NULL,
    [Ano]          INT           NULL,
    [Ativo]        BIT           NOT NULL,
    [Descricao]    VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblFeriado] PRIMARY KEY CLUSTERED ([IdFeriado] ASC)
);

