using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AuditControls.Model
{
    [Serializable]
    public class Notes
    {
        private ObservableCollection<Note> _notes;

        public Notes()
        {
            _notes = new ObservableCollection<Note>();
        }
        public ObservableCollection<Note> NoteCollection
        {
            get { return _notes; }
            set { _notes = value; }
        }
    }
}