using System.Text.Json;
using Microsoft.Maui.Storage;
using static MauiApp3.ListaProdutoPage;
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
            Validade = validade,
            CaminhoImagem = caminhoImagemSelecionada


        });

        ProdutoStorage.SalvarProdutos(Produto.Lista);
        await DisplayAlert("Sucesso", "Produto adicionado com sucesso!", "OK");
        await Navigation.PopAsync();
    }

    private string caminhoImagemSelecionada;
    private async void SelecionarImagem_Clicked(object sender, EventArgs e)

    {

        var resultado = await FilePicker.PickAsync(new PickOptions
        {

            PickerTitle = "Selecione uma imagem",

            FileTypes = FilePickerFileType.Images

        });


        if (resultado != null)

        {

            caminhoImagemSelecionada = resultado.FullPath;

            previewImagem.Source = ImageSource.FromFile(caminhoImagemSelecionada);

        }

    }
}
