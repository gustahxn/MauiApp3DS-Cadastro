namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void btnProduto_Clicked(object sender, EventArgs e)
        {
            Produto produto = new Produto();

            produto.Nome = "Buzina";
            produto.Preco = 300;
            produto.Categoria = "Acessórios";

            Navigation.PushAsync(new ProdutoPage() { BindingContext = produto});
        }

        private void btnListaProduto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaProdutoPage());
        }
    }

}
