namespace WpfPatterns.ViewModels
{
    public class AnimateOnDataTriggerViewModel : ViewModelBase, IHaveTitleAndDescription
    {
        public string Title { get; set; } = "Animate on DataTrigger";
        public string Description { get; set; } = "Example animation changing some icon's properties on ToggleButton state change";
    }
}
