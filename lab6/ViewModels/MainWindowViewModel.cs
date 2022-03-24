using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using lab6.Models;

namespace lab6.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {

        ViewModelBase content;
        NoteListViewModel notes;
        public ViewModelBase Content
        {
            get => content;
            set => this.RaiseAndSetIfChanged(ref content, value);
        }
        public MainWindowViewModel()
        {
            Content = notes = new NoteListViewModel();
        }

        public void OnZoom(Note note)
        {
            var vm = new NoteEditViewModel();
            vm.Tittle = note.Tittle;
            vm.Text = note.Content;
            Observable.Merge(vm.OnOKBtn, vm.OnCancelBtn).Take(1).Subscribe((x) =>
            {
                if (x != null)
                {
                    var index = notes.Notes.IndexOf(note);
                    notes.Notes[index] = x;
                }
                Content = notes;
            });

            Content = vm;
        }
        public void OnAddClick()
        {
            var vm = new NoteEditViewModel();
            Observable.Merge(vm.OnOKBtn, vm.OnCancelBtn).Take(1).Subscribe((x) =>
            {
                if(x!=null)
                {
                    notes.Notes.Add(x);
                }
                Content = notes;
            });
            Content = vm;
        }

        public void OnDeleteBtn(Note note)
        {
            notes.Notes.Remove(note);
        }

    }
}
