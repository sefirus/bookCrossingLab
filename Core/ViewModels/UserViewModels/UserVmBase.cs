namespace Core.ViewModels.UserViewModels;

public class UserVmBase
{
    public string Email { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public DateTime BirthDate { get; init; }
}