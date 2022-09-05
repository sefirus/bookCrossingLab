namespace Core.Entities;

public class Shelf 
{
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<Picture> Pictures { get; set; } 
        = new List<Picture>();
    public string FormattedAddress { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public IEnumerable<BookCopy> Books { get; set; } 
        = new List<BookCopy>();
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Comment> Comments { get; set; } 
        = new List<Comment>();
}