CREATE TABLE [dbo].[tblGrupoUsuario] (
    [IdGrupoUsuario] INT    NOT NULL IDENTITY,
    [IdUsuario]      BIGINT NOT NULL,
    [IdGrupo]        INT    NOT NULL,
    CONSTRAINT [PK_tblGrupoUsuario] PRIMARY KEY CLUSTERED ([IdGrupoUsuario] ASC),
    CONSTRAINT [FK_tblGrupoUsuario_tblGrupo] FOREIGN KEY ([IdGrupo]) REFERENCES [dbo].[tblGrupo] ([IdGrupo]),
    CONSTRAINT [FK_tblGrupoUsuario_tblUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[tblUsuario] ([IdUsuario])
);

