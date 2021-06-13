using Newtonsoft.Json;
using System;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class ResultadoResposta
    {
        [JsonProperty("timestamp", ItemConverterType = typeof(TimestampParaDateTimeConverter))]
        public DateTime[] Datas { get; set; }

        [JsonProperty("indicators")]
        public IndicadoresResposta Indicadores { get; set; }
    }
}
