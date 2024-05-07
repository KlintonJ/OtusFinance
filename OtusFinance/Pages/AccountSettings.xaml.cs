namespace OtusFinance.Pages;
using OtusFinance;
public partial class AccountSettings : ContentPage
{
    private LocalDB _db = new LocalDB();
    public int? MonthlyCap { get; set; }
    public AccountSettings()
	{
		InitializeComponent();
        this.BindingContext = this;

    }
    async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//DashboardPage");
    }

    private async void OnSaveMonthlyCapClicked(object sender, EventArgs e)
    {
        var username = UserData.Username;  // Ensure UserData is correctly defined and accessible
        bool updated = await _db.UpdateMonthlyCapByUsernameAsync(username, MonthlyCap);
        if (updated)
            await DisplayAlert("Success", "Monthly cap updated successfully.", "OK");
        else
            await DisplayAlert("Error", "Failed to update monthly cap.", "OK");
    }

    async void OnReportsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountReport");

    }

    async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountSettings");
    }

    async void OnOverviewClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//OverviewPage");
    }

    private async void OnLogOutClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");

        await DisplayAlert("Success!", "Log out was successful.", "OK"); 
    }
}