using Newtonsoft.Json;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
   public class CotacaoResposta
    {
        [JsonProperty("open")]
        public decimal?[] ValoresAbertos { get; set; }
    }
}
