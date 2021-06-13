using Newtonsoft.Json;
using NodaTime;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Yahoo.Variacao.Ativo.Aplicacao
{
    public class YahooFinancasCliente : IYahooFinancasCliente
    {
        private readonly IHttpClientFactory httpClientFactory;

        public YahooFinancasCliente(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<AtivosReposta> ObterAtivosPorNomePeriodo(string nomeAtivo, DateTime dataInicio, DateTime dataFim)
        {
            var httpClient = httpClientFactory.CreateClient("yahooFinancasAPI");

            long tsDataInicio = new DateTimeOffset(dataInicio).ToUnixTimeSeconds();
            long tsDataFim = new DateTimeOffset(dataFim).ToUnixTimeSeconds();

            var url = $"chart/{nomeAtivo}?interval=1d&period1={tsDataInicio}&period2={tsDataFim}";

            var resposta = await httpClient.GetAsync(url);

            if (resposta.IsSuccessStatusCode && resposta.StatusCode != HttpStatusCode.NoContent)
            {
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AtivosReposta>(json);
            }
            else
                throw new Exception($"Não foi possível obter os ativos de nome '{nomeAtivo}' nos últimos 30 pregões.");
        }
    }
}
