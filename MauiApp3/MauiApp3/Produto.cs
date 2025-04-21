using System;
using System.Collections.Generic;
using System.Globalization;

namespace MauiApp3
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
        public DateTime? Validade { get; set; }
        public string ValidadeFormatada => Validade?.ToString("dd/MM/yyyy");

        public bool EstaVencido => Validade.HasValue && Validade.Value.Date < DateTime.Now.Date;

        public string PrecoFormatado => Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

        private static List<Produto> lista = new List<Produto>
        {
            new Produto { Nome = "Cafeteira", Preco = 220, Categoria = "Eletrônicos", Descricao = "Máquina de preparar café em pequena escala", Validade = new DateTime(2031, 12, 31) },
            new Produto { Nome = "Mouse", Preco = 60, Categoria = "Outros", Descricao = "Mouse simples de escritório, preparado para proporcionar uma experiência confortável", Validade = new DateTime(2027, 12, 31) },
            new Produto { Nome = "Banana", Preco = 1, Categoria = "Alimentos", Descricao = "Deliciosa e nutritiva", Validade = new DateTime(2027, 12, 31) }
        };

        public static List<Produto> Lista => lista;
    }
}
