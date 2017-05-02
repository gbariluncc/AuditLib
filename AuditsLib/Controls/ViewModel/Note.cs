using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditControls.Model
{
    [Serializable]
    public class Note
    {
        private string _note;
        private DateTime _addDm;

        public Note() { }
        public DateTime Date
        {
            get { return _addDm; }
            set { _addDm = value; }
        }
        public string NoteText
        {
            get { return _note; }
            set
            {
                _note = value;
            }
        }
    }
}
