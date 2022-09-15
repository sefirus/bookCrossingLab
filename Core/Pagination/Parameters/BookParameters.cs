namespace Core.Pagination.Parameters;

public class BookParameters : FilteredParameters
{
    public IEnumerable<int> PublisherIds { get; set; }
    public IEnumerable<int> WriterIds { get; set; }
    public IEnumerable<int> CategoryIds { get; set; } 
    public int MaxPageCount { get; set; }
    public int MinPageCount { get; set; }
    public IEnumerable<string> Language { get; set; }
}