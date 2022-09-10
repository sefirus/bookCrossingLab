using Core.Enums;
using Core.ViewModels.BookViewModels;

namespace Core.ViewModels.BookCopyViewModels;

public class ReadBookCopyViewModel
{
    public int Id { get; set; }
    public IEnumerable<string> BookCopyPictures { get; set; }
    public ReadBookViewModel Book { get; set; }
    public BookCopyState State { get; set; }
    public int CurrentUserId { get; set; }
    public string CurrentUserName { get; set; }
    public string CurrentUserProfilePicture { get; set; }
    public int CurrentShelfId { get; set; } 
    public string CurrentShelfAddress { get; set; }
    public double CurrentShelfLatitude { get; set; }
    public double CurrentShelfLongitude { get; set; }
    public DateTime CreatedAt { get; set; }
}