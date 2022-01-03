/****** Object:  StoredProcedure [dbo].[SP_ListaPagamentos]    Script Date: 3/18/2020 3:16:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Alla Camilo
-- Create date: 02.03.2020
-- Description:	Get payments of employees on a specific period
-- =============================================
CREATE PROCEDURE [dbo].[SP_ListaPagamentos] 
	-- Add the parameters for the stored procedure here
	@dataInicio Date,
	@dataFim Date,
	@conta nvarchar(5)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT P.Funcionario AS Funcionario,  F.Nome, P.Banco as Banco, P.NumConta, P.NIB, P.DataEmissao,
	P.ModoPagTesouraria, SUM(P.ValorLiquido) Total , isnull(f.email,'') as Email
	FROM Pagamentos P INNER JOIN Funcionarios F ON P.Funcionario = F.Codigo
	WHERE (p.Conta = @conta) AND (P.DataEmissao BETWEEN @dataInicio and @dataFim)
	GROUP BY P.Funcionario,  F.nome, P.Banco, P.NumConta, P.NIB, P.DataEmissao, P.ModoPagTesouraria, f.email

END

create table TDU_RH_ExportacaoBancos(
	CDU_Id int,
	CDU_Data date,
	CDU_ValorTotal float
) 