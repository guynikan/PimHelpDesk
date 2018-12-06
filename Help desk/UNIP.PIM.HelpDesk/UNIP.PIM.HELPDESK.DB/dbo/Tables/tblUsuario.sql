CREATE TABLE [dbo].[tblUsuario] (
    [IdUsuario] BIGINT        NOT NULL IDENTITY,
    [Nome]      VARCHAR (100) NOT NULL,
    [Email]     VARCHAR (100) NOT NULL,
    [Senha]     VARCHAR (50)  NOT NULL,
    [Ativo]     BIT           NOT NULL,
    [IdCliente] INT           NOT NULL,
    CONSTRAINT [PK_tblUsuario] PRIMARY KEY CLUSTERED ([IdUsuario] ASC),
    CONSTRAINT [FK_tblUsuario_tblCliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[tblCliente] ([IdCliente]),
    CONSTRAINT [FK_tblUsuario_tblUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario] ([IdUsuario])
);

