
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

            produto.Nome = "Monster Hunter Wilds";
            produto.Preco = 350;
            produto.Categoria = "Acessorios";
            produto.Plataforma = "PS/XBOX/PC";
            produto.Ano = 2025;

            Navigation.PushAsync(new NewPage1() { BindingContext = produto });
        }

        private void btnProduto2_Clicked(object sender, EventArgs e)
        {

        }

        private void btnListaProduto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutoPage());
        }
    }

}
