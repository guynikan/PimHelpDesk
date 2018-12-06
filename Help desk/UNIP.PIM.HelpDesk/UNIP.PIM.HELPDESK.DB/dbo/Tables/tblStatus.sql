CREATE TABLE [dbo].[tblStatus] (
    [IdStatus]  INT           NOT NULL IDENTITY,
    [Codigo]    VARCHAR (50)  NOT NULL,
    [Descricao] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_tblStatus] PRIMARY KEY CLUSTERED ([IdStatus] ASC)
);

