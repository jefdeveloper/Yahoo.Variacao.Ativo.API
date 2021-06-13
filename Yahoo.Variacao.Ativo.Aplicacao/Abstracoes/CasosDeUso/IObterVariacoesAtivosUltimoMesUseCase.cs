using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public interface IObterVariacoesAtivosUltimoMesUseCase
    {
        Task<IEnumerable<AtivoDto>> Executar(string nomeAtivo);
    }
}
