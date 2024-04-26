using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace OtusFinance.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly LocalDB _database;

        public LoginPage()
        {
            InitializeComponent();
            _database = new LocalDB();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter a username and password.", "OK");
                return;
            }

            bool isPasswordCorrect = await _database.CheckPassword(username, password);

            if (isPasswordCorrect)
            {
                UserData.Username = username;
                Debug.WriteLine("Login successful.");
                await DisplayAlert("Welcome", "Login successful!", "OK");
                await Shell.Current.GoToAsync("//AccountSettings");
            }
            else
            {
                Debug.WriteLine("Login failed.");
                await DisplayAlert("Error", "Invalid username or password.", "OK");
            }
        }

        private async void OnHomeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MainPage");
        }
    }
}
