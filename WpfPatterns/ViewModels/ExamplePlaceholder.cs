using System.ComponentModel;

namespace WpfPatterns.ViewModels
{
    public class ExamplePlaceholder : ViewModelBase
    {
        private readonly IHaveTitleAndDescription _example;
        private bool _isExpanded;

        public ExamplePlaceholder(IHaveTitleAndDescription example)
        {
            _example = example;
            Title = example.Title;
            Description = example.Description;
        }

        public string Title { get; set; }
        public string Description { get; set; }

        public INotifyPropertyChanged Example { get; private set; }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                Example = value ? _example : null;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Example));
            }
        }
    }
}