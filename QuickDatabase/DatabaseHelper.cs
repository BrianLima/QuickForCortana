using SQLite;
using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace QuickDatabase
{
    public class DatabaseHelper
    {
        private String DB_NAME = "QuickDatabase.db";

        public SQLiteAsyncConnection Conn { get; set; }

        public DatabaseHelper()
        {
            Conn = new SQLiteAsyncConnection(DB_NAME);
            this.CreateDb();
        }

        public async void CreateDb()
        {
            bool dbExist = await CheckDbAsync();
            if (!dbExist)
            {
                await CreateDatabaseAsync();
            }
        }

        public async Task<bool> CheckDbAsync()
        {
            bool dbExist = true;

            try
            {
                StorageFile sf = await ApplicationData.Current.LocalFolder.GetFileAsync(DB_NAME);
            }
            catch (Exception)
            {
                dbExist = false;
            }

            return dbExist;
        }

        private async Task CreateDatabaseAsync()
        {
            await Conn.CreateTableAsync<DbNotes>();
        }
    }
}
