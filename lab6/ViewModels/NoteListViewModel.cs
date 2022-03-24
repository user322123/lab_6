using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using lab6.Models;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace lab6.ViewModels
{
    public class NoteListViewModel : ViewModelBase
    {
        Dictionary<DateTimeOffset, ObservableCollection<Note>> allNotes;
        DateTimeOffset selectedDate;
        DateTimeOffset previousDate;
        public DateTimeOffset SelectedDate
        {
            get => selectedDate;
            set => this.RaiseAndSetIfChanged(ref selectedDate, value);
        }

        ObservableCollection<Note> notes;
        public ObservableCollection<Note> Notes
        {
            get => notes;
            set => this.RaiseAndSetIfChanged(ref notes, value);
        }
        public NoteListViewModel()
        {
            selectedDate = DateTimeOffset.Now.Date;
            previousDate = selectedDate;
            allNotes = new Dictionary<DateTimeOffset, ObservableCollection<Note>>();
            //allNotes.Add(selectedDate.AddDays(1), new ObservableCollection<Note>{new Note("123", "123")});
            Notes = new ObservableCollection<Note>();
            this.WhenAnyValue((x) => x.SelectedDate).Subscribe(x => DateSel(x));
        }


        public void DateSel(DateTimeOffset datetime)
        {
            datetime = datetime.Date;
            allNotes[previousDate] = Notes;
            Notes = allNotes.GetValueOrDefault(datetime, new ObservableCollection<Note>());
            previousDate = datetime;
        }
    }
}
