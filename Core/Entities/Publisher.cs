using Core.Interfaces;

namespace Core.Entities;

public class Publisher : ICreatableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Picture> Pictures { get; set; } 
        = new List<Picture>();
    public string Description { get; set; }
    public IEnumerable<Book> Books { get; set; } 
        = new List<Book>();
    public DateTime CreatedDate { get; set; }
}