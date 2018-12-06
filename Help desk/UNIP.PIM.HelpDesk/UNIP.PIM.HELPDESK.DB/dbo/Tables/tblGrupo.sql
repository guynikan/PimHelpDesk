CREATE TABLE [dbo].[tblGrupo] (
    [IdGrupo]           INT           NOT NULL IDENTITY,
    [Descricao]         VARCHAR (100) NOT NULL,
    [Ativo]             BIT           NOT NULL,
    [Codigo]            VARCHAR (50)  NOT NULL,
    [HorarioInicio]     DECIMAL(18, 2)      NOT NULL,
    [HorarioFim]        DECIMAL(18, 2)      NOT NULL,
    [Segunda] BIT           NOT NULL,
    [Terca] BIT NOT NULL, 
    [Quarta] BIT NOT NULL, 
    [Quinta] BIT NOT NULL, 
    [Sexta] BIT NOT NULL, 
    [Sabado] BIT NOT NULL, 
    [Domingo] BIT NOT NULL, 
    CONSTRAINT [PK_tblGrupo] PRIMARY KEY CLUSTERED ([IdGrupo] ASC)
);

