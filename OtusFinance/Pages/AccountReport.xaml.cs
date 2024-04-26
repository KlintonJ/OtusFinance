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
        };  //In any case, do not remove this block of code. This helps to render elements in the dropdown menu in Log New Expense Section.




        // Here, I tried to add dummy data. Feel free to modify these codes. 
/*
        Transactions = new ObservableCollection<Transaction>
        {
            new Transaction { Date = "3/1", Description = "Paycheck", Amount = "++++" },
            new Transaction { Date = "3/2", Description = "Gas Bill", Amount = "++" },
            // Add more dummy transactions as needed
        };*/

        // Setting the BindingContext of the page to this instance
        this.BindingContext = this;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadTransactionsAsync();
    }
    public async Task LoadTransactionsAsync()
    {
        string username = UserData.Username; // Make sure this is not null.
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
    public async void LogExpense(string username, decimal amount, string type, string category, DateTime date, string description)
    {

        var transaction = new Transactions
        {
            Username = username,
            Amount = amount,
            Type = type,
            Category = category,
            Date = date
        };

        int transactionId = await _database.AddTransactionAsync(transaction);

        
        
    }

    private async void OnLogExpenseClicked(object sender, EventArgs e)
    {
        try
        {
            string username = UserData.Username; //UserData is in the root folder it only saves username
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

            //Reset Everything

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
