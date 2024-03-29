﻿using System.Drawing;
using System.Drawing.Imaging;
using System.Linq.Expressions;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Pagination;
using Core.Pagination.Parameters;
using Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using QRCoder;

namespace Application.Services;

public class ShelfService : IShelfService
{
    private readonly IRepository<Shelf> _shelfRepository;
    private readonly ICommentService _commentService;
    private readonly IImageService _imageService;
    private readonly IRepository<Picture> _pictureRepository;

    public ShelfService(
        IRepository<Shelf> shelfRepository,
        ICommentService commentService, 
        IImageService imageService, 
        IRepository<Picture> pictureRepository)
    {
        _shelfRepository = shelfRepository;
        _commentService = commentService;
        _imageService = imageService;
        _pictureRepository = pictureRepository;
    }

    public async Task<IEnumerable<Shelf>> GetShelvesInAreaAsync(MapBoundaries boundaries)
    {
        var shelves = await _shelfRepository.QueryAsync(shelf =>
            shelf.Longitude <= boundaries.North
            && shelf.Longitude >= boundaries.South 
            && shelf.Latitude <= boundaries.East
            && shelf.Latitude >= boundaries.West);
        return shelves;
    }

    public async Task<PagedList<Shelf>> GetPagedShelvesAsync(FilteredParameters parameters)
    {
        var filter = GetFilterQuery(parameters.FilterParam);
        var order = GetOrderByQuery(parameters.OrderByParam);
        
        var procedures = await _shelfRepository.GetPaged(
            parameters: parameters,
            filter: filter,
            orderBy: order,
            include: query => query.Include(shelf => shelf.Pictures)
                .Include(shelf => shelf.BookCopies)
                    .ThenInclude(bookCopy => bookCopy.Book)
                    .ThenInclude(book => book.Pictures));
        return procedures;
    }
    
    private static Expression<Func<Shelf, bool>>? GetFilterQuery(string? filterParam)
    {
        Expression<Func<Shelf, bool>>? filterQuery = null;
        if (filterParam is null) return filterQuery;
        var formattedFilter = filterParam.Trim().ToLower();
        filterQuery = sh => sh.FormattedAddress.ToLower().Contains(formattedFilter)
                            || sh.Title!.ToLower().Contains(formattedFilter);
        return filterQuery;
    }

    private static Func<IQueryable<Shelf>, IOrderedQueryable<Shelf>>? GetOrderByQuery(string? orderBy)
    {
        switch (orderBy)
        {
            case "Title": return query => query.OrderBy(shelf => shelf.Title);
            case "FormattedAddress": return query => query.OrderBy(shelf => shelf.FormattedAddress);
            default: return null; 
        }
    }

    public async Task<Shelf> GetShelfByIdAsync(int shelfId)
    {
        var shelf = await _shelfRepository.GetFirstOrThrowAsync(
            filter: sh => sh.Id == shelfId,
            include: query => query.Include(sh => sh.Comments)
                .Include(shelf => shelf.BookCopies)
                    .ThenInclude(bookCopy => bookCopy.Book)
                    .ThenInclude(book => book.Pictures)
                .Include(sh => sh.Pictures));
        return shelf;
    }
    
    public async Task AddShelfAsync(Shelf shelf, User currentUser)
    {
        var possiblePicture = shelf.Pictures.FirstOrDefault();
        if (!string.IsNullOrWhiteSpace(possiblePicture?.FullPath))
        {
            var pictureList = _imageService.MapPictures(new[] { possiblePicture.FullPath });
            await _imageService.ClearUnusedImagesAsync(pictureList, currentUser.Id, PictureOperationType.EditingShelf);
            shelf.Pictures = pictureList;
        }
        shelf.CreatedAt = DateTime.Now;
        await _shelfRepository.InsertAsync(shelf);
        await _shelfRepository.SaveChangesAsync();
        if (!string.IsNullOrWhiteSpace(possiblePicture?.FullPath))
        {
            possiblePicture.ShelfId = shelf.Id;
            await _pictureRepository.InsertAsync(possiblePicture);
            await _pictureRepository.SaveChangesAsync();
        }
    }

    public async Task DeleteShelfByIdAsync(int shelfId)
    {
        var shelf = await _shelfRepository.GetFirstOrDefaultAsync(sh => sh.Id == shelfId);
        if (shelf is null)
        {
            throw new NotFoundException($"Shelf with id {shelfId} does not exist");
        }
        _shelfRepository.Delete(shelf);
        await _shelfRepository.SaveChangesAsync();
    }

    private async Task<Bitmap> GetShelfQrCodeBitmapAsync(int shelfId)
    {
        var shelf = await _shelfRepository.GetFirstOrThrowAsync(sh => sh.Id == shelfId);
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(shelfId.ToString(), QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(10);
        return qrCodeImage;
    }

    public async Task<byte[]> GetShelfQrCodeFileAsync(int shelfId)
    {
        var bitmap = await GetShelfQrCodeBitmapAsync(shelfId);
        var ms = new MemoryStream();
        bitmap.Save(ms, ImageFormat.Png);
        return ms.ToArray();
    }

    public async Task AddCommentOnShelfAsync(int shelfId, Comment newComment)
    {
        var shelf = await _shelfRepository.GetFirstOrThrowAsync(sh => sh.Id == shelfId);
        newComment.ShelfId = shelfId;
        newComment.Shelf = shelf;
        await _commentService.CreateCommentAsync(newComment);
    }
}