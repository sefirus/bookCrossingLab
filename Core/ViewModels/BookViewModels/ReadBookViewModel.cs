using Core.ViewModels.PublisherViewModels;
using Core.ViewModels.WriterViewModels;

namespace Core.ViewModels.BookViewModels;

public class ReadBookViewModel
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public ReadEmbeddedPublisherVm Publisher { get; set; }
    public IEnumerable<ReadEmbeddedWriterVm> Writers { get; set; } 
    public string Isbn { get; set; }
    public string Language { get; set; }
    public int PageCount { get; set; }
    public double Rate { get; set; }
    public string PictureLink { get; set; } //TODO:implement retrieving a picture as well
}