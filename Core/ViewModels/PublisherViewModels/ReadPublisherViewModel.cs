namespace Core.ViewModels.PublisherViewModels;

public class ReadPublisherViewModel : ReadEmbeddedPublisherVm
{
    public IEnumerable<string> Pictures { get; set; }
    public string Description { get; set; }
}