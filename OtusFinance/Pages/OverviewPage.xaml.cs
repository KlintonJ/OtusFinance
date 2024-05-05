using Microcharts;
using SkiaSharp;
using System.Collections.Generic;

namespace OtusFinance.Pages
{
    public partial class OverviewPage : ContentPage
    {
        public OverviewPage()
        {
            InitializeComponent();
            LoadChartData();
        }

        private void LoadChartData()
        {
            var entries = new List<ChartEntry>
            {
                new ChartEntry(95) { Label = "Phone", ValueLabel = "95", Color = SKColor.Parse("#77A1D3") },
                new ChartEntry(225) { Label = "Paycheck", ValueLabel = "225", Color = SKColor.Parse("#79D2DE") },
                new ChartEntry(245) { Label = "Refund", ValueLabel = "245", Color = SKColor.Parse("#EDE574") },
                new ChartEntry(180) { Label = "Internet", ValueLabel = "180", Color = SKColor.Parse("#E38690") }
            };

            
            PieChartView.Chart = new DonutChart
            {
                Entries = entries,
                HoleRadius = 0.5f  
            };

            UpdateTopSpendingCategories(entries);
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
    }
}
