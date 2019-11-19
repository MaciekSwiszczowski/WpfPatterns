namespace WpfPatterns.ViewModels
{
    public class AnimateOnEventTriggerViewModel : ViewModelBase, IHaveTitleAndDescription
    {
        public string Title { get; set; } = "Animate on EventTrigger";
        public string Description { get; set; } = "Example animation rotating an icon on button click";

    }
}