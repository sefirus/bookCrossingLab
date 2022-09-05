namespace Core.ViewModels.UserViewModels;

public class CreateUserViewModel : UserVmBase
{
    public string? ProfilePicture { get; init; }
    public string? Password { get; init; }
}