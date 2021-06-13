using Newtonsoft.Json;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public  class ErroResposta
    {
        [JsonProperty("code")]
        public string Codigo { get; set; }

        [JsonProperty("description")]
        public string Descricao { get; set; }
    }
}
