using MauiApp3;
using System.Text.Json;
using Microsoft.Maui.Storage;
using static MauiApp3.ListaProdutoPage;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public static List<Produto> Produtos { get; set; } = ProdutoStorage.CarregarProdutos();

        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            var produtosSalvos = ProdutoStorage.CarregarProdutos();
            if (produtosSalvos.Any())
            {
                Produto.Lista.Clear();
                Produto.Lista.AddRange(produtosSalvos);
            }
        }

        private void btnProduto_Clicked(object sender, EventArgs e)
        {
            Produto produto = new Produto
            {
                Nome = "Monitor 60hz",
                Preco = 570,
                Categoria = "Periféricos",
                Descricao = "Tela de 23 polegadas, resolução de 1920x1080, perfeito para o dia a dia!",
                Validade = new DateTime(2028, 10, 5)
            };

            Navigation.PushAsync(new NewPage1() { BindingContext = produto });
        }

        private void btnProduto2_Clicked(object sender, EventArgs e)
        {
        }

        private void btnListaProduto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutoPage());
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Adicionar());
        }
    }
}
