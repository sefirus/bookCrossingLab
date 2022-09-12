﻿using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels.BookCopyViewModels;
using Core.ViewModels.BookViewModels;
using Core.ViewModels.CategoryViewModels;
using Core.ViewModels.CommentViewModels;
using Core.ViewModels.PublisherViewModels;
using Core.ViewModels.ShelfViewModels;
using Core.ViewModels.WriterViewModels;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Mappers.BookCopyMappers;
using WebApi.Mappers.BookMappers;
using WebApi.Mappers.CategoryMappers;
using WebApi.Mappers.CommentMappers;
using WebApi.Mappers.PublisherMappers;
using WebApi.Mappers.ShelfMappers;
using WebApi.Mappers.WriterMappers;

namespace WebApi.Mappers.Configurations;

public static class ApplicationMappersConfigurations
{
    public static void AddApplicationMappers(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPagedVmMapper<,>), typeof(PagedMapper<,>));
        services.AddTransient(typeof(IEnumerableVmMapper<,>), typeof(EnumerableMapper<,>));

        services.AddTransient<IVmMapper<Category, ReadCategoryViewModel>, ReadCategoryVmMapper>();
        services.AddTransient<IVmMapper<CreateCategoryViewModel, Category>, CreateCategoryVmMapper>();

        services.AddTransient<IVmMapper<Shelf, ReadShelfViewModel>, ReadShelfMapper>();
        services.AddTransient<IVmMapper<CreateShelfViewModel, Shelf>, CreateShelfMapper>();

        services.AddTransient<IVmMapper<CreateCommentViewModel, Comment>, CreateCommentMapper>();
        services.AddTransient<IVmMapper<Comment, ReadCommentViewModel>, ReadCommentMapper>();
        services.AddTransient<IVmMapper<UpdateCommentViewModel, Comment>, UpdateCommentMapper>();

        services.AddTransient<IVmMapper<BookCopy, ReadBookCopyViewModel>, ReadBookCopyMapper>();
        
        services.AddTransient<IVmMapper<Book, ReadBookViewModel>, ReadBookMapper>();

        services.AddTransient<IVmMapper<Writer, ReadEmbeddedWriterVm>, ReadEmbeddedWriterVmMapper>();
        
        services.AddTransient<IVmMapper<Publisher, ReadEmbeddedPublisherVm>, ReadEmbeddedPublisherVmMapper>();
    }
}