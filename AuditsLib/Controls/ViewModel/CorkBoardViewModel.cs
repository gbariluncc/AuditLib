using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Windows.Input;
using Audits.Infastructure.Commands;
using System.Windows;

namespace AuditControls.Model
{
    public class CorkboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Notes _notes;
        private ObservableCollection<DisplayNote> _displayNotes;
        private const string FILE_NAME = "Notes.xml";
        private string _currPath = FILE_NAME;

        private void OnPropertyChanged([CallerMemberName]string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public CorkboardViewModel()
        {
            _notes = null;
            _displayNotes = new ObservableCollection<DisplayNote>();
        }

        public string OutputFilePath
        {
            get { return _currPath; }
            set
            {
                Directory.CreateDirectory(value);
                _currPath = value + "\\" + FILE_NAME;
                OpenFile();
            }
        }

        public ObservableCollection<DisplayNote> StickItNotes
        {
            get
            {
                return _displayNotes;
            }
        }
        public ICommand SaveNote
        {
            get
            {
                Action<object> SaveTarget = delegate(object o) { SaveFile(); };
                return new DelegateCommand(SaveTarget, param => true);
            }
        }
        public ICommand AddNote
        {
            get
            {
                Action<object> AddTarget = delegate(object o) { CreateNote(); };
                return new DelegateCommand(AddTarget, param => true);
            }
        }

        //Methods
        private void Fill(Notes notes)
        {
            foreach (Note note in notes.NoteCollection)
            {
                _displayNotes.Add(new DisplayNote(note, _displayNotes));
            }
        }

        private void CreateNote()
        {
            DisplayNote n = new DisplayNote(_displayNotes);
            _displayNotes.Add(n);

            OnPropertyChanged("StickItNotes");
        }
        public void SaveFile()
        {
            try
            {
                if (_displayNotes == null) return;
                _notes.NoteCollection = Extract(_displayNotes);
                using (var stream = File.Open(_currPath, FileMode.Create))
                {
                    var serializer = new XmlSerializer(typeof(Notes));
                    serializer.Serialize(stream, _notes);
                }
            }
            catch (Exception) { }
        }
        public void OpenFile()
        {
            try
            {
                if (_notes == null)
                {
                    if (File.Exists(_currPath))
                    {
                        using (var stream = File.OpenRead(_currPath))
                        {
                            var serializer = new XmlSerializer(typeof(Notes));
                            _notes = serializer.Deserialize(stream) as Notes;
                            OnPropertyChanged("StickItNotes");
                        }
                    }
                    else
                    {
                        _notes = new Notes();
                    }
                }

                Fill(_notes);
            }
            catch (Exception err) { MessageBox.Show("CorkBoardViewModel.OpenFile: " + err.Message); }
        }
        private ObservableCollection<Note> Extract(ObservableCollection<DisplayNote> notes)
        {
            ObservableCollection<Note> temp = new ObservableCollection<Note>();

            foreach (DisplayNote note in _displayNotes)
            {
                temp.Add(note.NoteItem);
            }

            return temp;
        }
    }
}
