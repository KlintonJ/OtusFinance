using Microcharts;
using SkiaSharp;
using System.Linq;
using System.Threading.Tasks;

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

    protected override async void OnAppearing() //refresh
    {
        base.OnAppearing();
        await LoadChartData();  
    }

    private async Task LoadChartData()
    {
        var latestExpenses = await new LocalDB().GetLatestTransactionsAsync();
        var entries = latestExpenses.Select(expense => new ChartEntry((float)expense.Amount)
        {
            Label = expense.Date.ToString("MMM dd"),  
            ValueLabel = $"${expense.Amount}",
            Color = expense.Category == "Expense" ? SKColor.Parse("#FF0000") : SKColor.Parse("#00FF00")  // green for income, red for expense
        }).ToList();

        if (entries.Any())
        {
            LineChartView.Chart = new LineChart
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 8,
                PointMode = PointMode.Circle,
                PointSize = 18,
            };
        }
    }
}
