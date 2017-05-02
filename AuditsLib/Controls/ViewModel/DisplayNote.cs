using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Audits.Infastructure.Commands;
using System.Windows.Input;

namespace AuditControls.Model
{
    public class DisplayNote
    {
        private Note _note;
        private ObservableCollection<DisplayNote> _parent;

        public DisplayNote(Note note, ObservableCollection<DisplayNote> parent)
        {
            _note = note;
            _parent = parent;
        }
        public DisplayNote(ObservableCollection<DisplayNote> parent)
        {
            _parent = parent;
            _note = new Note();
        }

        public Note NoteItem
        {
            get { return _note; }
        }

        public ICommand DeleteNote
        {
            get
            {
                Action<object> RemoveTarget = delegate(object o) { RemoveNote(); };
                return new DelegateCommand(RemoveTarget, param => true);
            }
        }

        private void RemoveNote()
        {
            _parent.Remove(this);
        }
        public string NoteText
        {
            get { return _note.NoteText; }
            set { _note.NoteText = value; }
        }
        public DateTime Date
        {
            get { return _note.Date; }
        }
    }
}