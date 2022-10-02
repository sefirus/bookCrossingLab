namespace Core.ViewModels.PublisherViewModels;

public class UpdatePublisherViewModel : ReadEmbeddedPublisherVm
{
    public string Description { get; set; }
    public IEnumerable<string> ImageLinks { get; set; }
}