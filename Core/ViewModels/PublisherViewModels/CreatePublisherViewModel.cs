namespace Core.ViewModels.PublisherViewModels;

public class CreatePublisherViewModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<string> ImageLinks { get; set; }
}