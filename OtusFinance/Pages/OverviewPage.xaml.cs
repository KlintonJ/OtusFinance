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
                new ChartEntry(500) { Label = "Food and Drinks", ValueLabel = "500", Color = SKColor.Parse("#77A1D3") },
                new ChartEntry(150) { Label = "Travel", ValueLabel = "150", Color = SKColor.Parse("#79D2DE") },
                new ChartEntry(1200) { Label = "Income", ValueLabel = "1200", Color = SKColor.Parse("#EDE574") },
                new ChartEntry(450) { Label = "Other Expenses", ValueLabel = "450", Color = SKColor.Parse("#E38690") }
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
    }
}
