using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickStorage
{
    public class Note
    {
        public Note(string note, DateTime date, int id)
        {
            this._note = note;
            this._date = date;
            this._id = id;
        }

        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _note;

        public string note
        {
            get { return _note; }
            set { _note = value; }
        }

        private DateTime _date;

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
