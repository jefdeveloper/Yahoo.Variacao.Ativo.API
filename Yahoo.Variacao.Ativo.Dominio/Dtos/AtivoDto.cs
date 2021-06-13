using System;

namespace Yahoo.Variacao.Ativo
{
    public class AtivoDto
    {
        public AtivoDto(string nome, DateTime data, double valor)
        {
            Nome = nome;
            Data = data;
            Valor = valor;
        }

        public string Nome{ get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public double VariacaoDiaAnterior { get; private set; }
        public double VariacaoPrimeraData { get; private set; }

        public void DefinirVariacaoDiaAnterior(double? valorD1)
        {
            if (valorD1.HasValue)
                VariacaoDiaAnterior = (valorD1.Value - Valor) / Valor * 100;
        }

        public void DefinirVariacaoPrimeiraData(double? valorDataInicial)
        {
            if (valorDataInicial.HasValue)
                VariacaoPrimeraData = (valorDataInicial.Value - Valor) / Valor * 100;
        }
    }
}
