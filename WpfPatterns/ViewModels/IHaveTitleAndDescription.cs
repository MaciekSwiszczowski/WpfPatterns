using System.ComponentModel;

namespace WpfPatterns.ViewModels
{
    public interface IHaveTitleAndDescription : INotifyPropertyChanged
    {
        string Title { get; set; }
        string Description { get; set; }
    }
}