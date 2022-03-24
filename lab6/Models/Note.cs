using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;

namespace lab6.Models
{
    public class Note
    {
        string tittle;
        public string Tittle
        {
            get => tittle;
            set => tittle = value;
        }

        string content;
        public string Content
        {
            get => content;
            set => content = value;
        }

        public Note(string? tittle, string? content)
        {
            if (tittle == null) throw new ArgumentNullException();
            Tittle = tittle;
            Content = content;
        }
    }
}
