using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using lab6.Models;

namespace lab6.ViewModels
{
    public class NoteEditViewModel : ViewModelBase
    {
        string tittle;
        public string Tittle
        {
            get => tittle;
            set => this.RaiseAndSetIfChanged(ref tittle, value);
        }

        string text;
        public string Text
        {
            get => text;
            set => this.RaiseAndSetIfChanged(ref text, value);
        }

        bool okEnabled;
        public bool IsOKEnabled
        {
            get => okEnabled;
            set => this.RaiseAndSetIfChanged(ref okEnabled, value);
        }
        public NoteEditViewModel()
        {
            okEnabled = false;
            OnOKBtn = ReactiveCommand.Create(() => new Note(Tittle, Text));
            OnCancelBtn = ReactiveCommand.Create(() => (Note)null);

            this.WhenAnyValue((x) => x.Tittle).Subscribe((x) => { IsOKEnabled = (x != null && x.Length > 0); });
        }

        public ReactiveCommand<Unit, Note> OnOKBtn
        {
            get;
        }
        public ReactiveCommand<Unit, Note> OnCancelBtn
        {
            get;
        }
    }
}
