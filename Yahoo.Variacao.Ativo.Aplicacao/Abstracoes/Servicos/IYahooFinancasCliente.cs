using System;
using System.Threading.Tasks;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public interface IYahooFinancasCliente 
    {
        Task<AtivosReposta> ObterAtivosPorNomePeriodo(string nomeAtivo, DateTime dataInicio, DateTime dataFim);
    }
}
