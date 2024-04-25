using System.Diagnostics;
namespace OtusFinance.Pages;

public partial class SignupPage : ContentPage
{
    private readonly LocalDB _database;

    public SignupPage()
    {
        InitializeComponent();
        _database = new LocalDB();
    }

    private async void OnSignupClick(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;
        string reenteredPassword = reenterPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Please enter a username and password.", "OK");
            return;
        }

        if (password != reenteredPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        var user = new User { Email = username, Password = password };

        try
        {
            await _database.AddUserAsync(user);
            await DisplayAlert("Success", "User registered successfully.", "OK");
            Debug.WriteLine("User registered successfully.");
            await Shell.Current.GoToAsync("//LoginPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }
}
