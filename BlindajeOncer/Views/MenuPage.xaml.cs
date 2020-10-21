namespace BlindajeOncer.Views
{
    using System;
    using Xamarin.Forms;
    public partial class MenuPage : ContentPage
    { 
        public MenuPage()
        {
            InitializeComponent();
        }

        private void AsesoresPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AsesoresPage());
        }

        private void ClientesPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ClientesPage());
        }

        private void EmpresaPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EmpresaPage());
        }

        private void InstaladorPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InstaladorPage());
        }

        private void ProductosPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductosPage());
        }
    }
}