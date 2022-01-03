CREATE TABLE [dbo].[TDU_Parametros](
	[CDU_Parametro] [nvarchar](20) NULL,
	[CDU_Descricao] [nvarchar](200) NULL,
	[CDU_Valor] [nvarchar](200) NULL
) ON [PRIMARY]
GO

insert into TDU_Parametros (CDU_Parametro,CDU_Descricao,CDU_Valor)
values ('Log_PastaErro','Log_PastaErro','c:\Skills\Logs')
go
