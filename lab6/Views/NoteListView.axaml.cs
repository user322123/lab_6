using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using lab6.ViewModels;

namespace lab6.Views
{
    public partial class NoteListView : UserControl
    {
        public NoteListView()
        {
            InitializeComponent();
            
        } 
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
