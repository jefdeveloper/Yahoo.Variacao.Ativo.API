using Newtonsoft.Json;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class GraficoResposta
    {
        [JsonProperty("result")]
        public ResultadoResposta[] Resultados { get; set; }

        [JsonProperty("error")]
        public ErroResposta Erro { get; set; }
    }
}
