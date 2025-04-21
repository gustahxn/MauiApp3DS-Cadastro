using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        protected override void OnAppearing()

        {
            base.OnAppearing();
            lstProduto.ItemsSource = Produto.Lista.OrderBy(p => p.Validade).ToList();
        }
    }
}
