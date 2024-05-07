using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OtusFinance.Pages
{
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage()
        {
            InitializeComponent();
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadChartData(); 
        }
        private async Task LoadChartData()
        {
            string username = UserData.Username; 
            
            var totalsByCategory = await new LocalDB().GetTotalTransactionsByUserAndCategory(username);
            foreach (var total in totalsByCategory)
            {
                Debug.WriteLine($"{total.Key}: ${total.Value}");
            }


            var entries = new List<ChartEntry>();

            foreach (var total in totalsByCategory)
            {
                entries.Add(new ChartEntry((float)total.Value)
                {
                    Label = total.Key,
                    ValueLabel = total.Value.ToString("N0"), // Format as number with commas
                    Color = GetColorForCategory(total.Key) // use defined colors
                });
            }

            PieChartView.Chart = new DonutChart
            {
                Entries = entries,
                HoleRadius = 0.5f
            };

            UpdateTopSpendingCategories(entries);
        }

        private SKColor GetColorForCategory(string category)
        {
            switch (category)
            {
                case "Food and Drinks": return SKColor.Parse("#77A1D3");
                case "Travel": return SKColor.Parse("#79D2DE");
                case "Income": return SKColor.Parse("#00FF00");
                case "Housing and Utilities": return SKColor.Parse("#EDE574");
                case "Other Expenses": return SKColor.Parse("#E38690");
                default: return SKColor.Parse("#CCCCCC"); // Default color for undefined categories
            }
        }

        private void UpdateTopSpendingCategories(IEnumerable<ChartEntry> entries)
        {
            var topCategory = entries.OrderByDescending(e => e.Value).FirstOrDefault();
            TopCategory.Text = topCategory != null ? $"{topCategory.Label}: ${topCategory.Value}" : "Data not available";
        }

        async void OnSettingsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AccountSettings");
        }

        async void OnReportsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AccountReport");

        }

        async void OnDashboardClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//DashboardPage");
        }

    }
}