using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }

}
