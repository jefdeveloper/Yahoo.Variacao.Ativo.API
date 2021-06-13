using Newtonsoft.Json;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class IndicadoresResposta
    {
        [JsonProperty("quote")]
        public CotacaoResposta[] Cotacoes { get; set; }
    }
}
