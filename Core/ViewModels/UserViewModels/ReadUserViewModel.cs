using Core.ViewModels.BookCopyViewModels;

namespace Core.ViewModels.UserViewModels;

public class ReadUserViewModel : UserVmBase
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public string? ProfilePicture { get; set; }
    public IEnumerable<ReadBookCopyViewModel>? CurrentBooks { get; set; } 
        = new List<ReadBookCopyViewModel>();
}