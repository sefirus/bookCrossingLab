namespace Core.Entities;

public class Shelf 
{
    public int Id { get; set; }
    public IEnumerable<Picture> Pictures { get; set; } 
        = new List<Picture>();
    public string Adress { get; set; }
    public IEnumerable<BookCopy> Books { get; set; } 
        = new List<BookCopy>();
    public DateTime CreatedAt { get; set; }
    public IEnumerable<Comment> Comments { get; set; } 
        = new List<Comment>();
}