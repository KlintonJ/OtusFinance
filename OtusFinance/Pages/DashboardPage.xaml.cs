using Microcharts;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace OtusFinance.Pages;

public partial class DashboardPage : ContentPage
{
    private User CurrentUser { get; set; }
    public ObservableCollection<TransactionViewModel> RecentTransactions { get; set; } = new ObservableCollection<TransactionViewModel>();

    public DashboardPage()
    {
        InitializeComponent();
        this.BindingContext = this;
        LoadChartData();
        LoadBudgetInfo();
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
        await LoadBudgetInfo();
    }
    private async Task LoadBudgetInfo()
    {
        string username = UserData.Username;  
        CurrentUser = await new LocalDB().GetUserByUsernameAsync(username);

        MonthlyCapLabel.Text = $"Your Monthly Cap: ${CurrentUser.monthlyCap}";
        var totalExpensesThisMonth = await new LocalDB().GetTotalExpensesThisMonth(username);
        var amountLeft = CurrentUser.monthlyCap - totalExpensesThisMonth;

        AmountLeftLabel.Text = $"Amount Left This Month: ${amountLeft}";
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
        LoadRecentTransactions();
    }
    private async void LoadRecentTransactions()
    {
        var transactions = await new LocalDB().GetLatestTransactionsAsync(10);  // get 10
        RecentTransactions.Clear();

        if (!transactions.Any())  
        {
            await DisplayAlert("No Transactions", "No transactions found. You can add new transactions from the Report Page, and set a Monthly Spending Cap on the Settings Page", "OK");  //alert if new user or no transactions
        }
        else
        {
            foreach (var transaction in transactions)
            {
                RecentTransactions.Add(new TransactionViewModel
                {
                    DisplayTransaction = $"{transaction.Date:MMM dd}: {transaction.Type}, ${transaction.Amount}"
                });
            }
            TransactionsList.ItemsSource = RecentTransactions;  // Bind to the CollectionView
        }
    }

    public class TransactionViewModel
    {
        public string DisplayTransaction { get; set; }
    }
    
}
