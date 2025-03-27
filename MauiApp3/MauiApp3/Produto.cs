using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3
{
    internal class Produto
    {
        public double Preco { get; set; }

        public string Nome { get; set; }

        public string Categoria { get; set; }

        public string Plataforma { get; set; }

        public int Ano { get; set; }

        public static List<Produto> Lista
        {
            get
            {
                List<Produto> lista = new List<Produto>();
                lista.Add(new Produto() { Nome = "God of War", Preco = 220, Categoria = "Ação", Plataforma = "PS4/PS5", Ano = 2018 });
                lista.Add(new Produto() { Nome = "The Last of Us Part I", Preco = 250, Categoria = "Ação/Aventura", Plataforma = "PS4", Ano = 2020 });
                lista.Add(new Produto() { Nome = "Elden Ring", Preco = 300, Categoria = "RPG", Plataforma = "PS5/Xbox/PC", Ano = 2022 });
                lista.Add(new Produto() { Nome = "FIFA 23", Preco = 280, Categoria = "Esportes", Plataforma = "PS5/Xbox/PC", Ano = 2022 });
                lista.Add(new Produto() { Nome = "Cyberpunk 2077", Preco = 270, Categoria = "RPG", Plataforma = "PS5/Xbox/PC", Ano = 2020 });
                lista.Add(new Produto() { Nome = "Red Dead Redemption 2", Preco = 260, Categoria = "Ação/Aventura", Plataforma = "PS4/Xbox/PC", Ano = 2018 });
                lista.Add(new Produto() { Nome = "Call of Duty: Modern Warfare II", Preco = 350, Categoria = "FPS", Plataforma = "PS5/Xbox/PC", Ano = 2022 });
                lista.Add(new Produto() { Nome = "Minecraft", Preco = 150, Categoria = "Sandbox", Plataforma = "Multiplataforma", Ano = 2011 });
                lista.Add(new Produto() { Nome = "Hollow Knight", Preco = 80, Categoria = "Metroidvania", Plataforma = "PS4/Xbox/PC/Switch", Ano = 2017 });
                lista.Add(new Produto() { Nome = "Street Fighter 6", Preco = 280, Categoria = "Luta", Plataforma = "PS5/Xbox/PC", Ano = 2023 });

                return lista;
            }
        }
    }
}