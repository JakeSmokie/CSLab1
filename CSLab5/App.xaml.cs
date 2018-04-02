using Avalonia;
using Avalonia.Markup.Xaml;

namespace CSLab5
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
