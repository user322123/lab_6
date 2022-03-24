using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab6.Views
{
    public partial class NoteEditView : UserControl
    {
        public NoteEditView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
