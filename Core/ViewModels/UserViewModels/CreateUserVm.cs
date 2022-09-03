namespace Core.ViewModels.UserViewModels;

public class CreateUserVm : UserVmBase
{
    public string? ProfilePicture { get; init; }
    public string? Password { get; init; }
}