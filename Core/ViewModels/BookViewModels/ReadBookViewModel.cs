using Core.ViewModels.CommentViewModels;
namespace Core.ViewModels.BookViewModels;

public class ReadBookViewModel
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    //public ReadPublisherViewModel Publisher { get; set; }
    //public IEnumerable<ReadWriterViewModel> Writers { get; set; } 
    public string Isbn { get; set; }
    public string Language { get; set; }
    public int PageCount { get; set; }
    public double Rate { get; set; }
    public PagedViewModel<ReadCommentViewModel> PagedComments { get; set; }
}