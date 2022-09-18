using Application.Services;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configurations;

public static class ApplicationServicesConfigurations
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IBookApiService, BookApiService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IShelfService, ShelfService>();
        services.AddTransient<IBookCopyService, BookCopyService>();
        services.AddTransient<ICommentService, CommentService>();
        services.AddTransient<IFilterService, FilterService>();
        services.AddTransient<IWriterService, WriterService>();
        services.AddTransient<IPublisherService, PublisherService>();
        services.AddTransient<IImageService, ImageService>();
    }
}