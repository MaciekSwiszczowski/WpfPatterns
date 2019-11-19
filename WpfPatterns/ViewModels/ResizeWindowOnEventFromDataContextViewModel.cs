namespace WpfPatterns.ViewModels
{
    public class ResizeWindowOnEventFromDataContextViewModel : ViewModelBase, IHaveTitleAndDescription
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}