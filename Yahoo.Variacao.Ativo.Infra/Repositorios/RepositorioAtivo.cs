using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Yahoo.Variacao.Ativo
{
    public class RepositorioAtivo : RepositorioBase, IRepositorioAtivo
    {
        public RepositorioAtivo(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<Ativo>> ObterHistoricoAtivos(string nomeAtivo, DateTime dataInicio, DateTime dataFinal)
        {
            var query = @"select nome_ativo Nome, data_ativo Data, valor_ativo Valor
                          from historico_ativos 
                         where nome_ativo = @nomeAtivo and data_ativo between @dataInicio and @dataFinal ";

            using IDbConnection conn = ObterConexao();
            return await conn.QueryAsync<Ativo>(query, new { nomeAtivo, dataInicio = dataInicio.Date, dataFinal = dataFinal.Date });
        }

        public async Task<int> SalvarLista(IEnumerable<Ativo> ativos)
        {
            var sql = @"INSERT INTO historico_ativos (nome_ativo, data_ativo, valor_ativo) 
                        SELECT @Nome, @Data, @Valor 
                        WHERE NOT EXISTS (SELECT 1 FROM historico_ativos 
                                           WHERE nome_ativo = @Nome 
                                           AND data_ativo = @Data 
                                           AND valor_ativo = @Valor) ";

            using IDbConnection conn = ObterConexao();
            return await conn.ExecuteAsync(sql, ativos);
        }
    }
}
