using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductoCrud.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductoCrud.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoPage : ContentPage
    {
        public ProductoPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                myCollectionView.ItemsSource = await App.ProductosDatabase.ReadProductos();
            }
            catch { }
        }
        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductoDetail());
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            var Item = sender as SwipeItem;
            var prod = Item.CommandParameter as ProductoModel;
            await Navigation.PushAsync(new ProductoDetail(prod));
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            var item = sender as SwipeItem;
            var prod = item.CommandParameter as ProductoModel;
            var result = await DisplayAlert("Eliminar", $"Eliminar {prod.Nombre} de la base de Datos", "Si", "No");
            if (result)
            {
                await App.ProductosDatabase.DeleteProducto(prod);
                myCollectionView.ItemsSource = await App.ProductosDatabase.ReadProductos();
            }

        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            myCollectionView.ItemsSource = await App.ProductosDatabase.Search(e.NewTextValue);
        }
    }
}