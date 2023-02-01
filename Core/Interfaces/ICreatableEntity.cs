namespace Core.Interfaces;

public interface ICreatableEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
}