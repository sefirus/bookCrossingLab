using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.BookCopyViewModels;
using Core.ViewModels.BookViewModels;

namespace WebApi.Mappers.BookCopyMappers;

public class ReadBookCopyMapper : IVmMapper<BookCopy, ReadBookCopyViewModel>
{
    private readonly IVmMapper<Book, ReadBookViewModel> _readBookMapper;

    public ReadBookCopyMapper(IVmMapper<Book, ReadBookViewModel> readBookMapper)
    {
        _readBookMapper = readBookMapper;
    }

    public ReadBookCopyViewModel Map(BookCopy source)
    {
        var vm = new ReadBookCopyViewModel()
        {
            Id = source.Id,
            State = source.State,
            //BookCopyPictures = source.
            Book = _readBookMapper.Map(source.Book),
            CurrentUserId = source.CurrentUserId ?? 0,
            CurrentUserName = source.CurrentUser?.FirstName + " " + source.CurrentUser?.LastName,
            CurrentUserProfilePicture = source.CurrentUser?.ProfilePicture?.FullPath ?? "",
            CurrentShelfId = source.CurrentShelfId ?? 0,
            CurrentShelfAddress = source.CurrentShelf?.FormattedAddress ?? "",
            CurrentShelfLatitude = source.CurrentShelf?.Latitude ?? 0,
            CurrentShelfLongitude = source.CurrentShelf?.Longitude ?? 0,
            CreatedAt = source.CreatedAt
        };
        return vm;
    }
}