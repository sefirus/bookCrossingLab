using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.BookCopyViewModels;
using Core.ViewModels.UserViewModels;

namespace WebApi.Mappers.UserMappers;

public class ReadUserMapper : IVmMapper<User, ReadUserViewModel>
{
    private readonly IEnumerableVmMapper<BookCopy, ReadBookCopyViewModel> _bookCopyMapper;

    public ReadUserMapper(IEnumerableVmMapper<BookCopy, ReadBookCopyViewModel> bookCopyMapper)
    {
        _bookCopyMapper = bookCopyMapper;
    }

    public ReadUserViewModel Map(User source)
    {
        var viewModel = new ReadUserViewModel()
        {
            Id = source.Id,
            Email = source.Email,
            FirstName = source.FirstName,
            LastName = source.LastName,
            BirthDate = source.BirthDate,
            CurrentBooks = _bookCopyMapper.Map(source.CurrentBooks),
            IsActive = source.IsActive,
            ProfilePicture = source.ProfilePicture?.FullPath
        };
        return viewModel;
    }
}