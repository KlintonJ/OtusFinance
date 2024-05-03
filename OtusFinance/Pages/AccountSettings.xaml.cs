namespace OtusFinance.Pages;

public partial class AccountSettings : ContentPage
{
	public AccountSettings()
	{
		InitializeComponent();

    }
    private void OnDashboardClicked(object sender, EventArgs e)
    {
        // Handle Dashboard clicked
    }

    async void OnReportsClicked(object sender, EventArgs e)
    {
       await Shell.Current.GoToAsync("//AccountReport");
       
    }

    private void OnSettingsClicked(object sender, EventArgs e)
    {
        // Handle Settings clicked
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