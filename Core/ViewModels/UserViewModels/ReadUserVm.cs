namespace Core.ViewModels.UserViewModels;

public class ReadUserVm : UserVmBase
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public Guid ProfilePictureId { get; set; }
    public string ProfilePicture { get; set; }
    public IEnumerable<string>? CurrentBooks { get; set; } 
        = new List<string>();
    public DateTime CreatedAt { get; set; }
}