﻿using Core.Entities;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;

namespace Core.Interfaces.Services;

public interface IShelfService
{
    Task<PagedList<Shelf>> GetPagedShelvesAsync(FilteredParameters parameters);
    Task AddShelfAsync(Shelf shelf, User currentUser);
    Task DeleteShelfByIdAsync(int shelfId);
    Task<IEnumerable<Shelf>> GetShelvesInAreaAsync(MapBoundaries boundaries);
    Task<byte[]> GetShelfQrCodeFileAsync(int shelfId);
    Task AddCommentOnShelfAsync(int shelfId, Comment newComment);
    Task<Shelf> GetShelfByIdAsync(int shelfId);
}