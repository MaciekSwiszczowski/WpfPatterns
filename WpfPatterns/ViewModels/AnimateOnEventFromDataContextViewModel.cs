using System;
using System.Threading.Tasks;
using System.Windows;

namespace WpfPatterns.ViewModels
{
    public class AnimateOnEventFromDataContextViewModel : ViewModelBase, IHaveTitleAndDescription
    {
        private readonly Random _random = new Random();

        public event EventHandler UpEvent;
        public event EventHandler DownEvent;

        public string Title { get; set; } = "Animate on event in DataContext";
        public string Description { get; set; } = "";

        public AnimateOnEventFromDataContextViewModel()
        {
            Task.Run(SendUpNotifications);
            Task.Run(SendDownNotifications);
        }

        private async Task SendUpNotifications()
        {
            while (true)
            {
                await Task.Delay(_random.Next(3000));
                Application.Current.Dispatcher?.Invoke(() => UpEvent?.Invoke(this, EventArgs.Empty));
            }
        }

        private async Task SendDownNotifications()
        {
            while (true)
            {
                await Task.Delay(_random.Next(3000));
                Application.Current.Dispatcher?.Invoke(() => DownEvent?.Invoke(this, EventArgs.Empty));
            }
        }
    }
}