using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfPatterns.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract string Title { get; set; }
        public abstract string Code { get; set; }
        public abstract string Description { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
