namespace BlindajeOncer.Infraestructura
{
    using ViewModels;
    public class InstanciaLocal
    {
        #region Propiedades
        public MainViewModel Main 
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public InstanciaLocal()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}