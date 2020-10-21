namespace BlindajeOncer.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Views;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string usuario;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Usuario
        {
            get { return this.usuario; }
            set { SetValue(ref this.usuario, value); }
        }

        
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }


        public bool RememberMe { get; set; }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;
        }

        #endregion

        #region Commands
        public ICommand IngresarCommand
        {
            get
            {
                return new RelayCommand(Ingresar);
            }
        }


        private async void Ingresar()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa tu usuario",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingresa tu contraseña",
                    "Aceptar");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();
            
            if(!connection.IsSuccess)
            {

                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Aceptar");
                return;
            }

            var token = await this.apiService.GetToken("http://blindajeoncerbackend.azurewebsites.net", this.usuario, this.password);

            if(token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error","Algo falló, intenta más tarde","Aceptar");
                    return;
            }


            this.IsRunning = false;
            this.IsEnabled = true;

            this.Usuario = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Menu = new MenuViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());
        }
        #endregion
    }
}