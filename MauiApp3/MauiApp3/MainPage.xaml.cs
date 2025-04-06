
using MauiApp3;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnProduto_Clicked(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.Nome = "Monitor 60hz";
            produto.Preco = 570;
            produto.Categoria = "Periféricos";
            produto.Descricao = "Tela de 23 polegadas, resolução de 1920x1080, perfeito para o dia a dia!";
            produto.Validade = new DateTime (2028, 10, 5);

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
