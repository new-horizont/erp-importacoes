create view View_DocumentosVenda as
	select max(numdoc) as NumDoc, TipoDoc,Serie from Pri002.dbo.CabecDoc
	group by tipodoc,serie
go

CREATE View [dbo].[View_DocumentosVendas]
	as
	select cd.TipoDoc,cd.NumDoc,cd.Serie, cd.Entidade,cd.TipoEntidade,
		getdate() as data ,cd.DataGravacao,cd.CondPag,cd.ModoPag,
		cd.Nome,cd.NomeFac,cd.Morada,cd.Morada2,cd.MoradaFac,cd.Morada2Fac,
		cd.NumContribuinte,cd.NumContribuinteFac
		from  PRI002.dbo.cabecdoc cd
	inner join PRI002.dbo.LinhasDoc ld on ld.IdCabecDoc = cd.id
GO


CREATE View [dbo].[View_DocumentosVendas_Linhas]
	as
	select cd.Entidade,cd.Nome,ld.Artigo,ld.Descricao,
		ld.Unidade,ld.Quantidade,ld.PrecUnit,
		ld.Desconto1, ld.Desconto2,ld.Desconto3,ld.TotalDA,ld.TotalDC,
		ld.TipoLinha, ld.MovSTK,
		ld.TotalDF,	cd.TipoDoc,cd.NumDoc,cd.Serie ,ld.Armazem,ld.Localizacao,ld.Lote
		from  PRI002.dbo.cabecdoc cd
	inner join PRI002.dbo.LinhasDoc ld on ld.IdCabecDoc = cd.id
	
GO
