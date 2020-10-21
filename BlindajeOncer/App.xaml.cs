namespace BlindajeOncer
{
    using Views;
    using Xamarin.Forms;
    public partial class App : Application
    {
        #region Constructors
        public App()
        {
            InitializeComponent();

            NavigationPage navPage = new NavigationPage(new LoginPage());

            MainPage = navPage;
        }
        #endregion

        #region Metodos
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
