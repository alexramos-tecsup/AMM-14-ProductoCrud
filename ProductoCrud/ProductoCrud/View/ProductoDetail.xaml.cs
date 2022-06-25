using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductoCrud.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoDetail : ContentPage
    {
        public ProductoDetail()
        {
            InitializeComponent();
        }
        Model.ProductoModel _producto;
        public ProductoDetail(Model.ProductoModel producto)
        {
            InitializeComponent();
            Title = "Editar Informacion";
            _producto = producto;
            nombreEntry.Text = producto.Nombre;
            fechaEntry.Text = producto.Fecha.ToString();
            cantidadEntry.Text = producto.Cantidad.ToString();
            estadoEntry.Text = producto.Estado.ToString();
            nombreEntry.Focus();

        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nombreEntry.Text) || string.IsNullOrEmpty(fechaEntry.Text) || string.IsNullOrEmpty(cantidadEntry.Text) || string.IsNullOrEmpty(estadoEntry.Text))
            {
                await DisplayAlert("Invalido", "Espacios Vacios o en Blanco son invalidos!", "Ok");
            }
            else if (_producto != null)
            {
                UpdateProducto();
            }
            else
                AddNewProducto();
        }

        async void AddNewProducto()
        {
            await App.ProductosDatabase.CreateProducto(new Model.ProductoModel
            {
                Nombre = nombreEntry.Text,
                Fecha = Convert.ToDateTime(fechaEntry.Text),
                Cantidad = Convert.ToInt32(cantidadEntry.Text),
                Estado = bool.Parse(estadoEntry.Text)
            });
            await Navigation.PopAsync();
        }

        async void UpdateProducto()
        {
            _producto.Nombre = nombreEntry.Text;
            _producto.Fecha = Convert.ToDateTime(fechaEntry.Text);
            _producto.Cantidad = Convert.ToInt32(cantidadEntry.Text);
            _producto.Estado = bool.Parse(estadoEntry.Text);
            await App.ProductosDatabase.UpdateProducto(_producto);
            await Navigation.PopAsync();
        }
    }
}