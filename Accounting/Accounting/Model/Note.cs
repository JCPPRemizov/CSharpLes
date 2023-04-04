using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Accounting
{
    public class Note
    {
        public string name { get; set; }
        public string noteType { get; set; }

        private int money;
        public int _money { 
            get { return money; } 
            set 
            { 
                if (value < 0)
                {
                    this.isIncome = false;
                }
                else
                {
                    this.isIncome = true;
                }
                money = value; 
            } 
        }
        public bool isIncome { get; set; }

        public DateTime noteDate { get; set; }

        public static List<Note> NotesList { get; set; } = new List<Note>();

        public Note(string name, string noteType, int money, DateTime noteDate)
        {
            this.name = name;
            this.noteType = noteType;
            this._money = money;
            this.noteDate = noteDate;
        }
    }
}
