using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class ListaProdutoPage : ContentPage
    {
        public ListaProdutoPage()
        {
            InitializeComponent();
            lstProduto.ItemsSource = Produto.Lista.OrderBy(p => p.Validade).ToList();
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            if (sender is ViewCell viewCell && viewCell.BindingContext is Produto produto)
            {
                Navigation.PushAsync(new NewPage1 { BindingContext = produto });
            }
        }

        private void FiltrarPorCategoria(object sender, EventArgs e)
        {
            string categoriaSelecionada = filtroCategoriaPicker.SelectedItem?.ToString() ?? "Todas";

            if (categoriaSelecionada == "Todas")
            {
                lstProduto.ItemsSource = Produto.Lista.OrderBy(p => p.Validade).ToList();
            }
            else
            {
                lstProduto.ItemsSource = Produto.Lista
                    .Where(p => p.Categoria == categoriaSelecionada)
                    .OrderBy(p => p.Validade)
                    .ToList();
            }

            AtualizarResumo();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var produtos = Produto.Lista.OrderBy(p => p.Validade).ToList();
            lstProduto.ItemsSource = produtos;

            AtualizarResumo();

            var hoje = DateTime.Today;
            var vencidos = produtos.Where(p => p.Validade.HasValue && p.Validade.Value < hoje).ToList();
            var proximos = produtos.Where(p => p.Validade.HasValue && p.Validade.Value <= hoje.AddDays(3) && p.Validade.Value >= hoje).ToList();

            if (vencidos.Any() || proximos.Any())
            {
                AlertaLabel.Text = $" Atenção: {vencidos.Count} vencido(s), {proximos.Count} prestes a vencer!";
            }
            else
            {
                AlertaLabel.Text = string.Empty;
            }
        }


        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Produto produto)
            {
                bool confirmar = await DisplayAlert(
                    "Remover Produto",
                    $"Deseja remover o produto \"{produto.Nome}\"?",
                    "Sim", "Não");

                if (confirmar)
                {
                    Produto.Lista.Remove(produto);
                    ProdutoStorage.SalvarProdutos(Produto.Lista);
                    lstProduto.ItemsSource = Produto.Lista.OrderBy(p => p.Validade).ToList();
                    AtualizarResumo();
                }
            }
        }
        private void AtualizarResumo()
        {
            var produtos = lstProduto.ItemsSource as List<Produto>;

            int quantidade = produtos?.Count ?? 0;
            double total = produtos?.Sum(p => p.Preco) ?? 0;

            resumoLabel.Text = $"Total: {quantidade} produto(s) - Valor: R$ {total:F2}";
        }

        public static class ProdutoStorage
        {
            const string ProdutosKey = "ProdutosSalvos";

            public static void SalvarProdutos(List<Produto> produtos)
            {
                string json = JsonSerializer.Serialize(produtos);
                Preferences.Set(ProdutosKey, json);
            }

            public static List<Produto> CarregarProdutos()
            {
                string json = Preferences.Get(ProdutosKey, string.Empty);
                return string.IsNullOrEmpty(json) ? new List<Produto>() :
                    JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
            }
        }

    }
}

