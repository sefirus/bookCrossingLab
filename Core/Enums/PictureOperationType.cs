using Core.Exceptions;

namespace Core.Enums;

public enum PictureOperationType
{
    EditingShelf,
    EditingBook, 
    EditingBookCopy,
    EditingWriter,
    EditingPublisher,
    EditingUser
}

public static class PictureOperationTypeExtensions
{
    public static PictureOperationType GetPictureOperationType(this string type)
    {
        var normalizedType = type.ToLower();
        switch (normalizedType)
        {
            case "shelf" or "editingshelf":
                return PictureOperationType.EditingShelf;
            case "book" or "editingbook":
                return PictureOperationType.EditingBook;
            case "bookcopy" or "editingbookcopy":
                return PictureOperationType.EditingBookCopy;
            case "writer" or "editingwriter":
                return PictureOperationType.EditingWriter;
            case "publisher" or "editingpublisher":
                return PictureOperationType.EditingPublisher;
            case "user" or "editinguser":
                return PictureOperationType.EditingUser;
        }
        throw new BadRequestException("Wrong editing entity!");
    }

    public static string GetFolderName(this PictureOperationType operationType)
    {
        switch (operationType)
        {
            case PictureOperationType.EditingBook: return "books";
            case PictureOperationType.EditingBookCopy: return "bookCopies";
            case PictureOperationType.EditingPublisher: return "publishers";
            case PictureOperationType.EditingShelf: return "shelves";
            case PictureOperationType.EditingWriter: return "writers";
            case PictureOperationType.EditingUser: return "users";
        }

        throw new BadRequestException("Wrong folder to interact with!");
    }
}