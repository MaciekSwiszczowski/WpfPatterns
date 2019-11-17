using System.Collections.ObjectModel;

namespace WpfPatterns.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ViewModelBase> ViewModels { get; set; } 

        public MainViewModel()
        {
            ViewModels = new ObservableCollection<ViewModelBase>
            {
                new AnimateOnDataTriggerViewModel(),
                new AnimateOnEventTriggerViewModel(),
                new AnimateOnEventFromDataContextViewModel(),
            };

        }
    }
}
