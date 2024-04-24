namespace OtusFinance.Pages;

public partial class LandingPage : ContentPage
{
	public LandingPage()
	{
		InitializeComponent();
        
    }
    async void OnLoginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//LoginPage");
    }

    async void OnSignUpClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//SignupPage");
    }
}