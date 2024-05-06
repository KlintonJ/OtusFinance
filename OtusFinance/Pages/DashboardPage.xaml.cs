using Microcharts;
using SkiaSharp;

namespace OtusFinance.Pages;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
        LoadChartData();
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

    private void LoadChartData()
    {
        var entries = new List<ChartEntry>
            {
             //SAMPLE DATA. Ideally, this data would aim towards the savings goal.
             //For example, if our user intends to save $200, then the line chart would
             //show how far he or she is off of the goal ($-20, +$30, etc). 

                new ChartEntry(95) { Label = "", ValueLabel = "$95", Color = SKColor.Parse("#FF0000") },
                new ChartEntry(225) { Label = "", ValueLabel = "$225", Color = SKColor.Parse("#00FF00") },
                new ChartEntry(245) { Label = "", ValueLabel = "$245", Color = SKColor.Parse("#00FF00") },
                new ChartEntry(95) { Label = "", ValueLabel = "$95", Color = SKColor.Parse("##FF0000") },
                new ChartEntry(225) { Label = "", ValueLabel = "$225", Color = SKColor.Parse("#00FF00") },
                new ChartEntry(245) { Label = "", ValueLabel = "$245", Color = SKColor.Parse("#00FF00") },
                new ChartEntry(95) { Label = "", ValueLabel = "$95", Color = SKColor.Parse("#FF0000") },
                new ChartEntry(225) { Label = "", ValueLabel = "$225", Color = SKColor.Parse("#00FF00") },
                new ChartEntry(245) { Label = "", ValueLabel = "$245", Color = SKColor.Parse("#00FF00") },
                new ChartEntry(180) { Label = "", ValueLabel = "$180", Color = SKColor.Parse("#FF0000") }
            };


        LineChartView.Chart = new LineChart
        {
            Entries = entries
        };
    }

}