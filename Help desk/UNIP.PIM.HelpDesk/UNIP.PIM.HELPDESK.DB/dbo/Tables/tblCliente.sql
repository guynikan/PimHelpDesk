CREATE TABLE [dbo].[tblCliente] (
    [IdCliente]    INT           NOT NULL IDENTITY,
    [NomeFantasia] VARCHAR (100) NULL,
    [CNPJ]         VARCHAR (20)  NULL,
    [CPF]          VARCHAR (15)  NULL,
    [RazaoSocial]  VARCHAR (100) NOT NULL,
    [Ativo]        BIT           NOT NULL,
    [Email]        VARCHAR (100) NULL,
    [Cidade]       VARCHAR (50)  NOT NULL,
    [UF]           VARCHAR (2)   NOT NULL,
    [Numero]       INT           NOT NULL,
    [Complemento]  VARCHAR (50)  NULL,
    [Endereco]     VARCHAR (100) NOT NULL,
    [Bairro]       VARCHAR (50)  NOT NULL,
    [CEP]          VARCHAR (15)  NOT NULL,
    CONSTRAINT [PK_tblCliente] PRIMARY KEY CLUSTERED ([IdCliente] ASC)
);

