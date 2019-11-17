using System.Windows;
using ShowMeTheXAML;

namespace WpfPatterns
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            XamlDisplay.Init();
            base.OnStartup(e);
        }
    }
}
