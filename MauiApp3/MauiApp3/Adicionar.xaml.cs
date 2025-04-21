namespace MauiApp3;

public partial class Adicionar : ContentPage
{
    private DateTime? validade;

    public Adicionar()
    {
        InitializeComponent();
    }

    private async void AdicionarClicked(object sender, EventArgs e)
    {
        string nome = nomeEntry.Text;
        string categoria = categoriaEntry.Text;
        string descricao = descricaoEntry.Text;

        validade = validadeEntry.Date;

        if (!double.TryParse(precoEntry.Text, out double preco))
        {
            await DisplayAlert("Erro", "Preço inválido! Digite um número válido.", "OK");
            return;
        }

        Produto.Lista.Add(new Produto
        {
            Nome = nome,
            Preco = preco,
            Categoria = categoria,
            Descricao = descricao,
            Validade = validade
        });

        await DisplayAlert("Sucesso", "Produto adicionado com sucesso!", "OK");
        await Navigation.PopAsync();
    }

}
