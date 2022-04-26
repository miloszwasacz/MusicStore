using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Music_Store.Views
{
    public partial class MusicStoreView : UserControl
    {
        public MusicStoreView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
