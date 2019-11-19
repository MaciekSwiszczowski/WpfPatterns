using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfPatterns.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

    //    public abstract string Description { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExamplePlaceholder : ViewModelBase
    {
        private bool _isExpanded;
        private IHaveTitleAndDescription _example;

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

        public ExamplePlaceholder(IHaveTitleAndDescription example)
        {
            _example = example;
            Title = example.Title;
            Description = example.Description;
        }
    }
}
