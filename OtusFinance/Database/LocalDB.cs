using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Diagnostics;


namespace OtusFinance
{
    public class LocalDB
    {
        private const string DB_NAME = "OtusDB.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDB()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<User>();
            _connection.CreateTableAsync<Transactions>();

        }
        public async Task<bool> CheckPassword(string email, string password)
        {
            var user = await _connection.Table<User>().Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user != null && user.Password == password)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> EmailExistsAsync(string email)
        {
            var existingUser = await _connection.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
            return existingUser != null;
        }

        public async Task<int> AddUserAsync(User user)
        {
            // Check if the email already exists
            if (await EmailExistsAsync(user.Email))
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            return await _connection.InsertAsync(user);
        }

        public async Task<int> AddTransactionAsync(Transactions transaction)
        {
            try
            {
                int result = await _connection.InsertAsync(transaction);
                Debug.WriteLine("Transaction added with ID: " + result);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error adding transaction: " + ex.Message);
                throw; // Re-throw the exception to ensure it gets noticed
            }
        }


        public async Task<List<Transactions>> GetTransactionsByUserAsync(string username)
        {
            return await _connection.Table<Transactions>().Where(t => t.Username == username).ToListAsync();
        }

        public async Task<int> UpdateTransactionAsync(Transactions transaction)
        {
            return await _connection.UpdateAsync(transaction);
        }

        public async Task<int> DeleteTransactionAsync(Transactions transaction)
        {
            return await _connection.DeleteAsync(transaction);
        }

        public async Task<Transactions> GetTransactionByIdAsync(int id)
        {
            return await _connection.Table<Transactions>().Where(t => t.ID == id).FirstOrDefaultAsync();
        }


    }

}
