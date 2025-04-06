using System;
using System.Collections.Generic;
using System.Globalization;

namespace MauiApp3
{
    internal class Produto
    {
        public string Nome { get; set; }

        public double Preco { get; set; }

        public string Categoria { get; set; }

        public string Descricao { get; set; }

        public DateTime? Validade { get; set; }

        public string ValFormatada => Validade?.ToString("dd/MM/yyyy") ?? "Sem validade";

        public string PrecoFormatado => Preco.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));

        private static List<Produto> lista = new List<Produto>
        {
            new Produto { Nome = "Cafeteira", Preco = 220, Categoria = "Eletrodoméstico", Descricao = "Máquina de preparar café em pequena escala", Validade = new DateTime(2031, 12, 31) },
            new Produto { Nome = "Mouse", Preco = 60, Categoria = "Periféricos", Descricao = "Mouse simples de escritório, preparado para proporcionar uma experiência confortável", Validade = new DateTime(2027, 12, 31) }
        };

        public static List<Produto> Lista => lista;
    }
}
