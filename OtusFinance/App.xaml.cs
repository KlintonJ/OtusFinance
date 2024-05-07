using OtusFinance.Pages;

namespace OtusFinance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

        }
    }
}
