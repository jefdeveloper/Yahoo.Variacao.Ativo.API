using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class ObterVariacoesAtivosUltimoMesUseCase : IObterVariacoesAtivosUltimoMesUseCase
    {
        private readonly IYahooFinancasCliente yahooFinancasCliente;
        private readonly IRepositorioAtivo repositorioAtivo;
        private readonly IMapper mapper;

        public ObterVariacoesAtivosUltimoMesUseCase(IYahooFinancasCliente yahooFinancasCliente, IRepositorioAtivo repositorioAtivo)
        {
            this.yahooFinancasCliente = yahooFinancasCliente ?? throw new ArgumentNullException(nameof(yahooFinancasCliente));
            this.repositorioAtivo = repositorioAtivo ?? throw new ArgumentNullException(nameof(repositorioAtivo));

            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Ativo, AtivoDto>());

            mapper = mapperConfig.CreateMapper();
        }

        public async Task<IEnumerable<AtivoDto>> Executar(string nomeAtivo)
        {
            DateTime dataFim = DateTime.UtcNow;
            DateTime dataInicio = dataFim.AddDays(-30);

            IEnumerable<Ativo> lstAtivos = await repositorioAtivo.ObterHistoricoAtivos(nomeAtivo, dataInicio, dataFim);

            if (lstAtivos != null && !lstAtivos.Any())
            {
                AtivosReposta respostaApi = await yahooFinancasCliente.ObterAtivosPorNomePeriodo(nomeAtivo, dataInicio, dataFim);

                if (respostaApi != null)
                {
                    lstAtivos = MapearParaEntidade(nomeAtivo, respostaApi);

                    await repositorioAtivo.SalvarLista(lstAtivos);
                }
            }

            return MapearParaDto(lstAtivos);
        }

        private IEnumerable<AtivoDto> MapearParaDto(IEnumerable<Ativo> lstEntidades)
        {
            var lstAtivoDto = mapper.Map<IEnumerable<Ativo>, IEnumerable<AtivoDto>>(lstEntidades);

            var ativoInicio = lstAtivoDto.OrderBy(a => a.Data).FirstOrDefault();

            return lstAtivoDto.Select(ativo => {

                var ativoAnterior = lstAtivoDto.Where(a => a.Data < ativo.Data)
                                               .OrderByDescending(a => a.Data)
                                               .FirstOrDefault();

                ativo.DefinirVariacaoPrimeiraData(ativoInicio?.Valor);
                ativo.DefinirVariacaoDiaAnterior(ativoAnterior?.Valor);

                return ativo;

            }).OrderBy(a => a.Data);
        }

        private IEnumerable<Ativo> MapearParaEntidade(string nomeAtivo, AtivosReposta respostaApi)
        {
            DateTime[] lstDatas = respostaApi.ObterDatasResultado;
            decimal?[] lstValores = respostaApi.ObterCotacoesValoresAbertos;

            return lstDatas.Zip(lstValores, (data, valor) => new Ativo(nomeAtivo, data, valor));
        }
    }
}
