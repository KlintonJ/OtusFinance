namespace OtusFinance.Pages;

public partial class AccountSettings : ContentPage
{
	public AccountSettings()
	{
		InitializeComponent();

    }
    async void OnDashboardClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//DashboardPage");
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