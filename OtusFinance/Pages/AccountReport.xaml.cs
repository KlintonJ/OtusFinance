using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using OtusFinance;

namespace OtusFinance.Pages;

public partial class AccountReport : ContentPage
{
    public ObservableCollection<Transaction> Transactions { get; set; }

    public AccountReport()
    {
        InitializeComponent();
        ExpenseTypePicker.ItemsSource = new List<string>
        {
            "Housing and Utilities",
            "Food and Drinks",
            "Travel",
            "Income",
            "Other Expenses"
        };  //In any case, do not remove this block of code. This helps to render elements in the dropdown menu in Log New Expense Section.




        // Here, I tried to add dummy data. Feel free to modify these codes. 

        Transactions = new ObservableCollection<Transaction>
        {
            new Transaction { Date = "3/1", Description = "Paycheck", Amount = "++++" },
            new Transaction { Date = "3/2", Description = "Gas Bill", Amount = "++" },
            // Add more dummy transactions as needed
        };

        // Setting the BindingContext of the page to this instance
        this.BindingContext = this;
    }

    public class Transaction
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
    }
}
