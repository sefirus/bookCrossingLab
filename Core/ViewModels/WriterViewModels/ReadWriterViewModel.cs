namespace Core.ViewModels.WriterViewModels;

public class ReadWriterViewModel : ReadEmbeddedWriterVm
{
    public IEnumerable<string> Pictures { get; set; }
    public string Description { get; set; }
}