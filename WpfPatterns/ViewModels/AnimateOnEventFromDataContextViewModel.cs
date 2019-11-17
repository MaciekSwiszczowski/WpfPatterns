using System;
using System.Windows.Threading;

namespace WpfPatterns.ViewModels
{
    public class AnimateOnEventFromDataContextViewModel : ViewModelBase
    {
        public event EventHandler TickEvent;

        public override string Title { get; set; } = "Animate on event in DataContext";
        public override string Code { get; set; } = "DataTemplate for AnimateOnEventFromDataContextViewModel";
        public override string Description { get; set; } = "";

        public AnimateOnEventFromDataContextViewModel()
        {
            var timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle) {Interval = TimeSpan.FromSeconds(2)};

            timer.Tick += OnTick;

            timer.Start();
        }

        private void OnTick(object sender, EventArgs e)
        {
            TickEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}