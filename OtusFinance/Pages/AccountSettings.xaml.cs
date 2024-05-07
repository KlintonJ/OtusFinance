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
        var username = UserData.Username;  
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

    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        if (CurrentPassword.Text == await _db.GetCurrentPasswordAsync(UserData.Username))
        {
            if (NewPassword.Text != ConfirmPassword.Text)
            {
                await DisplayAlert("Error", "Passwords do not match.", "OK");
                return;
            }
            bool result = await _db.ChangePasswordAsync(NewPassword.Text);
            if (result)
                await DisplayAlert("Success", "Password changed successfully.", "OK");
            else
                await DisplayAlert("Error", "Failed to change password.", "OK");
        }
        else
        {
            await DisplayAlert("Error", "Current password incorrect.", "OK");
        }
    }
}