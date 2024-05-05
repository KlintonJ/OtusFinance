namespace OtusFinance.Pages;

public partial class LandingPage : ContentPage
{
	public LandingPage()
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

    async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }

    private void OnSignUpClicked(object sender, EventArgs e)
    {
        //handle signup.
    }
}