CREATE TABLE [dbo].[tblUsuarioPerfil] (
    [IdUsuarioPerfil] INT    NOT NULL IDENTITY,
    [IdUsuario]       BIGINT NOT NULL,
    [IdPerfil]        INT    NOT NULL,
    CONSTRAINT [PK_tblUsuarioPerfil] PRIMARY KEY CLUSTERED ([IdUsuarioPerfil] ASC),
    CONSTRAINT [FK_tblUsuarioPerfil_tblPerfil] FOREIGN KEY ([IdPerfil]) REFERENCES [dbo].[tblPerfil] ([IdPerfil]),
    CONSTRAINT [FK_tblUsuarioPerfil_tblUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario] ([IdUsuario])
);

