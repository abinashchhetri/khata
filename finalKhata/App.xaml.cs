using finalKhata.Configs;
using System.Diagnostics;


namespace finalKhata
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += Configs.FolderAndFiles.SaveDataOnExit;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "finalKhata" };
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("---Sleeping----");
        }
    }
        
}
