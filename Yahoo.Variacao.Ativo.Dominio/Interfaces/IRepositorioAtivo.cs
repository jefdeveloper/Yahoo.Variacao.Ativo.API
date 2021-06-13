using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yahoo.Variacao.Ativo
{
    public interface IRepositorioAtivo
    {
        Task<IEnumerable<Ativo>> ObterHistoricoAtivos(string nomeAtivo, DateTime dataInicio, DateTime dataFinal);

        Task<int> SalvarLista(IEnumerable<Ativo> ativos);
    }
}
