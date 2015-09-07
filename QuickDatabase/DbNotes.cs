using System;

namespace QuickDatabase
{
    internal class DbNotes
    {
        public long Id { get; internal set; }
        public DateTime date;
        public string note;
        public string vat;

        public DbNotes()
        {
        }

    }
}