using System.Collections.ObjectModel;

namespace WpfPatterns.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ExamplePlaceholder> ViewModels { get; set; } 

        public MainViewModel()
        {
            ViewModels = new ObservableCollection<ExamplePlaceholder>
            {
                new ExamplePlaceholder(new AnimateOnDataTriggerViewModel()),
                new ExamplePlaceholder(new AnimateOnEventTriggerViewModel()),
                new ExamplePlaceholder(new AnimateOnEventFromDataContextViewModel()),
            };
        }
    }
}
