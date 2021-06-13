using System;

namespace Yahoo.Variacao.Ativo
{
    public class Ativo
    {
        public Ativo(string nome, DateTime data, decimal? valor)
        {
            Nome = nome;
            Data = data;
            Valor = valor;
        }

        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal? Valor { get; set; }
    }
}
