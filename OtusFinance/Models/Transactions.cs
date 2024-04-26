using SQLite;
using System;

namespace OtusFinance
{
    [Table("transactions")]
    public class Transactions
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int ID { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("amount")]
        public decimal Amount { get; set; }

        [Column("type")]
        public string Type { get; set; } // For example, "Income" or "Expense"

        [Column("category")]
        public string Category { get; set; } // Housing & Utilities, Food and Drinks, Travel, Income, Other Expenses

        [Column("date")]
        public DateTime Date { get; set; }

    }
}
