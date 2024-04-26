using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Microsoft.Extensions.Logging;
using OtusFinance;
using System.Diagnostics;

namespace OtusFinance.Pages;

public partial class AccountReport : ContentPage
{
    private readonly LocalDB _database;
    public ObservableCollection<Transactions> Transactions { get; set; }

    public AccountReport()
    {
        InitializeComponent();
        _database = new LocalDB();
        Transactions = new ObservableCollection<Transactions>();
        ExpenseTypePicker.ItemsSource = new List<string>
        {
            "Housing and Utilities",
            "Food and Drinks",
            "Travel",
            "Income",
            "Other Expenses"
        };

        this.BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTransactionsAsync();
    }

    public async Task LoadTransactionsAsync()
    {
        string username = UserData.Username;
        var transactionsList = await _database.GetTransactionsByUserAsync(username);
        Transactions.Clear();
        foreach (var transaction in transactionsList)
        {
            Transactions.Add(transaction);
        }
    }

    async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AccountSettings");
    }

    private async void OnLogExpenseClicked(object sender, EventArgs e)
    {
        try
        {
            string username = UserData.Username;
            if (!decimal.TryParse(amountEntry.Text, out decimal amount))
            {
                await DisplayAlert("Error", "Please enter a valid amount.", "OK");
                return;
            }

            if (ExpenseTypePicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Please select a transaction type.", "OK");
                return;
            }

            string type = ExpenseTypePicker.SelectedItem.ToString();
            string category = type == "Income" ? "Income" : "Expense";
            DateTime date = datePicker.Date;

            Transactions transaction = new Transactions
            {
                Username = username,
                Amount = amount,
                Type = type,
                Category = category,
                Date = date
            };

            await _database.AddTransactionAsync(transaction);

            // Reset fields
            amountEntry.Text = string.Empty;
            ExpenseTypePicker.SelectedIndex = -1;
            datePicker.Date = DateTime.Today;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }

        await LoadTransactionsAsync();
    }
}