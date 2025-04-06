namespace MauiApp3;

public partial class Adicionar : ContentPage
{
    public Adicionar()
    {
        InitializeComponent();
    }

    private async void AdicionarClicked(object sender, EventArgs e)
    {
        string nome = nomeEntry.Text;
        string categoria = categoriaEntry.Text;
        string descricao = descricaoEntry.Text;

        if (!double.TryParse(precoEntry.Text, out double preco))
        {
            await DisplayAlert("Erro", "Preço inválido! Digite um número válido.", "OK");
            return;
        }

        DateTime? validade = null;

        if (!string.IsNullOrWhiteSpace(validadeEntry.Text))
        {
            if (int.TryParse(validadeEntry.Text, out int anoValidade) && anoValidade > DateTime.Now.Year)
            {
                validade = new DateTime(anoValidade, 12, 31);
            }
            else
            {
                await DisplayAlert("Erro", "Ano de validade inválido! Digite um ano SUPERIOR a 2025", "OK");
            }
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
