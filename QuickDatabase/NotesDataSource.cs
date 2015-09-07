using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickDatabase
{
    class NotesDataSource
    {
        private DatabaseHelper db;

        public NotesDataSource(DatabaseHelper databaseHelper)
        {
            this.db = databaseHelper;
        }

        public async Task<long> AddNotes(String vat, String Notes)
        {
            long id = 0;
            DateTime date = DateTime.Now;
            DbNotes dbn = new DbNotes();
            await db.Conn.InsertAsync(dbn);

            DbNotes insertDbc = await db.Conn.Table<DbNotes>().ElementAtAsync(await db.Conn.Table<DbNotes>().CountAsync() - 1);
            if (insertDbc != null)
            {
                id = insertDbc.Id;
            }

            return id;
        }

        public async void RemoveNotes(long idNotes)
        {
            DbNotes Notes = await db.Conn.Table<DbNotes>().Where(c => c.Id == idNotes).FirstOrDefaultAsync();
            if (Notes != null)
            {
                await db.Conn.DeleteAsync(Notes);
            }
        }

        public async Task<List<DbNotes>> FetchAllNotess(String vat)
        {
            return await db.Conn.Table<DbNotes>().Where(x => x.vat == vat).ToListAsync();
        }

    }
}
