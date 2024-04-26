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

    private void OnOverviewClicked(object sender, EventArgs e)
    {
        // Handle Overview clicked
    }
}