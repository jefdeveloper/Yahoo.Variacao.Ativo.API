using Newtonsoft.Json;
using System;
using System.Linq;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class AtivosReposta
    {
        [JsonProperty("chart")]
        public GraficoResposta Grafico { get; set; }

        public DateTime[] ObterDatasResultado 
            => Grafico?.Resultados?.FirstOrDefault()?.Datas;

        public decimal?[] ObterCotacoesValoresAbertos
           => Grafico?.Resultados?.FirstOrDefault()?.Indicadores?.Cotacoes?.FirstOrDefault().ValoresAbertos;
    }
}
